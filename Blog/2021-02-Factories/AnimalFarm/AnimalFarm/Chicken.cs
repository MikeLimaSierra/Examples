namespace AnimalFarm {
    internal class Chicken : ICreature {

        public IEgg Lay() {
            Factory.Chicken.Create(out IEgg obj);
            return obj;
        }

    }
}
