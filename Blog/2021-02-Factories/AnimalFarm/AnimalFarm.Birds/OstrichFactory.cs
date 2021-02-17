namespace AnimalFarm.Birds {
    internal class OstrichFactory : IAnimalFactory {

        public void Create(out IEgg obj) => obj = new OstrichEgg();

        public void Create(out ICreature obj) => obj = new Ostrich();

    }
}
