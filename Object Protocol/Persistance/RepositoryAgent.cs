using log4net;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorC
{
	public class RepositoryAgent : IAgentRepository
	{	
		private DbUtils dbUtils;
		string findString = "select * from Agenti where user=@user;";
		private static readonly ILog log = LogManager.GetLogger(Type.GetType("RepositoryAgent"));
		public Agent findByUser(string user)
		{
			Agent a = null;
			try
			{
				SQLiteConnection connection = dbUtils.getConnection();
				connection.Open();


					SQLiteCommand command = new SQLiteCommand(findString, connection);
					command.Parameters.Add(new SQLiteParameter("user", user));
					SQLiteDataReader dr = command.ExecuteReader();
					if (dr.HasRows==true)
					{
						dr.Read();

						a = new Agent(dr.GetString(0), dr.GetString(1));
					}
				dr.Close();
				command.Dispose();
				connection.Close();
				
			
			}
			catch (Exception e)
			{
				log.Error(e);
			}
			return a;
		}
				

		public RepositoryAgent(IDictionary<string, string> props)
		{
			dbUtils = new DbUtils(props);
		}

	}
}
