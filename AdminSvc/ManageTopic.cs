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
		private DataLayer dl;
		public ManageTopic()
		{
			this.dl = new DataLayer();
		}

		public int CreateTopic(string name)
		{
			return dl.TopicCreate(name, true);
		}

		public bool DeleteTopic(int id)
		{
			try
			{
				dl.TopicDelete(id);
				return true;
			} catch(Exception ex)
			{
				return false;
			}
		}

		public IList<Topic> GetTopics()
		{
			return dl.TopicReadAll();
		}
	}
}
