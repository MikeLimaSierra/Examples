namespace AnimalFarm {
    internal class OstrichEgg : IEgg {

        public ICreature Hatch() {
            Factory.Ostrich.Create(out ICreature obj);
            return obj;
        }

    }
}
