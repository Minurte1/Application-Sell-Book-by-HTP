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
//using System.Data.OfQuocBao
namespace Sachtest
{
    public partial class formKhachHang : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string connectionString = "Data Source=ACER;Initial Catalog=QLNS3;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
      

        void loaddata()
        {
            try
            {
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
            command.CommandText = "select * from KHACHHANG";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvKhachhang.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối sau khi sử dụng
                connection.Close();
            }
        }
        void Timkhachhang()
        {
            try
            {
                // Kiểm tra xem connection có được khởi tạo chưa
                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }

                command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM KHACHHANG WHERE TENKH LIKE @TenLienHe AND DIACHI LIKE @DiaChi AND SDT LIKE @Sdt AND GIOITINH LIKE @Gioitinh;";

                // Sử dụng Parameters để tránh SQL Injection
                command.Parameters.AddWithValue("@TenLienHe", "%" + txttenkh.Text + "%");
                command.Parameters.AddWithValue("@DiaChi", "%" + txtdiachi.Text + "%");
                command.Parameters.AddWithValue("@Sdt", "%" + txtsdt.Text + "%");
                command.Parameters.AddWithValue("@Gioitinh", "%" + cbgioitinh.Text + "%");
                adapter.SelectCommand = command;
                tableKhachHangTim.Clear();
                adapter.Fill(tableKhachHangTim);
                dgvKhachhang.DataSource = tableKhachHangTim;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm khách hàng: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối sau khi sử dụng
                connection.Close();
            }
        }

        private bool KiemTraTonTaiMakh(string makh)
        {
            // Thực hiện kiểm tra xem MaKH đã tồn tại trong cơ sở dữ liệu hay chưa
            string queryKiemTra = "SELECT COUNT(*) FROM KHACHHANG WHERE makh = @makh";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(queryKiemTra, conn))
            {
                cmd.Parameters.AddWithValue("@makh", makh);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }

        public formKhachHang()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (check_timkiem.Checked == true)
            {
                Timkhachhang();
            }
        }
        DataTable tableKhachHangTim = new DataTable();

        private void formKhachHang_Load(object sender, EventArgs e)
        {
            cbgioitinh.SelectedIndex = 0;
            cbgioitinh.Text = "Nam";
            connection = new SqlConnection(connectionString);
            connection.Open();
            loaddata();
            check_timkiem.Checked = false;
            txtmakh.ReadOnly = true; 
            cbgioitinh.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txttenkh.Text == "" || txtdiachi.Text == "" || txtsdt.Text == "")
                {
                    MessageBox.Show("bạn chưa truyền đủ dữ liệu không thể thêm");
                    return;
                }

                if (txtmakh.Text == "")
                {
                    command = connection.CreateCommand();
                    command.CommandText = "insert into KHACHHANG values (N'" + txtmakh.Text + "',N'" + txttenkh.Text + "','" + txtsdt.Text + "',N'" + txtdiachi.Text + "',N'" + cbgioitinh.Text + "')";
                    command.ExecuteNonQuery();
                    MessageBox.Show("thêm dữ liệu thành công!!!");
                    loaddata();
                    return;
                }
                else
                {
                    if (KiemTraTonTaiMakh(txtmakh.Text))
                    {
                        DialogResult result = MessageBox.Show("Mã khách hàng này đã tồn tại! Bạn muốn cập nhật thông tin khách hàng?", "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            // Thực hiện cập nhật thông tin khách hàng
                            command = connection.CreateCommand();
                            command.CommandText = "update KHACHHANG set tenkh = '" + txttenkh.Text + "', sdt = '" + txtsdt.Text + "',diachi = '" + txtdiachi.Text + "',gioitinh = '" + cbgioitinh.Text + "' where makh = '" + txtmakh.Text + "'";
                            command.ExecuteNonQuery();
                            loaddata();

                            return;
                        }
                        else
                        {

                            command = connection.CreateCommand();
                            command.CommandText = "insert into KHACHHANG values (N'" + txtmakh.Text + "',N'" + txttenkh.Text + "','" + txtsdt.Text + "',N'" + txtdiachi.Text + "',N'" + cbgioitinh.Text + "')";
                            command.ExecuteNonQuery();
                            MessageBox.Show("thêm dữ liệu thành công!!!");
                            loaddata();
                            return;
                        }
                    }
                    else
                    {
                        // Mã KH chưa tồn tại, thực hiện thêm mới
                        command = connection.CreateCommand();
                        command.CommandText = "insert into KHACHHANG values (N'" + txtmakh.Text + "',N'" + txttenkh.Text + "','" + txtsdt.Text + "',N'" + txtdiachi.Text + "',N'" + cbgioitinh.Text + "')";
                        command.ExecuteNonQuery();
                        MessageBox.Show("thêm dữ liệu thành công!!!");
                        loaddata();

                        return;
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi nhập liệu",ex.Message);
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "update KHACHHANG set tenkh = '" + txttenkh.Text + "', sdt = '" + txtsdt.Text + "',diachi = '" + txtdiachi.Text + "',gioitinh = '" + cbgioitinh.Text + "' where makh = '" + txtmakh.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi update dữ liệu", ex.Message);
            }
        }

        private void dgvKhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvKhachhang.CurrentRow != null && dgvKhachhang.CurrentRow.Index >= 0)
                {
                    int i = dgvKhachhang.CurrentRow.Index;

                    // Kiểm tra giá trị của ô trước khi truy cập
                    if (dgvKhachhang.Rows[i].Cells[0].Value != null)
                    {
                        txtmakh.Text = dgvKhachhang.Rows[i].Cells[0].Value.ToString();
                    }

                    if (dgvKhachhang.Rows[i].Cells[1].Value != null)
                    {
                        txttenkh.Text = dgvKhachhang.Rows[i].Cells[1].Value.ToString();
                    }

                    if (dgvKhachhang.Rows[i].Cells[2].Value != null)
                    {
                        txtsdt.Text = dgvKhachhang.Rows[i].Cells[2].Value.ToString();
                    }

                    if (dgvKhachhang.Rows[i].Cells[3].Value != null)
                    {
                        txtdiachi.Text = dgvKhachhang.Rows[i].Cells[3].Value.ToString();
                    }

                    if (dgvKhachhang.Rows[i].Cells[4].Value != null)
                    {
                        cbgioitinh.Text = dgvKhachhang.Rows[i].Cells[4].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtmakh.ReadOnly = true;
        }


        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from KHACHHANG where makh='" + txtmakh.Text + "' ";
                command.ExecuteNonQuery();
                loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi xóa dữ liệu", ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private bool CheckIfMaHDTonTai(string maKH)
        {
            bool result = false;
            const string prefix = "KH";
            string HDMAHD = prefix + maKH;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM KHACHHANG WHERE MAKH = @maHD", connection))
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

        private void thêmKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string gioitinh = cbgioitinh.Text;

            try
            {
                const string prefix = "KH";

                Random random = new Random();
                int randomNumber;
                string maKH;

                do
                {
                    // Sinh số ngẫu nhiên từ 1 đến 10000
                    randomNumber = random.Next(1, 10000);
                    maKH = randomNumber.ToString();
                } while (CheckIfMaHDTonTai(maKH));

                if (connection == null)
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                }
                else if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }

                if (txttenkh.Text == "" || txtdiachi.Text == "" || txtsdt.Text == "")
                {
                    MessageBox.Show("Bạn chưa truyền đủ dữ liệu, không thể thêm");
                    return;
                }

                // Kiểm tra số điện thoại có đủ 10 số hay không
                if (!IsNumeric(txtsdt.Text) || txtsdt.Text.Length != 10)
                {
                    MessageBox.Show("Số điện thoại phải chỉ chứa số và có đủ 10 số.");
                    return;
                }
                if (!IsValidVietnamesePhoneNumber(txtsdt.Text))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ theo định dạng Việt Nam.");
                    return;
                }
                if (ContainsNumeric(txttenkh.Text))
                {
                    MessageBox.Show("Tên khách hàng không được chứa số.");
                    return;
                }
                if (ContainsNumeric(txtdiachi.Text))
                {
                    MessageBox.Show("Tên tỉnh thành không được chứa số.");
                    return;
                }
                string MAKHne = prefix + maKH;
                command = connection.CreateCommand();
                command.CommandText = "INSERT INTO KHACHHANG VALUES (N'" + MAKHne + "', N'" + txttenkh.Text + "','" + txtsdt.Text + "', N'" + txtdiachi.Text + "', N'" + gioitinh + "')";
                command.ExecuteNonQuery();
                MessageBox.Show("Thêm dữ liệu thành công!!!");
                loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập liệu: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
             
    private bool ContainsNumeric(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsNumeric(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
        private bool IsValidVietnamesePhoneNumber(string phoneNumber)
        {
            // Sử dụng biểu thức chính quy để kiểm tra định dạng số điện thoại Việt Nam
            // Đây là một biểu thức chính quy đơn giản, bạn có thể điều chỉnh nó tùy theo yêu cầu cụ thể.
            string pattern = @"^(03|05|07|08|09|01[2|6|8|9])+([0-9]{8})\b";

            // Kiểm tra so khớp với biểu thức chính quy
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, pattern);
        }
        private void sửaKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
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

                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE KHACHHANG SET tenkh = @tenkh, sdt = @sdt, diachi = @diachi, gioitinh = @gioitinh WHERE makh = @makh";

                    // Thêm các tham số
                    command.Parameters.AddWithValue("@tenkh", txttenkh.Text);
                    command.Parameters.AddWithValue("@sdt", txtsdt.Text);
                    command.Parameters.AddWithValue("@diachi", txtdiachi.Text);
                    command.Parameters.AddWithValue("@gioitinh", cbgioitinh.Text);
                    command.Parameters.AddWithValue("@makh", txtmakh.Text);

                    command.ExecuteNonQuery();
                    loaddata();
                    MessageBox.Show("Sửa Thông Tin Khách Hàng Thành Công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message);
            }
            finally
            {
                // Đảm bảo đóng kết nối sau khi sử dụng
                connection.Close();
            }
        }


        private void xóaKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "delete from KHACHHANG where makh=@makh";
                        command.Parameters.AddWithValue("@makh", txtmakh.Text);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Đã xóa thành công");
                    }

                    loaddata();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa dữ liệu: " + ex.Message);
            }
        }


        private void làmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtmakh.ReadOnly = true;
            txtdiachi.Text = "";
            txtsdt.Text = "";
            txttenkh.Text = "";

        }
        private bool shouldRunSearch = false;
        private void tìmKiếmKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shouldRunSearch = true;
           
        }

        private void txttenkh_TextChanged(object sender, EventArgs e)
        {

            if (check_timkiem.Checked == true)
            {
                Timkhachhang();
            }
        }
        private void SearchCompleted()
        {
            shouldRunSearch = false;
        }
        private void txtsdt_TextChanged(object sender, EventArgs e)
        {
            if (check_timkiem.Checked == true)
            {
                Timkhachhang();
            }
        }

        private void cbgioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (check_timkiem.Checked == true)
            {
                Timkhachhang();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void txtmakh_TextChanged(object sender, EventArgs e)
        {

        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Timkhachhang();
        }
    }
}
