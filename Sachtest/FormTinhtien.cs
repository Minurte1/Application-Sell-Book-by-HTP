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
    public partial class FormTinhtien : Form
    {
        public FormTinhtien()
        {

            InitializeComponent();
            InitializeDatabaseConnection();
        }
        private SqlConnection sqlConnection;

     
    
       

        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=ACER;Initial Catalog=QLNS3;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        private void LoadDataFromSachTable()
        {
            try
            {
                //sqlConnection.Open();

                string query = "SELECT * FROM HOADON";
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Bây giờ bạn có thể sử dụng dataTable để đổ dữ liệu vào dataGridView hoặc các điều khiển khác.
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ bảng HOA DON: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private HashSet<string> usedInvoiceCodes = new HashSet<string>();
        private int invoiceCounter = 1; // Counter to keep track of the next invoice number

        private string GenerateUniqueInvoiceCode()
        {
            const string prefix = "HD";
            const int codeLength = 2; // You can adjust the length of the counter part

            // Format the counter part with leading zeros
            string counterPart = invoiceCounter.ToString("D" + codeLength);

            string newCode = prefix + counterPart;

            // Increment the counter for the next invoice
            invoiceCounter++;

            // Kiểm tra xem mã đã được sử dụng trước đó hay chưa
            if (usedInvoiceCodes.Contains(newCode))
            {
                // Nếu đã được sử dụng, gọi lại đệ quy để sinh mã mới
                return GenerateUniqueInvoiceCode();
            }

            // Nếu mã chưa được sử dụng, thêm vào danh sách mã đã sử dụng
            usedInvoiceCodes.Add(newCode);

            return newCode;
        }


        private void bt_XacNhan_Click(object sender, EventArgs e)
        {
            try
            {
               
                string selectedMaKhachHang = cb_MaKhachhang.SelectedValue.ToString();
                string selectedMasach = cb_Sach.SelectedValue.ToString();
                string selectedMaNV = cb_MaNV.SelectedValue.ToString();
                DateTime currentTime = DateTime.Now;
                int Tongtien = int.Parse(lb_Tongtien.Text);
                int Giatien = int.Parse(lb_GiaMua.Text);
                string invoiceCode = GenerateUniqueInvoiceCode();
                    
                // Thêm dữ liệu vào bảng HOADON
                InsertDataIntoHoaDonTable(invoiceCode, selectedMaKhachHang, selectedMaNV, currentTime, Tongtien, selectedMasach, Giatien);

                // Thêm dữ liệu vào bảng CHITIETHOADON
            

                MessageBox.Show("Thêm dữ liệu thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);

            }
        }
        private bool CheckIfMaHDTonTai(string maHD)
        {
            bool result = false;
            const string prefix = "HD";
            string HDMAHD = prefix + maHD;
     
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM HOADON WHERE MAHOADON = @maHD", sqlConnection))
                {
                    command.Parameters.AddWithValue("@maHD", HDMAHD);
                    sqlConnection.Open();

                    int count = (int)command.ExecuteScalar();

                    // Nếu count > 0, tức là MAHD đã tồn tại
                    result = count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra MAHD trong CSDL: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }

            return result;
        }


        private void InsertDataIntoHoaDonTable(string invoiceCode, string selectedMaKhachHang, string selectedMaNV, DateTime currentTime, int Tongtien,string selectedMasach ,int Giatien)
        {
            try
            {
                const string prefix = "HD";

                Random random = new Random();
                int randomNumber;
                string maHD;
                do
                {
                    // Sinh số ngẫu nhiên từ 1 đến 10000
                    randomNumber = random.Next(1, 10001);
                    maHD = randomNumber.ToString();
                } while (CheckIfMaHDTonTai(maHD));

                sqlConnection.Open();

                // Tạo SqlCommand để thực hiện INSERT vào bảng HOADON
                string insertHoaDonQuery = "INSERT INTO HOADON (MAHOADON, MANV, MAKH, NGAYLAPHD, TONGTIEN) VALUES (@MAHD,@MANV , @MAKH, @NGAYLAP, @TONGTIEN)";
                SqlCommand insertHoaDonCommand = new SqlCommand(insertHoaDonQuery, sqlConnection);

                // Thêm các tham số
                insertHoaDonCommand.Parameters.AddWithValue("@MAHD", prefix + maHD);
                insertHoaDonCommand.Parameters.AddWithValue("@MAKH", selectedMaKhachHang);
                insertHoaDonCommand.Parameters.AddWithValue("@MANV", selectedMaNV);
                insertHoaDonCommand.Parameters.AddWithValue("@NGAYLAP", currentTime);
                insertHoaDonCommand.Parameters.AddWithValue("@TONGTIEN", Tongtien);
      
                // Thực hiện INSERT
                insertHoaDonCommand.ExecuteNonQuery();
                InsertDataIntoChiTietHoaDonTable(maHD, selectedMasach, int.Parse(tb_Soluong.Text), Tongtien, Giatien);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu vào bảng HOADON: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private void InsertDataIntoChiTietHoaDonTable(string maHD, string selectedMasach, int soluong,int Tongtien, int Giatien)
        {
            try
            {
                const string prefix = "HD";

                string MAHDne = prefix + maHD;

                // Tạo SqlCommand để thực hiện INSERT vào bảng CHITIETHOADON
                string insertChiTietHoaDonQuery = "INSERT INTO CHITIETHOADON (MASACH, MAHOADON, SOLUONGMUA,GIATIEN,THANHTIEN) VALUES (@MASACH, @MAHD, @SOLUONG,@GIATIEN,@THANHTIEN)";
                SqlCommand insertChiTietHoaDonCommand = new SqlCommand(insertChiTietHoaDonQuery, sqlConnection);

                // Thêm các tham số
                insertChiTietHoaDonCommand.Parameters.AddWithValue("@MAHD", MAHDne);
                insertChiTietHoaDonCommand.Parameters.AddWithValue("@MASACH", selectedMasach);
                insertChiTietHoaDonCommand.Parameters.AddWithValue("@SOLUONG", soluong);
                insertChiTietHoaDonCommand.Parameters.AddWithValue("@GIATIEN", Giatien);
                insertChiTietHoaDonCommand.Parameters.AddWithValue("@THANHTIEN", Tongtien);
                // Thực hiện INSERT
                insertChiTietHoaDonCommand.ExecuteNonQuery();

                LoadDataFromSachTable();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu vào bảng CHITIETHOADON: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void bt_Xoa_Click(object sender, EventArgs e)
        {

        }

        private void bt_Lammoi_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cb_MaNV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_MaKhachhang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadDataIntoComboBox()
        {
            try
            {
                // Check if the connection is not open before attempting to open it
                if (sqlConnection.State != ConnectionState.Open)
                {
                    //sqlConnection.Open();

                    string query = "SELECT MANV, TENNV FROM NHANVIEN";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Thiết lập ComboBox
                    cb_MaNV.DataSource = dataTable;
                    cb_MaNV.DisplayMember = "TENNV";
                    cb_MaNV.ValueMember = "MANV";
                }
                // Đóng kết nối sau khi tải xong (nếu nó đang mở)
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ bảng NHANVIEN: " + ex.Message);
            }
        }

        // Similarly, make similar changes in other methods (LoadDataIntoComboBoxKHACHHANG and LoadDataIntoComboBoxSACH)

        private void LoadDataIntoComboBoxKHACHHANG()
        {
            try
            {
                //sqlConnection.Open();

                string query = "SELECT MAKH, TENKH FROM KHACHHANG";
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Thiết lập ComboBox
                cb_MaKhachhang.DataSource = dataTable;
                cb_MaKhachhang.DisplayMember = "TENKH"; // Hiển thị tên nhân viên
                cb_MaKhachhang.ValueMember = "MAKH";   // Giữ lại mã nhân viên

                // Đóng kết nối sau khi tải xong
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ bảng KHACHHANG: " + ex.Message);
            }
        }
        private void LoadDataIntoComboBoxSACH()
        {
            try
            {
                //    sqlConnection.Open();

                string query = "SELECT MASACH, TENSACH FROM SACH";
                SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Thiết lập ComboBox
                cb_Sach.DataSource = dataTable;
                cb_Sach.DisplayMember = "TENSACH"; // Hiển thị tên nhân viên
                cb_Sach.ValueMember = "MASACH";   // Giữ lại mã nhân viên
              
                // Đóng kết nối sau khi tải xong
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ bảng SACH: " + ex.Message);
            }
        }
        private void cb_Sach_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn sách nào chưa
            if (cb_Sach.SelectedIndex != -1)
            {
                // Lấy mã sách từ ComboBox
                string selectedMaSach = cb_Sach.SelectedValue.ToString();

                // Thực hiện truy vấn để lấy giá tiền của sách
                string query = $"SELECT GIAMUA FROM SACH WHERE MASACH = '{selectedMaSach}'";

                try
                {
                    sqlConnection.Open();

                    SqlCommand command = new SqlCommand(query, sqlConnection);
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        lb_d.Text = "đ";
                        //lb_TextGiatien.Text = "Giá tiền";
                        // Hiển thị giá tiền trên Label
                       lb_GiaMua.Text = $"{result.ToString()}";
                    }
                    else
                    {
                        // Nếu không tìm thấy giá tiền
                        lb_GiaMua.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi truy vấn CSDL: " + ex.Message);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            else
            {
                // Nếu không có sách nào được chọn
                lb_GiaMua.Text = "Vui lòng chọn sách";
            }
        }

        private void cb_Soluong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem lb_GiaMua.Text có chứa giá trị hợp lệ không
                if (int.TryParse(lb_GiaMua.Text, out int Giamua))
                {

                    // Kiểm tra xem tb_Soluong.Text có thể chuyển đổi thành số nguyên không
                    if (int.TryParse(tb_Soluong.Text, out int Soluong))
                    {
                        int Tongtien = Soluong * Giamua;
                        lb_Tongtien.Text = Tongtien.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Nhập số nguyên hợp lệ.");
                    }
                }
                else
                {
                    MessageBox.Show("Giá mua không hợp lệ.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }

        }

        private void FormTinhtien_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            LoadDataFromSachTable();
            LoadDataIntoComboBox();
            LoadDataIntoComboBoxKHACHHANG();
            LoadDataIntoComboBoxSACH();
            cb_MaKhachhang.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_MaNV.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_Sach.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            
        }

        private void xEMTHÔNGTINCHITIẾTHÓAĐƠNToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormThongKeHoaDon thongke =  new FormThongKeHoaDon();
            thongke.ShowDialog();
        }
    }
}
