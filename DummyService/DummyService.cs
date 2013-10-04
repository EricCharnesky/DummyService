using System.Diagnostics;
using System.ServiceProcess;

namespace DummyService
{
	public partial class DummyService : ServiceBase
	{
		public DummyService()
		{
			InitializeComponent();
			if ( !EventLog.SourceExists( "DummyService" ) )
			{
				EventLog.CreateEventSource( "DummyService", "DummyServiceLog" );
			}
			eventLog1.Source = "DummyService";
			eventLog1.Log = "DummyServiceLog";
			_pollingReader = new PollingReader( eventLog1 );
		}

		protected override void OnStart( string[] args )
		{
			eventLog1.WriteEntry( "Service Starting" );
			_pollingReader.Start();

		}

		protected override void OnStop()
		{
			eventLog1.WriteEntry( "Service Stopping" );
			_pollingReader.Stop();
		}

		private PollingReader _pollingReader;
	}
}
