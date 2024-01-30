Feature: Search
Search for product and verify results


Background:
	Given I open Automationpractice site

Scenario: Search something
	When I search for 'Women dress'
	Then Results page have '6' results