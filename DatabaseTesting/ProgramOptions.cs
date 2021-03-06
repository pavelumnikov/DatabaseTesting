﻿namespace DatabaseTesting
{
    public class ProgramOptions
    {
        public ProgramOptions()
        {
            DatabaseName = string.Empty;
            DropDatabase = false;
            JustInitialize = false;
        }

        public string DatabaseName { get; set; }

        public bool DropDatabase { get; set; }

        public bool JustInitialize { get; set; }
    }
}
