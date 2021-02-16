namespace AnimalFarm {
    internal class ChickenEgg : IEgg {

        public ICreature Hatch() {
            Factory.Chicken.Create(out ICreature obj);
            return obj;
        }

    }
}
