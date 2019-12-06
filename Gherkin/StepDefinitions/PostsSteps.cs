using BrokerAPIs.Abstraction;
using TechTalk.SpecFlow;

namespace BrokerAPIs.Gherkin.StepDefinitions
{
    [Binding]
    public class PostsSteps
    {
        private Posts _posts;
        private string _method;

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
            _posts.PostsRequest(_method);
        }
        
        [Then(@"All posts are shown")]
        public void ThenAllPostsAreShown()
        {
            _posts.PostsValidations(_method);
        }
        
        [Then(@"The new post is created")]
        public void ThenTheNewPostIsCreated()
        {
            _posts.PostsValidations(_method);
        }
    }
}
