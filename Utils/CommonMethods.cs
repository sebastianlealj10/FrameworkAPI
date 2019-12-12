using NUnit.Framework;
using System;

namespace BrokerAPIs.Utils
{
    public static class CommonMethods
    {
        /// <summary>
        /// Retrieves form context the given parameter name and returns it as a string
        /// </summary>
        /// <param name="paramName">Parameter name to be retrieve from context</param>
        /// <returns>String value of the given parameter</returns>
        public static string GetEnvironmentParameter(string paramName)
        {
            if (TestContext.Parameters.Exists(paramName))
                return TestContext.Parameters.Get(paramName);
            else
                throw new ArgumentException($"The parameter {paramName} was not found.");
        }
    }
}
