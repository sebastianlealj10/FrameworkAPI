using Beazley.InsightTesting.RestAPIClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
