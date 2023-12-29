using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sachtest
{
    public partial class DoiMatKhau : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string connectionString = "Data Source=ACER;Initial Catalog=QLNS3;Integrated Security=True";

        public DoiMatKhau()
        {
            InitializeComponent();
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
        private void tb_Xacnhan_Click(object sender, EventArgs e)
        {
            {
                string taiKhoan = tb_Taikhoan.Text;
                string matKhau =tb_Matkhau.Text;
                string matKhauMoi = tb_Matkhaumoi.Text;
                string Nhaplaimk = tb_Nhaplaimatkhau.Text;
                
                if (DangNhapAdmin(taiKhoan, matKhau))
                {
                    if(matKhauMoi == Nhaplaimk)
                    {
                        DoiMatKhauAdmin(taiKhoan, matKhau, matKhauMoi);
                        MessageBox.Show("Đã Đổi Mật Khẩu Thành Công");
                      DoiMatKhau doiMatKhau = new DoiMatKhau();
                        this.Hide();
                        Form1 a = new Form1();
                        DoiMatKhau FDangnhap = new DoiMatKhau();
                        FDangnhap.Closed += (s, args) => this.Close();
                       a.Show();
                    }
                    else
                    {
                        MessageBox.Show("Mật Khẩu Mới Và Mật Khẩu Nhập Lại Không Chuẩn Xác!!");
                    }
                  
                }
                else
                {
                    // Đăng nhập thất bại
                    MessageBox.Show("Tài Khoản Hoặc Mật Khẩu Không Đúng !!");
                }
            }
          
        }
        bool DoiMatKhauAdmin(string taiKhoan, string matKhau, string matKhauMoi)
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

                // Kiểm tra xem mật khẩu cũ có đúng không
                command = connection.CreateCommand();
                command.CommandText = "SELECT COUNT(*) FROM TAIKHOANADMIN WHERE TAIKHOAN = @TaiKhoan AND MATKHAU = @MatKhauCu;";

                // Sử dụng Parameters để tránh SQL Injection
                command.Parameters.AddWithValue("@TaiKhoan", taiKhoan);
                command.Parameters.AddWithValue("@MatKhauCu", matKhau);

                int count = Convert.ToInt32(command.ExecuteScalar());

                if (count == 1)
                {
                    // Cập nhật mật khẩu mới
                    command = connection.CreateCommand();
                    command.CommandText = "UPDATE TAIKHOANADMIN SET MATKHAU = @MatKhauMoi WHERE TAIKHOAN = @TaiKhoan;";

                    // Sử dụng Parameters để tránh SQL Injection
                    command.Parameters.AddWithValue("@TaiKhoan", taiKhoan);
                    command.Parameters.AddWithValue("@MatKhauMoi", matKhauMoi);

                    command.ExecuteNonQuery();

                    return true; // Đổi mật khẩu thành công
                }
                else
                {
                    return false; // Mật khẩu cũ không đúng
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đổi mật khẩu: " + ex.Message);
                return false;
            }
            finally
            {
                // Đóng kết nối sau khi sử dụng
                connection.Close();
            }
        }
        private void tb_Nhaplaimatkhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_Matkhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_Matkhaumoi_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_Taikhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 a = new Form1();
            DoiMatKhau FDangnhap = new DoiMatKhau();
            FDangnhap.Closed += (s, args) => this.Close();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
