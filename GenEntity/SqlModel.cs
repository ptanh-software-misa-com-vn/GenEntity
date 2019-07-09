using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenEntity
{
	public class SqlModel
	{
		private static Dictionary<string, SqlMappingData> _dicSqlModel;
		public static Dictionary<string, SqlMappingData> DicSqlModel
		{
			get
			{
				if (_dicSqlModel == null)
				{
					_dicSqlModel = GetDicData();
				}
				return _dicSqlModel;
			}
		}

		private static Dictionary<string, SqlMappingData> GetDicData()
		{
			var _dic = new Dictionary<string, SqlMappingData>();
			_dic.Add("bigint", new SqlMappingData()
			{
				SqlServerType = "bigint",
				NetFWType = "Int64",
				SqlDbEnumType = "BigInt",
				SqlDataReaderSqlType = "GetSqlInt64",
				DbEnumType = "Int64",
				SqlDataReaderDbType = "GetInt64",
			});
			_dic.Add("binary", new SqlMappingData()
			{
				SqlServerType = "binary",
				NetFWType = "Byte[]",
				SqlDbEnumType = "VarBinary",
				SqlDataReaderSqlType = "GetSqlBinary",
				DbEnumType = "Binary",
				SqlDataReaderDbType = "GetBytes",
			});
			_dic.Add("bit", new SqlMappingData()
			{
				SqlServerType = "bit",
				NetFWType = "Boolean",
				SqlDbEnumType = "Bit",
				SqlDataReaderSqlType = "GetSqlBoolean",
				DbEnumType = "Boolean",
				SqlDataReaderDbType = "GetBoolean",
			});
			_dic.Add("char", new SqlMappingData()
			{
				SqlServerType = "char",
				NetFWType = "String",
				SqlDbEnumType = "Char",
				SqlDataReaderSqlType = "GetSqlString",
				DbEnumType = "AnsiStringFixedLength,",
				SqlDataReaderDbType = "GetString",
			});
			_dic.Add("date 1", new SqlMappingData()
			{
				SqlServerType = "date 1",
				NetFWType = "DateTime",
				SqlDbEnumType = "Date 1",
				SqlDataReaderSqlType = "GetSqlDateTime",
				DbEnumType = "Date 1",
				SqlDataReaderDbType = "GetDateTime",
			});
			_dic.Add("datetime", new SqlMappingData()
			{
				SqlServerType = "datetime",
				NetFWType = "DateTime",
				SqlDbEnumType = "DateTime",
				SqlDataReaderSqlType = "GetSqlDateTime",
				DbEnumType = "DateTime",
				SqlDataReaderDbType = "GetDateTime",
			});
			_dic.Add("datetime2", new SqlMappingData()
			{
				SqlServerType = "datetime2",
				NetFWType = "DateTime",
				SqlDbEnumType = "DateTime2",
				SqlDataReaderSqlType = "None",
				DbEnumType = "DateTime2",
				SqlDataReaderDbType = "GetDateTime",
			});
			_dic.Add("datetimeoffset", new SqlMappingData()
			{
				SqlServerType = "datetimeoffset",
				NetFWType = "DateTimeOffset",
				SqlDbEnumType = "DateTimeOffset",
				SqlDataReaderSqlType = "none",
				DbEnumType = "DateTimeOffset",
				SqlDataReaderDbType = "GetDateTimeOffset",
			});
			_dic.Add("decimal", new SqlMappingData()
			{
				SqlServerType = "decimal",
				NetFWType = "Decimal",
				SqlDbEnumType = "Decimal",
				SqlDataReaderSqlType = "GetSqlDecimal",
				DbEnumType = "Decimal",
				SqlDataReaderDbType = "GetDecimal",
			});
			_dic.Add("varbinary(max)", new SqlMappingData()
			{
				SqlServerType = "varbinary(max)",
				NetFWType = "Byte[]",
				SqlDbEnumType = "VarBinary",
				SqlDataReaderSqlType = "GetSqlBytes",
				DbEnumType = "Binary",
				SqlDataReaderDbType = "GetBytes",
			});
			_dic.Add("float", new SqlMappingData()
			{
				SqlServerType = "float",
				NetFWType = "Double",
				SqlDbEnumType = "Float",
				SqlDataReaderSqlType = "GetSqlDouble",
				DbEnumType = "Double",
				SqlDataReaderDbType = "GetDouble",
			});
			_dic.Add("image", new SqlMappingData()
			{
				SqlServerType = "image",
				NetFWType = "Byte[]",
				SqlDbEnumType = "Binary",
				SqlDataReaderSqlType = "GetSqlBinary",
				DbEnumType = "Binary",
				SqlDataReaderDbType = "GetBytes",
			});
			_dic.Add("int", new SqlMappingData()
			{
				SqlServerType = "int",
				NetFWType = "Int32",
				SqlDbEnumType = "Int",
				SqlDataReaderSqlType = "GetSqlInt32",
				DbEnumType = "Int32",
				SqlDataReaderDbType = "GetInt32",
			});
			_dic.Add("money", new SqlMappingData()
			{
				SqlServerType = "money",
				NetFWType = "Decimal",
				SqlDbEnumType = "Money",
				SqlDataReaderSqlType = "GetSqlMoney",
				DbEnumType = "Decimal",
				SqlDataReaderDbType = "GetDecimal",
			});
			_dic.Add("nchar", new SqlMappingData()
			{
				SqlServerType = "nchar",
				NetFWType = "String",
				SqlDbEnumType = "NChar",
				SqlDataReaderSqlType = "GetSqlString",
				DbEnumType = "StringFixedLength",
				SqlDataReaderDbType = "GetString",
			});
			_dic.Add("ntext", new SqlMappingData()
			{
				SqlServerType = "ntext",
				NetFWType = "String",
				SqlDbEnumType = "NText",
				SqlDataReaderSqlType = "GetSqlString",
				DbEnumType = "String",
				SqlDataReaderDbType = "GetString",
			});
			_dic.Add("numeric", new SqlMappingData()
			{
				SqlServerType = "numeric",
				NetFWType = "Decimal",
				SqlDbEnumType = "Decimal",
				SqlDataReaderSqlType = "GetSqlDecimal",
				DbEnumType = "Decimal",
				SqlDataReaderDbType = "GetDecimal",
			});
			_dic.Add("nvarchar", new SqlMappingData()
			{
				SqlServerType = "nvarchar",
				NetFWType = "String",
				SqlDbEnumType = "NVarChar",
				SqlDataReaderSqlType = "GetSqlString",
				DbEnumType = "String",
				SqlDataReaderDbType = "GetString",
			});
			_dic.Add("real", new SqlMappingData()
			{
				SqlServerType = "real",
				NetFWType = "Single",
				SqlDbEnumType = "Real",
				SqlDataReaderSqlType = "GetSqlSingle",
				DbEnumType = "Single",
				SqlDataReaderDbType = "GetFloat",
			});
			_dic.Add("rowversion", new SqlMappingData()
			{
				SqlServerType = "rowversion",
				NetFWType = "Byte[]",
				SqlDbEnumType = "Timestamp",
				SqlDataReaderSqlType = "GetSqlBinary",
				DbEnumType = "Binary",
				SqlDataReaderDbType = "GetBytes",
			});
			_dic.Add("smalldatetime", new SqlMappingData()
			{
				SqlServerType = "smalldatetime",
				NetFWType = "DateTime",
				SqlDbEnumType = "DateTime",
				SqlDataReaderSqlType = "GetSqlDateTime",
				DbEnumType = "DateTime",
				SqlDataReaderDbType = "GetDateTime",
			});
			_dic.Add("smallint", new SqlMappingData()
			{
				SqlServerType = "smallint",
				NetFWType = "Int16",
				SqlDbEnumType = "SmallInt",
				SqlDataReaderSqlType = "GetSqlInt16",
				DbEnumType = "Int16",
				SqlDataReaderDbType = "GetInt16",
			});
			_dic.Add("smallmoney", new SqlMappingData()
			{
				SqlServerType = "smallmoney",
				NetFWType = "Decimal",
				SqlDbEnumType = "SmallMoney",
				SqlDataReaderSqlType = "GetSqlMoney",
				DbEnumType = "Decimal",
				SqlDataReaderDbType = "GetDecimal",
			});
			_dic.Add("Sql_variant", new SqlMappingData()
			{
				SqlServerType = "Sql_variant",
				NetFWType = "Object 2",
				SqlDbEnumType = "Variant",
				SqlDataReaderSqlType = "GetSqlValue 2",
				DbEnumType = "Object",
				SqlDataReaderDbType = "GetValue 2",
			});
			_dic.Add("text", new SqlMappingData()
			{
				SqlServerType = "text",
				NetFWType = "String",
				SqlDbEnumType = "Text",
				SqlDataReaderSqlType = "GetSqlString",
				DbEnumType = "String",
				SqlDataReaderDbType = "GetString",
			});
			_dic.Add("time", new SqlMappingData()
			{
				SqlServerType = "time",
				NetFWType = "TimeSpan",
				SqlDbEnumType = "Time",
				SqlDataReaderSqlType = "none",
				DbEnumType = "Time",
				SqlDataReaderDbType = "GetDateTime",
			});
			_dic.Add("timestamp", new SqlMappingData()
			{
				SqlServerType = "timestamp",
				NetFWType = "Byte[]",
				SqlDbEnumType = "Timestamp",
				SqlDataReaderSqlType = "GetSqlBinary",
				DbEnumType = "Binary",
				SqlDataReaderDbType = "GetBytes",
			});
			_dic.Add("tinyint", new SqlMappingData()
			{
				SqlServerType = "tinyint",
				NetFWType = "Byte",
				SqlDbEnumType = "TinyInt",
				SqlDataReaderSqlType = "GetSqlByte",
				DbEnumType = "Byte",
				SqlDataReaderDbType = "GetByte",
			});
			_dic.Add("uniqueidentifier", new SqlMappingData()
			{
				SqlServerType = "uniqueidentifier",
				NetFWType = "Guid",
				SqlDbEnumType = "UniqueIdentifier",
				SqlDataReaderSqlType = "GetSqlGuid",
				DbEnumType = "Guid",
				SqlDataReaderDbType = "GetGuid",
			});
			_dic.Add("varbinary", new SqlMappingData()
			{
				SqlServerType = "varbinary",
				NetFWType = "Byte[]",
				SqlDbEnumType = "VarBinary",
				SqlDataReaderSqlType = "GetSqlBinary",
				DbEnumType = "Binary",
				SqlDataReaderDbType = "GetBytes",
			});
			_dic.Add("varchar", new SqlMappingData()
			{
				SqlServerType = "varchar",
				NetFWType = "String",
				SqlDbEnumType = "VarChar",
				SqlDataReaderSqlType = "GetSqlString",
				DbEnumType = "AnsiString, String",
				SqlDataReaderDbType = "GetString",
			});
			_dic.Add("xml", new SqlMappingData()
			{
				SqlServerType = "xml",
				NetFWType = "Xml",
				SqlDbEnumType = "Xml",
				SqlDataReaderSqlType = "GetSqlXml",
				DbEnumType = "Xml",
				SqlDataReaderDbType = "none",
			});


			return _dic;
		}
	}
}
