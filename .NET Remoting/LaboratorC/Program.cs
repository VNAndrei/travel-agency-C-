using System;
using System.Collections;
using System.Windows.Forms;
using LaboratorC.Controllers;

using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Services;

namespace LaboratorC
{
	class Program
	{
	[STAThread]
	static void Main()
		{

		
			BinaryServerFormatterSinkProvider serverProvider= new BinaryServerFormatterSinkProvider();
			serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
			BinaryClientFormatterSinkProvider clientProvider= new BinaryClientFormatterSinkProvider();
			IDictionary props = new Hashtable();

			props["port"] = 0;
			TcpChannel channel= new TcpChannel(props,clientProvider,serverProvider);
			ChannelServices.RegisterChannel(channel,false);
			IServices services = (IServices) Activator.GetObject(typeof(IServices), "tcp://localhost:55555/app");

				//Console.ReadLine();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			ApplicationContext applicationContext = new ApplicationContext();
			
			LoginForm login = new LoginForm();
			LoginController lc= new LoginController(services,applicationContext,login);
			login.setController(lc);
			applicationContext.MainForm = login;
			Application.Run(applicationContext);
		}


	}
}
