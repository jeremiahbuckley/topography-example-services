using SvcInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminSvc
{
	public class ManageTopic : IManageTopic
	{
		public string CreateTopic(string name)
		{
			return name + "!";
		}

		public bool DeleteTopic(string name)
		{
			return true;
		}

		public IList<string> GetTopics()
		{
			IList<string> x = new List<string>();
			x.Add("a");
			x.Add("b");
			x.Add("c");
			return x;
		}
	}
}
