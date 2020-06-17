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
    public partial class HDDH : Form
    {
        string sCnnStr = @"Data Source=VANLINHPC\SQLEXPRESS;Initial Catalog=NMCNPM;Integrated Security=True";

        public HDDH()
        {
            InitializeComponent();
            loadMaNVCombobox();
            loadMaNLCombobox();
            getHDDH();
        }

        private void HDDH_Load(object sender, EventArgs e)
        {

        }

        private void getHDDH()
        {
            using (SqlConnection cnHDDH = new SqlConnection(sCnnStr))
            {
                cnHDDH.Open(); // mở kết nối
                using (SqlCommand cmHDDH = new SqlCommand(sCnnStr))
                {
                    cmHDDH.Connection = cnHDDH;
                    cmHDDH.CommandType = CommandType.StoredProcedure;
                    cmHDDH.CommandText = "sp_getHDDH";
                    using (SqlDataAdapter adapterHDDH = new SqlDataAdapter(cmHDDH))
                    {
                        DataTable dtHDDH = new DataTable();
                        adapterHDDH.Fill(dtHDDH);
                        if (dtHDDH.Rows.Count > 0)
                        {
                            dgvHDDH.DataSource = dtHDDH;

                        }
                    }
                }
                cnHDDH.Close();// đóng kết nối
            }
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
                        cbbNV.SelectedIndex = 0;
                    }
                }
                cnMaNV.Close();
            }
        }

        private void loadMaNLCombobox()
        {
            using (SqlConnection cnMaNL = new SqlConnection(sCnnStr))
            {
                cnMaNL.Open();
                using (SqlCommand cmMaNL = new SqlCommand(sCnnStr))
                {
                    cmMaNL.Connection = cnMaNL;
                    cmMaNL.CommandType = CommandType.StoredProcedure;
                    cmMaNL.CommandText = "sp_getNL";
                    using (SqlDataAdapter adapterKH = new SqlDataAdapter(cmMaNL))
                    {
                        DataTable dt = new DataTable();
                        adapterKH.Fill(dt);
                        DataRow row = dt.NewRow();
                        cbNLId.DisplayMember = "TenNL";
                        cbNLId.ValueMember = "MaNL";
                        cbNLId.DataSource = dt;
                        row["TenNL"] = "Chọn";
                        row["MaNL"] = 0;
                        dt.Rows.InsertAt(row, 0);
                        cbNLId.SelectedIndex = 0;
                    }
                }
                cnMaNL.Close();
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
            nbNumber.Enabled = true;
            cbNLId.Enabled = true;
            lbTime.Text = DateTime.Now.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnHDDH = new SqlConnection(sCnnStr))
            {
                cnHDDH.Open();
                using (SqlCommand cmHDDH = new SqlCommand(sCnnStr))
                {
                    cmHDDH.Connection = cnHDDH;
                    cmHDDH.CommandType = CommandType.StoredProcedure;
                    cmHDDH.CommandText = "sp_insertHDDH";
                    cmHDDH.Parameters.AddWithValue("@MaHD", int.Parse(txtMaHD.Text));
                    cmHDDH.Parameters.AddWithValue("@MaNV", cbbNV.SelectedValue.ToString());
                    cmHDDH.Parameters.AddWithValue("@MaNL", cbNLId.SelectedValue.ToString());
                    cmHDDH.Parameters.AddWithValue("@Thoigian", DateTime.Now);
                    cmHDDH.Parameters.AddWithValue("@Soluong", int.Parse(nbNumber.Value.ToString()));
                    int iRow = (int)cmHDDH.ExecuteNonQuery();
                    if (iRow > 0)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getHDDH();
                        resetForm();
                    }
                }
                cnHDDH.Close();
            }
        }

        private void resetForm()
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnHDDH = new SqlConnection(sCnnStr))
            {
                cnHDDH.Open();
                using (SqlCommand cmHDDH = new SqlCommand(sCnnStr))
                {
                    cmHDDH.Connection = cnHDDH;
                    cmHDDH.CommandType = CommandType.StoredProcedure;
                    cmHDDH.CommandText = "sp_updateHDDH";
                    cmHDDH.Parameters.AddWithValue("@MaHD", int.Parse(txtMaHD.Text));
                    cmHDDH.Parameters.AddWithValue("@MaNV", cbbNV.SelectedValue.ToString());
                    cmHDDH.Parameters.AddWithValue("@MaNL", cbNLId.SelectedValue.ToString());
                    cmHDDH.Parameters.AddWithValue("@Soluong", int.Parse(nbNumber.Value.ToString()));
                    int iRow = (int)cmHDDH.ExecuteNonQuery();
                    if (iRow > 0)
                    {
                        MessageBox.Show("thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getHDDH();
                        resetForm();
                    }
                }
                cnHDDH.Close();
            }
        }

        private void dgvHDDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = dgvHDDH.CurrentCell.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rowHDDH = dgvHDDH.Rows[e.RowIndex];
                txtMaHD.Text = rowHDDH.Cells[0].Value.ToString();
                cbbNV.Text = rowHDDH.Cells[1].Value.ToString();
                cbNLId.Text = rowHDDH.Cells[2].Value.ToString();
                nbNumber.Value = int.Parse(rowHDDH.Cells[3].Value.ToString());
                lbTime.Text = rowHDDH.Cells[5].Value.ToString();

                txtMaHD.Enabled = true;
                txtSearch.Enabled = true;
                txtMaHD.Enabled = true;

                btn_Add.Enabled = false;
                btnUpdate.Enabled = true;
            }
        }
    }
}
