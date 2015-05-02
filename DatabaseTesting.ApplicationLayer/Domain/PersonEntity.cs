using System;

namespace DatabaseTesting.ApplicationLayer.Domain
{
    public class PersonEntity : Entity<Guid>
    {
        public virtual string FirstName { get; set; }
        public virtual string SecondName { get; set; }
        public virtual string ThirdName { get; set; }
        
        // Foreign key to a PassportEntity
        public virtual PassportEntity Passport { get; set; }

        // Foreign key to a MedicalEntity
        public virtual MedicalBookEntity MedicalBook { get; set; }
    }
}
