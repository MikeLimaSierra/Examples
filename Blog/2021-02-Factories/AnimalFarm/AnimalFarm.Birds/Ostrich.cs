namespace AnimalFarm.Birds {
    internal class Ostrich : ICreature {

        public IFactoryCreate<IEgg> Factory { get; set; } = new OstrichFactory();

        public IEgg Lay() {
            Factory.Create(out IEgg obj);
            return obj;
        }

    }
}
