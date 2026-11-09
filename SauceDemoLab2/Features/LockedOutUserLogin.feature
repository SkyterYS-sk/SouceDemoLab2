Feature: Login on SauceDemo
  As a user of the online store
  I want to log in with my credentials
  So that I can access the products catalog

  Background:
    Given I open the SauceDemo login page

  Scenario: Locked out user cannot log in
    When I log in with username "locked_out_user" and password "secret_sauce"
    Then I should stay on the login page
    And I should see the error message "Epic sadface: Sorry, this user has been locked out."

  Scenario: Locked out user does not see the products page
    When I log in with username "locked_out_user" and password "secret_sauce"
    Then the products page should not be displayed

  Scenario: Error message can be closed
    When I log in with username "locked_out_user" and password "secret_sauce"
    And I close the error message
    Then no error message should be displayed

  Scenario: Standard user can log in (control scenario)
    When I log in with username "standard_user" and password "secret_sauce"
    Then I should see the products page
