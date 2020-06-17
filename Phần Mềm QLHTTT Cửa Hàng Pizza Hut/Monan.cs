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
    public partial class Monan : Form
    {
        public Monan()
        {
            InitializeComponent();
            resetForm();
            getMA();
        }

        private void Monan_Load(object sender, EventArgs e)
        {

        }
         string sCnnStr = @"Data Source=DESKTOP-89VADTR\SQLEXPRESS;Initial Catalog=NMCNPM;Integrated Security=True";
        
            
        
        private void resetForm()
        {
            txtMaMA.Enabled = false;
            txtTenMA.Enabled = false;
            txtDongia.Enabled = false;
            


            txtMaMA.Text = string.Empty;
            txtTenMA.Text = string.Empty;
            txtDongia.Text = string.Empty;
           


            btnThem.Enabled = true;
            btnCapnhat.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }
        private void getMA()
        {
            using (SqlConnection cnMA = new SqlConnection(sCnnStr))
            {
                cnMA.Open(); // mở kết nối
                using (SqlCommand cmMA = new SqlCommand(sCnnStr))
                {
                    cmMA.Connection = cnMA;
                    cmMA.CommandType = CommandType.StoredProcedure;
                    cmMA.CommandText = "sp_getMA";
                    using (SqlDataAdapter adapterMA= new SqlDataAdapter(cmMA))
                    {
                        DataTable dtMA = new DataTable();
                        adapterMA.Fill(dtMA);
                        if (dtMA.Rows.Count > 0)
                        {
                            dgvMA.DataSource = dtMA;
                        }
                    }
                }
                cnMA.Close();// đóng kết nối
            }
        }
        

        
     

       

        

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnLuu.Enabled = true;
            txtTenMA.Enabled = true;
            txtDongia.Enabled = true;
           
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection cnMA = new SqlConnection(sCnnStr))
            {
                cnMA.Open();
                using (SqlCommand cmMA = new SqlCommand(sCnnStr))
                {
                    cmMA.Connection = cnMA;
                    cmMA.CommandType = CommandType.StoredProcedure;
                    cmMA.CommandText = "sp_insertMA";
                    cmMA.Parameters.AddWithValue("@sTenMA", txtTenMA.Text);
                    cmMA.Parameters.AddWithValue("@Dongia", txtDongia.Text);

                    int iRow = (int)cmMA.ExecuteNonQuery();
                    if (iRow > 0)
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getMA();
                        resetForm();
                    }
                }
                cnMA.Close();
            }

        }

        private void btnCapnhat_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection cnMA = new SqlConnection(sCnnStr))
            {
                cnMA.Open();
                using (SqlCommand cmNCC = new SqlCommand(sCnnStr))
                {
                    cmNCC.Connection = cnMA;
                    cmNCC.CommandType = CommandType.StoredProcedure;
                    cmNCC.CommandText = "sp_updateMA";
                    cmNCC.Parameters.AddWithValue("@sMaMA", txtMaMA.Text);
                    cmNCC.Parameters.AddWithValue("@sTenMA", txtTenMA.Text);
                    cmNCC.Parameters.AddWithValue("@Dongia", txtDongia.Text);

                    int iRow = (int)cmNCC.ExecuteNonQuery();
                    if (iRow > 0)
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getMA();
                        resetForm();
                    }
                }
                cnMA.Close();
            }

        }

        private void btnHuy_Click_1(object sender, EventArgs e)
        {
            resetForm();
        }

        private void dgvMA_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sMaMA = null;

            int rowIndex = dgvMA.CurrentCell.RowIndex;
            if (rowIndex >= 0)
            {
                sMaMA = dgvMA.Rows[rowIndex].Cells[0].Value.ToString();
            }
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rowNhanVien = dgvMA.Rows[e.RowIndex];
                txtMaMA.Text = rowNhanVien.Cells[0].Value.ToString();
                txtTenMA.Text = rowNhanVien.Cells[1].Value.ToString();
                txtDongia.Text = rowNhanVien.Cells["Dongia"].Value.ToString();


                txtTenMA.Enabled = true;
                txtDongia.Enabled = true;
                


                btnCapnhat.Enabled = true;
                btnThem.Enabled = false;
            }
        }

       
    }
}
