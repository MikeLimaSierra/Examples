using System;

using AnimalFarm.Birds;
using AnimalFarm.Dinosaurs;

namespace AnimalFarm.Demo {
    class Program {
        static void Main(String[] args) {

            Factory.Instance.Chicken().Create(out IEgg egg_1);
            Console.WriteLine($"Created {egg_1.GetType().Name} ({nameof(egg_1)})");

            ICreature creature_1 = egg_1.Hatch();
            Console.WriteLine($"{egg_1.GetType().Name} has hatched a {creature_1.GetType().Name} ({nameof(creature_1)}))");

            creature_1.Factory = Factory.Instance.Ostrich();
            Console.WriteLine($"Injected egg factory into {creature_1.GetType().Name}");

            IEgg egg_2 = creature_1.Lay();
            Console.WriteLine($"{creature_1.GetType().Name} has layed a {egg_2.GetType().Name} ({nameof(egg_2)})");

            ICreature creature_2 = egg_2.Hatch();
            Console.WriteLine($"{egg_2.GetType().Name} has hatched a {creature_2.GetType().Name} ({nameof(creature_2)})");

            IEgg egg_3 = creature_2.Lay();
            Console.WriteLine($"{creature_2.GetType().Name} has layed a {egg_3.GetType().Name} ({nameof(egg_3)})");

            egg_3.Factory = Factory.Instance.TRex();
            Console.WriteLine($"Injected creature factory into {egg_3.GetType().Name}");

            ICreature creature_3 = egg_3.Hatch();
            Console.WriteLine($"{egg_3.GetType().Name} has hatched a {creature_3.GetType().Name} ({nameof(creature_3)})");

        }
    }
}
