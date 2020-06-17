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

namespace Phần_Mềm_QLHTTT_Cửa_Hàng_Pizza_Hut
{
    public partial class NguyenLieu : Form
    {
        public NguyenLieu()
        {
            InitializeComponent();
            resetForm();
            getNL();
            cbbNCC_SelectedIndexChanged();
        }
        string sCnnStr = @"Data Source=DESKTOP-89VADTR\SQLEXPRESS;Initial Catalog=NMCNPM;Integrated Security=True";



        private void resetForm()
        {
            txtMaNL.Enabled = false;
            txtTenNL.Enabled = false;
            txtDongia.Enabled = false;
            txtSoluong.Enabled = false;
            



            txtMaNL.Text = string.Empty;
            txtTenNL.Text = string.Empty;
            txtDongia.Text = string.Empty;
            txtSoluong.Text = string.Empty;



            btnThem.Enabled = true;
            btnCapnhat.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void getNL()
        {
            using (SqlConnection cnNL = new SqlConnection(sCnnStr))
            {
                cnNL.Open(); // mở kết nối
                using (SqlCommand cmNL = new SqlCommand(sCnnStr))
                {
                    cmNL.Connection = cnNL;
                    cmNL.CommandType = CommandType.StoredProcedure;
                    cmNL.CommandText = "sp_getNL";
                    using (SqlDataAdapter adapterNL = new SqlDataAdapter(cmNL))
                    {
                        DataTable dtNL = new DataTable();
                        adapterNL.Fill(dtNL);
                        if (dtNL.Rows.Count > 0)
                        {
                            dgvNL.DataSource = dtNL;
                        }
                    }
                }
                cnNL.Close();// đóng kết nối
            }
        }
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtTenNL.Enabled = true;
            txtDongia.Enabled = true;
            txtSoluong.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnNL= new SqlConnection(sCnnStr))
            {
                cnNL.Open();
                using (SqlCommand cmNL = new SqlCommand(sCnnStr))
                {
                    cmNL.Connection = cnNL;
                    cmNL.CommandType = CommandType.StoredProcedure;
                    cmNL.CommandText = "sp_insertNL";
                    cmNL.Parameters.AddWithValue("@sTenNL", txtTenNL.Text);
                    cmNL.Parameters.AddWithValue("@Dongia", txtDongia.Text);
                    cmNL.Parameters.AddWithValue("@Soluong", txtSoluong.Text);
                    cmNL.Parameters.AddWithValue("@MaNCC", cbbMaNCC.SelectedValue.ToString());

                    int iRow = (int)cmNL.ExecuteNonQuery();
                    if (iRow > 0)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getNL();
                        resetForm();
                    }
                }
                cnNL.Close();
            }
        }

        private void dgvNL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sMaNL = null;

            int rowIndex = dgvNL.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {
                sMaNL = dgvNL.Rows[rowIndex].Cells[0].Value.ToString();
            }
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rowNhanVien = dgvNL.Rows[e.RowIndex];
                txtMaNL.Text = rowNhanVien.Cells[0].Value.ToString();
                txtTenNL.Text = rowNhanVien.Cells[1].Value.ToString();
                txtDongia.Text = rowNhanVien.Cells["Dongia"].Value.ToString();
                txtSoluong.Text = rowNhanVien.Cells["Soluong"].Value.ToString();


                txtTenNL.Enabled = true;
                txtDongia.Enabled = true;
                txtSoluong.Enabled = true;



                btnCapnhat.Enabled = true;
                btnThem.Enabled = false;
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnNL = new SqlConnection(sCnnStr))
            {
                cnNL.Open();
                using (SqlCommand cmNL = new SqlCommand(sCnnStr))
                {
                    cmNL.Connection = cnNL;
                    cmNL.CommandType = CommandType.StoredProcedure;
                    cmNL.CommandText = "sp_updateNL";
                    cmNL.Parameters.AddWithValue("@sMaNL", txtMaNL.Text);
                    cmNL.Parameters.AddWithValue("@sTenNL", txtTenNL.Text);
                    cmNL.Parameters.AddWithValue("@Dongia", txtDongia.Text);
                    cmNL.Parameters.AddWithValue("@Soluong", txtSoluong.Text);
                    cmNL.Parameters.AddWithValue("@MaNCC", cbbMaNCC.SelectedValue.ToString());
                    int iRow = (int)cmNL.ExecuteNonQuery();
                    if (iRow > 0)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getNL();
                        resetForm();
                    }
                }
                cnNL.Close();
            }
        }

        private void cbbNCC_SelectedIndexChanged()
        {
            using (SqlConnection cnMaNCC = new SqlConnection(sCnnStr))
            {
                cnMaNCC.Open();
                using (SqlCommand cmMaNCC = new SqlCommand(sCnnStr))
                {
                    cmMaNCC.Connection = cnMaNCC;
                    cmMaNCC.CommandType = CommandType.StoredProcedure;
                    cmMaNCC.CommandText = "sp_getNCC";
                    using (SqlDataAdapter adapterBP = new SqlDataAdapter(cmMaNCC))
                    {
                        DataTable dtBP = new DataTable();
                        adapterBP.Fill(dtBP);
                        DataRow row = dtBP.NewRow();

                        cbbMaNCC.DisplayMember = "TenNCC";
                        cbbMaNCC.ValueMember = "MaNCC";
                        cbbMaNCC.DataSource = dtBP;
                        row["TenNCC"] = "Chọn Nhà Cung Cấp";
                        row["MaNCC"] = 0;
                        dtBP.Rows.InsertAt(row, 0);
                        cbbMaNCC.SelectedIndex = 0;
                    }
                }
                cnMaNCC.Close();
            }
        }
    }
}
