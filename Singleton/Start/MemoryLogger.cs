using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton.Start
{
    public class MemoryLogger
    {
        private int _InfoCount;
        private int _WarnCount;
        private int _ErrorCount;

        // private static readonly MemoryLogger _instance = new MemoryLogger();
        private static readonly Lazy<MemoryLogger> _instance
             = new Lazy<MemoryLogger>(()=> new MemoryLogger()); 

        // private static readonly object _lock = new object();

        private List<LogMessage> _logs = new List<LogMessage>();

        public IReadOnlyCollection<LogMessage> logs => _logs;

        private MemoryLogger()
        {

        }

        public static MemoryLogger GetLogger
        {

            get  
            {
                return _instance.Value;
            }

            //get
              //{
                //if(_instance == null)
                //{
                //  lock(_lock)
                //   { 
                //    if(_instance == null)
                //    {
                //     _instance = new MemoryLogger();
                //  }
                //    }
                //}
               // return _instance;
                    
              //}
        }

        private void Log(string message, LogType logType)
            => _logs.Add(new LogMessage
            {
                Message = message,
                LogType = logType,
                CreatedAt = DateTime.Now,
            });

        public void LogInfo(string message)
        {
            ++_InfoCount;
            Log(message, LogType.INFO);
        }

        public void LogError(string message)
        {
            ++_ErrorCount;
            Log(message, LogType.ERROR);
        }

        public void LogWarning(string message)
        {
            ++_WarnCount;
            Log(message, LogType.WARNING);
        }

        public void ShowLog()
        {
            _logs.ForEach(x => Console.WriteLine(x));
            Console.WriteLine($"--------------------");

            Console.WriteLine($"Info ({_InfoCount}) Warning ({_WarnCount}), Erro ({_ErrorCount}) ");
        }

        

    }
}
