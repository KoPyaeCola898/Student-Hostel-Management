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

namespace Student_Hostel_Management
{
    public partial class Policy : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBconnect dbcon = new DBconnect();
        SqlDataReader dr;

        public Policy()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadRules();
        }

        public void LoadRules()
        {
            int i = 0;
            dgvRule.Rows.Clear();
            cmd = new SqlCommand("SELECT * FROM tbRule ORDER BY ruDate DESC", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvRule.Rows.Add(i, dr["ruid"].ToString(), dr["ruleDes"].ToString(), Convert.ToDateTime(dr["ruDate"]));
                dgvRule.Columns[3].DefaultCellStyle.Format = "dd-MM-yyyy"; // Format the date column
            }
            dr.Close();
            cn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PolicyModule module = new PolicyModule(this);
            module.btnSave.Enabled = true;
            module.btnUpdate.Enabled = false;
            module.ShowDialog();
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvRule.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Rule?", "Delete Rule", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("DELETE FROM tbRule WHERE ruid LIKE '" + dgvRule[1, e.RowIndex].Value.ToString() + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Rule has been successfully deleted.", "Delete Rule", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (colName == "Edit")
            {
                PolicyModule module = new PolicyModule(this);
                module.lblId.Text = dgvRule[1, e.RowIndex].Value.ToString();
                module.txtRule.Text = dgvRule[2, e.RowIndex].Value.ToString();

                // DateTimePicker value
                if (dgvRule[3, e.RowIndex].Value != DBNull.Value)
                {
                    module.dtAddTime.Value = Convert.ToDateTime(dgvRule[3, e.RowIndex].Value);
                }
                module.btnSave.Enabled = false;
                module.btnUpdate.Enabled = true;
                module.ShowDialog();
            }
            LoadRules();
        }
    }
}
