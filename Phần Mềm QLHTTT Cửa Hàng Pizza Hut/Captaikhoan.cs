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
    public partial class Captaikhoan : Form
    {
         string sCnnStr = @"Data Source=DESKTOP-89VADTR\SQLEXPRESS;Initial Catalog=NMCNPM;Integrated Security=True";
        public Captaikhoan()
        {
            InitializeComponent();
            loadcbbMaNV();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtQuyen.Text = string.Empty;

        }

        private void btnCapTaiKhoan_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnNV = new SqlConnection(sCnnStr))
            {
                cnNV.Open();
                using (SqlCommand cmNV = new SqlCommand(sCnnStr))
                {
                    cmNV.Connection = cnNV;
                    cmNV.CommandType = CommandType.StoredProcedure;
                    cmNV.CommandText = "sp_updateNV";
                    cmNV.Parameters.AddWithValue("@sMaNhanVien", cbbMaNV.SelectedValue.ToString());
                    cmNV.Parameters.AddWithValue("@Quyen", txtQuyen.Text);
                    
                    
                    int iRow = (int)cmNV.ExecuteNonQuery();
                    if (iRow > 0)
                    {
                        MessageBox.Show("Cấp quyền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                }
                cnNV.Close();
            }
        }
        private void loadcbbMaNV()
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
                        DataTable dtNV = new DataTable();
                        adapterNV.Fill(dtNV);
                        DataRow row = dtNV.NewRow();

                        cbbMaNV.DisplayMember = "TenNV";
                        cbbMaNV.ValueMember = "MaNV";
                        cbbMaNV.DataSource = dtNV;
                        row["TenNV"] = "Chọn Nhân viên";
                        row["MaNV"] = 0;
                        dtNV.Rows.InsertAt(row, 0);
                        cbbMaNV.SelectedIndex = 0;
                    }
                }
                cnMaNV.Close();
            }
        }
    }
}
