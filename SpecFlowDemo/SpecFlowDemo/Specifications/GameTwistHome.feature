Feature: Game Twist Games
	In order to Play diffrent type of games
	As a User
	I want to have a User Interface which allows me find and play games of diffrent types

Scenario: Validate navigation for Slots, Bingo, Casino & Poker pages
    Given I open url as 'https://www.gametwist.com/en/'
    When I enter username 'bilal281' and password 'test123I!'
    And I click on Login Button
    Then I should see home page for game twist with nickname as 'bilal281'
	When I click on Slots link
	Then I should be navigated to 'Slots' page
	When I click on Bingo link
	Then I should be navigated to 'Bingo' page
	When I click on Poker link
	Then I should be navigated to 'Poker' page
	When I click on Casino link
	Then I should be navigated to 'Casino' page
	And I change language to German
	And I logout from application

Scenario: Validate game search from search section
    Given I open url as 'https://www.gametwist.com/en/'
    When I enter username 'bilal281' and password 'test123I!'
    And I click on Login Button
    Then I should see home page for game twist with nickname as 'bilal281'
    When I search for game 'Slots' from search game section
	Then I select and validate the selected game
	And I logout from application




