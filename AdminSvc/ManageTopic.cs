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
			throw new NotImplementedException();
		}

		public bool DeleteTopic(string name)
		{
			throw new NotImplementedException();
		}

		public IList<string> GetTopics()
		{
			throw new NotImplementedException();
		}
	}
}
