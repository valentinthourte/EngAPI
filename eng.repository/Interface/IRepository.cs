using eng.model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eng.repository.Interface
{
    public interface IRepository
    {
        Task<Guid> Save(object obj);

        Task SaveOrUpdateAsync(object obj);
        Task<IEntity> MergeAsync(object obj);

        void DeleteAsync(object obj);

        Task<object> GetById(Type objType, object objId);

        Task<object> GetByIdReadOnly(Type objType, object objId);

        Task EvictAsync(object obj);

        IQueryable<TEntity> ToList<TEntity>();

        IList<TEntity> SQLQuery<TEntity>(string queryString, string alias);

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
