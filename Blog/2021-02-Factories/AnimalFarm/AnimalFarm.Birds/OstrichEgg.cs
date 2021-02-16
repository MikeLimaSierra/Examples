namespace AnimalFarm.Birds {
    internal class OstrichEgg : IEgg {

        public IFactoryCreate<ICreature> Factory { get; set; } = new OstrichFactory();

        public ICreature Hatch() {
            Factory.Create(out ICreature obj);
            return obj;
        }

    }
}
