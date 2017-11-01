using AdminSvc;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ServiceTests
{
	[TestClass]
	public class ManageTopicTests
	{
		private ManageTopic manageTopic;

		[TestInitialize]
		public void Initialize()
		{
			manageTopic = new ManageTopic();
		}
		[TestMethod]
		public void TestCreateTopic()
		{
			int result = -1;
			try {
				result = manageTopic.CreateTopic("foo");
				Assert.IsTrue(result > 0);
			} finally
			{
				if (result > 0)
					manageTopic.DeleteTopic(result);
			}
		}

		[TestMethod]
		public void TestCreateTwoTopics()
		{
			int result = -1;
			int result2 = -1;
			try
			{
				result = manageTopic.CreateTopic("foo");
				result2 = manageTopic.CreateTopic("bar");
				Assert.IsTrue(result > 0);
				Assert.IsTrue(result2 > 0);
				Assert.IsTrue(result2 > result);
			} finally
			{
				try
				{
					if (result > 0)
						manageTopic.DeleteTopic(result);
				} finally
				{
					if (result2 > 0)
						manageTopic.DeleteTopic(result2);
				}
			}
		}

		[TestMethod]
		public void TestReadTopics()
		{
			int result = -1;
			int result2 = -1;
			try
			{
				result = manageTopic.CreateTopic("foo");
				result2 = manageTopic.CreateTopic("bar");
				var topics = manageTopic.GetTopics();
				Assert.IsTrue(topics.Count >= 0);
			}
			finally
			{
				try
				{
					if (result > 0)
						manageTopic.DeleteTopic(result);
				}
				finally
				{
					if (result2 > 0)
						manageTopic.DeleteTopic(result2);
				}
			}
		}

		[TestMethod]
		public void TestDeleteTopics()
		{
			int result = -1;
			try
			{
				var count = manageTopic.GetTopics().Count;
				result = manageTopic.CreateTopic("foo");
				var count2 = manageTopic.GetTopics().Count;
				Assert.AreEqual(count + 1, count2);

				manageTopic.DeleteTopic(result);
				var count3 = manageTopic.GetTopics().Count;
				Assert.AreEqual(count, count3);
			}
			finally
			{
				if (result > 0)
					manageTopic.DeleteTopic(result);
			}
		}
	}
}
