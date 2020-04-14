using Model;
using Services;
using System;
using System.Collections;
using System.Collections.Generic;

namespace LaboratorC
{
	class Service:MarshalByRefObject,IServices
	{
		private IAgentRepository agentRepo;
		private IExcursieRepository excursieRepo;
		private IRezervareRepository rezervareRepo;
		private readonly IDictionary<String, IObserver> loggedClients;
		public Service(IAgentRepository agentRepo, IExcursieRepository excursieRepo, IRezervareRepository rezervareRepo)
		{
			this.agentRepo = agentRepo;
			this.excursieRepo = excursieRepo;
			this.rezervareRepo = rezervareRepo;
			loggedClients = new Dictionary<string, IObserver>();
		}
		public bool login(string username, string password,IObserver user)
		{
			Agent a = agentRepo.findByUser(username);
			if (a != null)
			{
				if (loggedClients.ContainsKey(a.username))
					throw new ServicesException("Userul este deja conectat");
				loggedClients.Add(username, user);
				return true;
			}
			else
				throw new ServicesException("Autentificare esuata");
		}

		public void logout(string username, IObserver user)
		{
			bool localClient = loggedClients.Remove(username);
			if (!localClient)
				throw new ServicesException("User " + user + " is not logged in.");
		}

		public IEnumerable<Excursie> findAll()
		{
			return excursieRepo.findAll();
		}

		public IEnumerable<Excursie> findByDate(string destinatie, string begin, string end)
		{
			DateTime beginDate= DateTime.Parse(begin);
			DateTime endDate= DateTime.Parse(end);

			long b = (long)beginDate.ToUniversalTime().Subtract(
				new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

			long e = (long)endDate.ToUniversalTime().Subtract(
				new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
			return excursieRepo.findByDestinationAndDate(destinatie, b, e);
		}

		public void addRezervare(Rezervare r)
		{
			
			if (rezervareRepo.save(r))
			{
				excursieRepo.updateNrLocuri(r.eId, r.nrLocuri);
				foreach (IObserver client in loggedClients.Values)
				{
					client.updateNrLocuri(new UpdateDTO(r.eId,r.nrLocuri));
				}
			}
		}

		public override object InitializeLifetimeService()
		{
			return null;
		}
	}
}
