namespace AnimalFarm {
    public interface IAnimalFactory : IFactoryCreate<IEgg>, IFactoryCreate<ICreature> { }
}
