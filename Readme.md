# The Berlin Clock - Solution Notes

Dear reviewer, 

I would like to briefly describe solution notes and issues I have during development. Even though the code is simple to understand, please go through this text in order to better understand my ideas. It also might be a feedback for you.
### Build requirements

C# 7.0 features are used thus Visual Studio 2017 is must have for a sucessful build. I was told it's fine even through solution was originally created in VS 2013.

### Solution description

The solution is quite generic and each component has its own responsibility. Factories are responsible for creating correct component objects. It's all about settings.

Code is IoC and DI ready (currently it's not used)

### Testing

There is project only for testing purpose BerlinClock.Tests. It's good to separate test and product code because we don't want to ship testing code and test dependencies to production. I consider unit testing as essential thing during development so the code is really good testable and currently there are more than 130 unit tests (a lot of them are generated).

### Limitations and known issues

This implementation is not the best solution from a performance point of view (especially memory consuming). BerlinClockModel uses Bulb objects for each row (24 bulb instances) even though it's not necessary because we know that if a 6th bulb is on (in first minutes bulb row), first 5 bulbs are on as well. On the other hand, we can benefit from the generality of this solution. A BulbRow object just turns on bulbs and it doesn't care whether it's red or yellow. Since this is exercise, I've decided to go with a generic and elegant solution, which correspondents to a realistic BerlinClock model. As a demonstration of the generality of this solution, I created Modified Berlin clock, which is described at the end of this file.

My model is able to display time 24:59:59, which is not valid time from a real life point of view, but real BerlinClock is able to display this time as well. I decided to allow this, when I saw test case 24:00:00 (Which is also invalid).

### Modified BerlinClock

An original BerlinClock model loses information about seconds. We can only read, whether seconds count is even or odd. The solution contains BDD tests and implementation (all is just about settings) of Modified BerlinClock model, which works in following way:

* Seconds part consists of 3 rows
* The First row has 2 bulbs and each has value of 20
* The Second row has 3 bulbs and each has value of 5
* The Third row has 4 bulbs and each has value of 1

YO<br/>
YYO<br/>
YYYY

means 20 + 5 + 5 + 4 = 34 seconds.

All other parts (hours and minutes) are the same as in original BerlinClock.

<b>I hope you will appreciate my solution at least as much as I enjoyed the problem solving.</b>


