Feature: BusinessCustomerById  

#

@BusinessCustomerById
Scenario: Get Business Customer by ID	
	Given a Business Customer with the ID "a40354012" and request to CartegieApi returns :
		| property      | value                           |
		| name          | UBER PARTNER SUPPORT FRANCE SAS |
		| siret         | 81999478100022                  |
		| nafCode       | 8299Z                           |
		| zipCode       | 33000                           |
		| city          | UBER PARTNER SUPPORT FRANCE SAS |
		| socialReason  | UBER PARTNER SUPPORT FRANCE SAS |
		| phone         | +21268085321                    |
		| Adress        | Maarif                          |
		| Civility      | Marocaine                       |		
	When the Business Customer API receives the get request with ID "a40354012"
	Then the response status is "200"
	And the Business Customer API sends business customer information:
		| property      | value                           |
		| name          | UBER PARTNER SUPPORT FRANCE SAS |
		| siret         | 81999478100022                  |
		| nafCode       | 8299Z                           |
		| zipCode       | 33000                           |
		| city          | UBER PARTNER SUPPORT FRANCE SAS |
		| socialReason  | UBER PARTNER SUPPORT FRANCE SAS |
		| phone         | +21268085321                    |
		| Adress        | Maarif                          |
		| Civility      | Marocaine                       |