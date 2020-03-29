using System.ServiceModel;
using System.ServiceModel.Channels;

namespace ITworks.Brom.SOAP {
	public class BromSoapClient : brom_apiPortTypeClient {
		public BromSoapClient(Binding binding, EndpointAddress remoteAddress) : base(binding, remoteAddress) {
		}
	}
}
