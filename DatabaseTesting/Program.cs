using System;
using DatabaseTesting.Forms;

namespace DatabaseTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var programOptions = new ProgramOptions();

                foreach (var a in args)
                {
                    Console.WriteLine("Parsed argument: [{0}]", a);

                    if (a.Contains("dropDatabase"))
                        programOptions.DropDatabase = true;

                    if (a.Contains("justInitialize"))
                        programOptions.JustInitialize = true;

                    if (a.Contains("databasename"))
                    {
                        programOptions.DatabaseName = a.Substring(a.IndexOf(':') + 1);
                    }
                }

                if (!string.IsNullOrWhiteSpace(programOptions.DatabaseName))
                {
                    var testingCase = new TestingCase(programOptions);
                    testingCase.Start();
                }
                else
                {
                    Console.WriteLine("--> Database name/path is not set. Nothing to do here...");
                }
            }
            catch (Exception e)
            {
                if (IsCritical(e))
                    throw;

                new ExceptionMessageBox(e).ShowDialog();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static bool IsCritical(Exception e)
        {
            return e is OutOfMemoryException ||
                   e is AppDomainUnloadedException ||
                   e is BadImageFormatException ||
                   e is CannotUnloadAppDomainException ||
                   e is InvalidProgramException ||
                   e is System.Threading.ThreadAbortException;
        }
    }
}
