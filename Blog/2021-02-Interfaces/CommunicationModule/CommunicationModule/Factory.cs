namespace CommunicationModule {
    public static class Factory {

        public static IDataChannel CreateDataChannel() => new DataChannel();

    }
}
