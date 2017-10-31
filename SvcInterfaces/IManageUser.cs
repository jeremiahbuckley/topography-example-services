using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SvcInterfaces
{
	[ServiceContract(Namespace = "TopographyAdminSvc")]
	public interface IManageUser
	{
		[OperationContract]
		string EditUserName(string uid, string name);

		[OperationContract]
		bool UserEnableDisable(string uid, bool enable);

		[OperationContract]
		string CreateUser(string name, bool isEnabled);

		[OperationContract]
		bool DeleteUser(string uid);
		
	}
}
