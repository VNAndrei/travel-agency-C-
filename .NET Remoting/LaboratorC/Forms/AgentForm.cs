using LaboratorC.Controllers;
using Model;
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
	public partial class AgentForm : Form
	{
	
		private AgentController agentController;

	
		public AgentForm(object agentController)
		{
			InitializeComponent();
			this.agentController = (AgentController) agentController;
			this.agentController.updateEvent += userUpdate;
		}

		public void userUpdate(object sender, object e)
		{
			
			dataGridView1.BeginInvoke(new UpdateTable(this.updateTable), new object[] {dataGridView1,(UpdateDTO) e});

		}

		public delegate void UpdateTable(DataGridView gv,UpdateDTO newData);

		private void updateTable(DataGridView gv,UpdateDTO upd)
		{
			foreach (DataGridViewRow row in gv.Rows)
			{
				if (((int)row.Cells[0].Value) == upd.Eid)
				{
					int old = (int) row.Cells[4].Value;
					row.Cells[4].Value = old - upd.NrLocuri;
				}
					
			}
		}
		private void AgentForm_Load(object sender, EventArgs e)
		{
			dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			dataGridView1.MultiSelect = false;
			reloadTable(agentController.findAll());
			
		}


		private void openRezervareBtn_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows[0] == null)
			{
				MessageBox.Show("selectati excursie");

			}
			else
			{
				
				RezervareForm rezervare = new RezervareForm(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()),agentController);
			
				rezervare.Show();

			}
			
		}
		private void reloadTable(IEnumerable<Excursie> excursii)
		{
			dataGridView1.DataSource = excursii.ToList();
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void deleteFilterBtn_Click(object sender, EventArgs e)
		{
			reloadTable(agentController.findAll());
			
		}

		private void filterBtn_Click(object sender, EventArgs e)
		{
			if (destinationTxt.Text == "")
			{
				MessageBox.Show("Introduceti destinatie");


			}
			else
			{
				reloadTable(agentController.findByDate(destinationTxt.Text, beginDate.Value.ToString(), endDate.Value.ToString()));
			}
		}

		private void logoutBtn_Click(object sender, EventArgs e)
		{
			agentController.logout();
			this.Close();
		}
	}
}
