﻿namespace AnimalFarm {
    internal class Chicken : ICreature {

        public IEgg Lay() => Factory.CreateEgg();

    }
}