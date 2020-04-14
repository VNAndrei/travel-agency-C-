using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;

namespace LaboratorC.Controllers
{
	class LoginController
	{
		public IServices server;
		private ApplicationContext appContext;
		private Form form;
		public LoginController(IServices server,ApplicationContext ac,Form form)
		{
			this.server = server;
			appContext = ac;
			this.form = form;
		}

		public void login(string username,string password)
		{
			AgentController agentController= new AgentController(server,username,appContext,form);
			try
			{
				if (server.login(username, password, agentController))
				{
					AgentForm agentForm = new AgentForm(agentController);
					this.appContext.MainForm = agentForm;
					appContext.MainForm.Show();
					form.Hide();
				}
			}
			catch (ServicesException e)
			{
				MessageBox.Show(e.Message);
			}
			
			
		}
	}
}
