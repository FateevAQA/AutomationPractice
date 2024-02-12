Feature: AddToCart
Some kind of end 2 end test close to user experience. 
It could be split to number of small functional tests.
But it was done like this(with verifications in the middle of scenario) for clarity of example.

Background:
	Given I open AutomationPractice site

Scenario: Add products to cart and verify products details are correct 
	Given I search for 'Dress'
		And I open 'Printed Summer Dress' product page
		And I select next attributes of the product
			| color   | size  | quantity  |
			|  Blue   |   L   |     4     |
		And I memorize price of 'Printed Summer Dress'
		And I add product to cart
		And I choose to 'Continue shopping'
		And I search for 'Blouse'
		And I open "Quick View" for 'Blouse' product
		And I switch to modal window frame
		And I select next attributes of the product
			| color | size | quantity |
			| White | M    | 2        |
		And I memorize price of 'Blouse'
		And I add product to cart
		And I switch back to default frame
	When I choose to 'Proceed to checkout'
	Then I see correct summary about added products
		| name                 | color | size | quantity |
		| Printed Summer Dress | Blue  | L    | 4        |
		| Blouse               | White | M    | 2        |