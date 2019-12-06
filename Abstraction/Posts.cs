using System;
using System.Collections.Generic;
using Beazley.InsightTesting.RestAPIClient;
using BrokerAPIs.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace BrokerAPIs.Abstraction
{
    class Posts : Base
    {
        private int _statusCode;
        private string _jsonString;
        private List<PostsModel> _postsList;
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
            switch (method)
            {
                case "get":
                    _statusCode = GetCodeStatus("/posts");
                    _jsonString = GetJsonString("/posts");
                    _postsList = Posts.GetObject(_jsonString);
                    break;
                case "post":
                    AddPostContent(GetJsonString(_postsModelContent));
                    _statusCode = GetCodeStatus("/posts");
                    break;
                default:
                    Console.Error.WriteLine(method + "does exist in this context");
                    break;
            }
        }

        public void PostsValidations(string method)
        {
            switch (method)
            {
                case "get":
                    Assert.AreEqual(200, _statusCode);
                    Assert.AreEqual(_postsModelTest.Title,
                        _postsList.Find(x => x.UserId == 2 && x.Id == 11).Title);
                    Assert.AreEqual(_postsModelTest.Body,
                        _postsList.Find(x => x.UserId == 2 && x.Id == 11).Body);
                    break;
                case "post":
                    Assert.AreEqual(201, _statusCode);
                    break;
                default:
                    Console.Error.WriteLine(method + "does exist in this context");
                    break;
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
