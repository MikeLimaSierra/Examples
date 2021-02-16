namespace AnimalFarm {
    internal class OstrichEgg : IEgg {

        public ICreature Hatch() => Factory.Ostrich.CreateCreature();

    }
}
