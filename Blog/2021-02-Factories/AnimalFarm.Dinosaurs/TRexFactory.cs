namespace AnimalFarm.Dinosaurs {
    internal class TRexFactory : IAnimalFactory {

        public void Create(out IEgg obj) => obj = new TRexEgg();

        public void Create(out ICreature obj) => obj = new TRex();

    }
}
