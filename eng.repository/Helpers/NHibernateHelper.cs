using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using eng.repository.Interface;
using eng.repository.Mappings;

namespace eng.repository.Helpers
{
    public class NHibernateHelper : INHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012.ConnectionString(DBConnectionHelper.getConnectionString()))
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                        .BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static ISession GetActualSession()
        {
            return SessionFactory.OpenSession();
        }

        public ISession GetSession()
        {
            return GetActualSession();
        }
    }
}
