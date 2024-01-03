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
    public partial class FormThongKeHoaDon : Form
    {
        private string connectionString = "Data Source=ACER;Initial Catalog=QLNS3;Integrated Security=True";
        public FormThongKeHoaDon()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            // Tạo kết nối
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Thực hiện truy vấn SQL và lấy dữ liệu vào DataTable
                string query = "SELECT \r\n    KHACHHANG.MAKH,\r\n    KHACHHANG.TENKH,\r\n    NHANVIEN.MANV,\r\n    NHANVIEN.TENNV,\r\n    HOADON.MAHOADON AS MAHD,\r\n    HOADON.NGAYLAPHD,\r\n    CHITIETHOADON.SOLUONGMUA,\r\n    CHITIETHOADON.MASACH,\r\n    SACH.TENSACH,\r\n    SACH.GIAMUA,\r\n    SACH.GIAMUA * CHITIETHOADON.SOLUONGMUA AS THANHTIEN\r\nFROM \r\n    KHACHHANG\r\nJOIN \r\n    HOADON ON KHACHHANG.MAKH = HOADON.MAKH\r\nJOIN \r\n    NHANVIEN ON HOADON.MANV = NHANVIEN.MANV\r\nJOIN \r\n    CHITIETHOADON ON HOADON.MAHOADON = CHITIETHOADON.MAHOADON\r\nJOIN \r\n    SACH ON CHITIETHOADON.MASACH = SACH.MASACH\r\nORDER BY \r\n    HOADON.NGAYLAPHD DESC;";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Hiển thị dữ liệu trong DataGridView
                dataGridView1.DataSource = dataTable;
            }
        }
        private void FormThongKeHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
