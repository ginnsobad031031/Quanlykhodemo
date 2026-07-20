using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanlyKhodemo.DAL
{
    public class DatabaseConnection
    {
        private static string _connectionString;

        static DatabaseConnection()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["QuanlyKhoConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new Exception("Connection string not found in App.config");
            }
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database query error: " + ex.Message);
            }
            return dt;
        }

        public static bool ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Database execute error: " + ex.Message);
            }
        }

        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        return cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database scalar error: " + ex.Message);
            }
        }
    }
}
