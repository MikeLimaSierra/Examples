namespace AnimalFarm {
    internal class Chicken : ICreature {

        public IEgg Lay() => new Factory().CreateEgg();

    }
}
