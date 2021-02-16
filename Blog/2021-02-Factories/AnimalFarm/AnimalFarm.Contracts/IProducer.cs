namespace AnimalFarm {
    public interface IProducer<T> {

        IFactoryCreate<T> Factory { get; set; }

    }
}
