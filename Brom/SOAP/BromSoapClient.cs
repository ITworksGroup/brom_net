using System.ServiceModel;
using System.ServiceModel.Channels;

namespace ITworks.Brom.SOAP {
	public class BromSoapClient : brom_apiPortTypeClient {
		public BromSoapClient(EndpointConfiguration endpointConfiguration) : base(endpointConfiguration) {
		}

		public BromSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : base(endpointConfiguration, remoteAddress) {
		}

		public BromSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress) {
		}
	}
}
