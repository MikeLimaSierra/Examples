using System;

namespace AnimalFarm.Demo {
    class Program {
        static void Main(String[] args) {

            Factory.Chicken.Create(out IEgg egg_1);
            Console.WriteLine($"Created {egg_1.GetType().Name} ({nameof(egg_1)})");

            ICreature creature_1 = egg_1.Hatch();
            Console.WriteLine($"{nameof(egg_1)} has hatched a {creature_1.GetType().Name} ({nameof(creature_1)}))");

            creature_1.Factory = Factory.Ostrich;
            Console.WriteLine($"Injected egg factory into {nameof(creature_1)}");

            IEgg egg_2 = creature_1.Lay();
            Console.WriteLine($"{nameof(creature_1)} has layed a {egg_2.GetType().Name} ({nameof(egg_2)})");

            ICreature creature_2 = egg_2.Hatch();
            Console.WriteLine($"{nameof(egg_2)} has hatched a {creature_2.GetType().Name} ({nameof(creature_2)})");

            IEgg egg_3 = creature_2.Lay();
            Console.WriteLine($"{nameof(creature_2)} has layed a {egg_3.GetType().Name} ({nameof(egg_3)})");

            egg_3.Factory = Factory.Chicken;
            Console.WriteLine($"Injected creature factory into {nameof(egg_3)}");

            ICreature creature_3 = egg_3.Hatch();
            Console.WriteLine($"{nameof(egg_3)} has hatched a {creature_3.GetType().Name} ({nameof(creature_3)})");

        }
    }
}
