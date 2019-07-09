using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenEntity
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
			SetSourceComboTable();
		}

		private void SetSourceComboTable()
		{
			DataSet ds = new DataSet();
			DbConnect dbConn = new DbConnect();
			try
			{
				dbConn.Open();
				string sSQL = GetTableSQL();
				SqlCommand cmd = new SqlCommand(sSQL, dbConn.Conn);
				SqlDataAdapter adapt = new SqlDataAdapter(cmd);
				adapt.Fill(ds);
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				dbConn.Close();
			}
			cboTable.DataSource = ds.Tables[0];
			cboTable.DisplayMember = "TableName";
			cboTable.ValueMember = "ObjectID";
		}

		private string GetTableSQL()
		{
			StringBuilder sbSQL = new StringBuilder();
			sbSQL.AppendLine("Select name      AS TableName  ");
			sbSQL.AppendLine("     , object_id AS ObjectID   ");
			sbSQL.AppendLine("  From sys.tables				 ");
			return sbSQL.ToString();
		}

		private string GetColumnSQL()
		{
			StringBuilder sbSQL = new StringBuilder();
			sbSQL.AppendLine("select @table_name TableName,																										");
			sbSQL.AppendLine("	     col.name ColumnName,																										");
			sbSQL.AppendLine("       column_id ColumnId,																										");
			sbSQL.AppendLine("       typ.name as SqlServerType, 																								");
			sbSQL.AppendLine("       case typ.name 																												");
			sbSQL.AppendLine("          when 'bigint' then 'l'																									");
			sbSQL.AppendLine("          when 'binary' then 'byte'																								");
			sbSQL.AppendLine("          when 'bit' then 'b'																										");
			sbSQL.AppendLine("          when 'char' then 's'																									");
			sbSQL.AppendLine("          when 'date' then 'dtime'																								");
			sbSQL.AppendLine("          when 'datetime' then 'dtime'																							");
			sbSQL.AppendLine("          when 'datetime2' then 'dtime'																							");
			sbSQL.AppendLine("          when 'datetimeoffset' then 'dtimeOffset'																				");
			sbSQL.AppendLine("          when 'decimal' then 'dec'																								");
			sbSQL.AppendLine("          when 'float' then 'f'																									");
			sbSQL.AppendLine("          when 'image' then 'arraybyte'																							");
			sbSQL.AppendLine("          when 'int' then 'i'																										");
			sbSQL.AppendLine("          when 'money' then 'dec'																									");
			sbSQL.AppendLine("          when 'nchar' then 's'																									");
			sbSQL.AppendLine("          when 'ntext' then 's'																									");
			sbSQL.AppendLine("          when 'numeric' then 'dec'																								");
			sbSQL.AppendLine("          when 'nvarchar' then 's'																								");
			sbSQL.AppendLine("          when 'real' then 'f'																									");
			sbSQL.AppendLine("          when 'smalldatetime' then 'dtime'																						");
			sbSQL.AppendLine("          when 'smallint' then 'i'																								");
			sbSQL.AppendLine("          when 'smallmoney' then 'dec'																							");
			sbSQL.AppendLine("          when 'text' then 's'																									");
			sbSQL.AppendLine("          when 'time' then 'timespan'																								");
			sbSQL.AppendLine("          when 'timestamp' then 'l'																								");
			sbSQL.AppendLine("          when 'tinyint' then 'byte'																								");
			sbSQL.AppendLine("          when 'uniqueidentifier' then 'unique'																					");
			sbSQL.AppendLine("          when 'varbinary' then 'arrayBin'																						");
			sbSQL.AppendLine("          when 'varchar' then 's'																									");
			sbSQL.AppendLine("          else 'obj'																												");
			sbSQL.AppendLine("        end ColPrefix 																											");
			sbSQL.AppendLine("  from sys.columns col																											");
			sbSQL.AppendLine("  join sys.types typ on																											");
			sbSQL.AppendLine("       col.system_type_id = typ.system_type_id AND col.user_type_id = typ.user_type_id											");
			sbSQL.AppendLine("where object_id = @object_id																										");

			return sbSQL.ToString();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private DataSet GetColumn()
		{
			DataRowView drv = cboTable.SelectedItem as DataRowView;
			string tableName = drv.Row["TableName"].ToString();
			int objectID = int.Parse(drv.Row["ObjectID"].ToString());
			DataSet ds = new DataSet();
			DbConnect dbConn = new DbConnect();
			try
			{
				dbConn.Open();
				string sSQL = GetColumnSQL();
				SqlCommand cmd = new SqlCommand(sSQL, dbConn.Conn);
				cmd.Parameters.Add("@table_name", SqlDbType.NVarChar).Value = tableName;
				cmd.Parameters.Add("@object_id", SqlDbType.Int).Value = objectID;
				SqlDataAdapter adapt = new SqlDataAdapter(cmd);
				adapt.Fill(ds);
				ds.Tables[0].TableName = tableName;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				dbConn.Close();
			}
			return ds;
		}

		private void GetCommandColumn()
		{
			DataSet ds = GetColumn();
			StringBuilder sbClass = new StringBuilder();
			sbClass.AppendLine("SqlCommand cmd = new SqlCommand(sSQL, adbConn.Conn);");
			foreach (DataRow item in ds.Tables[0].Rows)
			{
				EntityModel en = new EntityModel()
				{
					TableName = item["TableName"].ToString(),
					ColumnName = item["ColumnName"].ToString(),
					SqlServerType = item["SqlServerType"].ToString(),
					ColPrefix = item["ColPrefix"].ToString(),
				};
				SqlMappingData tmp = null;
				SqlModel.DicSqlModel.TryGetValue(en.SqlServerType, out tmp);
				en.SqlMappingData = tmp;

				sbClass.AppendLine(string.Format(@"cmd.Parameters.Add(""@{0}"", SqlDbType.{1}).Value = {2};", en.ColumnName, en.SqlMappingData.SqlDbEnumType, en.ColPrefix + en.ColumnName));
			}
			txtCode.Text = sbClass.ToString();
		}

		private class EntityModel
		{
			/// <summary>
			/// 
			/// </summary>
			public string TableName { get; set; }
			public string ColumnName { get; set; }
			public string SqlServerType { get; set; }
			public string ColPrefix { get; set; }
			public SqlMappingData SqlMappingData { get; set; }
		}

		private void btnCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetDataObject(txtCode.Text);
		}

		private void btnSqlCommand_Click(object sender, EventArgs e)
		{
			if (cboTable.SelectedIndex < 0)
			{
				cboTable.Focus();
				return;
			}
			GetCommandColumn();
		}

		private void btnSqlInsert_Click(object sender, EventArgs e)
		{
			try
			{
				if (cboTable.SelectedIndex < 0)
				{
					cboTable.Focus();
					return;
				}
				GetInsertColumn();
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void GetInsertColumn()
		{
			DataSet ds = GetColumn();
			StringBuilder sbClass = new StringBuilder();
			sbClass.AppendLine("StringBuilder sbSQL = new StringBuilder();");
			sbClass.AppendLine(string.Format(@"sbSQL.AppendLine(""INSERT INTO {0}{1}"");", ds.Tables[0].TableName, new string('\t', 10)));
			sbClass.AppendLine(string.Format(@"sbSQL.AppendLine(""       {{{0}"");", new string('\t', 10)));
			var iCnt = 0;
			foreach (DataRow item in ds.Tables[0].Rows)
			{
				EntityModel en = new EntityModel()
				{
					TableName = item["TableName"].ToString(),
					ColumnName = item["ColumnName"].ToString(),
					SqlServerType = item["SqlServerType"].ToString(),
					ColPrefix = item["ColPrefix"].ToString(),
				};
				SqlMappingData tmp = null;
				SqlModel.DicSqlModel.TryGetValue(en.SqlServerType, out tmp);
				en.SqlMappingData = tmp;

				sbClass.AppendLine(string.Format(@"sbSQL.AppendLine(""       {0}{1}{2}"");", en.ColumnName, iCnt == ds.Tables[0].Rows.Count - 1 ? "" : ",", new string('\t', 10)));
				iCnt++;
			}
			sbClass.AppendLine(string.Format(@"sbSQL.AppendLine(""       }} VALUES{0}"");" ,new string('\t',10)));
			sbClass.AppendLine(string.Format(@"sbSQL.AppendLine(""       {{{0}"");", new string('\t', 10)));
			iCnt = 0;
			foreach (DataRow item in ds.Tables[0].Rows)
			{
				EntityModel en = new EntityModel()
				{
					TableName = item["TableName"].ToString(),
					ColumnName = item["ColumnName"].ToString(),
					SqlServerType = item["SqlServerType"].ToString(),
					ColPrefix = item["ColPrefix"].ToString(),
				};
				SqlMappingData tmp = null;
				SqlModel.DicSqlModel.TryGetValue(en.SqlServerType, out tmp);
				en.SqlMappingData = tmp;

				sbClass.AppendLine(string.Format(@"sbSQL.AppendLine(""       :{0}{1}{2}"");", en.ColumnName, iCnt == ds.Tables[0].Rows.Count - 1 ? "" : ",", new string('\t', 10)));
				iCnt++;
			}
			sbClass.AppendLine(string.Format(@"sbSQL.AppendLine(""       }}{0}"");", new string('\t', 10)));
			txtCode.Text = sbClass.ToString();
		}

		private void btnSqlUpdate_Click(object sender, EventArgs e)
		{
			try
			{
				if (cboTable.SelectedIndex < 0)
				{
					cboTable.Focus();
					return;
				}
				GetUpdateColumn();
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void GetUpdateColumn()
		{
			DataSet ds = GetColumn();
			StringBuilder sbClass = new StringBuilder();
			sbClass.AppendLine("SqlCommand cmd = new SqlCommand(sSQL, adbConn.Conn);");
			foreach (DataRow item in ds.Tables[0].Rows)
			{
				EntityModel en = new EntityModel()
				{
					TableName = item["TableName"].ToString(),
					ColumnName = item["ColumnName"].ToString(),
					SqlServerType = item["SqlServerType"].ToString(),
					ColPrefix = item["ColPrefix"].ToString(),
				};
				SqlMappingData tmp = null;
				SqlModel.DicSqlModel.TryGetValue(en.SqlServerType, out tmp);
				en.SqlMappingData = tmp;

				sbClass.AppendLine(string.Format(@"cmd.Parameters.Add(""@{0}"", SqlDbType.{1}).Value = {2};", en.ColumnName, en.SqlMappingData.SqlDbEnumType, en.ColPrefix + en.ColumnName));
			}
			txtCode.Text = sbClass.ToString();
		}

		private void btnSqlDelete_Click(object sender, EventArgs e)
		{
			try
			{
				if (cboTable.SelectedIndex < 0)
				{
					cboTable.Focus();
					return;
				}
				GetDeleteColumn();
			}
			catch (Exception)
			{

				throw;
			}
		}

		private void GetDeleteColumn()
		{
			DataSet ds = GetColumn();
			StringBuilder sbClass = new StringBuilder();
			sbClass.AppendLine("SqlCommand cmd = new SqlCommand(sSQL, adbConn.Conn);");
			foreach (DataRow item in ds.Tables[0].Rows)
			{
				EntityModel en = new EntityModel()
				{
					TableName = item["TableName"].ToString(),
					ColumnName = item["ColumnName"].ToString(),
					SqlServerType = item["SqlServerType"].ToString(),
					ColPrefix = item["ColPrefix"].ToString(),
				};
				SqlMappingData tmp = null;
				SqlModel.DicSqlModel.TryGetValue(en.SqlServerType, out tmp);
				en.SqlMappingData = tmp;

				sbClass.AppendLine(string.Format(@"cmd.Parameters.Add(""@{0}"", SqlDbType.{1}).Value = {2};", en.ColumnName, en.SqlMappingData.SqlDbEnumType, en.ColPrefix + en.ColumnName));
			}
			txtCode.Text = sbClass.ToString();



		}
	}
}
