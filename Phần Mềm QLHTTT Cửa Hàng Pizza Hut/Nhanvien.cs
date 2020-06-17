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
    public partial class Nhanvien : Form
    {
        string sCnnStr = @"Data Source=VANLINHPC\SQLEXPRESS;Initial Catalog=NMCNPM;Integrated Security=True";
        public Nhanvien()
        {
            InitializeComponent();
            getNV();
            loadMaBPCombobox();
            resetForm();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nhanvien_Load(object sender, EventArgs e)
        {

        }
        private void resetForm(){
            txtMaNV.Enabled=false;
            txtTenNV.Enabled = false;
            txtDiachi.Enabled = false;
            txtSDT.Enabled = false;
            dNgaysinh.Enabled = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;

            txtMaNV.Text = string.Empty;
            txtTenNV.Text = string.Empty;
            txtDiachi.Text = string.Empty;
            txtSDT.Text = string.Empty;
            dNgaysinh.Value = DateTime.Now;
            

            btnThem.Enabled = true;
            btnCapnhat.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void getNV()
        {
            using (SqlConnection cnEmployee = new SqlConnection(sCnnStr))
            {
                cnEmployee.Open(); // mở kết nối
                using (SqlCommand cmEmployee = new SqlCommand(sCnnStr))
                {
                    cmEmployee.Connection = cnEmployee;
                    cmEmployee.CommandType = CommandType.StoredProcedure;
                    cmEmployee.CommandText = "sp_getEmployee";
                    using (SqlDataAdapter adapterEmployee = new SqlDataAdapter(cmEmployee))
                    {
                        DataTable dtEmployee = new DataTable();
                        adapterEmployee.Fill(dtEmployee);
                        if (dtEmployee.Rows.Count > 0)
                        {
                            dgvNhanVien.DataSource = dtEmployee;
                        }
                    }
                }
                cnEmployee.Close();// đóng kết nối
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtTenNV.Enabled = true;
            txtDiachi.Enabled = true;
            txtSDT.Enabled = true;
            dNgaysinh.Enabled = true;
            rdbNam.Enabled = true;
            rdbNu.Enabled = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            resetForm();
        }
        private void dgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 2:
                    if (e.Value is bool)
                    {
                        bool gioiTinh = (bool)e.Value;
                        e.Value = gioiTinh ? "Nam" : "Nữ";
                    }
                    break;
            }
        }
        private void loadMaBPCombobox()
        {
            using (SqlConnection cnMaBP = new SqlConnection(sCnnStr))
            {
                cnMaBP.Open();
                using (SqlCommand cmMaBP = new SqlCommand(sCnnStr))
                {
                    cmMaBP.Connection = cnMaBP;
                    cmMaBP.CommandType = CommandType.StoredProcedure;
                    cmMaBP.CommandText = "sp_getBP";
                    using (SqlDataAdapter adapterBP = new SqlDataAdapter(cmMaBP))
                    {
                        DataTable dtBP = new DataTable();
                        adapterBP.Fill(dtBP);
                        DataRow row = dtBP.NewRow();

                        cbbMaBP.DisplayMember = "TenBP";
                        cbbMaBP.ValueMember = "MaBP";
                        cbbMaBP.DataSource = dtBP;
                        row["TenBP"] = "Chọn Bộ Phận";
                        row["MaBP"] = 0;
                        dtBP.Rows.InsertAt(row, 0);
                        cbbMaBP.SelectedIndex = 0;
                    }
                }
                cnMaBP.Close();
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnEmployees = new SqlConnection(sCnnStr))
            {
                cnEmployees.Open();
                using (SqlCommand cmEmployees = new SqlCommand(sCnnStr))
                {
                    cmEmployees.Connection = cnEmployees;
                    cmEmployees.CommandType = CommandType.StoredProcedure;
                    cmEmployees.CommandText = "sp_insertEmplyees";
                    cmEmployees.Parameters.AddWithValue("@sTenNhanVien", txtTenNV.Text);
                    cmEmployees.Parameters.AddWithValue("@sSDT", txtSDT.Text);
                    cmEmployees.Parameters.AddWithValue("@sDiaChi", txtDiachi.Text);
                    cmEmployees.Parameters.AddWithValue("@bGioiTinh", rdbNam.Checked ? true : false);
                    cmEmployees.Parameters.AddWithValue("@dNgaySinh", dNgaysinh.Value.ToString());
                    cmEmployees.Parameters.AddWithValue("@MaBP", cbbMaBP.SelectedValue.ToString());
                    int iRow = (int)cmEmployees.ExecuteNonQuery();
                    if (iRow > 0)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getNV();
                        resetForm();
                    }
                }
                cnEmployees.Close();
            }
        }
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sMaNhanVien = null;

            int rowIndex = dgvNhanVien.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {
                sMaNhanVien = dgvNhanVien.Rows[rowIndex].Cells[0].Value.ToString();
            }
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rowNhanVien = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = rowNhanVien.Cells[0].Value.ToString();
                txtTenNV.Text = rowNhanVien.Cells[1].Value.ToString();
                if ((bool)dgvNhanVien.CurrentRow.Cells[2].Value == true)
                {
                    rdbNam.Checked = true;
                }
                else if ((bool)dgvNhanVien.CurrentRow.Cells[2].Value == false)
                {
                    rdbNu.Checked = true;
                }
                dNgaysinh.Value = Convert.ToDateTime(rowNhanVien.Cells["dNgaysinh"].Value.ToString());
                txtSDT.Text = rowNhanVien.Cells["SDT"].Value.ToString();
                txtDiachi.Text = rowNhanVien.Cells["Diachi"].Value.ToString();
                cbbMaBP.Text = rowNhanVien.Cells["TenBP"].Value.ToString();

                txtTenNV.Enabled = true;
                txtDiachi.Enabled = true;
                txtSDT.Enabled = true;
                dNgaysinh.Enabled = true;
                rdbNam.Enabled = true;
                rdbNu.Enabled = true;

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
                    cmEmployees.CommandText = "sp_updateEmployees";
                    cmEmployees.Parameters.AddWithValue("@sMaNhanVien", txtMaNV.Text);
                    cmEmployees.Parameters.AddWithValue("@sTenNhanVien", txtTenNV.Text);
                    cmEmployees.Parameters.AddWithValue("@sSDT", txtSDT.Text);
                    cmEmployees.Parameters.AddWithValue("@sDiaChi", txtDiachi.Text);
                    cmEmployees.Parameters.AddWithValue("@bGioiTinh", rdbNam.Checked ? true : false);
                    cmEmployees.Parameters.AddWithValue("@dNgaySinh", dNgaysinh.Value.ToString());
                    cmEmployees.Parameters.AddWithValue("@MaBP", cbbMaBP.SelectedValue.ToString());
                    int iRow = (int)cmEmployees.ExecuteNonQuery();
                    if (iRow > 0)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getNV();
                        resetForm();
                    }
                }
                cnEmployees.Close();
            }

        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sMaNhanVien = null;

            int rowIndex = dgvNhanVien.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {
                sMaNhanVien = dgvNhanVien.Rows[rowIndex].Cells[0].Value.ToString();
            }
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rowNhanVien = dgvNhanVien.Rows[e.RowIndex];
                txtMaNV.Text = rowNhanVien.Cells[0].Value.ToString();
                txtTenNV.Text = rowNhanVien.Cells[1].Value.ToString();
                if ((bool)dgvNhanVien.CurrentRow.Cells[2].Value == true)
                {
                    rdbNam.Checked = true;
                }
                else if ((bool)dgvNhanVien.CurrentRow.Cells[2].Value == false)
                {
                    rdbNu.Checked = true;
                }
                dNgaysinh.Value = Convert.ToDateTime(rowNhanVien.Cells["Ngaysinh"].Value.ToString());
                txtSDT.Text = rowNhanVien.Cells["SDT"].Value.ToString();
                txtDiachi.Text = rowNhanVien.Cells["Diachi"].Value.ToString();
                cbbMaBP.Text = rowNhanVien.Cells["MaBP"].Value.ToString();

                txtTenNV.Enabled = true;
                txtDiachi.Enabled = true;
                txtSDT.Enabled = true;
                dNgaysinh.Enabled = true;
                rdbNam.Enabled = true;
                rdbNu.Enabled = true;

                btnCapnhat.Enabled = true;
                btnThem.Enabled = false;

            }
        }

        private void cbbMaBP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
