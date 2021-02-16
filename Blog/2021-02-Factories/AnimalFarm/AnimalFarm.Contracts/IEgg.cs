namespace AnimalFarm {
    public interface IEgg {

        IFactoryCreate<ICreature> Factory { get; set; }

        ICreature Hatch();

    }
}
