using log4net;
using System;
using System.Collections.Generic;
using System.Data.SQLite;


namespace LaboratorC
{
	public class DbUtils
	{
		private static SQLiteConnection connection;
		private IDictionary<string, string> properies;
		//private static readonly ILog logger = LogManager.GetLogger(Type.GetType("DbUtils"));
		
		public DbUtils(IDictionary<string,string> props)
		{
			
			properies = props;
		}
		private SQLiteConnection createConnection () 
		{
			//logger.Info("realizare conexiune...");
			string connString = properies["connectionString"];
			return new SQLiteConnection(connString);
		}
		public SQLiteConnection getConnection()
		{

			try
			{
				if(connection==null)
					connection = createConnection();
					

				
				
			}
			catch(SQLiteException e)
			{
				//logger.Error(e);
			}
			return connection;
		}
	}
}
