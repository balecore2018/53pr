using ReportGeneration_Шаповалов.Classes.Common;
using System.Data;

namespace ReportGeneration_Шаповалов.Classes
{
    internal static class ContextTools
    {
        public static DataTable LoadFirst(params string[] tableNames)
        {
            foreach (string tableName in tableNames)
            {
                try
                {
                    return Connection.Select($"SELECT * FROM `{tableName}`");
                }
                catch
                {
                }
            }

            return new DataTable();
        }

        public static DataTable Select(string sql)
        {
            try
            {
                return Connection.Select(sql);
            }
            catch
            {
                return new DataTable();
            }
        }

        public static int IntValue(DataRow row, params string[] names)
        {
            object? value = Value(row, names);
            return value == null || value == DBNull.Value ? 0 : Convert.ToInt32(value);
        }

        public static bool BoolValue(DataRow row, params string[] names)
        {
            object? value = Value(row, names);
            if (value == null || value == DBNull.Value)
            {
                return false;
            }

            return value is bool boolValue ? boolValue : Convert.ToInt32(value) > 0;
        }

        public static DateTime DateValue(DataRow row, params string[] names)
        {
            object? value = Value(row, names);
            return value == null || value == DBNull.Value ? DateTime.Today : Convert.ToDateTime(value);
        }

        public static string StringValue(DataRow row, params string[] names)
        {
            object? value = Value(row, names);
            return value == null || value == DBNull.Value ? string.Empty : value.ToString() ?? string.Empty;
        }

        private static object? Value(DataRow row, params string[] names)
        {
            foreach (string name in names)
            {
                if (row.Table.Columns.Contains(name))
                {
                    return row[name];
                }
            }

            return null;
        }
    }
}
