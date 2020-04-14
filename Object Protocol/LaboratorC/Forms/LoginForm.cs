using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LaboratorC.Controllers;

namespace LaboratorC
{
	public partial class LoginForm : Form
	{
		
		private LoginController controller;
		public LoginForm()
		{
			InitializeComponent();
			
		}

		public void setController(object loginController)
		{
			controller = (LoginController)loginController;
		}

		private void LoginForm_Load(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void loginBtn_Click(object sender, EventArgs e)
		{
			if (userTxt.Text.Equals("") || passwordTxt.Text.Equals(""))
			{
				label4.ForeColor=Color.Red;
			}
			else
			{
				controller.login(userTxt.Text, passwordTxt.Text);
				
			}
			
		}
		

	}
}
