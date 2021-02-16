namespace AnimalFarm {
    internal class ChickenEgg : IEgg {

        public ICreature Hatch() => Factory.Chicken.CreateCreature();

    }
}
