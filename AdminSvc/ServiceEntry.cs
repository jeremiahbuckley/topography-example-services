using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace AdminSvc
{
	public static class ServiceEntry
	{

		private static LogWriter log;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		public static void Main(string[] args)
		{
			if (Environment.UserInteractive)
			{
				AdminSvc asvc = new AdminSvc();
				asvc.TestStartupAndStop(args);
			} else {
				ServiceBase[] ServicesToRun;
				ServicesToRun = new ServiceBase[]
				{
				new AdminSvc()
				};
				ServiceBase.Run(ServicesToRun);
			}
		}
	}
}
