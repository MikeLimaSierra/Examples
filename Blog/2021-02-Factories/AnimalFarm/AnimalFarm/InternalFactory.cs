namespace AnimalFarm {
    internal class InternalFactory : IFactory {

        public IEgg CreateEgg() => new ChickenEgg();

        public ICreature CreateCreature() => new Chicken();

    }
}
