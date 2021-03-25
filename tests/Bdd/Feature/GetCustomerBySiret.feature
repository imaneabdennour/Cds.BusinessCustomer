Feature: GetCustomerBySiret

@BusinessCustomerBySiret
Scenario: Get Business Customer by Siret	
	Given a Business Customer with the Siret : "81999478100022"  and request to CartegieApi returns :
		| property      | value                           |
		| name          | UBER PARTNER SUPPORT FRANCE SAS |
		| siret         | 81999478100022                  |
		| naf_code      | 8299Z                           |
		| zip_code      | 33000                           |
		| city          | UBER PARTNER SUPPORT FRANCE SAS |
		| social_reason | UBER PARTNER SUPPORT FRANCE SAS |
		| phone         | +21268085321                    |
		| Adress        | Maarif                          |
		| Civility      | Marocaine                       |	
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
		| phone         | +21268085321                    |
		| Adress        | Maarif                          |
		| Civility      | Marocaine                       |	