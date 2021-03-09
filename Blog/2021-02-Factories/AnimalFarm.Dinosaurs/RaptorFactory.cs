namespace AnimalFarm.Dinosaurs {
    internal class RaptorFactory : IAnimalFactory {

        public void Create(out IEgg obj) => obj = new RaptorEgg();

        public void Create(out ICreature obj) => obj = new Raptor();

    }
}
