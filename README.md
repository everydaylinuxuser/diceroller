# DiceRoller

Simple C# class library that rolls a die with a specified number of sides, with an ASP.NET Core Web API for remote access.

## Building

Build the entire solution:

```bash
dotnet build DiceRoller.sln
```

## Running the Web API

Start the API server:

```bash
dotnet run --project DiceRoller.Api/DiceRoller.Api.csproj
```

The API will be available at `https://localhost:5001` (or `http://localhost:5000`).

### API Endpoints

#### Roll a single die
```
GET /api/dice/roll/{sides}
```
Returns a random integer between 1 and `sides` (inclusive).

Example: `GET /api/dice/roll/6`
Response:
```json
{
  "sides": 6,
  "result": 4
}
```

#### Roll multiple dice
```
GET /api/dice/roll/{sides}/{count}
```
Roll `count` dice with `sides` sides each.

Example: `GET /api/dice/roll/6/3`
Response:
```json
{
  "sides": 6,
  "count": 3,
  "results": [4, 2, 5],
  "total": 11
}
```

### Swagger Documentation

When running in development, visit `https://localhost:5001/swagger` to explore the API interactively.

## Library API

- `DiceRoller.Dice.Roll(int sides)` — returns an `int` between `1` and `sides` (inclusive). Throws `ArgumentOutOfRangeException` if `sides < 2`.
