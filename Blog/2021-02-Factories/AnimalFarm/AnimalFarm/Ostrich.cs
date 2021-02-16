namespace AnimalFarm {
    internal class Ostrich : ICreature {

        public IEgg Lay() {
            Factory.Ostrich.Create(out IEgg obj);
            return obj;
        }

    }
}
