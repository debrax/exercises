# Double Cola

Original kata by [AlexIsHappy](https://www.codewars.com/users/AlexIsHappy) on [CodeWars](https://www.codewars.com/).  
Topics: C#, TDD, optimization  
**Try it before looking at the solution!**

## Requirements

> - There is a queue before a crazy cola machine.
> - Each time the first person of the queue drinks cola, it doubles and go at the end of the queue.
> - Create a program which gives the name of the n-th cola drinker.
> - The n-th drinker should be nobody when no cola is drunk.
> - The initial queue has five people: Sheldon, Leonard, Penny, Rajesh and Howard.
> - The 1st drinker should be Sheldon.
> - The 9th drinker should be Penny.
> - The 59th drinker should be Rajesh.
> - The 141th drinker should be Howard.
> - The 7230702951th drinker should be Leonard.

## Steps

Following TDD:
- DoubleCola object initialized with the names (`string[]`)
- Nobody returned when no drinker
- Nobody returned when no cola drunk
- First cases with a naive `List<string>`, then a `Queue<string>`
- Performance crash on 7230702951 case
    - Space: each drinker doubles => O(2^n) for the queue
    - Time: iteration on the queue => O(2^n)
- **Idea: clones are always together (all doubled) or in two groups (some doubled at the end and some waiting at the start)**
- Object `DrinkerClones` for clones (name and count)
    - Space: only group count change => O(n)
    - Time: iteration on the queue => O(n)
- Case 7230702951 complete
- Refactoring for lisibility, **without TDD** (behavior covered, no real value for internal structure)