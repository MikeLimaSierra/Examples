namespace AnimalFarm {
    internal class ChickenEgg : IEgg {

        public ICreature Hatch() => new Factory().CreateCreature();

    }
}
