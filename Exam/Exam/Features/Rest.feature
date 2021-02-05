Feature: Rest

@rest
Scenario: Get Users endpoint
	Given I GET Users list via the corresponding endpoint
	Then I should see status message OK

@rest
Scenario: Get User
	Given I make a GET request for user with id 22
	Then I should see status message OK

@rest
Scenario Outline: Login User
	Given I log in via the corresponding endpoint
	When I login user with:
		| email   | password |
		| <email> | <pass>   |
	Then I should see login status message OK

	Examples:
		| email                | pass    |
		| user_email@gmail.com | pass123 |

@rest
Scenario: Create User
	Given I POST User via the corresponding endpoint
	When I create user with:
		| first_name  | sir_name  | email   | password | country   | city   | title   |
		| <firstName> | <sirName> | <email> | <pass>   | <country> | <city> | <title> |
	Then I should see create status message OK

	Examples:
		| firstName | sirName  | email            | pass     | country  | city  | title |
		| Vanyo      | Mladenov | vanyu@abv.bg | pass1234 | Bulgaria | Varna | Mr.   |