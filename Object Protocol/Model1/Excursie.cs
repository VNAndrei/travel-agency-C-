using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Excursie
	{
		public int id { get; set; }
		public string destinatie { get; set; }
		
		public string data { get; set; }

		public string aeroport { get; set; }
		public int nrLocuri{ get; set; }
		
		
		public Excursie(int id, string destinatie, long data, string aeroport, int nrLocuri)
		{
			this.id = id;
			this.destinatie = destinatie;
			this.data = getStringData(data);
			this.aeroport = aeroport;
			this.nrLocuri = nrLocuri;
		}
		public Excursie(int id, string destinatie, string data, string aeroport, int nrLocuri)
		{
			this.id = id;
			this.destinatie = destinatie;
			this.data =data;
			this.aeroport = aeroport;
			this.nrLocuri = nrLocuri;
		}
		public string getStringData(long data1)
		{
			
			DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return start.AddMilliseconds(data1).ToLocalTime().ToString();
		}
		
	}
}
