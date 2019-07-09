using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace GenEntity
{
	public partial class Form1 : Form
	{
		public Form1()
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
				dbConn.Close();
				throw;
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
			sbSQL.AppendLine("       case typ.name 																												");
			sbSQL.AppendLine("          when 'bigint' then 'long'																								");
			sbSQL.AppendLine("          when 'binary' then 'byte[]'																								");
			sbSQL.AppendLine("          when 'bit' then 'bool'																									");
			sbSQL.AppendLine("          when 'char' then 'string'																								");
			sbSQL.AppendLine("          when 'date' then 'DateTime'																								");
			sbSQL.AppendLine("          when 'datetime' then 'DateTime'																							");
			sbSQL.AppendLine("          when 'datetime2' then 'DateTime'																						");
			sbSQL.AppendLine("          when 'datetimeoffset' then 'DateTimeOffset'																				");
			sbSQL.AppendLine("          when 'decimal' then 'decimal'																							");
			sbSQL.AppendLine("          when 'float' then 'double'																								");
			sbSQL.AppendLine("          when 'image' then 'byte[]'																								");
			sbSQL.AppendLine("          when 'int' then 'int'																									");
			sbSQL.AppendLine("          when 'money' then 'decimal'																								");
			sbSQL.AppendLine("          when 'nchar' then 'string'																								");
			sbSQL.AppendLine("          when 'ntext' then 'string'																								");
			sbSQL.AppendLine("          when 'numeric' then 'decimal'																							");
			sbSQL.AppendLine("          when 'nvarchar' then 'string'																							");
			sbSQL.AppendLine("          when 'real' then 'float'																								");
			sbSQL.AppendLine("          when 'smalldatetime' then 'DateTime'																					");
			sbSQL.AppendLine("          when 'smallint' then 'short'																							");
			sbSQL.AppendLine("          when 'smallmoney' then 'decimal'																						");
			sbSQL.AppendLine("          when 'text' then 'string'																								");
			sbSQL.AppendLine("          when 'time' then 'TimeSpan'																								");
			sbSQL.AppendLine("          when 'timestamp' then 'long'																							");
			sbSQL.AppendLine("          when 'tinyint' then 'byte'																								");
			sbSQL.AppendLine("          when 'uniqueidentifier' then 'Guid'																						");
			sbSQL.AppendLine("          when 'varbinary' then 'byte[]'																							");
			sbSQL.AppendLine("          when 'varchar' then 'string'																							");
			sbSQL.AppendLine("          else 'UNKNOWN_' + typ.name																								");
			sbSQL.AppendLine("        end ColumnType,																											");
			sbSQL.AppendLine("        case 																														");
			sbSQL.AppendLine("          when col.is_nullable = 1 and typ.name in ('bigint', 'bit', 'date', 'datetime', 'datetime2'								");
			sbSQL.AppendLine("                              , 'datetimeoffset', 'decimal', 'float', 'int', 'money', 'numeric', 'real', 'smalldatetime'			");
			sbSQL.AppendLine("                               , 'smallint', 'smallmoney', 'time', 'tinyint', 'uniqueidentifier') 								");
			sbSQL.AppendLine("          then '?' 																												");
			sbSQL.AppendLine("        else '' 																													");
			sbSQL.AppendLine("       end NullableSign																											");
			sbSQL.AppendLine("  from sys.columns col																											");
			sbSQL.AppendLine("  join sys.types typ on																											");
			sbSQL.AppendLine("       col.system_type_id = typ.system_type_id AND col.user_type_id = typ.user_type_id											");
			sbSQL.AppendLine("where object_id = @object_id																										");

			return sbSQL.ToString();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (cboTable.SelectedIndex < 0)
			{
				cboTable.Focus();
				return;
			}
			GetColumn();
		}

		private void GetColumn()
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
			}
			catch (Exception)
			{
				dbConn.Close();
				throw;
			}
			StringBuilder sbClass = new StringBuilder();
			sbClass.AppendLine(txtHeader.Text);
			sbClass.AppendLine("{");
			sbClass.AppendLine(string.Format("    public class {0} : 基本クラス", tableName));
			foreach (DataRow item in ds.Tables[0].Rows)
			{
				EntityModel en = new EntityModel()
				{
					TableName = item["TableName"].ToString(),
					ColumnName = item["ColumnName"].ToString(),
					ColumnType = item["ColumnType"].ToString(),
					NullableSign = item["NullableSign"].ToString(),
				};
				sbClass.AppendLine("        /// <summary>");
				sbClass.AppendLine("        /// ");
				sbClass.AppendLine("        /// </summary>");
				sbClass.AppendLine(string.Format("    public {0} {1} {{ get; set; }}", en.ColumnName, en.ColumnType + en.NullableSign));
				sbClass.AppendLine();
			}
			sbClass.AppendLine("    }");
			sbClass.AppendLine("}");

			using (FileStream fs = new FileStream(string.Format(@".\{0}.cs", tableName), FileMode.Create))
			{
				Encoding unicode = Encoding.GetEncoding(932);
				byte[] bs = unicode.GetBytes(sbClass.ToString());
				fs.Write(bs, 0, bs.Length);
			}
			System.Diagnostics.Process.Start(string.Format(@".\{0}.cs", tableName));
		}
		private class EntityModel
		{
			/// <summary>
			/// 
			/// </summary>
			public string TableName { get; set; }
			public string ColumnName { get; set; }
			public string ColumnType { get; set; }
			public string NullableSign { get; set; }
		}
	}
}
