using System;
using System.Windows.Forms;
using LaboratorC.Controllers;
using Networking;

namespace LaboratorC
{
	class Program
	{
	[STAThread]
	static void Main()
		{

		
		
			
			//Console.ReadLine();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			ApplicationContext applicationContext = new ApplicationContext();
			ServerProxy server= new ServerProxy("127.0.0.1",55555);
			LoginForm login = new LoginForm();
			LoginController lc= new LoginController(server,applicationContext,login);
			login.setController(lc);
			applicationContext.MainForm = login;
			Application.Run(applicationContext);
		}


	}
}
