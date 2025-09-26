using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace telebip_erp
{
    public static class DatabaseHelper
    {
        // Pega a string de conexão do App.config
        private static readonly string connString = ConfigurationManager
            .ConnectionStrings["SQLiteConn"].ConnectionString;

        // Retorna uma conexão aberta
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connString);
        }

        // Executa SELECT e retorna um DataTable
        public static DataTable ExecuteQuery(string sql, SQLiteParameter[]? parameters = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    using (var adapter = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        // Executa INSERT, UPDATE, DELETE
        public static int ExecuteNonQuery(string sql, SQLiteParameter[]? parameters = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // Executa um SELECT que retorna apenas um valor
        public static object? ExecuteScalar(string sql, SQLiteParameter[]? parameters = null)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);

                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}

