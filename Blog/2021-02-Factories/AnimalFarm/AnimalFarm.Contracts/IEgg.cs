namespace AnimalFarm {
    public interface IEgg : IProducer<ICreature> {

        ICreature Hatch();

    }
}
