namespace AnimalFarm {
    public interface IFactory {

        IEgg CreateEgg();

        ICreature CreateCreature();

    }
}
