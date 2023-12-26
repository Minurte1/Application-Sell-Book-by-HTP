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
    public partial class formKhachHang : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=ACER;Initial Catalog=QLNS3;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();


        void loaddata()
        {

            command = connection.CreateCommand();
            command.CommandText = "select * from KHACHHANG";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvKhachhang.DataSource = table;
        }

        private bool KiemTraTonTaiMakh(string makh)
        {
            // Thực hiện kiểm tra xem MaKH đã tồn tại trong cơ sở dữ liệu hay chưa
            string queryKiemTra = "SELECT COUNT(*) FROM KHACHHANG WHERE makh = @makh";

            using (SqlConnection conn = new SqlConnection(str))
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

        }

        private void formKhachHang_Load(object sender, EventArgs e)
        {
            cbgioitinh.SelectedIndex = 0;
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmakh.Text == "" || txttenkh.Text == "" || txtdiachi.Text == "" || txtsdt.Text == "")
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
                MessageBox.Show("lỗi nhập liệu");
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
                MessageBox.Show("lỗi update dữ liệu");
            }
        }

        private void dgvKhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmakh.ReadOnly = true;
            int i;
            i = dgvKhachhang.CurrentRow.Index;
            txtmakh.Text = dgvKhachhang.Rows[i].Cells[0].Value.ToString();
            txttenkh.Text = dgvKhachhang.Rows[i].Cells[1].Value.ToString();
            txtsdt.Text = dgvKhachhang.Rows[i].Cells[2].Value.ToString();
            txtdiachi.Text = dgvKhachhang.Rows[i].Cells[3].Value.ToString();
            cbgioitinh.Text = dgvKhachhang.Rows[i].Cells[4].Value.ToString();
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
                MessageBox.Show("lỗi xóa dữ liệu");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void thêmKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtmakh.Text == "" || txttenkh.Text == "" || txtdiachi.Text == "" || txtsdt.Text == "")
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
                MessageBox.Show("lỗi nhập liệu");
            }
        }

        private void sửaKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dữ liệu: " + ex.Message);
            }

        }

        private void xóaKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
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
                MessageBox.Show("lỗi xóa dữ liệu");
            }
        }

        private void làmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtmakh.ReadOnly = false;
        }
    }
}
