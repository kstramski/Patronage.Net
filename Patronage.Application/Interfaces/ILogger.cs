using System;
using System.Collections.Generic;
using System.Text;

namespace Patronage.Application.Interfaces
{
    public interface ILogger
    {
        void LogError(string message);
        void LogInfo(string message);
    }
}
