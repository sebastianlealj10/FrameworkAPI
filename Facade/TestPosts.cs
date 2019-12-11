using System;
using BrokerAPIs.Abstraction;
using BrokerAPIs.Models;
using BrokerAPIs.TestData;
using NUnit.Framework;

namespace BrokerAPIs.Facade
{
    [TestFixture]
    public class TestPosts
    {
        private Posts _posts;
        private string _method;

        [Test]
        public void GetAllPosts()
        {
            _method = "get";
            _posts = new Posts(_method);
            _posts.PostsRequest(_method);
            _posts.PostsValidations(_method);
        }

        [Test]
        public void CreateANewPost()
        {
            _method = "post";
            _posts = new Posts(_method);
            _posts.PostsRequest(_method);
            _posts.PostsValidations(_method);
        }

        [Test]
        public void UpdateAPost()
        {
            _method = "put";
            _posts = new Posts(_method);
            _posts.PostsRequest(_method);
            _posts.PostsValidations(_method);
        }

        [Test]
        public void DeleteAPost()
        {
            _method = "delete";
            _posts = new Posts(_method);
            _posts.PostsRequest(_method);
            _posts.PostsValidations(_method);
        }
    }
}
