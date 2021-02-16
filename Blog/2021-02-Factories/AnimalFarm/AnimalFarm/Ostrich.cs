namespace AnimalFarm {
    internal class Ostrich : ICreature {

        public IEgg Lay() => Factory.Ostrich.CreateEgg();

    }
}
