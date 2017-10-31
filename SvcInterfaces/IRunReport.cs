using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SvcInterfaces
{
	[ServiceContract(Namespace = "TopographyAdminSvc")]
	public interface IRunReport
	{
		[OperationContract]
		string RunAllUsersReport(string timeframe);

		[OperationContract]
		string RunAllTopicsReport(string timeframe);
	}
}
