using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Threading;

namespace DummyService
{
	class PollingReader
	{
		public PollingReader( EventLog eventLog )
		{
			_eventLog = eventLog;
			_ints = new List<int>();
		}

		public bool IsRunning { get; private set; }

		public void Start()
		{
			if ( IsRunning ) throw new InvalidOperationException( "Already running" );

			_pollingReader = new Thread( new ThreadStart( Poll ) );
			_pollingReader.Start();
		}

		public void Stop()
		{
			if ( !IsRunning ) throw new InvalidOperationException( "Not running" );

			_pollingReader.Abort();
			_pollingReader.Join();

			IsRunning = false;
		}

		private void Poll()
		{
			IsRunning = true;

			try
			{
				while (true)
				{
					_ints.Add((new Random().Next()));
				}
			}
			catch ( IOException e )
			{
				_eventLog.WriteEntry( e.ToString(), EventLogEntryType.Error );
				throw;
			}
			catch ( ThreadAbortException )
			{
				// Do nothing -- Stop was called
			}
		}

		private EventLog _eventLog;
		private Thread _pollingReader;
		private List<int> _ints;
	}
}
