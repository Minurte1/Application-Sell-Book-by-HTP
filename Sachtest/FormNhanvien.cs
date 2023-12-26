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
using System.Data.SqlClient;
namespace Sachtest
{
    public partial class FormNhanvien : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=ACER;Initial Catalog=QLNS3;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void loaddata()
        {
           
            command = connection.CreateCommand();
            command.CommandText = "select * from NHANVIEN";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvnhanvien.DataSource = table;
        }
        public FormNhanvien()
        {
            InitializeComponent();
        }

        private void FormNhanvien_Load(object sender, EventArgs e)
        {
            cbgioitinh.SelectedIndex = 0;
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
            cbgioitinh.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private bool KiemTraTonTaiManv(string manv)
        {
            // Thực hiện kiểm tra xem MaKH đã tồn tại trong cơ sở dữ liệu hay chưa
            string queryKiemTra = "SELECT COUNT(*) FROM NHANVIEN WHERE manv = @manv";

            using (SqlConnection conn = new SqlConnection(str))
            using (SqlCommand cmd = new SqlCommand(queryKiemTra, conn))
            {
                cmd.Parameters.AddWithValue("@manv", manv);

                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtmanv.Text == "" || txttennv.Text == "" || txtdiachi.Text == "" || txtsdt.Text == "")
                {
                    MessageBox.Show("bạn chưa truyền đủ dữ liệu không thể thêm");
                    return;
                }

                if(txtmanv.Text == "")
                {
                    command = connection.CreateCommand();
                    command.CommandText = "insert into NHANVIEN values (N'" + txtmanv.Text + "',N'" + txttennv.Text + "','" + txtsdt.Text + "',N'" + txtdiachi.Text + "',N'" + cbgioitinh.Text + "')";
                    command.ExecuteNonQuery();
                    MessageBox.Show("thêm dữ liệu thành công!!!");
                    loaddata();
                    return;
                }
                else
                {
                    if (KiemTraTonTaiManv(txtmanv.Text))
                    {
                        DialogResult result = MessageBox.Show("Mã nhân viên này đã tồn tại! Bạn muốn cập nhật thông tin nhân viên?", "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            // Thực hiện cập nhật thông tin khách hàng
                            command = connection.CreateCommand();
                            command.CommandText = "update NHANVIEN set tennv = '" + txttennv.Text + "', sdtnv = '" + txtsdt.Text + "',diachinv = '" + txtdiachi.Text + "',gioitinhnv = '" + cbgioitinh.Text + "' where manv = '" + txtmanv.Text + "'";
                            command.ExecuteNonQuery();
                            loaddata();
                        
                            return;
                        }
                        else
                        {

                            command = connection.CreateCommand();
                            command.CommandText = "insert into NHANVIEN values (N'" + txtmanv.Text + "',N'" + txttennv.Text + "','" + txtsdt.Text + "',N'" + txtdiachi.Text + "',N'" + cbgioitinh.Text + "')";
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
                        command.CommandText = "insert into NHANVIEN values (N'" + txtmanv.Text + "',N'" + txttennv.Text + "','" + txtsdt.Text + "',N'" + txtdiachi.Text + "',N'" + cbgioitinh.Text + "')";
                        command.ExecuteNonQuery();
                        MessageBox.Show("thêm dữ liệu thành công!!!");
                        loaddata();

                        return;
                    }
                }

              
            }
            catch(Exception ex)
            {
                MessageBox.Show("lỗi nhập liệu");
            }
            
        }

        private void dgvnhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmanv.ReadOnly = true;
            int i;
            i = dgvnhanvien.CurrentRow.Index;
            txtmanv.Text = dgvnhanvien.Rows[i].Cells[0].Value.ToString();
            txttennv.Text = dgvnhanvien.Rows[i].Cells[1].Value.ToString();
            txtsdt.Text = dgvnhanvien.Rows[i].Cells[2].Value.ToString();
            txtdiachi.Text = dgvnhanvien.Rows[i].Cells[3].Value.ToString();
            cbgioitinh.Text = dgvnhanvien.Rows[i].Cells[4].Value.ToString();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "update NHANVIEN set tennv = '" + txttennv.Text + "', sdtnv = '" + txtsdt.Text + "',diachinv = '" + txtdiachi.Text + "',gioitinhnv = '" + cbgioitinh.Text + "' where manv = '" + txtmanv.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
            }
            catch(Exception ex)
            {
                MessageBox.Show("lỗi update dữ liệu");
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            try
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from NHANVIEN where MANV='"+txtmanv.Text+"' ";
                command.ExecuteNonQuery();
                loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi xóa dữ liệu");
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
