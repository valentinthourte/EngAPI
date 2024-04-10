using eng.model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eng.application.Model
{
    public class User : IEntity
    {
        public virtual Guid Id { get ; set ; }
        public virtual string Name { get; set; }
        public virtual DateTime Birthdate { get; set; }
        public virtual bool Active { get; set; }

        public User() { }
        public User(Guid id, string name, DateTime birth, bool active = true) 
        {
            this.Id = id;
            this.Name = name;
            this.Birthdate = birth;
            this.Active = active;
        }

    }
}
