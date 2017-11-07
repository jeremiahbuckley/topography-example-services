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
		bool EditUserName(int uid, string name);

		[OperationContract]
		bool UserEnableDisable(int uid, bool enable);

		[OperationContract]
		int CreateUser(string name, bool isEnabled);

		[OperationContract]
		bool DeleteUser(int uid);

		[OperationContract]
		IList<User> GetUsers();
	}
}
