namespace AnimalFarm {
    public static class Factory {

        public static IFactory Instance => new InternalFactory();

    }
}
