using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace LaboratorC.Controllers
{
	class RezervareController
	{
		public IServices server;
		private ApplicationContext appContext;
		private Form form;


		public RezervareController(IServices service)
		{
			this.server = service;
		}

		internal void addRezervare(string numeClient, string numeTuristi, string telefon, int nrLocuri, int eid)
		{
			Rezervare r = new Rezervare(1, numeClient, numeTuristi, telefon, nrLocuri, eid);
		}
	}
}
