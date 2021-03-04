Feature: Order
	In order to 
	As a administrator
	I want to be able to manage Orders

Background:
	Given 'reza' is an administrador
	And 'reza' is(has) logged in

Scenario: customer order registration (customer request)
	Given that a person with following information exists as customer:
		| frist name | last name |
		| hamid      | rezaei    |
	When 'hamid rezaei' requests collection as follows
		| Item                               |
		| Washing a 12 meter handmade carpet |
	And  'reza' announced '22'$ Price
	Then a requested order will be registrated for 'hamid rezaei'(customer)

Scenario: collect order
	Given that a person with following information exists as customer:
		| frist name | last name |
		| hamid      | rezaei    |
	And customer requests collection as follows
		| Item                               |
		| Washing a 12 meter handmade carpet |
	And 'reza' announced '22'$ Price
	When collecting a requested order for 'hamid rezaei'
	Then a requested order will be collect for 'hamid rezaei'(customer)

Scenario: calculate order
	Given that a person with following information exists as customer:
		| frist name | last name |
		| hamid      | rezaei    |
	And customer requests collection as follows
		| Item                               |
		| Washing a 12 meter handmade carpet |
	And 'reza' announced '22'$ Price
	And collecting a requested order for 'hamid rezaei'
	When calculating a collected order for 'hamid rezaei'
	Then a collected order will be calculate for 'hamid rezaei'(customer)

Scenario: process order
	Given that a person with following information exists as customer:
		| frist name | last name |
		| hamid      | rezaei    |
	And customer requests collection as follows
		| Item                               |
		| Washing a 12 meter handmade carpet |
	And 'reza' announced '22'$ Price
	And collecting a requested order for 'hamid rezaei'
	And calculating a collected order for 'hamid rezaei'
	When processing a calculated order for 'hamid rezaei'
	Then a calculated order will be process for 'hamid rezaei'(customer)

Scenario: deliver order
	Given that a person with following information exists as customer:
		| frist name | last name |
		| hamid      | rezaei    |
	And customer requests collection as follows
		| Item                               |
		| Washing a 12 meter handmade carpet |
	And 'reza' announced '22'$ Price
	And collecting a requested order for 'hamid rezaei'
	And calculating a collected order for 'hamid rezaei'
	And processing a calculated order for 'hamid rezaei'
	When delivering a processed order for 'hamid rezaei'
	Then a processed order will be deliver for 'hamid rezaei'(customer)

Scenario: balance order
	Given that a person with following information exists as customer:
		| frist name | last name |
		| hamid      | rezaei    |
	And customer requests collection as follows
		| Item                               |
		| Washing a 12 meter handmade carpet |
	And 'reza' announced '22'$ Price
	And collecting a requested order for 'hamid rezaei'
	And calculating a collected order for 'hamid rezaei'
	And processing a calculated order for 'hamid rezaei'
	And delivering a processed order for 'hamid rezaei'
	When balancing a delivered order for 'hamid rezaei'
	Then a delivered order will be balance for 'hamid rezaei'(customer)