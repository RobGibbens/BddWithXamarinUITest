Feature: Edit a task
	I want to be able to quickly edit a task

@editTask
Scenario: Edit an existing task
	Given I have at least one existing task named "Get Milk"
	When I select the task named "Get Milk"
	When I edit the task name to be "Buy cereal"
	When I save the task
	Then I should see the "Buy cereal" task in the list
	And the task named "Get Milk" no longer exists	