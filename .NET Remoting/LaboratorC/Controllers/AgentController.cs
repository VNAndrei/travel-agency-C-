using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Services;

namespace LaboratorC.Controllers
{
	class AgentController :MarshalByRefObject, IObserver
	{

		public event EventHandler<object> updateEvent;
		private readonly IServices server;
		private string username;
		private ApplicationContext appContext;
		private Form loginForm;
		public AgentController(IServices server, string username, ApplicationContext ac, Form form)
		{
			this.server = server;
			this.username = username;
			appContext = ac;
			loginForm = form;
		}

		
		public void updateNrLocuri(object updateDTO)
		{
			if (updateEvent == null) return;
			updateEvent(this, updateDTO);
			Console.WriteLine("Update Event called");
		}


		internal void addRezervare(string numeClient, string numeTuristi, string telefon, int nrLocuri, int eid)
		{
			Rezervare r = new Rezervare(1, numeClient, numeTuristi, telefon, nrLocuri, eid);
			server.addRezervare(r);
		}

		internal IEnumerable<Excursie> findAll()
		{
			return server.findAll();
		}

		internal IEnumerable<Excursie> findByDate(string text, string v1, string v2)
		{
			return server.findByDate(text, v1, v2);
		}

		internal void logout()
		{
			server.logout(username,this);
			appContext.MainForm = this.loginForm;
			appContext.MainForm.Show();
			
		}
	}
}
