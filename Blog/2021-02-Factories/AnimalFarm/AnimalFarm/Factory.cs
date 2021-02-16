namespace AnimalFarm {
    public static class Factory {

        public static IEgg CreateEgg() => new ChickenEgg();

        public static ICreature CreateCreature() => new Chicken();

    }
}
