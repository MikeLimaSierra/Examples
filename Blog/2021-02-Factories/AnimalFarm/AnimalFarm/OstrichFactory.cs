namespace AnimalFarm {
    internal class OstrichFactory : IFactory {

        public void Create(out IEgg obj) => obj = new OstrichEgg();

        public void Create(out ICreature obj) => obj = new Ostrich();

    }
}
