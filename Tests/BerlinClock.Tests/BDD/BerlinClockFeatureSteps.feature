
Feature: The Berlin Clock
	As a clock enthusiast
    I want to tell the time using the Berlin Clock
    So that I can increase the number of ways that I can read the time


Scenario: Midnight 00:00
When the time is "00:00:00"
Then the clock should look like
"""
Y
OOOO
OOOO
OOOOOOOOOOO
OOOO
"""


Scenario: Middle of the afternoon
When the time is "13:17:01"
Then the clock should look like
"""
O
RROO
RRRO
YYROOOOOOOO
YYOO
"""

Scenario: Just before midnight
When the time is "23:59:59"
Then the clock should look like
"""
O
RRRR
RRRO
YYRYYRYYRYY
YYYY
"""

Scenario: Midnight 24:00
When the time is "24:00:00"
Then the clock should look like
"""
Y
RRRR
RRRR
OOOOOOOOOOO
OOOO
"""

Scenario: Maximum 24:59:59
When the time is "24:59:59"
Then the clock should look like
"""
O
RRRR
RRRR
YYRYYRYYRYY
YYYY
"""

Scenario: Early Morning 07:01:09
When the time is "07:01:09"
Then the clock should look like
"""
O
ROOO
RROO
OOOOOOOOOOO
YOOO
"""

Scenario: Format Exception #1
When the time is ""
Then the format exception should be thrown

Scenario: Format Exception #2
When the time is "25:00:00"
Then the format exception should be thrown

Scenario: Format Exception #3
When the time is "24:60:00"
Then the format exception should be thrown
