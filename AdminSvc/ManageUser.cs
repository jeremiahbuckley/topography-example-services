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
		private DataLayer dl;
		public ManageUser()
		{
			this.dl = new DataLayer();
		}


		public int CreateUser(string name, bool isEnabled)
		{
			return dl.UserCreate(name, true);
		}

		public bool DeleteUser(int uid)
		{
			try
			{
				dl.UserDelete(uid);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public bool EditUserName(int uid, string name)
		{
			var users = dl.UserRead(uid);
			if (users == null || users.Count == 0)
				return false;
			var user = users[0];

			if (dl.UserUpdate(user.Id, user.Version, name, user.Enabled) < 0)
				return false;

			return true;
		}

		public bool UserEnableDisable(int uid, bool enable)
		{
			var users = dl.UserRead(uid);
			if (users == null || users.Count == 0)
				return false;
			var user = users[0];

			if (dl.UserUpdate(user.Id, user.Version, user.Name, enable) < 0)
				return false;

			return true;
		}

		public IList<User> GetUsers()
		{
			return dl.UserReadAll();
		}
	}
}
