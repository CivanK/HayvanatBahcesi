using HayvanatBahcesi.Models;

namespace HayvanatBahcesi.Services
{
    public class Zoo
    {
        public int AreaSize = 500;
        public List<Animal> Animals = new List<Animal>();
        public Hunter Hunter;
        private Random rnd = new Random();
        private Dictionary<Wolf, int> wolfKills = new Dictionary<Wolf, int>();
        private Dictionary<Lion, int> lionKills = new Dictionary<Lion, int>();
        private int hunterKills = 0;

        public Zoo()
        {
            for (int i = 0; i < 15; i++)
                Animals.Add(new Sheep(RandomPosition(), Gender.Male));
            for (int i = 0; i < 15; i++)
                Animals.Add(new Sheep(RandomPosition(), Gender.Female));

            for (int i = 0; i < 5; i++)
                Animals.Add(new Cow(RandomPosition(), Gender.Male));
            for (int i = 0; i < 5; i++)
                Animals.Add(new Cow(RandomPosition(), Gender.Female));

            for (int i = 0; i < 10; i++)
                Animals.Add(new Chicken(RandomPosition(), Gender.Female));
            for (int i = 0; i < 10; i++)
                Animals.Add(new Rooster(RandomPosition(), Gender.Male));

            for (int i = 0; i < 5; i++)
                Animals.Add(new Wolf(RandomPosition(), Gender.Male));
            for (int i = 0; i < 5; i++)
                Animals.Add(new Wolf(RandomPosition(), Gender.Female));

            for (int i = 0; i < 4; i++)
                Animals.Add(new Lion(RandomPosition(), Gender.Male));
            for (int i = 0; i < 4; i++)
                Animals.Add(new Lion(RandomPosition(), Gender.Female));

            Hunter = new Hunter(RandomPosition());
        }

        private Point RandomPosition()
        {
            return new Point(rnd.Next(0, AreaSize + 1), rnd.Next(0, AreaSize + 1));
        }

        public void Simulate()
        {
            for (int i = 0; i < 1000; i++)
            {
                foreach (var animal in Animals.ToList())
                    animal.Move(AreaSize, rnd);

                Hunter.Move(AreaSize, rnd);

                HandlePredation();
                HandleReproduction();
            }

            PrintResults();
        }

        private void HandlePredation()
        {
            foreach (var wolf in Animals.OfType<Wolf>().ToList())
            {
                var prey = Animals.Where(a =>
                    (a is Sheep || a is Chicken || a is Rooster) &&
                    wolf.Position.DistanceTo(a.Position) <= 4).ToList();
                
                if (!wolfKills.ContainsKey(wolf))
                    wolfKills[wolf] = 0;
                
                wolfKills[wolf] += prey.Count;
                foreach (var p in prey)
                    Animals.Remove(p);
            }

            foreach (var lion in Animals.OfType<Lion>().ToList())
            {
                var prey = Animals.Where(a =>
                    (a is Sheep || a is Cow) &&
                    lion.Position.DistanceTo(a.Position) <= 5).ToList();
                
                if (!lionKills.ContainsKey(lion))
                    lionKills[lion] = 0;
                
                lionKills[lion] += prey.Count;
                foreach (var p in prey)
                    Animals.Remove(p);
            }

            var hunterPrey = Animals.Where(a => Hunter.Position.DistanceTo(a.Position) <= 8).ToList();
            hunterKills += hunterPrey.Count;
            foreach (var p in hunterPrey)
                Animals.Remove(p);
        }

        private void HandleReproduction()
        {
            var groups = Animals.GroupBy(a => a.GetType());
            foreach (var group in groups)
            {
                var males = group.Where(a => a.Gender == Gender.Male).ToList();
                var females = group.Where(a => a.Gender == Gender.Female).ToList();

                foreach (var male in males)
                {
                    foreach (var female in females)
                    {
                        if (male.Position.DistanceTo(female.Position) <= 3)
                        {
                            var gender = (Gender)rnd.Next(0, 2);
                            Animal baby = male switch
                            {
                                Sheep => new Sheep(RandomPosition(), gender),
                                Cow => new Cow(RandomPosition(), gender),
                                Wolf => new Wolf(RandomPosition(), gender),
                                Lion => new Lion(RandomPosition(), gender),
                                Rooster => new Chicken(RandomPosition(), gender),
                                _ => null
                            };

                            if (baby != null)
                            {
                                Animals.Add(baby);
                                // Initialize kill tracking for predator offspring
                                if (baby is Wolf wolf)
                                    wolfKills[wolf] = 0;
                                else if (baby is Lion lion)
                                    lionKills[lion] = 0;
                            }
                        }
                    }
                }
            }
        }

        private void PrintResults()
        {
            Console.WriteLine("\nAnimal Population Report:");
            Console.WriteLine("========================");
            
            PrintAnimalTypeStats<Sheep>("Sheep");
            PrintAnimalTypeStats<Cow>("Cow");
            PrintAnimalTypeStats<Chicken>("Chicken");
            PrintAnimalTypeStats<Rooster>("Rooster");
            PrintAnimalTypeStats<Wolf>("Wolf");
            PrintAnimalTypeStats<Lion>("Lion");

            Console.WriteLine("\nPredator Kill Report:");
            Console.WriteLine("===================");
            
            // Print Wolf kills
            var wolves = Animals.OfType<Wolf>().ToList();
            if (wolves.Any())
            {
                Console.WriteLine("\nWolf Kills:");
                foreach (var wolf in wolves)
                {
                    if (wolfKills.ContainsKey(wolf))
                        Console.WriteLine($"  Wolf at ({wolf.Position.X}, {wolf.Position.Y}): {wolfKills[wolf]} kills");
                }
            }

            // Print Lion kills
            var lions = Animals.OfType<Lion>().ToList();
            if (lions.Any())
            {
                Console.WriteLine("\nLion Kills:");
                foreach (var lion in lions)
                {
                    if (lionKills.ContainsKey(lion))
                        Console.WriteLine($"  Lion at ({lion.Position.X}, {lion.Position.Y}): {lionKills[lion]} kills");
                }
            }

            // Print Hunter kills
            Console.WriteLine($"\nHunter Kills: {hunterKills}");
        }

        private void PrintAnimalTypeStats<T>(string animalName) where T : Animal
        {
            var animals = Animals.OfType<T>().ToList();
            var males = animals.Count(a => a.Gender == Gender.Male);
            var females = animals.Count(a => a.Gender == Gender.Female);
            
            Console.WriteLine($"\n{animalName}:");
            Console.WriteLine($"  Total: {animals.Count}");
            Console.WriteLine($"  Males: {males}");
            Console.WriteLine($"  Females: {females}");
        }
    }
}