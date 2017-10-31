namespace ReportSvc
{
	partial class ProjectInstaller
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.serviceProcessInstaller1 = new System.ServiceProcess.ServiceProcessInstaller();
			this.reportServiceInstaller = new System.ServiceProcess.ServiceInstaller();
			this.adminServiceInstaller = new System.ServiceProcess.ServiceInstaller();
			// 
			// serviceProcessInstaller1
			// 
			this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalService;
			this.serviceProcessInstaller1.Password = null;
			this.serviceProcessInstaller1.Username = null;
			// 
			// reportServiceInstaller
			// 
			this.reportServiceInstaller.DisplayName = "JBReportSvc";
			this.reportServiceInstaller.ServiceName = "ReportSvc";
			// 
			// adminServiceInstaller
			// 
			this.adminServiceInstaller.DisplayName = "JBAdminSvc";
			this.adminServiceInstaller.ServiceName = "AdminSvc";
			// 
			// ProjectInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller1,
            this.reportServiceInstaller,
            this.adminServiceInstaller});

		}

		#endregion

		private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller1;
		private System.ServiceProcess.ServiceInstaller reportServiceInstaller;
		private System.ServiceProcess.ServiceInstaller adminServiceInstaller;
	}
}