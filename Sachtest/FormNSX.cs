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
    public partial class FormNSX : Form
    {
        private string connectionString = "Data Source=ACER;Initial Catalog=QLNS3;Integrated Security=True";
        public FormNSX()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellContentClick;
        }

        private void FormNSX_Load(object sender, EventArgs e)
        {
            LoadData();
            tb_MaTL.ReadOnly = true;
        }
        private void LoadData()
        {
            // Tạo kết nối
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Thực hiện truy vấn SQL và lấy dữ liệu vào DataTable
                string query = "SELECT * FROM NHAXUATBAN";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Hiển thị dữ liệu trong DataGridView
                dataGridView1.DataSource = dataTable;
            }
        }
        private bool CheckIfMaHDTonTai(string MATGG)
        {
            bool result = false;
            const string prefix = "NXB";
            string HDMAHD = prefix + MATGG;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();  // Open the connection before executing the command

                    using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM NHAXUATBAN WHERE MANXB = @maHD", connection))
                    {
                        command.Parameters.AddWithValue("@maHD", HDMAHD);

                        int count = (int)command.ExecuteScalar();

                        // Nếu count > 0, tức là MAHD đã tồn tại
                        result = count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra MANXB trong CSDL: " + ex.Message);
            }

            return result;
        }
        private void bt_Them_Click(object sender, EventArgs e)
        {
            try
            {
                const string prefix = "NXB";

                Random random = new Random();
                int randomNumber;
                string maNXB;

                do
                {
                    // Sinh số ngẫu nhiên từ 1 đến 10000
                    randomNumber = random.Next(1, 10000);
                    maNXB = randomNumber.ToString();
                } while (CheckIfMaHDTonTai(maNXB));
                string maNXBne = prefix + maNXB;

                // Lấy thông tin từ các controls trên form

                string tenNXB = tb_TenNXB.Text;

                if (string.IsNullOrWhiteSpace(tenNXB))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng lại nếu giá trị rỗng
                }

                // Tạo kết nối
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Kiểm tra xem có tên NXB đã tồn tại hay chưa
                    string checkQuery = $"SELECT COUNT(*) FROM NHAXUATBAN WHERE TENNXB = N'{tenNXB}'";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    int existingRecords = (int)checkCommand.ExecuteScalar();

                    if (existingRecords > 0)
                    {
                        MessageBox.Show("Tên NXB đã tồn tại. Vui lòng chọn tên NXB khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu tên NXB đã tồn tại
                    }

                    // Nếu không có trùng lặp, tiếp tục thực hiện thêm mới dữ liệu vào CSDL
                    string query = $"INSERT INTO NHAXUATBAN (MANXB, TENNXB) VALUES ('{maNXBne}', N'{tenNXB}')";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowsAffected = command.ExecuteNonQuery();

                    // Kiểm tra xem có dữ liệu nào bị ảnh hưởng không
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm NXB thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Sau khi thêm, cập nhật DataGridView
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Thêm NXB thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string query = $"DELETE FROM NHAXUATBAN WHERE MANXB = '{maTheLoai}'";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ dòng được click
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Hiển thị dữ liệu lên các TextBox
                tb_MaTL.Text = row.Cells["MANXB"].Value.ToString();
                tb_TenNXB.Text = row.Cells["TENNXB"].Value.ToString();
            }
        }

        private void bt_sua_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin từ các controls trên form
                string maNXB = tb_MaTL.Text;
                string tenNXB = tb_TenNXB.Text;
                if (string.IsNullOrWhiteSpace(tenNXB))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng lại nếu giá trị rỗng
                }

                // Tạo kết nối
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Kiểm tra xem tên NXB đã tồn tại hay chưa
                    string checkQuery = $"SELECT COUNT(*) FROM NHAXUATBAN WHERE TENNXB = N'{tenNXB}' AND MANXB != '{maNXB}'";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    int existingRecords = (int)checkCommand.ExecuteScalar();

                    if (existingRecords > 0)
                    {
                        MessageBox.Show("Tên NXB đã tồn tại. Vui lòng chọn tên NXB khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu tên NXB đã tồn tại
                    }

                    // Nếu không có trùng lặp, tiếp tục thực hiện cập nhật dữ liệu trong CSDL
                    string query = $"UPDATE NHAXUATBAN SET TENNXB = N'{tenNXB}' WHERE MANXB = '{maNXB}'";
                    SqlCommand command = new SqlCommand(query, connection);
                    int rowsAffected = command.ExecuteNonQuery();

                    // Kiểm tra xem có dữ liệu nào bị ảnh hưởng không
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Sửa NXB thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Sau khi sửa, cập nhật DataGridView
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Sửa NXB thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tb_MaTL_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt_Lammoi_Click(object sender, EventArgs e)
        {
            tb_MaTL.Text = "";
            tb_TenNXB.Text = "";
        }

        private void tb_TenTL_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
