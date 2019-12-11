using System;
using System.Collections.Generic;
using Beazley.InsightTesting.RestAPIClient;
using BrokerAPIs.Models;
using BrokerAPIs.TestData;
using BrokerAPIs.Utils;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BrokerAPIs.Abstraction
{
    internal class Posts : Base
    {
        private int _statusCode;
        private string _jsonString;
        private List<PostsModel> _postsList;
        private readonly PostsData _postObject = new PostsData();
        private PostsModel _testObj = new PostsModel();
        private readonly string _postsEndpoint = CommonMethods.GetEnvironmentParameter("Posts");

        public Posts(string method)
        {
            switch (method)
            {
                case "get":
                    RestClient.WithMethod(Verb.GET);
                    break;
                case "post":
                    RestClient.WithMethod(Verb.POST);
                    break;
                case "put":
                    RestClient.WithMethod(Verb.PUT);
                    break;
                case "delete":
                    RestClient.WithMethod(Verb.DELETE);
                    break;
                default:
                    throw new ArgumentException($"The method {method} is not valid.");
            }
        }

        public void PostsRequest(string method)
        {
            switch (method)
            {
                case "get":
                    _statusCode = GetCodeStatus(_postsEndpoint);
                    _jsonString = GetJsonString(_postsEndpoint);
                    _postsList = Posts.GetObject(_jsonString);
                    break;
                case "post":
                    _testObj = _postObject.GetTestObject("post");
                    AddPostContent(GetJsonString(_testObj));
                    _statusCode = GetCodeStatus(_postsEndpoint);
                    break;
                case "put":
                    _testObj = _postObject.GetTestObject("put");
                    AddPostContent(GetJsonString(_testObj));
                    _statusCode = GetCodeStatus(_postsEndpoint + "/5");
                    break;
                case "delete":
                    _statusCode = GetCodeStatus(_postsEndpoint + "/4");
                    break;
                default:
                    throw new ArgumentException($"The method {method} is not valid.");
            }
        }

        public void PostsValidations(string method)
        {
            switch (method)
            {
                case "get":
                    _testObj = _postObject.GetTestObject("get");
                    Assert.AreEqual(200, _statusCode);
                    Assert.AreEqual(_testObj.Title,
                        _postsList.Find(x => x.id == 1).Title);
                    Assert.AreEqual(_testObj.Author,
                        _postsList.Find(x => x.id == 1).Author);
                    break;
                case "post":
                    Assert.AreEqual(201, _statusCode);
                    break;
                case "put":
                    Assert.AreEqual(200, _statusCode);
                    break;
                case "delete":
                    Assert.AreEqual(200, _statusCode);
                    break;
                default:
                    throw new ArgumentException($"The method {method} is not valid.");
            }
        }

        private int GetCodeStatus(string endpoint)
        {
            return RestClient.GetRequestResponseStatus(endpoint);
        }

        private string GetJsonString(string endpoint)
        {
            return RestClient.Request(endpoint);
        }

        private static List<PostsModel> GetObject(string json)
        {
            return JsonConvert.DeserializeObject<List<PostsModel>>(json);
        }

        private static string GetJsonString(PostsModel posts)
        {
            return JsonConvert.SerializeObject(posts);
        }

        private void AddPostContent(string jsonContent)
        {
            RestClient.WithPostData(jsonContent);
        }
    }
}
