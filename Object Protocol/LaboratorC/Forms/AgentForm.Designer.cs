namespace LaboratorC
{
	partial class AgentForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.deleteFilterBtn = new System.Windows.Forms.Button();
			this.openRezervareBtn = new System.Windows.Forms.Button();
			this.filterBtn = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.destinationTxt = new System.Windows.Forms.TextBox();
			this.beginDate = new System.Windows.Forms.DateTimePicker();
			this.endDate = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.logoutBtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// deleteFilterBtn
			// 
			this.deleteFilterBtn.Location = new System.Drawing.Point(450, 378);
			this.deleteFilterBtn.Name = "deleteFilterBtn";
			this.deleteFilterBtn.Size = new System.Drawing.Size(75, 23);
			this.deleteFilterBtn.TabIndex = 1;
			this.deleteFilterBtn.Text = "Sterge Filtru";
			this.deleteFilterBtn.UseVisualStyleBackColor = true;
			this.deleteFilterBtn.Click += new System.EventHandler(this.deleteFilterBtn_Click);
			// 
			// openRezervareBtn
			// 
			this.openRezervareBtn.Location = new System.Drawing.Point(12, 428);
			this.openRezervareBtn.Name = "openRezervareBtn";
			this.openRezervareBtn.Size = new System.Drawing.Size(133, 23);
			this.openRezervareBtn.TabIndex = 2;
			this.openRezervareBtn.Text = "Rezervare noua";
			this.openRezervareBtn.UseVisualStyleBackColor = true;
			this.openRezervareBtn.Click += new System.EventHandler(this.openRezervareBtn_Click);
			// 
			// filterBtn
			// 
			this.filterBtn.Location = new System.Drawing.Point(13, 378);
			this.filterBtn.Name = "filterBtn";
			this.filterBtn.Size = new System.Drawing.Size(75, 23);
			this.filterBtn.TabIndex = 3;
			this.filterBtn.Text = "Filtreaza";
			this.filterBtn.UseVisualStyleBackColor = true;
			this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(13, 22);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.Size = new System.Drawing.Size(512, 288);
			this.dataGridView1.TabIndex = 4;
			// 
			// destinationTxt
			// 
			this.destinationTxt.Location = new System.Drawing.Point(12, 352);
			this.destinationTxt.Name = "destinationTxt";
			this.destinationTxt.Size = new System.Drawing.Size(100, 20);
			this.destinationTxt.TabIndex = 5;
			// 
			// beginDate
			// 
			this.beginDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.beginDate.Location = new System.Drawing.Point(198, 352);
			this.beginDate.Name = "beginDate";
			this.beginDate.Size = new System.Drawing.Size(87, 20);
			this.beginDate.TabIndex = 6;
			// 
			// endDate
			// 
			this.endDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.endDate.Location = new System.Drawing.Point(358, 352);
			this.endDate.Name = "endDate";
			this.endDate.Size = new System.Drawing.Size(87, 20);
			this.endDate.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 333);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Destinatie:";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(198, 333);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Data inceput:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(358, 332);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Data final:";
			// 
			// logoutBtn
			// 
			this.logoutBtn.Location = new System.Drawing.Point(450, 485);
			this.logoutBtn.Name = "logoutBtn";
			this.logoutBtn.Size = new System.Drawing.Size(75, 23);
			this.logoutBtn.TabIndex = 11;
			this.logoutBtn.Text = "logout";
			this.logoutBtn.UseVisualStyleBackColor = true;
			this.logoutBtn.Click += new System.EventHandler(this.logoutBtn_Click);
			// 
			// AgentForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(536, 520);
			this.Controls.Add(this.logoutBtn);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.endDate);
			this.Controls.Add(this.beginDate);
			this.Controls.Add(this.destinationTxt);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.filterBtn);
			this.Controls.Add(this.openRezervareBtn);
			this.Controls.Add(this.deleteFilterBtn);
			this.Name = "AgentForm";
			this.Text = "AgentForm";
			this.Load += new System.EventHandler(this.AgentForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button deleteFilterBtn;
		private System.Windows.Forms.Button openRezervareBtn;
		private System.Windows.Forms.Button filterBtn;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.TextBox destinationTxt;
		private System.Windows.Forms.DateTimePicker beginDate;
		private System.Windows.Forms.DateTimePicker endDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button logoutBtn;
	}
}