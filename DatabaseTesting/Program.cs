using System;
using DatabaseTesting.Forms;

namespace DatabaseTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            try
            {
                var programOptions = new ProgramOptions(true);

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
                var messageBox = new ExceptionMessageBox(e);
                messageBox.ShowDialog();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
