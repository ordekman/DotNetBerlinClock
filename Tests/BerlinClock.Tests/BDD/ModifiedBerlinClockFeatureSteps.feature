
Feature: The Modified Berlin Clock
	As a clock enthusiast
    I want to tell the time using the Modified Berlin Clock
    So that I can increase the number of ways that I can read the time


Scenario: Midnight 00:00
When the time is "00:00:00"
Then the modified clock should look like
"""
OO
OOO
OOOO
OOOO
OOOO
OOOOOOOOOOO
OOOO
"""


Scenario: Middle of the afternoon
When the time is "13:17:01"
Then the modified clock should look like
"""
OO
OOO
YOOO
RROO
RRRO
YYROOOOOOOO
YYOO
"""

Scenario: Just before midnight
When the time is "23:59:59"
Then the modified clock should look like
"""
YY
YYY
YYYY
RRRR
RRRO
YYRYYRYYRYY
YYYY
"""

Scenario: Midnight 24:00
When the time is "24:00:00"
Then the modified clock should look like
"""
OO
OOO
OOOO
RRRR
RRRR
OOOOOOOOOOO
OOOO
"""

Scenario: Maximum 24:59:59
When the time is "24:59:59"
Then the modified clock should look like
"""
YY
YYY
YYYY
RRRR
RRRR
YYRYYRYYRYY
YYYY
"""

Scenario: Early Morning 07:01:09
When the time is "07:01:09"
Then the modified clock should look like
"""
OO
YOO
YYYY
ROOO
RROO
OOOOOOOOOOO
YOOO
"""
