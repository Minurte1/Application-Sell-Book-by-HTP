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
using System.Text.RegularExpressions;

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
        string connectionString = "Data Source=ACER;Initial Catalog=QLNS3;Integrated Security=True";




        private void InitializeDatabaseConnection()
        {
            string connectionString = "Data Source=ACER;Initial Catalog=QLNS3;Integrated Security=True";
            sqlConnection = new SqlConnection(connectionString);
        }
        private void LoadDataFromSachTable()
        {
            try
            {
                // Mở kết nối
                //sqlConnection.Open();

                // Lấy ngày giờ hiện tại đến phút
                DateTime currentDateTime = DateTime.Now;
                DateTime currentDateTimeWithoutSeconds = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, currentDateTime.Hour, currentDateTime.Minute, 0);

                // Lệnh SQL với tham số
                string query = "SELECT KHACHHANG.MAKH, NHANVIEN.TENNV,KHACHHANG.TENKH, HOADON.MAHOADON AS MAHD, CONVERT(VARCHAR(16), HOADON.NGAYLAPHD, 120) AS NGAYLAPHD, CHITIETHOADON.SOLUONGMUA, CHITIETHOADON.MASACH, SACH.TENSACH,  SACH.GIAMUA, HOADON.TONGTIEN FROM  KHACHHANG JOIN  HOADON ON KHACHHANG.MAKH = HOADON.MAKH JOIN NHANVIEN ON HOADON.MANV = NHANVIEN.MANV JOIN CHITIETHOADON ON HOADON.MAHOADON = CHITIETHOADON.MAHOADON JOIN SACH ON CHITIETHOADON.MASACH = SACH.MASACH WHERE CONVERT(VARCHAR(16), HOADON.NGAYLAPHD, 120) = CONVERT(VARCHAR(16), GETDATE(), 120) ORDER BY HOADON.NGAYLAPHD;";

                // Sử dụng using để đảm bảo giải phóng tài nguyên
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection))
                {
                    // Thêm tham số và giá trị
                    adapter.SelectCommand.Parameters.AddWithValue("@NGAYLAPHD", currentDateTimeWithoutSeconds);

                    // DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();

                    // Đổ dữ liệu từ Adapter vào DataTable
                    adapter.Fill(dataTable);

                    // Bạn có thể sử dụng dataTable để thao tác với dữ liệu.

                    // Nếu bạn muốn hiển thị trong DataGridView:
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ bảng HOA DON: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối trong khối finally để đảm bảo rằng nó sẽ được đóng dù có lỗi xảy ra hay không.
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }


        private void LoadDataFromSachTablee()
        {
            try
            {
                //sqlConnection.Open();

                string query = "SELECT \r\n    " +
                    "KHACHHANG.MAKH,\r\n   " +
                    " KHACHHANG.TENKH,\r\n   " +
                   
                    "  NHANVIEN.TENNV,\r\n  " +
                    "  HOADON.MAHOADON AS MAHD,\r\n  " +
                    "  HOADON.NGAYLAPHD,\r\n  " +
                    "  CHITIETHOADON.SOLUONGMUA,\r\n  " +
                    "  CHITIETHOADON.MASACH,\r\n    SACH.TENSACH,\r\n    SACH.GIAMUA,\r\n    SACH.GIAMUA * CHITIETHOADON.SOLUONGMUA AS THANHTIEN\r\nFROM \r\n    KHACHHANG\r\nJOIN \r\n    HOADON ON KHACHHANG.MAKH = HOADON.MAKH\r\nJOIN \r\n    NHANVIEN ON HOADON.MANV = NHANVIEN.MANV\r\nJOIN \r\n    CHITIETHOADON ON HOADON.MAHOADON = CHITIETHOADON.MAHOADON\r\nJOIN \r\n    SACH ON CHITIETHOADON.MASACH = SACH.MASACH\r\nORDER BY \r\n    HOADON.NGAYLAPHD DESC;";
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

        private bool MuaSach(string maSach, int soLuongMua)
        {
            try
            {
                // Tạo kết nối và thực hiện mua sách
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Lấy số lượng sách hiện có từ CSDL
                    string querySelect = $"SELECT SoLuong FROM SACH WHERE MaSach = '{maSach}'";
                    SqlCommand selectCommand = new SqlCommand(querySelect, connection);
                    int soLuongHienCo = Convert.ToInt32(selectCommand.ExecuteScalar());

                    // Kiểm tra xem có đủ sách để mua không
                    if (soLuongHienCo >= soLuongMua)
                    {
                        // Cập nhật số lượng sách mới
                        int soLuongConLai = soLuongHienCo - soLuongMua;
                        string queryUpdate = $"UPDATE SACH SET SoLuong = {soLuongConLai} WHERE MaSach = '{maSach}'";
                        SqlCommand updateCommand = new SqlCommand(queryUpdate, connection);
                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        // Kiểm tra xem có dữ liệu nào bị ảnh hưởng không
                        if (rowsAffected > 0)
                        {
                            return true; // Mua sách thành công
                        }
                        else
                        {
                            return false; // Mua sách thất bại
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số lượng sách không đủ để mua", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false; // Mua sách thất bại
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mua sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // Mua sách thất bại
            }
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
                string maSach = selectedMasach;
                int soLuongMua = int.Parse(tb_Soluong.Text);

                // Mua sách và kiểm tra lỗi
                if (!MuaSach(maSach, soLuongMua))
                {
                    //MessageBox.Show("Lỗi khi mua sách. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Thoát khỏi phương thức nếu có lỗi
                }

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

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            LoadDataFromSachTablee();
        }

        private void xuấtHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormXuatHoaDonRP XUATHOADON = new FormXuatHoaDonRP();
            XUATHOADON.ShowDialog();
        }
    }
}
