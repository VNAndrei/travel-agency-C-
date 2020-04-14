namespace LaboratorC
{
	partial class RezervareForm
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
			this.addRezervareBtn = new System.Windows.Forms.Button();
			this.locuri = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.numeCTXT = new System.Windows.Forms.TextBox();
			this.telefonTxt = new System.Windows.Forms.TextBox();
			this.turistiTxt = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.locuri)).BeginInit();
			this.SuspendLayout();
			// 
			// addRezervareBtn
			// 
			this.addRezervareBtn.Location = new System.Drawing.Point(12, 376);
			this.addRezervareBtn.Name = "addRezervareBtn";
			this.addRezervareBtn.Size = new System.Drawing.Size(128, 23);
			this.addRezervareBtn.TabIndex = 0;
			this.addRezervareBtn.Text = "Adauga Rezervare";
			this.addRezervareBtn.UseVisualStyleBackColor = true;
			this.addRezervareBtn.Click += new System.EventHandler(this.addRezervareBtn_Click);
			// 
			// locuri
			// 
			this.locuri.Location = new System.Drawing.Point(98, 298);
			this.locuri.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.locuri.Name = "locuri";
			this.locuri.Size = new System.Drawing.Size(120, 20);
			this.locuri.TabIndex = 1;
			this.locuri.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 105);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Nume Client:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 145);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Telefon:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 189);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Nume turisti*:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 300);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Numar locuri:";
			// 
			// numeCTXT
			// 
			this.numeCTXT.Location = new System.Drawing.Point(98, 102);
			this.numeCTXT.Name = "numeCTXT";
			this.numeCTXT.Size = new System.Drawing.Size(151, 20);
			this.numeCTXT.TabIndex = 6;
			// 
			// telefonTxt
			// 
			this.telefonTxt.Location = new System.Drawing.Point(98, 142);
			this.telefonTxt.Name = "telefonTxt";
			this.telefonTxt.Size = new System.Drawing.Size(148, 20);
			this.telefonTxt.TabIndex = 7;
			// 
			// turistiTxt
			// 
			this.turistiTxt.Location = new System.Drawing.Point(98, 186);
			this.turistiTxt.Multiline = true;
			this.turistiTxt.Name = "turistiTxt";
			this.turistiTxt.Size = new System.Drawing.Size(151, 65);
			this.turistiTxt.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 428);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(210, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "*Introduceti numele turistilor separate prin \';\'";
			this.label5.Click += new System.EventHandler(this.label5_Click);
			// 
			// RezervareForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(412, 450);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.turistiTxt);
			this.Controls.Add(this.telefonTxt);
			this.Controls.Add(this.numeCTXT);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.locuri);
			this.Controls.Add(this.addRezervareBtn);
			this.Name = "RezervareForm";
			this.Text = "RezervareForm";
			((System.ComponentModel.ISupportInitialize)(this.locuri)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button addRezervareBtn;
		private System.Windows.Forms.NumericUpDown locuri;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox numeCTXT;
		private System.Windows.Forms.TextBox telefonTxt;
		private System.Windows.Forms.TextBox turistiTxt;
		private System.Windows.Forms.Label label5;
	}
}