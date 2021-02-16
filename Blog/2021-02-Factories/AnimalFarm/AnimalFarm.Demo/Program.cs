using System;

namespace AnimalFarm.Demo {
    class Program {
        static void Main(String[] args) {

            IEgg egg_1 = Factory.Instance.CreateEgg();
            Console.WriteLine($"Created {egg_1.GetType().Name} ({nameof(egg_1)})");

            ICreature creature_1 = egg_1.Hatch();
            Console.WriteLine($"{nameof(egg_1)} has hatched a {creature_1.GetType().Name} ({nameof(creature_1)}))");

            IEgg egg_2 = creature_1.Lay();
            Console.WriteLine($"{nameof(creature_1)} has layed a {egg_2.GetType().Name} ({nameof(egg_2)})");

            ICreature creature_2 = egg_2.Hatch();
            Console.WriteLine($"{nameof(egg_2)} has hatched a {creature_2.GetType().Name} ({nameof(creature_2)})");

        }
    }
}
