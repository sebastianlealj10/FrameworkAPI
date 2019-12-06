using BrokerAPIs.Abstraction;
using BrokerAPIs.Models;
using BrokerAPIs.TestData;
using TechTalk.SpecFlow;

namespace BrokerAPIs.Gherkin.StepDefinitions
{
    [Binding]
    public class PostsSteps
    {
        private Posts _posts;
        private string _method;
        private PostsData _postObject = new PostsData();
        private PostsModel _testObj;

        [Given(@"I have set the URI to (.*) posts")]
        public void GivenIHaveSetTheUri(string method)
        {
            _method = method;
            _posts = new Posts(method);
        }

        [When(@"I have requested all posts")]
        public void WhenIHaveRequestedAllPosts()
        {
            _posts.PostsRequest(_method);
        }
        
        [When(@"I have submitted a new post")]
        public void WhenIHaveSubmittedANewPost()
        {
            _testObj = _postObject.GetTestObject("post");
            _posts.PostsRequest(_method, _testObj);
        }
        
        [Then(@"All posts are shown")]
        public void ThenAllPostsAreShown()
        {
            _testObj = _postObject.GetTestObject("get");
            _posts.PostsValidations(_method,_testObj);
        }
        
        [Then(@"The new post is created")]
        public void ThenTheNewPostIsCreated()
        {
            _posts.PostsValidations(_method);
        }
    }
}
