# Gilded Rose

Code for coding kata about refactoring (C#).  
Credits to [Bobby Johnson](https://github.com/notmyself/GildedRose) for the starter.

## Setup

- .NET 5.0 SDK
- `dotnet run -p GildedRose.App` (console app)
- `dotnet watch -p GildedRose.Test test` (xUnit tests)

## Changelog

- Functional tests added: given requirements covered
- First snapshot test added: one real execution covered
- **Program code not touched**

## TODO

- Understand and add snapshot tests
- Refactor the legacy code. Ideas :
    - Use inheritance to define different behaviours
    - Use [factory pattern](https://refactoring.guru/design-patterns/factory-method) to setup the items
    - Use composition instead of inheritance ([strategy pattern](https://refactoring.guru/design-patterns/strategy)) and compare
- Support new conjured items