using System.ComponentModel;

namespace DummyService
{
	[RunInstaller( true )]
	public partial class ProjectInstaller : System.Configuration.Install.Installer
	{
		public ProjectInstaller()
		{
			InitializeComponent();
		}
	}
}
