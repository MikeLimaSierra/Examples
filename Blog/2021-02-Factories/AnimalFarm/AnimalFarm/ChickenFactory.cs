namespace AnimalFarm {
    internal class ChickenFactory : IFactory {

        public IEgg CreateEgg() => new ChickenEgg();

        public ICreature CreateCreature() => new Chicken();

    }
}
