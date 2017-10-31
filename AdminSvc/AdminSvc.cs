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

		///// <summary>
		///// The main entry point for the application.
		///// </summary>
		//static void Main(string[] args)
		//{
		//	Console.WriteLine("hi");
		//	Console.ReadLine();
		//	if (Environment.UserInteractive)
		//	{
		//		AdminSvc asvc = new AdminSvc();
		//		asvc.TestStartupAndStop(args);
		//	}
		//	ServiceBase[] ServicesToRun;
		//	ServicesToRun = new ServiceBase[]
		//	{
		//		new AdminSvc()
		//	};
		//	ServiceBase.Run(ServicesToRun);
		//}

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

			if (manageUserServiceHost != null)
			{
				manageUserServiceHost.Close();
			}

			if (manageTopicServiceHost != null)
			{
				manageTopicServiceHost.Close();
			}

			if (runReportServiceHost != null)
			{
				runReportServiceHost.Close();
			}

			manageUserServiceHost = new ServiceHost(typeof(ManageUser));
			manageTopicServiceHost = new ServiceHost(typeof(ManageTopic));
			runReportServiceHost = new ServiceHost(typeof(RunReport));

			manageUserServiceHost.Open();
			manageTopicServiceHost.Open();
			runReportServiceHost.Open();

			log.Write("Completed AdminSvc Start", "General");

		}

		protected override void OnStop()
		{
			if (manageUserServiceHost != null)
			{
				manageUserServiceHost.Close();
				manageUserServiceHost = null;
			}

			if (manageTopicServiceHost != null)
			{
				manageTopicServiceHost.Close();
				manageTopicServiceHost = null;
			}

			if (runReportServiceHost != null)
			{
				runReportServiceHost.Close();
				runReportServiceHost = null;
			}
		}
	}
}
