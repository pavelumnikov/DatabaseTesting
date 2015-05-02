using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTesting.ApplicationLayer.Domain
{
    public class Entity<TId> : IEntity<TId>
    {
        public virtual TId Id { get; set; }
    }
}
