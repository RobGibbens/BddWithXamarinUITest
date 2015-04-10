Feature: Remove a task
	I want to be able to quickly remove a task

@removeTask
Scenario: Remove an existing task
	Given I have at least one existing task named "Get Milk"
	When I select the task named "Get Milk"
	When I tap delete 
	Then the task named "Get Milk" no longer exists