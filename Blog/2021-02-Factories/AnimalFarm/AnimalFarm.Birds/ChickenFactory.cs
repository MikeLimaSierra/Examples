namespace AnimalFarm.Birds {
    internal class ChickenFactory : IAnimalFactory {

        public void Create(out IEgg obj) => obj = new ChickenEgg();

        public void Create(out ICreature obj) => obj = new Chicken();

    }
}
