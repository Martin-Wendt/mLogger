// See https://aka.ms/new-console-template for more information
using mLogger.Config;
using mLogger.Enum;
using mLogger.Factory;
using mLogger.LogEvent;
using mLogger.Logger;

namespace runner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string filePath = @"c:\logs";

            IMLoggerConfig conf = new MLoggerConfig(LogLevel.Verbose, filePath, true, true, true);

            MLoggerFactory loggerFactory = new(conf);
            IMLogger mLogger = loggerFactory.CreateMLogger();
            IMLogger mLogger2 = loggerFactory.CreateMLogger();


            if (mLogger == mLogger2)
            {
                Console.WriteLine("loggers are the same");
            }



            Console.WriteLine($"should only log {conf.Loglevel} or above");
            var ex = new InvalidOperationException("Logfile cannot be read-only", new OutOfMemoryException());

            IMLogEvent exLogEvent0 = new MLogEvent(ex, LogLevel.Verbose);
            IMLogEvent exLogEvent1 = new MLogEvent(ex, LogLevel.Debug);
            IMLogEvent exLogEvent2 = new MLogEvent(ex, LogLevel.Information);
            IMLogEvent exLogEvent3 = new MLogEvent(ex, LogLevel.Warning);
            IMLogEvent exLogEvent4 = new MLogEvent(ex, LogLevel.Error);
            IMLogEvent exLogEvent5 = new MLogEvent(ex, LogLevel.Fatal);

            mLogger.Log(exLogEvent0);
            mLogger.Log(exLogEvent1);
            mLogger.Log(exLogEvent2);
            mLogger.Log(exLogEvent3);
            mLogger.Log(exLogEvent4);
            mLogger.Log(exLogEvent5);



            Console.ReadKey();

        }
    }
}


