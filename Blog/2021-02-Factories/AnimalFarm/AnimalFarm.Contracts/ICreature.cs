namespace AnimalFarm {
    public interface ICreature {

        IFactoryCreate<IEgg> Factory { get; set; }

        IEgg Lay();

    }
}
