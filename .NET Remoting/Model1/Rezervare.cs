using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	[Serializable]
	public class Rezervare
	{
		public int id { get; set; }
		public string numeClient { get; set; }
		public List<string> numeTuristi { get; set; }
		public string telefon { get; set; }
		public int nrLocuri { get; set; }
		public int eId { get; set; }

		public Rezervare(int id, string numeClient, List<string> numeTuristi, string telefon, int nrLocuri, int eId)
		{
			this.id = id;
			this.numeClient = numeClient;
			this.numeTuristi = numeTuristi;
			this.telefon = telefon;
			this.nrLocuri = nrLocuri;
			this.eId = eId;
		}
		public Rezervare(int id, string numeClient,string numeTuristi, string telefon, int nrLocuri, int eId)
		{
			this.id = id;
			this.numeClient = numeClient;
			this.numeTuristi = numeTuristi.Split(';').ToList();
			this.telefon = telefon;
			this.nrLocuri = nrLocuri;
			this.eId = eId;
		}
		public string getStringTuristi()
		{
			string s = "";
			foreach(var n in numeTuristi)
			{
				s += n + ";";
			}
			return s;
		}
	}
}
