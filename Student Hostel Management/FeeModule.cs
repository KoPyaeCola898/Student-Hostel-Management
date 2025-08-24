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
    public partial class FeeModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBconnect dbcon = new DBconnect();
        SqlDataReader dr;

        public FeeModule()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure about this student paid this Monthly Fee?", "Paid Monthly Fee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("UPDATE tbMFee SET paidDate = @paidDate, status = 'Paid' WHERE sid = (SELECT stid FROM tbStudent WHERE rollNo = @rollNo) AND status = 'Unpaid'", cn);
                    cmd.Parameters.AddWithValue("@rollNo", txtRollNo.Text);
                    cmd.Parameters.AddWithValue("@paidDate", dtPaid.Value.ToString("d"));
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Monthly Fee has been paid successfully.", "Paid Monthly Fee");
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MainForm main = (MainForm)Application.OpenForms["MainForm"];
            main.btnFee.PerformClick();
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
