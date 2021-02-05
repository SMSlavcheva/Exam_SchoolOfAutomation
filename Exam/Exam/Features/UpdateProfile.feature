Feature: UpdateProfile
	Verify update profile unctionality

@updateProfile
Scenario Outline: Typing fields test
	Given Update profile page is opened
	When I type into fields "<firstNam>" and "<sirName>" and "<country>" and "<city>"
	Then The certain field text is change

	Examples:
		| firstName | sirName | country | city |
		| firstName | sirName | country | city |

@updateProfile
Scenario Outline: Try to update with empty field
	Given Update profile page is opened
	When I try to update
		| FirstName   | SirName   | Country   | City   |
		| <firstName> | <sirName> | <country> | <city> |
	Then The page title doesn't change

	Examples:
		| firstName | sirName | country | city      |
		|           | Raily   | UK      | Liverpool |
		| Davide    |         | UK      | Liverpool |
		| Davide    | Raily   |         | Liverpool |
		| Davide    | Raily   | UK      |           |

@updateProfile
Scenario: UpdateProfile radio button select Mr
	Given Update profile page is opened
	When I select UpdateProfile Mr
	Then UpdateProfile Mr has checked attribute

@updateProfile
Scenario: UpdateProfile radio button select Mrs
	Given Update profile page is opened
	When I select UpdateProfile Mrs
	Then UpdateProfile Mrs has checked attribute

@updateProfile
Scenario Outline: Try to update valid data
	Given Update profile page is opened
	When I try to update
		| FirstName   | SirName   | Country   | City   |
		| <firstName> | <sirName> | <country> | <city> |
	Then The page title is changed

	Examples:
		| firstName | sirName | country | city       |
		| Dan       | Raily   | UK      | Liverpool  |
		| Davide    | Ridick  | UK      | Liverpool  |
		| Davide    | Raily   | England | Liverpool  |
		| Davide    | Raily   | UK      | Manchester |