using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SvcInterfaces
{
	[ServiceContract(Namespace="TopographyAdminSvc")]
	public interface IManageTopic
	{
		[OperationContract]
		string CreateTopic(string name);

		[OperationContract]
		bool DeleteTopic(string name);

		[OperationContract]
		IList<string> GetTopics();
	}
}
