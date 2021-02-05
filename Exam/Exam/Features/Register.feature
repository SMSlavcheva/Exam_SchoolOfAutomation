Feature: Register
	Verify Register page functionality

@register
Scenario Outline: Typing fields test
	Given Register page is opened
	When I type into regiter fields "<firstName>" and "<sirName>" and "<email>" and "<pass>" and "<country>" and "<city>"
	Then The certain register field text is change

	Examples:
		| firstName | sirName | email | pass | country | city |
		| firstName | sirName | email | pass | country | city |

@register
Scenario: Radio button select Mr
	Given Register page is opened
	When I select Mr
	Then Mr has checked attribute

@register
Scenario: Radio button select Mrs
	Given Register page is opened
	When I select Mrs
	Then Mrs has checked attribute

@register
Scenario: Terms of service checked
	Given Register page is opened
	When I select TOS
	Then TOS has checked attribute

@register
Scenario: Terms of service unchecked
	Given Register page is opened
	When I unselect Mrs
	Then Mrs hasn't checked attribute

@register
Scenario Outline: Successfull registration
	Given Register page is opened
	When I try to register with valid data "<firstName>" and "<sirName>" and "<email>" and "<pass>" and "<country>" and "<city>"
	Then I registered successfully

	Examples:
		| firstName | sirName | email        | pass   | country | city      |
		| Dan       | Daily   | DD@gmail.com | Bsdfd3 | UK      | Liverpool |

@register
Scenario Outline: Unsuccessfull registration with empty field
	Given Register page is opened
	When I try to register with empty field
		| FirstName   | SirName   | Email   | Pass   | Country   | City   |
		| <firstName> | <sirName> | <email> | <pass> | <country> | <city> |
	Then I stay on register page

	Examples:
		| firstName | sirName | email         | pass   | country | city      |
		|           | Raily   | DoR@gmail.com | Bsdfd3 | UK      | Liverpool |
		| David     |         | DoR@gmail.com | Bsdfd3 | UK      | Liverpool |
		| David     | Raily   |               | Bsdfd3 | UK      | Liverpool |
		| David     | Raily   | DoR@gmail.com |        | UK      | Liverpool |
		| David     | Raily   | DoR@gmail.com | Bsdfd3 |         | Liverpool |
		| David     | Raily   | DoR@gmail.com | Bsdfd3 | UK      |           |

@register
Scenario Outline: Unsuccessfull registration with used email
	Given Register page is opened
	When I try to register with already used email "<firstName>" and "<sirName>" and "<email>" and "<pass>" and "<country>" and "<city>"
	Then Error message pops-up

	Examples:
		| firstName | sirName | email        | pass   | country | city      |
		| Davide    | Raily   | DR@gmail.com | Bsdfd3 | UK      | Liverpool |