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
            tb_MaTL.ReadOnly = true;    
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
        private bool CheckIfMaHDTonTai(string maKH)
        {
            bool result = false;
            const string prefix = "TL";
            string HDMAHD = prefix + maKH;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM THELOAISACH WHERE MATL = @maHD", connection))
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
                MessageBox.Show("Lỗi khi kiểm tra MAHD trong CSDL: " + ex.Message);
            }

            return result;
        }
        private void bt_Them_Click(object sender, EventArgs e)
        {
            try
            {
                const string prefix = "TL";

                // Lấy thông tin từ các controls trên form
                string tenTheLoai = tb_TenTL.Text;
                if (string.IsNullOrWhiteSpace(tenTheLoai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng lại nếu giá trị rỗng
                }

                // Tạo kết nối
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Kiểm tra xem tên thể loại có trùng lặp không
                    string checkQuery = $"SELECT COUNT(*) FROM THELOAISACH WHERE TENTL = N'{tenTheLoai}'";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    int existingRecords = (int)checkCommand.ExecuteScalar();

                    if (existingRecords > 0)
                    {
                        MessageBox.Show("Tên thể loại đã tồn tại. Vui lòng chọn tên thể loại khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu tên thể loại đã tồn tại
                    }

                    // Nếu không có trùng lặp, tiếp tục thêm dữ liệu vào CSDL
                    Random random = new Random();
                    int randomNumber;
                    string maKH;

                    do
                    {
                        // Sinh số ngẫu nhiên từ 1 đến 10000
                        randomNumber = random.Next(1, 10000);
                        maKH = randomNumber.ToString();
                    } while (CheckIfMaHDTonTai(maKH));

                    string maTheLoai = prefix + maKH;

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
                if (string.IsNullOrWhiteSpace(tenTheLoai))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Dừng lại nếu giá trị rỗng
                }

                // Tạo kết nối
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Kiểm tra xem có tên thể loại khác trùng lặp hay không
                    string checkQuery = $"SELECT COUNT(*) FROM THELOAISACH WHERE TENTL = N'{tenTheLoai}' AND MATL <> '{maTheLoai}'";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    int existingRecords = (int)checkCommand.ExecuteScalar();

                    if (existingRecords > 0)
                    {
                        MessageBox.Show("Tên thể loại đã tồn tại. Vui lòng chọn tên thể loại khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng lại nếu tên thể loại đã tồn tại
                    }

                    // Nếu không có trùng lặp, tiếp tục thực hiện cập nhật dữ liệu trong CSDL
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
