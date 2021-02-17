namespace AnimalFarm {
    public abstract class Producer<TOut, TFactory> : IProducer<TOut>
        where TFactory : IFactoryCreate<TOut>, new() {

        public IFactoryCreate<TOut> Factory { get; set; }

        public Producer() => Factory = new TFactory();

        protected TOut Produce() {
            Factory.Create(out TOut obj);
            return obj;
        }

    }
}
