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
    public partial class FormXuathoadon : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string connectionString = "Data Source=ACER;Initial Catalog=QLNS3;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private void LoadData()
        {
            // Tạo kết nối
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Thực hiện truy vấn SQL và lấy dữ liệu vào DataTable
                string query = "SELECT KHACHHANG.MAKH,KHACHHANG.TENKH, HOADON.MAHOADON AS MAHD, HOADON.NGAYLAPHD AS NGAYLAPHD, CHITIETHOADON.SOLUONGMUA, CHITIETHOADON.MASACH, SACH.TENSACH, KHACHHANG.DIACHI, SACH.GIAMUA\r\nFROM \r\n    KHACHHANG\r\nJOIN \r\n    HOADON ON KHACHHANG.MAKH = HOADON.MAKH JOIN CHITIETHOADON ON HOADON.MAHOADON = CHITIETHOADON.MAHOADON JOIN SACH ON CHITIETHOADON.MASACH = SACH.MASACH ORDER BY HOADON.NGAYLAPHD DESC;";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Hiển thị dữ liệu trong DataGridView
                dataGridView1.DataSource = dataTable;
            }
        }
        public FormXuathoadon()
        {
            InitializeComponent();
        }
        void TimHOADON()
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
                command.CommandText = "SELECT * FROM HOADON WHERE CONVERT(date, NGAYLAPHD, 103) = @NgayLapHD;";

                // Sử dụng Parameters để tránh SQL Injection
                command.Parameters.AddWithValue("@NgaylapHD", dateTimePicker1.Value.Date);

                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm hóa đơn: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối sau khi sử dụng
                connection.Close();
            }
        }
        decimal TinhTongSoTienTrongNgay()
        {
            decimal tongSoTien = 0;

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
                command.CommandText = "SELECT SUM(TONGTIEN) FROM HOADON WHERE CONVERT(date, NGAYLAPHD, 103) = @Ngay;";

                // Sử dụng Parameters để tránh SQL Injection
                command.Parameters.AddWithValue("@Ngay", dateTimePicker1.Value.Date);

                object result = command.ExecuteScalar();

                // Kiểm tra xem kết quả trả về có null không
                if (result != DBNull.Value)
                {
                    tongSoTien = Convert.ToDecimal(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính tổng số tiền trong ngày: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối sau khi sử dụng
                connection.Close();
            }

            return tongSoTien;
        }

        int ThongKeTongSoLuongBan()
        {
            int tongSoLuongBan = 0;

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
                command.CommandText = "SELECT SUM(SOLUONGMUA) FROM CHITIETHOADON " +
                                      "INNER JOIN HOADON ON CHITIETHOADON.MAHOADON = HOADON.MAHOADON " +
                                      "WHERE CONVERT(date, HOADON.NGAYLAPHD, 103) = @Ngay;";

                // Sử dụng Parameters để tránh SQL Injection
                command.Parameters.AddWithValue("@Ngay", dateTimePicker1.Value.Date);

                object result = command.ExecuteScalar();

                // Kiểm tra xem kết quả trả về có null không
                if (result != DBNull.Value)
                {
                    tongSoLuongBan = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thống kê tổng số lượng bán: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối sau khi sử dụng
                connection.Close();
            }

            return tongSoLuongBan;
        }
        string ThongKeSachBanNhieuNhat()
        {
            string tenSachMax = "";

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
                command.CommandText = "SELECT TOP 1 SACH.TENSACH, SUM(CHITIETHOADON.SOLUONGMUA) AS TONGSOLUONG " +
                                      "FROM CHITIETHOADON " +
                                      "INNER JOIN HOADON ON CHITIETHOADON.MAHOADON = HOADON.MAHOADON " +
                                      "INNER JOIN SACH ON CHITIETHOADON.MASACH = SACH.MASACH " +
                                      "WHERE CONVERT(date, HOADON.NGAYLAPHD, 103) = @Ngay " +
                                      "GROUP BY SACH.TENSACH " +
                                      "ORDER BY TONGSOLUONG DESC;";

                // Sử dụng Parameters để tránh SQL Injection
                command.Parameters.AddWithValue("@Ngay", dateTimePicker1.Value.Date);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Lấy giá trị tên sách được bán nhiều nhất
                    tenSachMax = reader["TENSACH"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thống kê số lượng sách bán ra nhiều nhất: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối sau khi sử dụng
                connection.Close();
            }

            return tenSachMax;
        }

        string ThongKeTinhMuaNhieuNhat()
        {
            string tenTinhMax = "";

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
                command.CommandText = "SELECT TOP 1 KHACHHANG.DIACHI, COUNT(DISTINCT HOADON.MAKH) AS TONGKHACH " +
                                      "FROM HOADON " +
                                      "INNER JOIN KHACHHANG ON HOADON.MAKH = KHACHHANG.MAKH " +
                                      "GROUP BY KHACHHANG.DIACHI " +
                                      "ORDER BY TONGKHACH DESC;";

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Lấy giá trị tên tỉnh có lượng khách mua nhiều nhất
                    tenTinhMax = reader["DIACHI"].ToString();
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thống kê tỉnh có lượng khách mua nhiều nhất: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối sau khi sử dụng
                connection.Close();
            }

            return tenTinhMax;
        }

        private void FormXuathoadon_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            TimHOADON();
          string Tinhthanh =  ThongKeTinhMuaNhieuNhat();
            label8.Text= Tinhthanh.ToString();
            // Định dạng với dấu phẩy, không có số thập phân
            string Sachbannhieunhat = ThongKeSachBanNhieuNhat();
            label5.Text = Sachbannhieunhat.ToString();
            int tongsoluong = ThongKeTongSoLuongBan();
            label3.Text = tongsoluong.ToString("N0");
            decimal tongTien = TinhTongSoTienTrongNgay();
            label2.Text = tongTien.ToString("N0");
            label11.Text = "đ";
           
        }
    }
}
