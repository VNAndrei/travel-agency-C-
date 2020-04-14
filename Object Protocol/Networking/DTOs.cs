using System;
using System.Collections.Generic;
using System.Text;

namespace Networking
{
	[Serializable]
	public class FilterDTO
	{
		public string Begin { get; }
		public string End { get; }
		public string Destination { get; }
		public FilterDTO(string begin, string end, string destination)
		{
			Begin = begin;
			End = end;
			Destination = destination;
		}

		
	}

	[Serializable]
	public class AgentDTO
	{
		public string User { get; }
		public string Password { get; }

		public AgentDTO(string user, string password)
		{
			User = user;
			Password = password;
		}
	}
	[Serializable]
	public class UpdateDTO
	{
		public UpdateDTO(int eid, int nrLocuri)
		{
			Eid = eid;
			NrLocuri = nrLocuri;
		}

		public int Eid { get; }
		public int NrLocuri { get; }

		
	}
	[Serializable]
	public class ExcursieDTO
	{
	

		public string Aeroport { get; }
		public int Id { get; }
		public string Destinatie { get; }
		public string Data { get; }
		public int NrLocuri { get; }
		public ExcursieDTO( int id, string aeroport, string destinatie, string data,int nrLocuri)
		{
			Aeroport = aeroport;
			Id = id;
			Destinatie = destinatie;
			Data = data;
			NrLocuri = nrLocuri;
		}
	}

	[Serializable]
	public class RezervareDTO
	{
		public int Id { get; }
		public string NumeClient { get; }
		public string NumeTuristi { get; }
		public string Telefon { get; }
		public int NrLocuri { get; }
		public int EId { get; }

		public RezervareDTO(int id, string numeClient, string numeTuristi, string telefon, int nrLocuri, int eId)
		{
			Id = id;
			NumeClient = numeClient;
			NumeTuristi = numeTuristi;
			Telefon = telefon;
			NrLocuri = nrLocuri;
			EId = eId;
		}
	}

}
