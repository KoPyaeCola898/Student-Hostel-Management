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
    public partial class PolicyModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBconnect dbcon = new DBconnect();
        Policy policy;

        public PolicyModule(Policy pc)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            policy = pc;
        }

        public void Clear()
        {
            txtRule.Clear();
            txtRule.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure want to Add this Rule?", "Add Rule", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("INSERT INTO tbRule (ruleDes, ruDate) VALUES (@ruleDes, @ruDate)", cn);
                    cmd.Parameters.AddWithValue("@ruleDes", txtRule.Text);
                    cmd.Parameters.AddWithValue("@ruDate", dtAddTime.Value.ToString("d"));
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Rule has been saved successful.", "Save Room");
                    Clear();
                    this.Dispose();
                }
                policy.LoadRules();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
