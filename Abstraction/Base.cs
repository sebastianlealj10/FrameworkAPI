using Beazley.InsightTesting.RestAPIClient;
using BrokerAPIs.Utils;

namespace BrokerAPIs.Abstraction
{
    internal class Base
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger
                (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected readonly RestClient RestClient = new RestClient();
        private readonly string _jsonServerUri = CommonMethods.GetEnvironmentParameter("URI");
        protected Base()
        {
            RestClient.WithEndPoint(_jsonServerUri);
            Log.Info($"URI set to {_jsonServerUri}");
        }
    }
}
