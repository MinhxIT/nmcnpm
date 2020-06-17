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
    public partial class Khachhang : Form
    {
        string sCnnStr = @"Data Source=DESKTOP-89VADTR\SQLEXPRESS;Initial Catalog=NMCNPM;Integrated Security=True";
        public Khachhang()
        {
            InitializeComponent();
            resetForm();
            getKH();
        }
        private void resetForm()
        {
            txtMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            txtDiachi.Enabled = false;
            txtSDT.Enabled = false;
            

            txtMaKH.Text = string.Empty;
            txtTenKH.Text = string.Empty;
            txtDiachi.Text = string.Empty;
            txtSDT.Text = string.Empty;
            

            btnThem.Enabled = true;
            btnCapnhat.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void getKH()
        {
            using (SqlConnection cnKH = new SqlConnection(sCnnStr))
            {
                cnKH.Open(); // mở kết nối
                using (SqlCommand cmKH = new SqlCommand(sCnnStr))
                {
                    cmKH.Connection = cnKH;
                    cmKH.CommandType = CommandType.StoredProcedure;
                    cmKH.CommandText = "sp_getKH";
                    using (SqlDataAdapter adapterKH = new SqlDataAdapter(cmKH))
                    {
                        DataTable dtKH = new DataTable();
                        adapterKH.Fill(dtKH);
                        if (dtKH.Rows.Count > 0)
                        {
                            dgvKhachHang.DataSource = dtKH;
                        }
                    }
                }
                cnKH.Close();// đóng kết nối
            }
        }
        
          
        private void btnHuy_Click(object sender, EventArgs e)
        {
            resetForm();
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
              btnLuu.Enabled = true;
            txtTenKH.Enabled = true;
            txtDiachi.Enabled = true;
            txtSDT.Enabled = true;
        
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection cnEmployees = new SqlConnection(sCnnStr))
            {
                cnEmployees.Open();
                using (SqlCommand cmEmployees = new SqlCommand(sCnnStr))
                {
                    cmEmployees.Connection = cnEmployees;
                    cmEmployees.CommandType = CommandType.StoredProcedure;
                    cmEmployees.CommandText = "sp_insertKH";
                    cmEmployees.Parameters.AddWithValue("@sTenKH", txtTenKH.Text);
                    cmEmployees.Parameters.AddWithValue("@sSDT", txtSDT.Text);
                    cmEmployees.Parameters.AddWithValue("@sDiaChi", txtDiachi.Text);

                    int iRow = (int)cmEmployees.ExecuteNonQuery();
                    if (iRow > 0)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getKH();
                        resetForm();
                    }
                }
                cnEmployees.Close();
            }
        }

        private void dgvKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sMaKhachHang = null;

            int rowIndex = dgvKhachHang.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {
                sMaKhachHang = dgvKhachHang.Rows[rowIndex].Cells[0].Value.ToString();
            }
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rowNhanVien = dgvKhachHang.Rows[e.RowIndex];
                txtMaKH.Text = rowNhanVien.Cells[0].Value.ToString();
                txtTenKH.Text = rowNhanVien.Cells[1].Value.ToString();
                txtSDT.Text = rowNhanVien.Cells["SDT"].Value.ToString();
                txtDiachi.Text = rowNhanVien.Cells["Diachi"].Value.ToString();
                

                txtTenKH.Enabled = true;
                txtDiachi.Enabled = true;
                txtSDT.Enabled = true;
               

                btnCapnhat.Enabled = true;
                btnThem.Enabled = false;
            }
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnEmployees = new SqlConnection(sCnnStr))
            {
                cnEmployees.Open();
                using (SqlCommand cmEmployees = new SqlCommand(sCnnStr))
                {
                    cmEmployees.Connection = cnEmployees;
                    cmEmployees.CommandType = CommandType.StoredProcedure;
                    cmEmployees.CommandText = "sp_updateKH";
                    cmEmployees.Parameters.AddWithValue("@sMaKH", txtMaKH.Text);
                    cmEmployees.Parameters.AddWithValue("@sTenKH", txtTenKH.Text);
                    cmEmployees.Parameters.AddWithValue("@sSDT", txtSDT.Text);
                    cmEmployees.Parameters.AddWithValue("@sDiaChi", txtDiachi.Text);
                    
                    int iRow = (int)cmEmployees.ExecuteNonQuery();
                    if (iRow > 0)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getKH();
                        resetForm();
                    }
                }
                cnEmployees.Close();
            }
        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            resetForm();
        }
        
    }
}
