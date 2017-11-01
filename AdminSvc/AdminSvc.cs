using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AdminSvc
{
	partial class AdminSvc : ServiceBase
	{
		private ServiceHost manageUserServiceHost = null;
		private ServiceHost manageTopicServiceHost = null;
		private ServiceHost runReportServiceHost = null;

		private static LogWriter log;

		internal void TestStartupAndStop(string[] args)
		{
			this.OnStart(args);
			Console.ReadLine();
			this.OnStop();
		}

		public AdminSvc()
		{
			InitializeComponent();
			LogWriterFactory logWriterFactory = new LogWriterFactory();
			log = logWriterFactory.Create();
		}

		protected override void OnStart(string[] args)
		{
			log.Write("Starting AdminSvc", "General");

			if (manageTopicServiceHost != null)
			{
				manageTopicServiceHost.Close();
			}

			if (manageUserServiceHost != null)
			{
				manageUserServiceHost.Close();
			}

			if (runReportServiceHost != null)
			{
				runReportServiceHost.Close();
			}

			manageTopicServiceHost = new ServiceHost(typeof(ManageTopic));
			manageUserServiceHost = new ServiceHost(typeof(ManageUser));
			runReportServiceHost = new ServiceHost(typeof(RunReport));

			manageTopicServiceHost.Open();
			manageUserServiceHost.Open();
			runReportServiceHost.Open();

			log.Write("Completed AdminSvc Start", "General");

		}

		protected override void OnStop()
		{
			if (manageTopicServiceHost != null)
			{
				manageTopicServiceHost.Close();
				manageTopicServiceHost = null;
			}

			if (manageUserServiceHost != null)
			{
				manageUserServiceHost.Close();
				manageUserServiceHost = null;
			}

			if (runReportServiceHost != null)
			{
				runReportServiceHost.Close();
				runReportServiceHost = null;
			}
		}
	}
}
