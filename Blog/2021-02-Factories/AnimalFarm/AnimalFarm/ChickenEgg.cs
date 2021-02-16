namespace AnimalFarm {
    internal class ChickenEgg : IEgg {

        public IFactoryCreate<ICreature> Factory { get; set; } = new ChickenFactory();

        public ICreature Hatch() {
            Factory.Create(out ICreature obj);
            return obj;
        }

    }
}
