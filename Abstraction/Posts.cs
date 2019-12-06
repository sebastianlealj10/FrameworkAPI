using System;
using System.Collections.Generic;
using Beazley.InsightTesting.RestAPIClient;
using BrokerAPIs.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BrokerAPIs.Abstraction
{
    internal class Posts : Base
    {
        private int _statusCode;
        private string _jsonString;
        private List<PostsModel> _postsList;
       

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
                default:
                    Console.Error.WriteLine(method + "does exist in this context");
                    break;
            }
        }

        public void PostsRequest(string method)
        {
            _statusCode = GetCodeStatus("/posts");
            _jsonString = GetJsonString("/posts");
            _postsList = Posts.GetObject(_jsonString);
        }

        public void PostsRequest(string method, PostsModel modelContent)
        {
            AddPostContent(GetJsonString(modelContent));
            _statusCode = GetCodeStatus("/posts");
        }

        public void PostsValidations(string method)
        {
            Assert.AreEqual(201, _statusCode);
        }

        public void PostsValidations(string method, PostsModel ModelTest)
        {
            Assert.AreEqual(200, _statusCode);
            Assert.AreEqual(ModelTest.Title,
                        _postsList.Find(x => x.UserId == 2 && x.Id == 11).Title);
            Assert.AreEqual(ModelTest.Body,
                        _postsList.Find(x => x.UserId == 2 && x.Id == 11).Body);
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
