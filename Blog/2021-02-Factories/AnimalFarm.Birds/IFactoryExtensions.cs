namespace AnimalFarm.Birds {
    public static class IFactoryExtensions {

        public static IAnimalFactory Chicken(this IFactory @this) => new ChickenFactory();

        public static IAnimalFactory Ostrich(this IFactory @this) => new OstrichFactory();

    }
}
