namespace AnimalFarm {
    public interface ICreature : IProducer<IEgg> {

        IEgg Lay();

    }
}
