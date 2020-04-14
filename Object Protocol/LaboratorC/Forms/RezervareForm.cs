using LaboratorC.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaboratorC
{
	public partial class RezervareForm : Form
	{
		private AgentController controller;
	
		private int eid;
		public RezervareForm(int eid, object agentController)
		{
			InitializeComponent();
			controller = (AgentController) agentController;
			this.eid = eid;
		}


		private void label5_Click(object sender, EventArgs e)
		{

		}

		private void addRezervareBtn_Click(object sender, EventArgs e)
		{
			if (numeCTXT.Text == "" || telefonTxt.Text == "" || turistiTxt.Text == "")
			{
				MessageBox.Show("introduceti datele");
			}
			else
			{
				controller.addRezervare(numeCTXT.Text, turistiTxt.Text, telefonTxt.Text, int.Parse(locuri.Text), eid);
				
				this.Close();
			}

		}
	}
}
