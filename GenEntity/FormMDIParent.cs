using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenEntity
{
	public partial class FormMDIParent : Form
	{
		private string[] arrayConnectionString = new string[4];
		public FormMDIParent()
		{
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
			timer1.Start();
			DbConnect dbConn = new DbConnect();
			try
			{
				dbConn.Open();
				toolStripStatusLabel1.Text = "Server name: " + dbConn.Conn.DataSource + ";Database: " + dbConn.Conn.Database + " ";
				arrayConnectionString[0] = dbConn.Conn.DataSource;
				arrayConnectionString[1] = dbConn.Conn.Database;
				arrayConnectionString[2] = "sa";
				arrayConnectionString[3] = "net123aA@";

			}
			catch (Exception)
			{
			}
			ShowMDIChild("Form1");

		}

		private void ShowMDIChild(string formName)
		{
			Form openForm = GetFormOpen(formName);
			bool bKeepFormOpened = bool.Parse(ConfigurationManager.AppSettings["KeepFormOpened"]);
			HiddenOtherForm(bKeepFormOpened, openForm);
			switch (formName)
			{
				case "Form1":
					Form1 frmForm1 = null;
					if (openForm == null)
					{
						frmForm1 = new Form1();
					}
					else
					{
						frmForm1 = openForm as Form1;
					}

					frmForm1.MdiParent = this;
					frmForm1.WindowState = FormWindowState.Maximized;
					frmForm1.Show();
					break;
				case "Form2":
					Form2 frmForm2 = null;
					if (openForm == null)
					{
						frmForm2 = new Form2();
					}
					else
					{
						frmForm2 = openForm as Form2;
					}

					frmForm2.MdiParent = this;
					frmForm2.WindowState = FormWindowState.Maximized;
					frmForm2.Show();
					break;
				case "Form3":
					Form3 frmForm3 = null;
					if (openForm == null)
					{
						frmForm3 = new Form3();
					}
					else
					{
						frmForm3 = openForm as Form3;
					}

					frmForm3.MdiParent = this;
					frmForm3.WindowState = FormWindowState.Maximized;
					frmForm3.Show();
					break;
				default:
					break;
			}
		}

		private void HiddenOtherForm(bool bKeepFormOpened, Form openForm)
		{
			if (bKeepFormOpened)
			{
				foreach (var item in this.MdiChildren)
				{
					if (openForm == null || !item.Equals(openForm))
					{
						item.WindowState = FormWindowState.Minimized;
						item.Hide();
					}
				}
			}
			else
			{
				foreach (var item in this.MdiChildren)
				{
					if (openForm == null || !item.Equals(openForm))
					{
						item.Dispose();
						item.Close();
					}
				}
			}
		}

		private Form GetFormOpen(string formName)
		{

			foreach (var item in this.MdiChildren)
			{
				if (item.Name == formName)
				{
					return item;
				}
			}
			return null;
		}



		public static void OpenSmss(string command)
		{
			string path = @"C:\Program Files (x86)\Microsoft SQL Server Management Studio 18\Common7\IDE\Ssms.exe";
			//string command = @" ""C:\Users\ANHPT\Documents\SQL Server Management Studio\SQLQuery1.sql""";
			//string command = string.Format(" -S {0} -d {1}  -U {2} -nosplash", arrayConnectionString);
			//string command = string.Format(" -S {0} -d {1}  -U {2}", arrayConnectionString);
			Process[] arrayP = Process.GetProcessesByName("ssms");
			Process p = null;
			if (arrayP.Length > 0)
			{
				p = arrayP[0];
			}
			else
			{
				p = new Process();
			}
			try
			{
				ProcessStartInfo inf = p.StartInfo;
				inf.UseShellExecute = false;
				inf.FileName = path;
				inf.Arguments = command;
				p.Start();
			}
			catch (Exception)
			{
			}
			finally
			{
				p.Dispose();
				p.Close();
			}


		}
		private void FormMDIParent_Load(object sender, EventArgs e)
		{

		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			toolStripStatusLabel2.Text = DateTime.Now.ToLongTimeString();
		}

		private void toolStripStatusLabel1_Click(object sender, EventArgs e)
		{
			try
			{
				OpenSmss("");
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			try
			{
				if (e.ClickedItem.Equals(genEntityToolStripMenuItem))
				{
					ShowMDIChild("Form1");
					return;
				}
				if (e.ClickedItem.Equals(genCommandToolStripMenuItem))
				{
					ShowMDIChild("Form2");
					return;
				}
				if (e.ClickedItem.Equals(clearCacheToolStripMenuItem))
				{
					ShowMDIChild("Form3");
					return;
				}
			}
			catch (Exception)
			{
				throw;
			}

		}
	}
}
