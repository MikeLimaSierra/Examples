namespace AnimalFarm {
    internal class ChickenFactory : IFactory {

        public void Create(out IEgg obj) => obj = new ChickenEgg();

        public void Create(out ICreature obj) => obj = new Chicken();

    }
}
