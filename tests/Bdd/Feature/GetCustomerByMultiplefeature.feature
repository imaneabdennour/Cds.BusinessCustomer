Feature: GetCustomerByMultiplefeature

@BusinessCustomerByMultiple
Scenario: Get Business Customer by SocialReason And ZipCode	
	Given a Business Customer with the socialreason : "123" and zipcode : "456" and request to CartegieApi returns :
		| Name          | Adress    | Id    | SocialReason |
		| Electroplanet | Maarif    | 1254  | rs154        |
		| Jumia         | Derb Omar | 78945 | rs7864       | 
	When the Business Customer API receives the get request with socialreason : "a40354012" and zipcode : "456"
	Then the response status is:"200"
	And the Business Customer API sends business customer information  :
		| Name          | Adress    | Id    | SocialReason |
		| Electroplanet | Maarif    | 1254  | rs154        |
		| Jumia         | Derb Omar | 78945 | rs7864       | 

Scenario: Get Business Customer by SocialReason and invalid ZipCode
	When the Business Customer API receives the get request with socialreason : "a40354012" and zipcode : ""
	Then the response status is:"400"

Scenario: Get Business Customer by invalid SocialReason and ZipCode
	When the Business Customer API receives the get request with socialreason : "" and zipcode : "123456"
	Then the response status is:"400"