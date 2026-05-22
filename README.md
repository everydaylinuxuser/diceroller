# DiceRoller

Simple C# class library that rolls a die with a specified number of sides.

Usage:

1. Build the example and library:

```bash
dotnet build Example/Example.csproj
```

2. Run the example:

```bash
dotnet run --project Example/Example.csproj
```

API:

- `DiceRoller.Dice.Roll(int sides)` — returns an `int` between `1` and `sides` (inclusive). Throws `ArgumentOutOfRangeException` if `sides < 2`.
