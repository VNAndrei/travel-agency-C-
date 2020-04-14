using Services;
using System;
using System.Collections;
using System.Collections.Generic;

using System.Runtime.Remoting.Channels;
using System.Threading;
using System.Configuration;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;

namespace LaboratorC
{
	public class StartServer
	{
		static void Main(string[] args)
		{
			BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
			serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
			BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
			IDictionary pro= new Hashtable();
			pro["port"] = 55555;
			TcpChannel channel=new TcpChannel(pro,clientProvider,serverProvider);
			ChannelServices.RegisterChannel(channel,false);


			IDictionary<string, string> props = new Dictionary<string, string>();
			props.Add("connectionString", GetConnectionStringByName("excursiiDB"));
			
			IAgentRepository agentRepository = new RepositoryAgent(props);
			IRezervareRepository rezervareRepository = new RepositoryRezervare(props);
			IExcursieRepository excursieRepository = new RepositoryExcursie(props);
			Service s = new Service(agentRepository, excursieRepository, rezervareRepository);
			RemotingServices.Marshal(s,"app");

			// SerialServer server = new SerialServer("127.0.0.1", 55555, s);
			// server.Start();
			Console.WriteLine("Server started ...");

			Console.ReadLine();

		}

		static string GetConnectionStringByName(string name)
		{
			string returnValue = null;

			ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

			// If found, return the connection string.
			if (settings != null)
				returnValue = settings.ConnectionString;

			return returnValue;
		}
	}
}