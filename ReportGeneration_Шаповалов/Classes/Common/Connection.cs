using MySql.Data.MySqlClient;
using System.Data;

namespace ReportGeneration_Шаповалов.Classes.Common
{
    public static class Connection
    {
        private const string ConnectionString =
            "server=localhost;port=3306;user=root;password=;database=journal;charset=utf8;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public static DataTable Select(string sql)
        {
            using MySqlConnection connection = GetConnection();
            using MySqlCommand command = new MySqlCommand(sql, connection);
            using MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
