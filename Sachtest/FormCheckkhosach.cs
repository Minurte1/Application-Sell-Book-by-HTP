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
            // TODO: This line of code loads data into the 'qLNS3DataSet1.NHAXUATBAN' table. You can move, or remove it, as needed.
           
            // TODO: This line of code loads data into the 'qLNS3DataSet.THELOAISACH' table. You can move, or remove it, as needed.
         
            // TODO: This line of code loads data into the 'qLNS3TG.TACGIA' table. You can move, or remove it, as needed.
           
            LoadComboBoxFromDatabase(cb_MaTG, str, "TACGIA", "MaTG", "TenTG");

            // Load dữ liệu cho ComboBox từ bảng THELOAISACH
            LoadComboBoxFromDatabase(cb_MaTL, str, "THELOAISACH", "MaTL", "TenTL");
         
            // Load dữ liệu cho ComboBox từ bảng NHAXUATBAN
            LoadComboBoxFromDatabase(cb_MaNXB, str, "NHAXUATBAN", "MaNXB", "TenNXB");
            SetDefaultValuesForComboBoxes();
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
                // Lấy thông tin từ các controls trên form
                string MaSach = tb_Masach.Text.Trim();
                string TenSach = tb_Tensach.Text.Trim();
                string MaTG = cb_MaTG.Text.Trim();
                string MaTL = cb_MaTL.SelectedValue.ToString(); // Sử dụng SelectedValue
                string MaNXB = cb_MaNXB.Text.Trim();
                string NamNXB = tb_Namxb.Text.Trim();
                string LanTB = tb_Lantaiban.Text.Trim();
                string GiaBia = tb_Giaban.Text.Trim();
                string GiaMua = tb_Giamua.Text.Trim();
                MessageBox.Show(MaTL);
                Console.WriteLine(MaTL);
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
    }


//    --Tạo bảng TG 
//-- Tạo bảng NXB
//-- Tạo bảng sách
}
