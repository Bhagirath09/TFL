Feature: Journey Planner
In order to plan my journey
As a user
I should be able to use Journey Planner Widget

@JourneyPlanner
  Scenario: Verify Valid Journey
    Given I go to Journey planner on Tfl
      And I enter valid locations Queensbury Underground Station and Camden Underground Station
     When I click on Plan my journey button
     Then I should see Journey results
  
  @JourneyPlanner
  Scenario: Verify Invalid Journey - invalid location
    Given I go to Journey planner on Tfl
      And I enter invalid locations Queensbury Underground Station and isanpur
     When I click on Plan my journey button
     Then I should see location not maching message Journey results

  @JourneyPlanner
  Scenario: Verify Invalid Journey - no location
    Given I go to Journey planner on Tfl
      And I enter no locations into the widget
     When I click on Plan my journey button
     Then I should see required field error messages
  
  @JourneyPlanner
  Scenario: Verify journey can be amended by using Edit journey
    Given I am on Journey result page on Tfl
     When I click on Edit journey button
      And I change stations to Kingsbury Underground Station and Camden Underground Station
      And I click update journey button
     Then I should see amended journey
  
  @JourneyPlanner  
  Scenario: Verify recent journey list
    Given I go to Journey planner on Tfl
      And I enter valid locations Queensbury Underground Station and Camden Underground Station
     When I click on Plan my journey button
      And I go back to journey planner widget 
     Then I should see list of recently planned journeys under Recent tab