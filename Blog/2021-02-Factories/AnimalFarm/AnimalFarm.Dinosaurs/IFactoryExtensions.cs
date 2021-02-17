namespace AnimalFarm.Dinosaurs {
    public static class IFactoryExtensions {

        public static IAnimalFactory TRex(this IFactory @this) => new TRexFactory();

        public static IAnimalFactory Raptor(this IFactory @this) => new RaptorFactory();

    }
}
