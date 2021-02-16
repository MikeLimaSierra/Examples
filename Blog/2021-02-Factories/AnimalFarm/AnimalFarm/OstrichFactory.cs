namespace AnimalFarm {
    internal class OstrichFactory : IFactory {

        public IEgg CreateEgg() => new OstrichEgg();

        public ICreature CreateCreature() => new Ostrich();

    }
}
