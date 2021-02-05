Feature: Login
	Verify Login functionality

@ui
Scenario: Typing fileds test
	Given Login page is opened
	When I type into field "email" and "pass"
	Then The ceratin field text is change

@ui
Scenario Outline: Login with existing user
	Given Login page is opened
	When I log in "<email>" and "<pass>"
	Then I'm successfully logged in

Examples: 
	| email              | pass  |
	| BB@gmail.com       | BB123 |
	| mimi_dakova@abv.bg | MiMiD |


#Unhappy scenario
@ui
Scenario Outline: Login with non-existing user
	Given Login page is opened
	When I try to log in: 
	| Email   | Pass   |
	| <email> | <pass> |
	Then Error Message pops-up


Examples: 
	| email        | pass  |
	| test@abv.bg  | MiMiD |
	| BB@gmail.com | test  |


@ui
Scenario Outline: Try to login with empty field
	Given Login page is opened
	When I try to log in: 
	| Email   | Pass   |
	| <email> | <pass> |
	Then User stays on login page


Examples: 
	| email        | pass  |
	|			   | MiMiD |
	| BB@gmail.com |       |