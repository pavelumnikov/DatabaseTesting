using System;
using System.Threading.Tasks;
using DatabaseTesting.ApplicationLayer;
using DatabaseTesting.ApplicationLayer.DAL;
using DatabaseTesting.ApplicationLayer.Domain;

namespace DatabaseTesting
{
    public class TestingCase
    {
        private readonly ProgramOptions _options;

        public TestingCase(ProgramOptions options)
        {
            if(options == null)
                throw new ArgumentNullException("options");

            _options = options;
        }

        public void Start()
        {
            var databaseConnection = new NHibernateSQLiteDatabaseConnection(_options.DatabaseName);
            if(_options.DropDatabase)
                databaseConnection.DropDatabase();

            var databaseConfiguration = new NHibernateSQLiteDatabaseConfiguration(databaseConnection);
            var sessionManager = databaseConfiguration.CreateSessionManager();
            var uowFactory = new NHibernateUnitOfWorkFactory(sessionManager);

            // Initialize all repositories
            var personRepository = new NHibernateRepository<PersonEntity, Guid>(sessionManager);
            var passportRepository = new NHibernateRepository<PassportEntity, Guid>(sessionManager);
            var medbookRepository = new NHibernateRepository<MedicalBookEntity, Guid>(sessionManager);

            if(!_options.JustInitialize)
                StartMassiveWriting(personRepository, passportRepository, medbookRepository, uowFactory);
        }

        public void StartMassiveWriting(IRepository<PersonEntity, Guid> personRepository,
            IRepository<PassportEntity, Guid> passportRepository,
            IRepository<MedicalBookEntity, Guid> medbookRepository,
            IUnitOfWorkFactory uowFactory)
        {

            Parallel.For(0, 100, (x, y) =>
            {
                var passportEntity = AddNewPassportEntity(passportRepository, uowFactory);
                var medbookEntity = AddNewMedicalBookEntity(medbookRepository, uowFactory);
                AddNewPersonEntity(personRepository, uowFactory, passportEntity, medbookEntity);
            });
        }

        private static PassportEntity AddNewPassportEntity(IRepository<PassportEntity, Guid> passportRepository,
            IUnitOfWorkFactory uowFactory)
        {
            var passportEntity = new PassportEntity
            {
                Id = Guid.NewGuid(),
                Number = 667880,
                Series = 4512
            };

            using (var uow = uowFactory.Create())
            {
                try
                {
                    passportRepository.Add(passportEntity);
                    uow.Commit();
                }
                catch (Exception)
                {
                    uow.Rollback();
                    throw;
                }
            }

            return passportEntity;
        }

        private static MedicalBookEntity AddNewMedicalBookEntity(IRepository<MedicalBookEntity, Guid> medbookRepository,
            IUnitOfWorkFactory uowFactory)
        {
            var medbookEntity = new MedicalBookEntity
            {
                Id = Guid.NewGuid(),
                Number = 150
            };

            using (var uow = uowFactory.Create())
            {
                try
                {
                    medbookRepository.Add(medbookEntity);
                    uow.Commit();
                }
                catch (Exception)
                {
                    uow.Rollback();
                    throw;
                }
            }

            return medbookEntity;
        }

        private void AddNewPersonEntity(IRepository<PersonEntity, Guid> personRepository,
            IUnitOfWorkFactory uowFactory,
            PassportEntity passport,
            MedicalBookEntity medbook)
        {
            var person = new PersonEntity
            {
                Id = Guid.NewGuid(),
                FirstName = "Чувак",
                SecondName = "Чуваков",
                ThirdName = "Чувакович",
                MedicalBook = medbook,
                Passport = passport
            };

            using (var uow = uowFactory.Create())
            {
                try
                {
                    personRepository.Add(person);
                    uow.Commit();
                }
                catch (Exception)
                {
                    uow.Rollback();
                    throw;
                }
            }
        }
    }
}
