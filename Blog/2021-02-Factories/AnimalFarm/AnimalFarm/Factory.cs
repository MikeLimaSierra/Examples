namespace AnimalFarm {
    public class Factory : IFactory {

        public IEgg CreateEgg() => new ChickenEgg();

        public ICreature CreateCreature() => new Chicken();

    }
}
