using System;

namespace DatabaseTesting.ApplicationLayer.Domain
{
    public class MedicalBookEntity : Entity<Guid>
    {
        public virtual uint Number { get; set; }
    }
}
