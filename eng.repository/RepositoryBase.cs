using eng.model.Domain;
using eng.repository.Interface;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eng.repository
{
    public class RepositoryBase : IRepository, IDisposable
    {
        protected ISession _session = null;
        protected ITransaction _transaction = null;
        protected INHibernateHelper NhibernateHelper;

        public RepositoryBase(ISession session)
        {
            _session = session;
        }

        public RepositoryBase(INHibernateHelper nHibernateHelper)
        {
            NhibernateHelper = nHibernateHelper;
            _session = NhibernateHelper.GetSession();
            _session.SetBatchSize(2000);
        }

        public virtual ISession GetSession()
        {
            _session = NhibernateHelper.GetSession();
            return _session;
        }

        #region Transaction and Session Management Methods

        public void BeginTransaction()
        {
            _transaction = GetSession().BeginTransaction();
        }

        public void CommitTransaction()
        {
            // _transaction will be replaced with a new transaction            // by NHibernate, but we will close to keep a consistent state.
            _transaction.Commit();
            CloseTransaction();
        }

        public void RollbackTransaction()
        {
            // _session must be closed and disposed after a transaction            // rollback to keep a consistent state.
            _transaction.Rollback();
            CloseTransaction();
            CloseSession();
        }

        private void CloseTransaction()
        {
            _transaction.Dispose();
            _transaction = null;
        }

        private void CloseSession()
        {
            _session.Close();
            _session.Dispose();
        }

        #endregion

        #region IRepository Members

        public virtual async Task<Guid> Save(object obj)
        {
            //return ((IEntity) await _session.SaveAsync(obj)).Id;
            return (Guid)await _session.SaveAsync(obj);
        }

        public virtual async Task SaveOrUpdateAsync(object obj)
        {
            await _session.SaveOrUpdateAsync(obj);
        }

        public virtual async Task<IEntity> MergeAsync(object obj)
        {
            return (IEntity)await _session.MergeAsync(obj);
        }

        public virtual async void DeleteAsync(object obj)
        {
            await _session.DeleteAsync(obj);
        }

        public virtual async Task<object> GetById(Type objType, object objId)
        {
            var obj = await _session.GetAsync(objType, objId);
            return obj;
        }

        public virtual async Task EvictAsync(object obj)
        {
            await _session.EvictAsync(obj);
        }

        public virtual async Task<object> GetByIdReadOnly(Type objType, object objId)
        {
            var obj = await _session.GetAsync(objType, objId);
            _session.SetReadOnly(obj, true);
            return obj;
        }

        public virtual IQueryable<TEntity> ToList<TEntity>()
        {
            return from entity in _session.Query<TEntity>() select entity;
        }

        /// <summary>
        /// Según una consulta SQL devuelve una lista de entidades
        /// </summary>
        /// <typeparam name="TEntity">Modelo de dominio</typeparam>
        /// <param name="queryString">Consulta SQL. ej: SELECT * FROM Properties</param>
        /// <param name="alias">Alias que se le va a dar a la tabla. ej: P (en SELECT p.* FROM Properties P)</param>
        /// <returns></returns>
        public virtual IList<TEntity> SQLQuery<TEntity>(string queryString, string alias)
        {
            var query = _session.CreateSQLQuery(queryString);

            query.AddEntity(alias, typeof(TEntity));

            return query.List<TEntity>();
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            if (_transaction != null)
            {
                // Commit transaction by default, unless user explicitly rolls it back.
                // To rollback transaction by default, unless user explicitly commits,                // comment out the line below.
                CommitTransaction();
            }
            if (_session != null && _session.IsOpen)
            {
                _session.Flush(); // commit session transactions
                CloseSession();
            }
        }
        #endregion
    }
}
