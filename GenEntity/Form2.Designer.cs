namespace GenEntity
{
	partial class Form2
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
			this.txtCode = new System.Windows.Forms.TextBox();
			this.btnSqlCommand = new System.Windows.Forms.Button();
			this.cboTable = new System.Windows.Forms.ComboBox();
			this.btnCopy = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnSqlInsert = new System.Windows.Forms.Button();
			this.btnSqlUpdate = new System.Windows.Forms.Button();
			this.btnSqlDelete = new System.Windows.Forms.Button();
			this.chkPutArray = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// txtCode
			// 
			this.txtCode.Location = new System.Drawing.Point(12, 101);
			this.txtCode.Multiline = true;
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(464, 165);
			this.txtCode.TabIndex = 6;
			// 
			// btnSqlCommand
			// 
			this.btnSqlCommand.Location = new System.Drawing.Point(12, 39);
			this.btnSqlCommand.Name = "btnSqlCommand";
			this.btnSqlCommand.Size = new System.Drawing.Size(80, 23);
			this.btnSqlCommand.TabIndex = 5;
			this.btnSqlCommand.Text = "SqlCommand";
			this.btnSqlCommand.UseVisualStyleBackColor = true;
			this.btnSqlCommand.Click += new System.EventHandler(this.btnSqlCommand_Click);
			// 
			// cboTable
			// 
			this.cboTable.FormattingEnabled = true;
			this.cboTable.Location = new System.Drawing.Point(12, 12);
			this.cboTable.Name = "cboTable";
			this.cboTable.Size = new System.Drawing.Size(150, 20);
			this.cboTable.TabIndex = 4;
			// 
			// btnCopy
			// 
			this.btnCopy.Location = new System.Drawing.Point(400, 77);
			this.btnCopy.Name = "btnCopy";
			this.btnCopy.Size = new System.Drawing.Size(75, 23);
			this.btnCopy.TabIndex = 7;
			this.btnCopy.Text = "Copy";
			this.btnCopy.UseVisualStyleBackColor = true;
			this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
			// 
			// textBox1
			// 
			this.textBox1.Enabled = false;
			this.textBox1.Location = new System.Drawing.Point(12, 76);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(464, 25);
			this.textBox1.TabIndex = 8;
			this.textBox1.Text = "C#";
			// 
			// btnSqlInsert
			// 
			this.btnSqlInsert.Location = new System.Drawing.Point(98, 38);
			this.btnSqlInsert.Name = "btnSqlInsert";
			this.btnSqlInsert.Size = new System.Drawing.Size(64, 23);
			this.btnSqlInsert.TabIndex = 9;
			this.btnSqlInsert.Text = "SqlInsert";
			this.btnSqlInsert.UseVisualStyleBackColor = true;
			this.btnSqlInsert.Click += new System.EventHandler(this.btnSqlInsert_Click);
			// 
			// btnSqlUpdate
			// 
			this.btnSqlUpdate.Location = new System.Drawing.Point(168, 39);
			this.btnSqlUpdate.Name = "btnSqlUpdate";
			this.btnSqlUpdate.Size = new System.Drawing.Size(66, 23);
			this.btnSqlUpdate.TabIndex = 10;
			this.btnSqlUpdate.Text = "SqlUpdate";
			this.btnSqlUpdate.UseVisualStyleBackColor = true;
			this.btnSqlUpdate.Click += new System.EventHandler(this.btnSqlUpdate_Click);
			// 
			// btnSqlDelete
			// 
			this.btnSqlDelete.Location = new System.Drawing.Point(240, 39);
			this.btnSqlDelete.Name = "btnSqlDelete";
			this.btnSqlDelete.Size = new System.Drawing.Size(64, 23);
			this.btnSqlDelete.TabIndex = 11;
			this.btnSqlDelete.Text = "SqlDelete";
			this.btnSqlDelete.UseVisualStyleBackColor = true;
			this.btnSqlDelete.Click += new System.EventHandler(this.btnSqlDelete_Click);
			// 
			// chkPutArray
			// 
			this.chkPutArray.AutoSize = true;
			this.chkPutArray.Checked = true;
			this.chkPutArray.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPutArray.Location = new System.Drawing.Point(329, 45);
			this.chkPutArray.Name = "chkPutArray";
			this.chkPutArray.Size = new System.Drawing.Size(52, 16);
			this.chkPutArray.TabIndex = 12;
			this.chkPutArray.Text = "Array";
			this.chkPutArray.UseVisualStyleBackColor = true;
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(498, 307);
			this.Controls.Add(this.chkPutArray);
			this.Controls.Add(this.btnSqlDelete);
			this.Controls.Add(this.btnSqlUpdate);
			this.Controls.Add(this.btnSqlInsert);
			this.Controls.Add(this.btnCopy);
			this.Controls.Add(this.txtCode);
			this.Controls.Add(this.btnSqlCommand);
			this.Controls.Add(this.cboTable);
			this.Controls.Add(this.textBox1);
			this.Name = "Form2";
			this.Text = "Form2";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox txtCode;
		private System.Windows.Forms.Button btnSqlCommand;
		private System.Windows.Forms.ComboBox cboTable;
		private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnSqlInsert;
		private System.Windows.Forms.Button btnSqlUpdate;
		private System.Windows.Forms.Button btnSqlDelete;
		private System.Windows.Forms.CheckBox chkPutArray;
	}
}