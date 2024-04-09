using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eng.model.Domain
{
    public interface IEntity
    {
        Guid Id { get; set;  }
    }
}
