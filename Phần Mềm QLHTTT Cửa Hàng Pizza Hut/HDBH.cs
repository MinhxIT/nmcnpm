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

namespace Phần_Mềm_QLHTTT_Cửa_Hàng_Pizza_Hut
{
    public partial class HDBH : Form
    {
        string sCnnStr = @"Data Source=VANLINHPC\SQLEXPRESS;Initial Catalog=NMCNPM;Integrated Security=True";
        public HDBH()
        {
            InitializeComponent();
            loadMaMonCombobox();
            loadMaKHCombobox();
            loadMaNVCombobox();
            getHDBH();
            resetForm();
            
        }

        private void getHDBH()
        {
            using (SqlConnection cnHDBH = new SqlConnection(sCnnStr))
            {
                cnHDBH.Open(); // mở kết nối
                using (SqlCommand cmHDBH = new SqlCommand(sCnnStr))
                {
                    cmHDBH.Connection = cnHDBH;
                    cmHDBH.CommandType = CommandType.StoredProcedure;
                    cmHDBH.CommandText = "sp_getHDBH";
                    using (SqlDataAdapter adapterHDBH = new SqlDataAdapter(cmHDBH))
                    {
                        DataTable dtHDBH = new DataTable();
                        adapterHDBH.Fill(dtHDBH);
                        if (dtHDBH.Rows.Count > 0)
                        {
                            dtgvHDBH.DataSource = dtHDBH;

                        }
                    }
                }
                cnHDBH.Close();// đóng kết nối
            }
        }

        private void resetForm()
        {
            txtMagiamgia.Enabled = false;
            txtSoban.Enabled = false;
            txtSoluongmon.Enabled = false;
            txtTimkiem.Enabled = false;
            txtMaHD.Enabled = false;


            txtMagiamgia.Text = string.Empty;
            txtSoban.Text = string.Empty;
            txtSoluongmon.ResetText();
            txtTimkiem.Text = string.Empty;
            txtMaHD.Text = string.Empty;

            btnThem.Enabled = true;
            btnCapnhat.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void loadMaNVCombobox()
        {
            using (SqlConnection cnMaNV = new SqlConnection(sCnnStr))
            {
                cnMaNV.Open();
                using (SqlCommand cmMaNV = new SqlCommand(sCnnStr))
                {
                    cmMaNV.Connection = cnMaNV;
                    cmMaNV.CommandType = CommandType.StoredProcedure;
                    cmMaNV.CommandText = "sp_getEmployee";
                    using (SqlDataAdapter adapterNV = new SqlDataAdapter(cmMaNV))
                    {
                        DataTable dt = new DataTable();
                        adapterNV.Fill(dt);
                        DataRow row = dt.NewRow();

                        cbbNV.DisplayMember = "TenNV";
                        cbbNV.ValueMember = "MaNV";
                        cbbNV.DataSource = dt;
                        row["TenNV"] = "Chọn";
                        row["MaNV"] = 0;
                        dt.Rows.InsertAt(row, 0);
                        cbbKH.SelectedIndex = 0;
                    }
                }
                cnMaNV.Close();
            }
        }
        private void loadMaKHCombobox()
        {
            using (SqlConnection cnMaKH = new SqlConnection(sCnnStr))
            {
                cnMaKH.Open();
                using (SqlCommand cmMaKH = new SqlCommand(sCnnStr))
                {
                    cmMaKH.Connection = cnMaKH;
                    cmMaKH.CommandType = CommandType.StoredProcedure;
                    cmMaKH.CommandText = "sp_getKH";
                    using (SqlDataAdapter adapterKH = new SqlDataAdapter(cmMaKH))
                    {
                        DataTable dt = new DataTable();
                        adapterKH.Fill(dt);
                        DataRow row = dt.NewRow();
                        cbbKH.DisplayMember = "TenKH";
                        cbbKH.ValueMember = "MaKH";
                        cbbKH.DataSource = dt;
                        row["TenKH"] = "Chọn";
                        row["MaKH"] = 0;
                        dt.Rows.InsertAt(row, 0);
                        cbbKH.SelectedIndex = 0;
                    }
                }
                cnMaKH.Close();
            }
        }

        private void loadMaMonCombobox()
        {
            using (SqlConnection cnMaMon = new SqlConnection(sCnnStr))
            {
                cnMaMon.Open();
                using (SqlCommand cmMaMon = new SqlCommand(sCnnStr))
                {
                    cmMaMon.Connection = cnMaMon;
                    cmMaMon.CommandType = CommandType.StoredProcedure;
                    cmMaMon.CommandText = "sp_getMA";
                    using (SqlDataAdapter adapterMon = new SqlDataAdapter(cmMaMon))
                    {
                        DataTable dt = new DataTable();
                        adapterMon.Fill(dt);
                        DataRow row = dt.NewRow();                        
                        cbbMamon.DisplayMember = "TenMon";
                        cbbMamon.ValueMember = "MaMon";
                        cbbMamon.DataSource = dt;
                        row["TenMon"] = "Chọn";
                        row["MaMon"] = 0;
                        dt.Rows.InsertAt(row, 0);
                        cbbMamon.SelectedIndex = 0;
                    }
                }
                cnMaMon.Close();
            }
        }

        private void HDDH_Load(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtMagiamgia.Enabled = true;
            txtSoban.Enabled = true;
            txtSoluongmon.Enabled = true;
            txtTimkiem.Enabled = true;
            txtMaHD.Enabled = true;
            lblThoigian.Text = DateTime.Now.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnHDBH = new SqlConnection(sCnnStr))
            {
                cnHDBH.Open();
                using (SqlCommand cmHDBH = new SqlCommand(sCnnStr))
                {
                    cmHDBH.Connection = cnHDBH;
                    cmHDBH.CommandType = CommandType.StoredProcedure;
                    cmHDBH.CommandText = "sp_insertHDBH";
                    cmHDBH.Parameters.AddWithValue("@MaHD",int.Parse(txtMaHD.Text));
                    cmHDBH.Parameters.AddWithValue("@MaNV", cbbNV.SelectedValue.ToString());
                    cmHDBH.Parameters.AddWithValue("@MaKH", cbbKH.SelectedValue.ToString());
                    cmHDBH.Parameters.AddWithValue("@Soban", txtSoban.Text);
                    cmHDBH.Parameters.AddWithValue("@Thoigian", DateTime.Now);
                    cmHDBH.Parameters.AddWithValue("@Giamgia", txtMagiamgia.Text);
                    cmHDBH.Parameters.AddWithValue("@MaMon", cbbMamon.SelectedValue.ToString());
                    cmHDBH.Parameters.AddWithValue("@Soluong",int.Parse(txtSoluongmon.Value.ToString()));
                    int iRow = (int)cmHDBH.ExecuteNonQuery();
                    if (iRow > 0)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getHDBH();
                        resetForm();
                    }
                }
                cnHDBH.Close();
            }
        }

