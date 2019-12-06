using System;
using BrokerAPIs.Abstraction;
using BrokerAPIs.Models;
using BrokerAPIs.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrokerAPIs.Facade
{
    [TestClass]
    public class TestPosts
    {
        private Posts _posts;
        private string _method;
        private PostsData _postObject = new PostsData();
        private PostsModel _testObj;

        [TestMethod]
        public void GetAllPosts()
        {
            _testObj = _postObject.GetTestObject("get");
            _method = "get";
            _posts = new Posts(_method);
            _posts.PostsRequest(_method);
            _posts.PostsValidations(_method,_testObj);
        }

        [TestMethod]
        public void CreateANewPost()
        {
            _testObj = _postObject.GetTestObject("post");
            _method = "post";
            _posts = new Posts(_method);
            _posts.PostsRequest(_method, _testObj);
            _posts.PostsValidations(_method);
        }


    }
}
