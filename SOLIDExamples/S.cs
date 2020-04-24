using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SOLIDExamples
{
    class S
    {
        // S - Single Responsibility Principle

        class BadS
        {
            // This method does too much
            void AddToDatabase()
            {
                try
                {
                    // add
                }
                catch (Exception e)
                {
                    File.WriteAllText(@"\error.log", e.ToString());
                }
            }
        }

        class GoodS
        {
            private FileLogger fileLogger = new FileLogger();

            //This method only adds, doesn't know how to log
            public void AddToDatabase()
            {
                try
                {
                    // add
                }
                catch (Exception e)
                {
                    fileLogger.LogError(e.ToString());
                }
            }
        }

        class FileLogger
        {
            public void LogError(string error)
            {
                File.WriteAllText(@"\error.log", error);
            }
        }
    }
}
