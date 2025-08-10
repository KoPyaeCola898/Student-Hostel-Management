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
    public partial class ParentModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBconnect dbcon = new DBconnect();
        SqlDataReader dr;
        Parent parent;

        public ParentModule(Parent pt)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            parent = pt;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Clear()
        {
            txtPhNo.Clear();
            txtName.Clear();
            txtAddress.Clear();

            txtName.Enabled = true;
            txtName.Focus();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure want to update this Parent Data?", "Update Parent", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();

                    // Update Parent Info
                    cmd = new SqlCommand("UPDATE tbParent SET fname = @fname, fphno = @fphno, faddress = @faddress WHERE ptid = @ptid", cn);
                    cmd.Parameters.AddWithValue("@fname", txtName.Text);
                    cmd.Parameters.AddWithValue("@fphno", txtPhNo.Text);
                    cmd.Parameters.AddWithValue("@faddress", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@ptid", lblId.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Parent info updated successfully!", "Update Parent");
                    Clear();
                    parent.LoadParent();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
