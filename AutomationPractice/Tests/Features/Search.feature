Feature: Search
Search for product and verify results


Background:
	Given I open AutomationPractice site

Scenario Outline: Verify total number of the search results is shown correctly
	When I search for '<searchText>'
	Then I see that total number of shown results is '<numberOfResults>'

	Examples:
	| searchText    | numberOfResults |
	| printed dress | 5               |
	| blouse        | 1               |