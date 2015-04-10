Feature: Adding a task
  I want to be able to quickly add a task

@addTask
  Scenario: Add a task
    Given I am on the Home screen
    When I add a new task called "Get Milk"
    And I save the task
    Then I should see the "Get Milk" task in the list