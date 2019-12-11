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
                    return _postsPostModelContent;
                case "put":
                    return _postsPutModelContent;
                case "delete":
                    return _postsDeleteModelContent;
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

        private readonly PostsModel _postsPostModelContent = new PostsModel()
        {
            Title = "et ea vero quia laudantium autem",
            Author = "delectus reiciendis molestiae"
        };

        private readonly PostsModel _postsPutModelContent = new PostsModel()
        {
            Title = "et",
            Author = "delectus"
        };

        private readonly PostsModel _postsDeleteModelContent = new PostsModel()
        {
            id = 4
        };
    }
}
