using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sachtest
{
    public partial class FormXuatHoaDonRP : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable tableKhachHangTim = new DataTable();
        SqlCommand command;
        private SqlConnection sqlConnection;
        string connectionString = "Data Source=ACER;Initial Catalog=QLNS3;Integrated Security=True";
        public FormXuatHoaDonRP()
        {

            InitializeComponent();
            sqlConnection = new SqlConnection(connectionString);
        }
        private void LoadDataFromSachTable()
        {
            try
            {
                // Mở kết nối
                sqlConnection.Open();

                // Lấy ngày giờ hiện tại đến phút
                DateTime currentDateTime = DateTime.Now;
                DateTime currentDateTimeWithoutSeconds = new DateTime(currentDateTime.Year, currentDateTime.Month, currentDateTime.Day, currentDateTime.Hour, currentDateTime.Minute, 0);

                // Lệnh SQL với tham số
                //string query = "SELECT KHACHHANG.MAKH, NHANVIEN.TENNV, KHACHHANG.TENKH, HOADON.MAHOADON AS MAHD, HOADON.NGAYLAPHD, CHITIETHOADON.SOLUONGMUA, CHITIETHOADON.MASACH, SACH.TENSACH, SACH.GIAMUA, HOADON.TONGTIEN FROM KHACHHANG JOIN HOADON ON KHACHHANG.MAKH = HOADON.MAKH JOIN NHANVIEN ON HOADON.MANV = NHANVIEN.MANV JOIN CHITIETHOADON ON HOADON.MAHOADON = CHITIETHOADON.MAHOADON JOIN SACH ON CHITIETHOADON.MASACH = SACH.MASACH WHERE HOADON.NGAYLAPHD = @NGAYLAPHD ORDER BY HOADON.NGAYLAPHD;";
                string query = "SELECT TOP 1\r\n    KHACHHANG.MAKH,\r\n    KHACHHANG.TENKH,\r\n    NHANVIEN.MANV,\r\n    NHANVIEN.TENNV,\r\n    HOADON.MAHOADON AS MAHD,\r\n    HOADON.NGAYLAPHD,\r\n    CHITIETHOADON.SOLUONGMUA,\r\n    CHITIETHOADON.MASACH,\r\n    SACH.TENSACH,\r\n    SACH.GIAMUA,\r\n    CHITIETHOADON.GIATIEN * CHITIETHOADON.SOLUONGMUA AS THANHTIEN\r\nFROM \r\n    KHACHHANG\r\nJOIN \r\n    HOADON ON KHACHHANG.MAKH = HOADON.MAKH\r\nJOIN \r\n    NHANVIEN ON HOADON.MANV = NHANVIEN.MANV\r\nJOIN \r\n    CHITIETHOADON ON HOADON.MAHOADON = CHITIETHOADON.MAHOADON\r\nJOIN \r\n    SACH ON CHITIETHOADON.MASACH = SACH.MASACH\r\nORDER BY \r\n    HOADON.NGAYLAPHD DESC;";
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
                MessageBox.Show("Lỗi khi tải dữ liệu từ bảng HOA DON: " + ex.Message + "\n" + ex.StackTrace);
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
        
        

        private void FormXuatHoaDonRP_Load(object sender, EventArgs e)
        {
            LoadDataFromSachTable();
   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Result.pdf";
                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("Unable to write data to disk" + ex.Message);
                        }
                    }

                    if (!ErrorMessage)
                    {
                        try
                        {
                            // Tạo font Unicode cho Tiếng Việt
                            BaseFont bf = BaseFont.CreateFont("C:/Windows/Fonts/Arial.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 12);

                            PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            // Thêm font vào cột header
                            foreach (DataGridViewColumn col in dataGridView1.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText, font));
                                pTable.AddCell(pCell);
                            }

                            // Thêm dữ liệu vào bảng
                            foreach (DataGridViewRow viewRow in dataGridView1.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewRow.Cells)
                                {
                                    // Kiểm tra xem giá trị của ô có phải là null không
                                    if (dcell.Value != null)
                                    {
                                        pTable.AddCell(new Phrase(dcell.Value.ToString(), font));
                                    }
                                    else
                                    {
                                        // Nếu giá trị là null, thêm một giá trị mặc định hoặc xử lý tùy thuộc vào yêu cầu của bạn.
                                        pTable.AddCell(new Phrase("N/A", font));
                                    }
                                }
                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, fileStream);
                                document.Open();

                                // Thêm tiêu đề vào trung tâm trang
                                Paragraph title = new Paragraph("HÓA ĐƠN", new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD));
                                title.Alignment = Element.ALIGN_CENTER;
                                document.Add(title);

                                // Thêm dòng trống
                                document.Add(new Paragraph(" "));

                                // Thêm bảng vào trang
                                document.Add(pTable);

                                document.Close();
                                fileStream.Close();
                            }

                            MessageBox.Show("Data Export Successfully", "info");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while exporting Data" + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No Record Found", "Info");
            }
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            LoadDataFromSachTablee();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            LoadDataFromSachTable();
        }
    }
}
