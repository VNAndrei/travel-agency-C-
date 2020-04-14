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
	public class RepositoryRezervare:IRezervareRepository
	{
		private DbUtils dbUtils;
		private static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		private string insertString = "insert into Rezervari(numeClient, numeTuristi, numarTelefon, nrLocuri, eid) values (@numeC,@numeT,@nrT,@nrL,@eid);";

		public RepositoryRezervare(IDictionary<string, string> props)
		{
			dbUtils = new DbUtils(props);
		}

		

		public bool save(Rezervare entity)
		{
			SQLiteConnection connection = dbUtils.getConnection();
			
				try
				{
					connection.Open();
					SQLiteCommand command = new SQLiteCommand(insertString, connection);
					command.Parameters.Add(new SQLiteParameter("numeC", entity.numeClient));
					command.Parameters.Add(new SQLiteParameter("numeT", entity.getStringTuristi()));
					command.Parameters.Add(new SQLiteParameter("nrT", entity.telefon));
					command.Parameters.Add(new SQLiteParameter("nrL", entity.nrLocuri));
					command.Parameters.Add(new SQLiteParameter("eid", entity.eId));


					command.ExecuteNonQuery();
				
				command.Dispose();
				connection.Close();
				}
				catch (Exception e)
				{
					log.Error(e);
					return false;
				}
				
			
			return true;
		}
	}
}
