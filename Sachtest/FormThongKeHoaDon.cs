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
                string query = "SELECT KHACHHANG.MAKH,KHACHHANG.TENKH, HOADON.MAHOADON AS MAHD, HOADON.NGAYLAPHD AS NGAYLAPHD, CHITIETHOADON.SOLUONGMUA, CHITIETHOADON.MASACH, SACH.TENSACH, KHACHHANG.DIACHI, SACH.GIAMUA\r\nFROM \r\n    KHACHHANG\r\nJOIN \r\n    HOADON ON KHACHHANG.MAKH = HOADON.MAKH JOIN CHITIETHOADON ON HOADON.MAHOADON = CHITIETHOADON.MAHOADON JOIN SACH ON CHITIETHOADON.MASACH = SACH.MASACH ORDER BY HOADON.NGAYLAPHD DESC;";
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
