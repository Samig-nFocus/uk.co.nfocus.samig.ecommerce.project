Feature: ShopItems

Background: 
	Given that i have logged in using valid credentials

@DiscountTest
Scenario Outline: Applying Coupon
	When i add an '<item>' to the cart
	And i apply a valid coupon 'edgewords'
	Then discount of '15'% is applied
	And the total is calculated with shipping and discount

	Examples: 
	| item       |
	| Beanie     |
	| Sunglasses |
	| Polo       |

@OrderTest
Scenario: Order Confirmation
	When i checkout my cart
	And complete the billing form
	Then order number is generated and viewable in order page


