# The Berlin Clock - Solution Notes

Dear reviewer, 

I would like to briefly describe solution notes and issues I have during development. Even through code is simple to understand, please go throug this text in order to better understanding of my ideas. It also might be a feedback for you.

### Build requirements

C# 7.0 features are used thus Visual Studio 2017 is must have for sucessful build. I was told it's fine even through solution was originally created in VS 2013.

### Solution description

Solution is quite generic and each component has its own responsibility. Factories are responsible for creating correct component objects. It's all about settings.

Code is IoC and DI ready (currently it's not used)

### Testing

There is project only for testing purpose BerlinClock.Tests. It's goood to separate test and product code, because we don't want to ship testing code and test dependencies to production.
I consider unit testing as essential thing during development so code is really good testable and currently there is more than 130 unit tests (lot are generated).

### Limitations and known issues

This implementation is not the best solution from performance point of view (especially memory consuming). BerlinClockModel uses Bulb objects for each row (24 bulb instances) even through it's not necessary, because we know that if 6th bulb is on (in first minutes bulb row), first 5 bulbs are on as well. On the other hand, we can benefit from generality of this solution. BulbRow object just turns on bulbs and it doesn't care whether it's red or yellow. Since this is excercise, I've decided to go with generic and elegant solution, which correspondents to a realistic BerlinClock model. As a demonstration of generality of this solution, I created Modified Berlin clock, which is described at the end of this file.

My model is able to display time 24:59:59, which is not valid time from real life point of view, but real BerlinClock is able to display this time as well. I decieded to allow this, when I saw test case 24:00:00 (Which is also invalid).

### Modified BerlinClock

Original BerlinClock model loses information about seconds. We can only read, whether seconds count is even or odd. Solution contains BDD tests and implementation (all is just about settings) of Modiefied BerlinClock model, which works in following way:

* Seconds part consists of 3 rows
* First row has 2 bulbs and each has value of 20
* Second row has 3 bulbs and each has value of 5
* Third row has 4 bulbs and each has value of 1

YO<br/>
YYO<br/>
YYYY

means 20 + 5 + 5 + 4 = 34 seconds.

All other parts (hours and minutes) are the same as in original BerlinClock.

<b>I hope you will appreciate my solution at least as much as I enjoyed the problem solving.</b>


