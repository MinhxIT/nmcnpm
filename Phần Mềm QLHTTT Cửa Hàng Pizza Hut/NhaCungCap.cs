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
    public partial class NhaCungCap : Form
    {
        string sCnnStr = @"Data Source=DESKTOP-89VADTR\SQLEXPRESS;Initial Catalog=NMCNPM;Integrated Security=True";
        public NhaCungCap()
        {
            InitializeComponent();
            resetForm();
            getNCC();
        }
        private void resetForm()
        {
            txtMaNCC.Enabled = false;
            txtTenNCC.Enabled = false;
            txtDiachi.Enabled = false;
            txtSDT.Enabled = false;


            txtMaNCC.Text = string.Empty;
            txtTenNCC.Text = string.Empty;
            txtDiachi.Text = string.Empty;
            txtSDT.Text = string.Empty;


            btnThem.Enabled = true;
            btnCapnhat.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void getNCC()
        {
            using (SqlConnection cnNCC = new SqlConnection(sCnnStr))
            {
                cnNCC.Open(); // mở kết nối
                using (SqlCommand cmNCC = new SqlCommand(sCnnStr))
                {
                    cmNCC.Connection = cnNCC;
                    cmNCC.CommandType = CommandType.StoredProcedure;
                    cmNCC.CommandText = "sp_getNCC";
                    using (SqlDataAdapter adapterNCC= new SqlDataAdapter(cmNCC))
                    {
                        DataTable dtNCC = new DataTable();
                        adapterNCC.Fill(dtNCC);
                        if (dtNCC.Rows.Count > 0)
                        {
                            dgvNCC.DataSource = dtNCC;
                        }
                    }
                }
                cnNCC.Close();// đóng kết nối
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtTenNCC.Enabled = true;
            txtDiachi.Enabled = true;
            txtSDT.Enabled = true;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnNCC = new SqlConnection(sCnnStr))
            {
                cnNCC.Open();
                using (SqlCommand cmNCC = new SqlCommand(sCnnStr))
                {
                    cmNCC.Connection = cnNCC;
                    cmNCC.CommandType = CommandType.StoredProcedure;
                    cmNCC.CommandText = "sp_insertNCC";
                    cmNCC.Parameters.AddWithValue("@sTenNCC", txtTenNCC.Text);
                    cmNCC.Parameters.AddWithValue("@sSDT", txtSDT.Text);
                    cmNCC.Parameters.AddWithValue("@sDiaChi", txtDiachi.Text);

                    int iRow = (int)cmNCC.ExecuteNonQuery();
                    if (iRow > 0)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getNCC();
                        resetForm();
                    }
                }
                cnNCC.Close();
            }

        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnNCC = new SqlConnection(sCnnStr))
            {
                cnNCC.Open();
                using (SqlCommand cmNCC = new SqlCommand(sCnnStr))
                {
                    cmNCC.Connection = cnNCC;
                    cmNCC.CommandType = CommandType.StoredProcedure;
                    cmNCC.CommandText = "sp_updateNCC";
                    cmNCC.Parameters.AddWithValue("@sMaNCC", txtMaNCC.Text);
                    cmNCC.Parameters.AddWithValue("@sTenNCC", txtTenNCC.Text);
                    cmNCC.Parameters.AddWithValue("@sSDT", txtSDT.Text);
                    cmNCC.Parameters.AddWithValue("@sDiaChi", txtDiachi.Text);

                    int iRow = (int)cmNCC.ExecuteNonQuery();
                    if (iRow > 0)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getNCC();
                        resetForm();
                    }
                }
                cnNCC.Close();
            }

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            resetForm();

        }

        private void dgvNCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sMaNCC = null;

            int rowIndex = dgvNCC.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {
                sMaNCC = dgvNCC.Rows[rowIndex].Cells[0].Value.ToString();
            }
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rowNhanVien = dgvNCC.Rows[e.RowIndex];
                txtMaNCC.Text = rowNhanVien.Cells[0].Value.ToString();
                txtTenNCC.Text = rowNhanVien.Cells[1].Value.ToString();
                txtSDT.Text = rowNhanVien.Cells["SDT"].Value.ToString();
                txtDiachi.Text = rowNhanVien.Cells["Diachi"].Value.ToString();


                txtTenNCC.Enabled = true;
                txtDiachi.Enabled = true;
                txtSDT.Enabled = true;


                btnCapnhat.Enabled = true;
                btnThem.Enabled = false;
            }
        }

    }
}
