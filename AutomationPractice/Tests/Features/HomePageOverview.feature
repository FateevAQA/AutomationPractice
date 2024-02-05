Feature: HomePageOverview
Overall verifications on Home page


Scenario: Verify categories names
	Given I open AutomationPractice site
	Then I see categories names are 'WOMEN,DRESSES,T-SHIRTS,BLOG'

Scenario Outline: Verify subcategories names
	Given I open AutomationPractice site
	When I hover '<categoryName>' category
	Then I see next subcategories titles '<expectedSubcategoriesTitles>' for the '<categoryName>' category
		And I see next subcategories '<expectedSubcategoriesNames>' for the '<categoryName>' category

Examples:
	| categoryName | expectedSubcategoriesTitles                   | expectedSubcategoriesNames                                     |
	| Women        | TOPS,DRESSES                                  | T-shirts,Blouses,Casual Dresses,Evening Dresses,Summer Dresses |
	| Dresses      | CASUAL DRESSES,EVENING DRESSES,SUMMER DRESSES |                                                                |