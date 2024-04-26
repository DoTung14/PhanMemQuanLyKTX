using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhanMemQuanLyKTX
{
    public static class KetNoiDB
    {
        private static SqlConnection conn;

        public static string GetConnectionString()
        {
            return "Server=DESKTOP-QKB88I1\\SQLEXPRESS;Database=KTX_CDKTKTVP;Integrated Security=True";
        }

        public static bool DBConnect(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                return true; // Trả về true nếu kết nối thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu. Chi tiết lỗi: " + ex.Message, "Lỗi Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Trả về false nếu kết nối không thành công
            }
        }

        public static void DBDisconnect()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }

        public static DataTable GetData(string query)
        {
            if (!DBConnect(GetConnectionString()))
            {
                return null;
            }

            DataTable dataTable = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dataTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dữ liệu từ cơ sở dữ liệu: " + ex.Message);
            }
            finally
            {
                DBDisconnect();
            }
            return dataTable;
        }

        public static void ExecuteQuery(string query)
        {
            if (!DBConnect(GetConnectionString()))
            {
                return;
            }

            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực thi truy vấn: " + ex.Message);
            }
            finally
            {
                DBDisconnect();
            }
        }

        public static string ExecuteScalar(string query, SqlParameter[] parameters)
        {
            if (!DBConnect(GetConnectionString()))
            {
                return null;
            }

            string result = null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(parameters);
                result = cmd.ExecuteScalar()?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực thi truy vấn: " + ex.Message);
            }
            finally
            {
                DBDisconnect();
            }
            return result;
        }

        public static SqlDataReader ExecuteReader(string query)
        {
            if (!DBConnect(GetConnectionString()))
            {
                return null;
            }

            SqlDataReader reader = null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thực thi truy vấn: " + ex.Message);
            }
            return reader;
        }
    }
}

