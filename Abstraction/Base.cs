using Beazley.InsightTesting.RestAPIClient;

namespace BrokerAPIs.Abstraction
{
    class Base
    {
        protected readonly RestClient RestClient = new RestClient();
        protected Base()
        {
            RestClient.WithEndPoint("https://jsonplaceholder.typicode.com");
        }
    }
}
