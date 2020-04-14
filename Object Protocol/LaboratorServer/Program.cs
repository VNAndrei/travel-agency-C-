using Services;
using System;
using System.Collections.Generic;
using Networking;
using ServerTemplate;
using System.Threading;
using System.Configuration;
namespace LaboratorC
{
	public class StartServer
	{
		static void Main(string[] args)
		{

			IDictionary<string, string> props = new Dictionary<string, string>();
			//props.Add("connectionString", GetConnectionStringByName("excursiiDB"));
			props.Add("connectionString", "Data Source=D:\\Documents\\MPP\\Laborator\\proiectLaboratordb.db;Version=3;");
			IAgentRepository agentRepository = new RepositoryAgent(props);
			IRezervareRepository rezervareRepository = new RepositoryRezervare(props);
			IExcursieRepository excursieRepository = new RepositoryExcursie(props);
			Service s = new Service(agentRepository, excursieRepository, rezervareRepository);

		
			SerialServer server = new SerialServer("127.0.0.1", 55555, s);
			server.Start();
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

	public class SerialServer : ConcurrentServer
	{
		private IServices server;
		private ClientWorker worker;

		public SerialServer(string host, int port, IServices server) : base(host, port)
		{
			this.server = server;
			
		}

		protected override Thread createWorker(System.Net.Sockets.TcpClient client)
		{
			worker = new ClientWorker(server, client);
			return new Thread(new ThreadStart(worker.run));
		}
	}
}