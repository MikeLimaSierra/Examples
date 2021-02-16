using CommunicationModule.Network;

namespace CommunicationModule.TCP {
    public static class Factory {

        public static INetworkDataChannel CreateDataChannel() => new TCPDataChannel();
  
    }
}
