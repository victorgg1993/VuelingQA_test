Feature: RounTrip
	Buying round trip ticket for 1 adult From Barcelona to Madrid

@Test_roundTrip
Scenario: Buy a 1 adult ticket for a round trip with basic plan.
		  The origin date must be +3 days of the purchase date and the destiny, +5 days.
	Given the origin is Barcelona
	And the destiny is Madrid
	When the ticket is bought
	Then Go to payment window
