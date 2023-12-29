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
namespace Sachtest
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string connectionString = "Data Source=ACER;Initial Catalog=QLNS3;Integrated Security=True";
     
      

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string taiKhoan = textBox1.Text;
            string matKhau = textBox2.Text;

            if (DangNhapAdmin(taiKhoan, matKhau))
            {
                // Đăng nhập thành công
                this.Hide();
                Form1 a = new Form1();
                Form2 FDangnhap = new Form2();
                a.Closed += (s, args) => this.Close();
                FDangnhap.Show();
            }
            else
            {
                // Đăng nhập thất bại
                MessageBox.Show("Tài Khoản Hoặc Mật Khẩu Không Đúng !!");
            }
        }

        bool DangNhapAdmin(string taiKhoan, string matKhau)
        {
            try
            {
                // Kiểm tra xem connection có được khởi tạo chưa
                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM TAIKHOANADMIN WHERE TAIKHOAN = @TaiKhoan AND MATKHAU = @MatKhau;";

                // Sử dụng Parameters để tránh SQL Injection
                command.Parameters.AddWithValue("@TaiKhoan", taiKhoan);
                command.Parameters.AddWithValue("@MatKhau", matKhau);

                int count = Convert.ToInt32(command.ExecuteScalar());

                // Nếu số lượng bản ghi khớp là 1, đăng nhập thành công
                return count == 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message);
                return false;
            }
            finally
            {
                // Đóng kết nối sau khi sử dụng
                connection.Close();
            }
        }
        private void lblSaimatkhau_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void TextCLick1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a = new Form1();
           DoiMatKhau FDangnhap = new DoiMatKhau();
            a.Closed += (s, args) => this.Close();
            FDangnhap.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
