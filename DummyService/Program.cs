using System.ServiceProcess;

namespace DummyService
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
			ServiceBase[] ServicesToRun;
			ServicesToRun = new ServiceBase[] 
            { 
                new DummyService() 
            };
			ServiceBase.Run( ServicesToRun );
		}
	}
}
