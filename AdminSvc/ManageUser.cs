using SvcInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSvc
{
	public class ManageUser : IManageUser
	{
		public string CreateUser(string name, bool isEnabled)
		{
			throw new NotImplementedException();
		}

		public bool DeleteUser(string uid)
		{
			throw new NotImplementedException();
		}

		public string EditUserName(string uid, string name)
		{
			throw new NotImplementedException();
		}

		public bool UserEnableDisable(string uid, bool enable)
		{
			throw new NotImplementedException();
		}
	}
}
