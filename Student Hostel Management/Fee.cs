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

namespace Student_Hostel_Management
{
    public partial class Fee : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlCommand cmd2 = new SqlCommand();
        SqlCommand cmd3 = new SqlCommand();
        SqlCommand cmd4 = new SqlCommand();
        DBconnect dbcon = new DBconnect();
        SqlDataReader dr;
        SqlDataReader dr2;

        public Fee()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            dgvFee.Rows.Clear();
            LoadAdmissionFee();
            LoadMonthlyFee();
            CheckMonthlyFee();
        }

        public void LoadAdmissionFee()
        {
            int i = dgvFee.Rows.Count;
            cmd = new SqlCommand("SELECT s.rollNo, s.name, r.roomNo, a.status FROM tbAdFee AS a INNER JOIN tbStudent AS s ON a.sid = s.stid INNER JOIN tbRoom AS r ON s.rid = r.id WHERE a.status = 'Unpaid'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvFee.Rows.Add(i, dr["rollNo"].ToString(), dr["name"].ToString(), dr["roomNo"].ToString(), "Admission", "-", dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        public void LoadMonthlyFee()
        {
            int i = dgvFee.Rows.Count;
            cmd2 = new SqlCommand("SELECT s.rollNo, s.name, r.roomNo, m.feeMonth, m.status FROM tbMFee AS m INNER JOIN tbStudent AS s ON m.sid = s.stid INNER JOIN tbRoom AS r ON s.rid = r.id WHERE m.status = 'Unpaid'", cn);
            cn.Open();
            dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                i++;
                dgvFee.Rows.Add(i, dr2["rollNo"].ToString(), dr2["name"].ToString(), dr2["roomNo"].ToString(), "Monthly", Convert.ToDateTime(dr2["feeMonth"]), dr2["status"].ToString());
                dgvFee.Columns[5].DefaultCellStyle.Format = "MM-yyyy"; // Format the date column
            }
            dr2.Close();
            cn.Close();
        }

        private void CheckMonthlyFee()
        {
            string currentMonth = DateTime.Now.ToString("yyyy-MM");
            cn.Open();
            string query = "SELECT Amount FROM MonthlyFee WHERE FORMAT(FeeMonth, 'yyyy-MM') = @month";
            cmd3 = new SqlCommand(query, cn);
            cmd3.Parameters.AddWithValue("@month", currentMonth);

            object result = cmd3.ExecuteScalar();

            if (result != null) // Fee already set for this month
            {
                txtMonthFee.Text = result.ToString();
                txtMonthFee.ReadOnly = true;
                btnOK.Visible = false; // Button hide
            }
            else
            {
                txtMonthFee.Clear();
                txtMonthFee.ReadOnly = false;
                btnOK.Visible = true;
            }
            cn.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMonthFee.Text))
            {
                MessageBox.Show("Please enter monthly fee.");
                return;
            }

            decimal fee = Convert.ToDecimal(txtMonthFee.Text);

            cn.Open();
            string query = "INSERT INTO MonthlyFee (FeeMonth, Amount) VALUES (@feeMonth, @amount)";
            cmd4 = new SqlCommand(query, cn);
            cmd4.Parameters.AddWithValue("@feeMonth", DateTime.Now.ToString("yyyy-MM-01"));
            cmd4.Parameters.AddWithValue("@amount", fee);
            cmd4.ExecuteNonQuery();

            cn.Close();

            MessageBox.Show("Monthly fee set successfully!");

            txtMonthFee.ReadOnly = true;
            btnOK.Visible = false;
        }

        private void Fee_Load(object sender, EventArgs e)
        {
            
        }
    }
}
