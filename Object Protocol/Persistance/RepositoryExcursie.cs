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
	public class RepositoryExcursie : IExcursieRepository
	{
		private DbUtils dbUtils;
		private static readonly ILog log = LogManager.GetLogger(Type.GetType("RepositoryExcursie"));
		private string selectByDestinationString = "select * from Excursii where destinatie=@dest and data > @start and data < @end";
		private string selectAllString = "select * from Excursii";
		private string updateNrLocuriString = "update Excursii set nrLocuri= nrLocuri-@nr where id =@id";

		public RepositoryExcursie(IDictionary<string, string> props)
		{
			dbUtils = new DbUtils(props);
		}

		public IEnumerable<Excursie> findAll()
		{
			List<Excursie> excursii = new List<Excursie>();
			SQLiteConnection connection = dbUtils.getConnection();
			
				try
				{
					connection.Open();
					SQLiteCommand command = new SQLiteCommand(selectAllString, connection);
					SQLiteDataReader dr = command.ExecuteReader();
					while (dr.Read())
					{
						excursii.Add(new Excursie(dr.GetInt32(0), dr.GetString(1), dr.GetInt64(2), dr.GetString(3), dr.GetInt32(4)));
					}
				dr.Close();
				command.Dispose();
				connection.Close();
				}
				catch (Exception e)
				{
					log.Error(e);
				}
			
			return excursii.AsEnumerable();
		}

		public IEnumerable<Excursie> findByDestinationAndDate(string destinatie, long begin, long end)
		{
			List<Excursie> excursii = new List<Excursie>();
			SQLiteConnection connection = dbUtils.getConnection();
			
				try
				{
					connection.Open();
					SQLiteCommand command = new SQLiteCommand(selectByDestinationString, connection);
					command.Parameters.Add(new SQLiteParameter("dest", destinatie));
					command.Parameters.Add(new SQLiteParameter("start", begin));
					command.Parameters.Add(new SQLiteParameter("end", end));
					SQLiteDataReader dr = command.ExecuteReader();
					
					while (dr.Read())
					{
						excursii.Add(new Excursie(dr.GetInt32(0), dr.GetString(1), dr.GetInt64(2), dr.GetString(3), dr.GetInt32(4)));
					}
				dr.Close();
				command.Dispose();
				connection.Close();

				}
				catch (Exception e)
				{
					log.Error(e);
				}

			
			return excursii.AsEnumerable();
		}

		public void updateNrLocuri(int eid, int nrLocuri)
		{
			SQLiteConnection connection = dbUtils.getConnection();
			
				try
				{
					connection.Open();
					SQLiteCommand command = new SQLiteCommand(updateNrLocuriString, connection);
					command.Parameters.Add(new SQLiteParameter("nr", nrLocuri));
					command.Parameters.Add(new SQLiteParameter("id", eid));

					command.ExecuteNonQuery();

				
				command.Dispose();
				connection.Close();
				}
				catch (Exception e)
				{
					log.Error(e);
				}

			
		}
	}
}
