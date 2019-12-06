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
            UserId = 2,
            Id = 11,
            Title = "et ea vero quia laudantium autem",
            Body = "delectus reiciendis molestiae occaecati non minima eveniet qui voluptatibus\naccusamus in eum beatae sit\nvel qui neque voluptates ut commodi qui incidunt\nut animi commodi"
        };
        private readonly PostsModel _postsModelContent = new PostsModel()
        {
            UserId = 8,
            Id = 11,
            Title = "et ea vero quia laudantium autem",
            Body = "delectus reiciendis molestiae occaecati non minima eveniet qui voluptatibus\naccusamus in eum beatae sit\nvel qui neque voluptates ut commodi qui incidunt\nut animi commodi"
        };
    }
}
