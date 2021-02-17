namespace AnimalFarm {
    public abstract class Egg<TFactory> : Producer<ICreature, TFactory>, IEgg
        where TFactory : IFactoryCreate<ICreature>, new() {

        public ICreature Hatch() => Produce();

    }
}
