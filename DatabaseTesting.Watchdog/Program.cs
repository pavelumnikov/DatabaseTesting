using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DatabaseTesting.Watchdog
{
    class Program
    {
        private const string ExeName = "DatabaseTesting.exe";
        private const string DatabaseName = "TestDatabase.db3";

        static void Main(string[] args)
        {
            try
            {
                var numberOfProcesses = 4;
                var numberOfCreatedProcesses = new List<Task>(numberOfProcesses);
                if (!File.Exists(DatabaseName))
                {
                    var arguments = string.Format("--dropdatabase --justInitialize --databasename:{0}", DatabaseName);
                    var info = new ProcessStartInfo(ExeName, arguments);
                    var process = Process.Start(info);
                    if (process == null)
                        throw new ApplicationException("Failed to start DatabaseTesting.exe!");

                    process.WaitForExit();
                }

                Console.WriteLine("--> Press any key to start! <--");
                Console.ReadKey();

                for (var i = 0; i < numberOfProcesses; i++)
                {
                    numberOfCreatedProcesses.Add(Task.Factory.StartNew(() =>
                    {
                        var arguments = string.Format("--databasename:{0}", DatabaseName);
                        var info = new ProcessStartInfo(ExeName, arguments);
                        var process = Process.Start(info);
                        if (process == null)
                            Console.WriteLine("--> Failed to start new process [{0}]!", ExeName);
                        else
                        {
                            Console.WriteLine("--> Starting new process [{0}], with id [{1}]", ExeName, process.Id);
                            Thread.Sleep(100); //!< Sleep for some time before application really started up
                            Console.WriteLine("[{1}]Threads count: [{0}]", process.Threads.Count, process.Id);
                            process.WaitForExit();

                            Console.WriteLine("[{1}]Exit code: [{0}]", process.ExitCode, process.Id);
                        }
                    }));
                }

                Task.WaitAll(numberOfCreatedProcesses.ToArray());
            }
            catch (Exception e)
            {
                Console.WriteLine("--> Exception thrown: \r\nAt: [{0}]\r\nDescription: [{1}]", e.Source, e.Message);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
