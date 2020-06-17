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
    public partial class DoiMK : Form
    {
        public DoiMK()
        {
            InitializeComponent();
            loadcbbMaNV();
        }
        string sCnnStr = @"Data Source=DESKTOP-89VADTR\SQLEXPRESS;Initial Catalog=NMCNPM;Integrated Security=True";


        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMKcu.Text = string.Empty;
            txtMKmoi.Text = string.Empty;

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

                        cbbNV.DisplayMember = "TenNV";
                        cbbNV.ValueMember = "MaNV";
                        cbbNV.DataSource = dtNV;
                        row["TenNV"] = "Chọn Nhân viên";
                        row["MaNV"] = 0;
                        dtNV.Rows.InsertAt(row, 0);
                        cbbNV.SelectedIndex = 0;
                    }
                }
                cnMaNV.Close();
            }
        }

        private void btnDoi_Click(object sender, EventArgs e)
        {
            using (SqlConnection cnNV = new SqlConnection(sCnnStr))
            {
                cnNV.Open();
                using (SqlCommand cmNV = new SqlCommand(sCnnStr))
                {
                    cmNV.Connection = cnNV;
                    cmNV.CommandType = CommandType.StoredProcedure;
                    cmNV.CommandText = "sp_updateMKNV";
                    cmNV.Parameters.AddWithValue("@sMaNhanVien", cbbNV.SelectedValue.ToString());
                    cmNV.Parameters.AddWithValue("@MKcu", txtMKcu.Text);
                    cmNV.Parameters.AddWithValue("@MKmoi", txtMKmoi.Text);


                    int iRow = (int)cmNV.ExecuteNonQuery();
                    if (iRow > 0)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                }
                cnNV.Close();
            }
        }
    }
}
