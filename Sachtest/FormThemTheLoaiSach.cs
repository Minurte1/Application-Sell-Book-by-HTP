using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sachtest
{
    public partial class FormThemTheLoaiSach : Form
    {
        // Chuỗi kết nối đến cơ sở dữ liệu
        private string connectionString = "Data Source=ACER;Initial Catalog=QLNS3;Integrated Security=True";

        public FormThemTheLoaiSach()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellContentClick;
        }

        private void FormThemTheLoaiSach_Load(object sender, EventArgs e)
        {
            // Khi form được tải, hiển thị dữ liệu từ CSDL
            LoadData();
        }

        private void LoadData()
        {
            // Tạo kết nối
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Thực hiện truy vấn SQL và lấy dữ liệu vào DataTable
                string query = "SELECT * FROM THELOAISACH";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Hiển thị dữ liệu trong DataGridView
                dataGridView1.DataSource = dataTable;
            }
        }

        private void bt_Them_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các controls trên form
                string maTheLoai = tb_MaTL.Text;
                string tenTheLoai = tb_TenTL.Text;

                // Tạo kết nối
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Thực hiện lệnh SQL để thêm dữ liệu vào CSDL
                    string query = $"INSERT INTO THELOAISACH (MATL, TENTL) VALUES ('{maTheLoai}', N'{tenTheLoai}')";
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
                string maTheLoai = tb_MaTL.Text;

                // Tạo kết nối
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Thực hiện lệnh SQL để xóa dữ liệu từ CSDL
                    string query = $"DELETE FROM THELOAISACH WHERE MATL = '{maTheLoai}'";
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
                string maTheLoai = tb_MaTL.Text;
                string tenTheLoai = tb_TenTL.Text;

                // Tạo kết nối
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Thực hiện lệnh SQL để cập nhật dữ liệu trong CSDL
                    string query = $"UPDATE THELOAISACH SET TENTL = N'{tenTheLoai}' WHERE MATL = '{maTheLoai}'";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ dòng được click
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Hiển thị dữ liệu lên các TextBox
                tb_MaTL.Text = row.Cells["MATL"].Value.ToString();
                tb_TenTL.Text = row.Cells["TENTL"].Value.ToString();
            }
        }

        private void bt_Lammoi_Click(object sender, EventArgs e)
        {
            tb_MaTL.Text = "";
            tb_TenTL.Text = "";
        }



        // Các phương thức sửa và xóa có thể được triển khai tương tự
    }
}
