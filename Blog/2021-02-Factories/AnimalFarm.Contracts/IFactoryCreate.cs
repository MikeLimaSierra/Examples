namespace AnimalFarm {
    public interface IFactoryCreate<T> {

        void Create(out T obj);

    }
}
