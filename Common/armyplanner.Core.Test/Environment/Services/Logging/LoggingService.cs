using armyplanner.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace armyplanner.Core.Test.Environment.Services.Logging
{
    public class LoggingService : ILoggingService
    {
        private string _userId = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <param name="properties"></param>
        /// <param name="attachments"></param>
        public void LogException(Exception ex)
        {
            Console.WriteLine(ex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <param name="properties"></param>
        /// <param name="attachments"></param>
        public void LogException(Exception ex, IDictionary<string, string> properties = null, params object[] attachments)
        {
            Console.WriteLine($"userId: {_userId}");
            Console.WriteLine(ex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="message"></param>
        /// <param name="properties"></param>
        /// <param name="attachments"></param>
        public void LogException(Exception ex, string message = null, IDictionary<string, string> properties = null, params object[] attachments)
        {
            Console.WriteLine($"userId: {_userId}");
            Console.WriteLine($"message: {message}");
            Console.WriteLine(ex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        /// <param name="method"></param>
        /// <param name="message"></param>
        public void LogMessage(string className, string method, string message)
        {
            Console.WriteLine($"userId: {_userId}");
            Console.WriteLine($"{className}::{method}() - {message}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        public void SetLogUser(string userId)
        {
            this._userId = userId;
        }
    }
}