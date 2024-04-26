using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PhanMemQuanLyKTX
{
    public partial class Form1 : Form
    {
        private string defaultPassword = "default";

        public Form1()
        {
            InitializeComponent();
        }
        //Kết nối đến KetNoiDB
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            string connectionString = KetNoiDB.GetConnectionString();
            KetNoiDB.DBConnect(connectionString);
        }
        private void Form1_Load(object sender, EventArgs e)
        { 
          

            tPass.KeyPress += tPass_KeyPress;
            tPass.PasswordChar = '\0'; // Hiển thị văn bản thay vì dấu '*' trong TextBox mật khẩu
            tPass.TextChanged += tPass_TextChanged;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        { // Kiểm tra chuỗi văn bản nhập vào password chứa ký hiệu '*'
            if (tPass.PasswordChar == '*')
            {
                // Hiển thị mật khẩu bằng cách đặt PasswordChar thành '\0'
                tPass.PasswordChar = '\0';
            }
            else
            {
                // Nếu không, ẩn mật khẩu bằng cách đặt PasswordChar thành '*'
                tPass.PasswordChar = '*';
            }
        }

        private void tPass_TextChanged(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2TextBox textBox = (Guna.UI2.WinForms.Guna2TextBox)sender;

            // Kiểm tra nếu TextBox mật khẩu đang chứa văn bản mặc định
            if (textBox.Text == defaultPassword)
            {
                // Thiết lập mật khẩu hiển thị dạng plaintext
                textBox.PasswordChar = '\0';
            }
            else
            {
                // Thiết lập mật khẩu hiển thị dạng '*' khi có mật khẩu thực tế
                textBox.PasswordChar = '*';
            }
        }

        private void tPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                bDangNhap_Click(sender, e);
            }
        }


        private void bDangNhap_Click(object sender, EventArgs e)
        {
            string username = tUser.Text;
            string password = tPass.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng kiểm tra lại tên đăng nhập và mật khẩu.");
                return;
            }

            if (username == "admin" && password == "admin")
            {
                MessageBox.Show("Bạn đang đăng nhập bằng tài khoản admin!");
                this.Hide();
                // Hiển thị Form2
                Menu form2 = new Menu();
                form2.Show();
                return;
            }

            string query = "SELECT hovaten FROM DangNhap WHERE username = @username COLLATE SQL_Latin1_General_CP1_CS_AS AND password = @password COLLATE SQL_Latin1_General_CP1_CS_AS";
            SqlParameter[] parameters =
            {
    new SqlParameter("@username", username),
    new SqlParameter("@password", password)
};

            string hoVaTen = KetNoiDB.ExecuteScalar(query, parameters);


            if (!string.IsNullOrEmpty(hoVaTen))
            {
                //  MessageBox.Show("Đăng nhập thành công! Chào bạn, " + hoVaTen + "!");
                this.Hide();
                Menu form2 = new Menu();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.");
                tUser.Clear();
                tPass.Clear();
            }
        }
    }
}