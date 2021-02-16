namespace AnimalFarm {
    public interface IFactory : IFactoryCreate<IEgg>, IFactoryCreate<ICreature> { }
}
