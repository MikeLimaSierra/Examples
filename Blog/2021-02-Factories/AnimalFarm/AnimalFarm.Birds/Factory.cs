namespace AnimalFarm.Birds {
    public static class Factory {

        public static IFactory Chicken => new ChickenFactory();

        public static IFactory Ostrich => new OstrichFactory();

    }
}
