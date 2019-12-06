Feature: Posts

Scenario: Get all posts
	Given I have set the URI to get posts
	When  I have requested all posts
	Then  All posts are shown

Scenario: Create a new post
	Given  I have set the URI to post posts
	When  I have submitted a new post
	Then  The new post is created
