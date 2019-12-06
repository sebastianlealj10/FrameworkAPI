using System;
using BrokerAPIs.Abstraction;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrokerAPIs.Facade
{
    [TestClass]
    public class TestPosts
    {
        private Posts _posts;

        [TestMethod]
        public void GetAllPosts()
        {
            _posts = new Posts("get");
            _posts.PostsRequest("get");
            _posts.PostsValidations("get");
        }

        [TestMethod]
        public void CreateANewPost()
        {
            _posts = new Posts("post");
            _posts.PostsRequest("post");
            _posts.PostsValidations("post");
        }


    }
}
