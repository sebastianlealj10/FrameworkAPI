using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrokerAPIs.Models;

namespace BrokerAPIs.TestData
{
    internal class PostsData
    {
        public PostsModel GetTestObject(string method)
        {
            switch (method)
            {
                case "get":
                    return _postsModelTest;
                case "post":
                    return _postsModelContent;
                default:
                    return null;
            }
        }
        private readonly PostsModel _postsModelTest = new PostsModel()
        {
            id = 1,
            Title = "json-server",
            Author = "typicode"
        };
        private readonly PostsModel _postsModelContent = new PostsModel()
        {
            Title = "et ea vero quia laudantium autem",
            Author = "delectus reiciendis molestiae"
        };
    }
}
