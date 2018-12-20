using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Patronage.Application.Interfaces;

namespace Patronage.Infrastructure.Services
{
    public class LoggerService : ILogger
    {
        public void LogError(string message)
        {
            SaveLog(message, "ErrorLogs.txt");
        }

        public void LogInfo(string message)
        {
            SaveLog(message, "InfoLogs.txt");
        }

        private static void SaveLog(string message, string fileName)
        {
            using (var writeLog = new StreamWriter(Path.Combine("../", fileName), true))
            {
                writeLog.WriteLine(message);
            }
        }
    }
}
