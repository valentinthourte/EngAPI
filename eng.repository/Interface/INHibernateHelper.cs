using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eng.repository.Interface
{
    public interface INHibernateHelper
    {
        ISession GetSession();
    }
}
