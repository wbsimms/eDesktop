namespace DocumentIndexer
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
			this.IndexerProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
			this.IndexerInstaller = new System.ServiceProcess.ServiceInstaller();
			// 
			// IndexerProcessInstaller
			// 
			this.IndexerProcessInstaller.Password = null;
			this.IndexerProcessInstaller.Username = null;
			// 
			// IndexerInstaller
			// 
			this.IndexerInstaller.ServiceName = "eDocumentsIndexer";
			// 
			// ProjectInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.IndexerProcessInstaller,
            this.IndexerInstaller});

		}

		#endregion

		private System.ServiceProcess.ServiceProcessInstaller IndexerProcessInstaller;
		private System.ServiceProcess.ServiceInstaller IndexerInstaller;
	}
}