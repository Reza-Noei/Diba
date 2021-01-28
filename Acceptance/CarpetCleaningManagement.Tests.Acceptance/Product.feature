Feature: Product
	In order to 
	As a Product Management administrator
	I want to be able to manage Products

Background:
	Given 'reza' is an administrador
	And 'reza' is(has) logged in

Scenario: define new a product
	Given there is constraints in system as following
		| Title       |
		| WeavingType |
		| Meterial    |
		| Area        |
	When 'reza' has define a product in system as following
		| Name   |
		| carpet |
	And he has assigned the following constraint for it
		| Title       | Type      | Options                 |
		| WeavingType | Selective | 1= Machine, 2= Handmade |
	Then It should be available in the list of products

Scenario: modifying a product
	Given there is constraints in system as following
		| Title       |
		| WeavingType |
		| Meterial    |
	And 'reza' has define a product in system as following
		| Title  |
		| carpet |
	And he has assigned the following constraint for it
		| Title    | Type      | Options          |
		| Meterial | Selective | 1= silky, 2=Wool |
	When he changes the measures given in the example above as following
		| Title  |
		| carpet |
	And he has assigned the following constraint for it:
		| Title       | Type      | Options          |
		| WeavingType | Selective | 1= silky, 2=Wool |
	Then The product has changed with the above information

Scenario: deleting a product
	Given there is constraints in system as following
		| Title       |
		| WeavingType |
		| Meterial    |
		| Area        |
	And 'reza' has define a product in system as following
		| Title  |
		| carpet |
	And he has assigned the following constraint for it
		| Title       | Type      | Options                 |
		| WeavingType | Selective | 1= Machine, 2= Handmade |
	When he removes the product defined above
	Then It should not appear in the list of products