        private void dtgvHDBH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dtgvHDBH.CurrentCell.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rowHDBH = dtgvHDBH.Rows[e.RowIndex];
                txtMaHD.Text = rowHDBH.Cells[0].Value.ToString();
                cbbNV.Text = rowHDBH.Cells[1].Value.ToString();
                cbbMamon.Text = rowHDBH.Cells[2].Value.ToString();
                txtSoluongmon.Value =int.Parse(rowHDBH.Cells[3].Value.ToString());
                cbbKH.Text = rowHDBH.Cells[5].Value.ToString();
                txtMagiamgia.Text = rowHDBH.Cells[6].Value.ToString();
                txtSoban.Text = rowHDBH.Cells[7].Value.ToString();

                txtMagiamgia.Enabled = true;
                txtSoban.Enabled = true;
                txtSoluongmon.Enabled = true;
                txtTimkiem.Enabled = true;
                txtMaHD.Enabled = true;

                btnThem.Enabled = false;
                btnCapnhat.Enabled = true;
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnHDBH = new SqlConnection(sCnnStr))
            {
                cnHDBH.Open();
                using (SqlCommand cmHDBH = new SqlCommand(sCnnStr))
                {
                    cmHDBH.Connection = cnHDBH;
                    cmHDBH.CommandType = CommandType.StoredProcedure;
                    cmHDBH.CommandText = "sp_updateHDBH";
                    cmHDBH.Parameters.AddWithValue("@MaHD",int.Parse(txtMaHD.Text));
                    cmHDBH.Parameters.AddWithValue("@MaNV", cbbNV.SelectedValue.ToString());
                    cmHDBH.Parameters.AddWithValue("@MaKH", cbbKH.SelectedValue.ToString());
                    cmHDBH.Parameters.AddWithValue("@Soban", txtSoban.Text);
                    cmHDBH.Parameters.AddWithValue("@Giamgia", txtMagiamgia.Text);
                    cmHDBH.Parameters.AddWithValue("@MaMon", cbbMamon.SelectedValue.ToString());
                    cmHDBH.Parameters.AddWithValue("@Soluong", int.Parse(txtSoluongmon.Value.ToString()));
                    int iRow = (int)cmHDBH.ExecuteNonQuery();
                    if (iRow > 0)
                    {
                        MessageBox.Show("thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getHDBH();
                        resetForm();
                    }
                }
                cnHDBH.Close();
            }
        }
    }
}
