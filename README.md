# Hayvanat Bahçesi (Zoo Simulation)

A C# console application that simulates a zoo ecosystem with various animals, predators, and a hunter. The simulation demonstrates animal behavior, predation, reproduction, and population dynamics.

## Features

- Multiple animal types with different behaviors:
  - Prey: Sheep, Cows, Chickens/Roosters
  - Predators: Wolves, Lions
  - Hunter
- Realistic movement patterns for all animals
- Predation system where predators hunt prey
- Reproduction system based on proximity and gender
- Population tracking and statistics
- Kill count tracking for predators and hunter

## Animal Types and Initial Population

- Sheep: 15 males, 15 females
- Cows: 5 males, 5 females
- Chickens: 10 females
- Roosters: 10 males
- Wolves: 5 males, 5 females
- Lions: 4 males, 4 females
- 1 Hunter

## Simulation Rules

1. **Movement**: All animals move randomly within the zoo area (500x500 units)
2. **Predation**:
   - Wolves can hunt Sheep, Chickens, and Roosters within 4 units
   - Lions can hunt Sheep and Cows within 5 units
   - Hunter can hunt any animal within 8 units
3. **Reproduction**: Animals can reproduce when they are within 3 units of each other
   - Requires male and female of the same species
   - Offspring gender is randomly determined

## Requirements

- .NET 6.0 or later

## How to Run

1. Clone the repository
```bash
git clone https://github.com/yourusername/HayvanatBahcesi.git
```

2. Navigate to the project directory
```bash
cd HayvanatBahcesi
```

3. Build and run the project
```bash
dotnet build
dotnet run
```

## Project Structure

- `Models/`: Contains animal class definitions
- `Services/`: Contains the main Zoo simulation logic
- `Program.cs`: Entry point of the application

## Output

The simulation runs for 1000 iterations and provides:
- Final population counts for each animal type
- Gender distribution statistics
- Kill counts for predators and hunter
- Position information for remaining animals

## Future Improvements

- Add more animal types
- Implement more complex behavior patterns
- Add visualization of the zoo
- Include environmental factors
- Add configuration options for simulation parameters 
