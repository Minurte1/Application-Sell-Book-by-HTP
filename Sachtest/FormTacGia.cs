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

namespace Sachtest
{
    public partial class FormTacGia : Form
    {
        private string connectionString = "Data Source=ACER;Initial Catalog=QLNS3;Integrated Security=True";
        public FormTacGia()
        {
            InitializeComponent(); 
            dataGridView1.CellClick += dataGridView1_CellContentClick;
        }

        private void LoadData()
        {
            // Tạo kết nối
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Thực hiện truy vấn SQL và lấy dữ liệu vào DataTable
                string query = "SELECT * FROM TACGIA";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Hiển thị dữ liệu trong DataGridView
                dataGridView1.DataSource = dataTable;
            }
        }
        private void FormTacGia_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ dòng được click
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Hiển thị dữ liệu lên các TextBox
                tb_MaTG.Text = row.Cells["MATG"].Value.ToString();
                tb_TenTG.Text = row.Cells["TENTG"].Value.ToString();
              dateTimePicker1.Text = row.Cells["NAMSINH"].Value.ToString();
            }
        }

        private void bt_Them_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các controls trên form
                string maTheLoai = tb_MaTG.Text;
                string tenTheLoai = tb_TenTG.Text;
                string NgaySinh = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                // Tạo kết nối
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Thực hiện lệnh SQL để thêm dữ liệu vào CSDL
                    string query = $"INSERT INTO TACGIA (MATG, TENTG, NAMSINH) VALUES ('{maTheLoai}', N'{tenTheLoai}','{NgaySinh}')";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowsAffected = command.ExecuteNonQuery();

                    // Kiểm tra xem có dữ liệu nào bị ảnh hưởng không
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm thể loại sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Sau khi thêm, cập nhật DataGridView
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thể loại sách thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã thể loại từ TextBox
                string maTG = tb_MaTG.Text;

                // Tạo kết nối
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Thực hiện lệnh SQL để xóa dữ liệu từ CSDL
                    string query = $"DELETE FROM TACGIA WHERE MATG = '{maTG}'";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowsAffected = command.ExecuteNonQuery();

                    // Kiểm tra xem có dữ liệu nào bị ảnh hưởng không
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa thể loại sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Sau khi xóa, cập nhật DataGridView
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thể loại sách thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các controls trên form
                string MATG = tb_MaTG.Text;
                string tenTG = tb_TenTG.Text;
                string NAMSINH = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // Chuyển định dạng năm sinh

                // Tạo kết nối
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Thực hiện lệnh SQL để cập nhật dữ liệu trong CSDL
                    string query = $"UPDATE TACGIA SET TENTG = N'{tenTG}', NAMSINH = '{NAMSINH}' WHERE MATG = '{MATG}'";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowsAffected = command.ExecuteNonQuery();

                    // Kiểm tra xem có dữ liệu nào bị ảnh hưởng không
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa thể loại sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Sau khi sửa, cập nhật DataGridView
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thể loại sách thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

     
        }
    }
}
