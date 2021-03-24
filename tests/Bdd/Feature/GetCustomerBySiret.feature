Feature: GetCustomerBySiret

@BusinessCustomerBySirte
Scenario: Get Business Customer by Siret	
	Given a Business Customer with the Siret : "81999478100022"
	When the Business Customer API receives the get request with Siret : "81999478100022"
	Then the response status is : "200"
	And the Business Customer API sends business customer information :
		| property      | value                           |
		| name          | UBER PARTNER SUPPORT FRANCE SAS |
		| siret         | 81999478100022                  |
		| naf_code      | 8299Z                           |
		| zip_code      | 33000                           |
		| city          | UBER PARTNER SUPPORT FRANCE SAS |
		| social_reason | UBER PARTNER SUPPORT FRANCE SAS |