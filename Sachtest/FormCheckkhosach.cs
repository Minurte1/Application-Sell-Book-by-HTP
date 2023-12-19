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
using ComboBox = System.Windows.Forms.ComboBox;


using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Sachtest
{
    public partial class FormCheckkhosach : Form
    {
        public FormCheckkhosach()
        {
            InitializeComponent();

        }

        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=ACER;Initial Catalog=QLNS3;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        void loaddatasach()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from SACH";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvKhosach.DataSource = table;
        }

        private void FormCheckkhosach_Load(object sender, EventArgs e)
        {
            dgvKhosach.MultiSelect = false;
            dgvKhosach.CellClick += dgvKhosach_CellContentClick;
            dgvKhosach.SelectionChanged += dgvKhosach_SelectionChanged;

            // Load dữ liệu cho ComboBox từ bảng TACGIA
            LoadComboBoxFromDatabase(cb_MaTG, str, "TACGIA", "MaTG", "TenTG");

            // Load dữ liệu cho ComboBox từ bảng THELOAISACH
            LoadComboBoxFromDatabase(cb_MaTL, str, "THELOAISACH", "MaTL", "TenTL");

            // Load dữ liệu cho ComboBox từ bảng NHAXUATBAN
            LoadComboBoxFromDatabase(cb_MaNXB, str, "NHAXUATBAN", "MaNXB", "TenNXB");
            SetDefaultValuesForComboBoxes();

            // Mở kết nối và load dữ liệu sách
            connection = new SqlConnection(str);
            connection.Open();
            loaddatasach();
        }
        private void SetDefaultValuesForComboBoxes()
        {
            // Chọn giá trị đầu tiên trong ComboBox hoặc giá trị mặc định khác
            if (cb_MaTG.Items.Count > 0)
                cb_MaTG.SelectedIndex = 0;

            if (cb_MaTL.Items.Count > 0)
                cb_MaTL.SelectedIndex = 0;

            if (cb_MaNXB.Items.Count > 0)
                cb_MaNXB.SelectedIndex = 0;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void dgvKhosach_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKhosach.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvKhosach.SelectedRows[0];
                tb_Masach.Text = selectedRow.Cells["MASACH"].Value.ToString();
                tb_Tensach.Text = selectedRow.Cells["TENSACH"].Value.ToString();
                cb_MaTG.Text = selectedRow.Cells["MATG"].Value.ToString();

                // Check if SelectedValue is not null before using it
                object selectedValue = cb_MaTL.SelectedValue;
                if (selectedValue != null)
                {
                    cb_MaTL.Text = selectedValue.ToString();
                }

                cb_MaNXB.Text = selectedRow.Cells["MANXB"].Value.ToString();
                tb_Namxb.Text = selectedRow.Cells["NAMXUATBAN"].Value.ToString();
                tb_Lantaiban.Text = selectedRow.Cells["LANTAIBAN"].Value.ToString();
                tb_Giaban.Text = selectedRow.Cells["GIABIA"].Value.ToString();
                tb_Giamua.Text = selectedRow.Cells["GIAMUA"].Value.ToString();
            }
        }




        private void LoadComboBoxFromDatabase(ComboBox comboBox, string connectionString, string tableName, string valueColumnName, string displayColumnName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"SELECT {valueColumnName}, {displayColumnName} FROM {tableName}";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string value = reader[valueColumnName].ToString();
                                string display = reader[displayColumnName].ToString();
                                comboBox.Items.Add(new ComboboxItem(display, value));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public class ComboboxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public ComboboxItem(string text, string value)
            {
                Text = text;
                Value = value;
            }

            public override string ToString()
            {
                return Text;
            }
        }

        private void thêmDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cb_MaTG.Items.Count > 0 && cb_MaTL.Items.Count > 0 && cb_MaNXB.Items.Count > 0)
                {
                    // Lấy thông tin từ các controls trên form
                    string MaSach = tb_Masach.Text.Trim();
                    string TenSach = tb_Tensach.Text.Trim();

                    // Sử dụng SelectedItem để lấy giá trị và hiển thị tên
                    ComboboxItem selectedTG = (ComboboxItem)cb_MaTG.SelectedItem;
                    ComboboxItem selectedTL = (ComboboxItem)cb_MaTL.SelectedItem;
                    ComboboxItem selectedNXB = (ComboboxItem)cb_MaNXB.SelectedItem;

                    // Kiểm tra SelectedItem có khác null hay không
                    if (selectedTG != null && selectedTL != null && selectedNXB != null)
                    {
                        string MaTG = selectedTG.Value;
                        string MaTL = selectedTL.Value;
                        string MaNXB = selectedNXB.Value;
                        string NamNXB = tb_Namxb.Text.Trim();
                        string LanTB = tb_Lantaiban.Text.Trim();
                        string GiaBia = tb_Giaban.Text.Trim();
                        string GiaMua = tb_Giamua.Text.Trim();

                        // Kiểm tra thông tin có đầy đủ hay không
                        if (string.IsNullOrEmpty(MaSach) || string.IsNullOrEmpty(TenSach) || string.IsNullOrEmpty(MaTG) ||
                            string.IsNullOrEmpty(MaTL) || string.IsNullOrEmpty(MaNXB) || string.IsNullOrEmpty(NamNXB) ||
                            string.IsNullOrEmpty(LanTB) || string.IsNullOrEmpty(GiaBia) || string.IsNullOrEmpty(GiaMua))
                        {
                            MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Tạo câu lệnh SQL để thêm dữ liệu vào bảng SACH
                        string query = "INSERT INTO SACH (MASACH, MATG, MATL, MANXB, TENSACH, GIAMUA,GIABIA,LANTAIBAN,NAMXUATBAN) " +
                                        "VALUES (@MaSach, @MaTG, @MaTL, @MaNXB, @TenSach,@GiaMua,@GiaBia, @LanTB, @NamXB)";

                        // Sử dụng tham số để tránh SQL Injection
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@MaSach", MaSach);
                        command.Parameters.AddWithValue("@TenSach", TenSach);
                        command.Parameters.AddWithValue("@MaTG", MaTG);
                        command.Parameters.AddWithValue("@MaTL", MaTL);
                        command.Parameters.AddWithValue("@MaNXB", MaNXB);
                        command.Parameters.AddWithValue("@NamXB", NamNXB);
                        command.Parameters.AddWithValue("@LanTB", LanTB);
                        command.Parameters.AddWithValue("@GiaBia", GiaBia);
                        command.Parameters.AddWithValue("@GiaMua", GiaMua);

                        // Thực hiện lệnh SQL
                        command.CommandText = query;
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Sau khi thêm, cập nhật DataGridView
                            loaddatasach();
                        }
                        else
                        {
                            MessageBox.Show("Thêm sách thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Một hoặc nhiều ComboBox không có dữ liệu hoặc giá trị được chọn là null.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Một hoặc nhiều ComboBox không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void lb_Tensach_Click(object sender, EventArgs e)
        {

        }

        private void dgvKhosach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvKhosach.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvKhosach.Rows[e.RowIndex];
                tb_Masach.Text = selectedRow.Cells["MASACH"].Value.ToString();
                tb_Tensach.Text = selectedRow.Cells["TENSACH"].Value.ToString();
                cb_MaTG.Text = selectedRow.Cells["MATG"].Value.ToString();
                cb_MaTL.Text = selectedRow.Cells["MATL"].Value.ToString();
                // Check if SelectedValue is not null before using it
                object selectedValue = cb_MaTL.SelectedValue;
                if (selectedValue != null)
                {
                    cb_MaTL.Text = selectedValue.ToString();
                }

                cb_MaNXB.Text = selectedRow.Cells["MANXB"].Value.ToString();
                tb_Namxb.Text = selectedRow.Cells["NAMXUATBAN"].Value.ToString();
                tb_Lantaiban.Text = selectedRow.Cells["LANTAIBAN"].Value.ToString();
                tb_Giaban.Text = selectedRow.Cells["GIABIA"].Value.ToString();
                tb_Giamua.Text = selectedRow.Cells["GIAMUA"].Value.ToString();
            }

        }

        private void tb_Tensach_TextChanged(object sender, EventArgs e)
        {

        }

        private void cb_MaTL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_MaNXB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void thêmThểLoạiSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCheckkhosach a = new FormCheckkhosach();
            FormThemTheLoaiSach FForgetpass = new FormThemTheLoaiSach();
            a.Closed += (s, args) => this.Close();
            FForgetpass.Show();

        }

        private void thêmTácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCheckkhosach a = new FormCheckkhosach();
            FormTacGia FForgetpass = new FormTacGia();
            a.Closed += (s, args) => this.Close();
            FForgetpass.Show();
        }

        private void thêmNhàXuấtBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCheckkhosach a = new FormCheckkhosach();
            FormNSX FForgetpass = new FormNSX();
            a.Closed += (s, args) => this.Close();
            FForgetpass.Show();
        }

        private void tổngSốLượngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void xóaDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã sách từ TextBox
                string MaSach = tb_Masach.Text.Trim();

                // Kiểm tra xem có chắc chắn muốn xóa không
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sách này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Tạo câu lệnh SQL để xóa dữ liệu từ bảng SACH
                    string query = "DELETE FROM SACH WHERE MASACH = @MaSach";

                    // Sử dụng tham số để tránh SQL Injection
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@MaSach", MaSach);

                    // Thực hiện lệnh SQL
                    command.CommandText = query;
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Sau khi xóa, cập nhật DataGridView
                        loaddatasach();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sách thất bại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sửaDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ComboboxItem selectedTG = (ComboboxItem)cb_MaTG.SelectedItem;
                ComboboxItem selectedTL = (ComboboxItem)cb_MaTL.SelectedItem;
                ComboboxItem selectedNXB = (ComboboxItem)cb_MaNXB.SelectedItem;
                // Lấy thông tin từ các controls trên form
                string MaSach = tb_Masach.Text.Trim();
                string TenSach = tb_Tensach.Text.Trim();
                string MaTG = selectedTG.Value;
                string MaTL = selectedTL.Value;
                string MaNXB = selectedNXB.Value;
                string NamNXB = tb_Namxb.Text.Trim();
                string LanTB = tb_Lantaiban.Text.Trim();
                string GiaBia = tb_Giaban.Text.Trim();
                string GiaMua = tb_Giamua.Text.Trim();

                // Kiểm tra thông tin có đầy đủ hay không
                if (string.IsNullOrEmpty(MaSach) || string.IsNullOrEmpty(TenSach) || string.IsNullOrEmpty(MaTG) ||
                    string.IsNullOrEmpty(MaTL) || string.IsNullOrEmpty(MaNXB) || string.IsNullOrEmpty(NamNXB) ||
                    string.IsNullOrEmpty(LanTB) || string.IsNullOrEmpty(GiaBia) || string.IsNullOrEmpty(GiaMua))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tạo câu lệnh SQL để cập nhật dữ liệu vào bảng SACH
                string query = "UPDATE SACH SET MATG = @MaTG, MATL = @MaTL, MANXB = @MaNXB, TENSACH = @TenSach, GIAMUA = @GiaMua, GIABIA = @GiaBia, LANTAIBAN = @LanTB, NAMXUATBAN = @NamXB WHERE MASACH = @MaSach";

                // Sử dụng tham số để tránh SQL Injection
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@MaSach", MaSach);
                command.Parameters.AddWithValue("@TenSach", TenSach);
                command.Parameters.AddWithValue("@MaTG", MaTG);
                command.Parameters.AddWithValue("@MaTL", MaTL);
                command.Parameters.AddWithValue("@MaNXB", MaNXB);
                command.Parameters.AddWithValue("@NamXB", NamNXB);
                command.Parameters.AddWithValue("@LanTB", LanTB);
                command.Parameters.AddWithValue("@GiaBia", GiaBia);
                command.Parameters.AddWithValue("@GiaMua", GiaMua);

                // Thực hiện lệnh SQL
                command.CommandText = query;
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Sửa sách thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Sau khi sửa, cập nhật DataGridView
                    loaddatasach();

                    // Thiết lập giá trị hiển thị cho ComboBox sau khi cập nhật
                    foreach (ComboboxItem item in cb_MaTL.Items)
                    {
                        if (item.Value == MaTL)
                        {
                            cb_MaTL.Text = item.Text;
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Sửa sách thất bại. Không có dữ liệu nào được cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Lỗi SQL: {sqlEx.Message}\nMã lỗi: {sqlEx.ErrorCode}\nChi tiết: {sqlEx.ToString()}", "Lỗi SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}\nStackTrace: {ex.StackTrace}", "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }

        //    --Tạo bảng TG 
        //-- Tạo bảng NXB
        //-- Tạo bảng sách
    }
