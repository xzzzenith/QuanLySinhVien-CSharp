using System;
using System.Data.SqlClient;

namespace Paint
{
    public static class DatabaseConfig
    {
        // Chuỗi kết nối theo giáo trình (bổ sung TrustServerCertificate để tương thích SQL Server mới)
        public static string ConnectionString = @"Server=.;Database=DBHocSinh;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static bool TestConnection(out string error)
        {
            error = string.Empty;
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
        }
    }
}
