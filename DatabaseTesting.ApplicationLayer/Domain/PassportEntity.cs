using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTesting.ApplicationLayer.Domain
{
    public class PassportEntity : Entity<Guid>
    {
        public virtual short Series { get; set; }
        public virtual int Number { get; set; }
    }
}
