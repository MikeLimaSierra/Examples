using CommunicationModule.Network;

namespace CommunicationModule.UDP {
    public static class Factory {

        public static INetworkDataChannel CreateDataChannel() => new UDPDataChannel();

    }
}
