namespace AnimalFarm {
    public abstract class Creature<TFactory> : Producer<IEgg, TFactory>, ICreature
        where TFactory : IFactoryCreate<IEgg>, new() {

        public IEgg Lay() => Produce();

    }
}
