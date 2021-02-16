namespace AnimalFarm.Birds {
    internal class Chicken : ICreature {

        public IFactoryCreate<IEgg> Factory { get; set; } = new ChickenFactory();

        public IEgg Lay() {
            Factory.Create(out IEgg obj);
            return obj;
        }

    }
}
