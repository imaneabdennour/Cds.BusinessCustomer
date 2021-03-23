Feature: BusinessCustomerById

@BusinessCustomerById
Scenario: Get Business Customer by Id	
	Given a Business Customer with the Id : "a40354012"
	When the Business Customer API receives the get request with Id : "a40354012"
	Then the response status is : "200"
	And the Business Customer API sends business customer information :
		| property      | value                           |
		| name          | UBER PARTNER SUPPORT FRANCE SAS |
		| siret         | 81999478100022                  |
		| naf_code      | 8299Z                           |
		| adress        | Maarif                          |
		| phone         |                                 |
		| zip_code      | 33000                           |
		| city          | UBER PARTNER SUPPORT FRANCE SAS |
		| social_reason | UBER PARTNER SUPPORT FRANCE SAS |
		| civility      |                                 |