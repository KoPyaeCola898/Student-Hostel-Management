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
    public partial class RollCall : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBconnect dbcon = new DBconnect();
        SqlDataReader dr;
        Staff staff;

        public RollCall(Staff st)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadData();
            staff = st;
        }

        public void LoadData()
        {
            int i = 0;
            dgvRollCall.Rows.Clear();
            cmd = new SqlCommand("SELECT s.rollNo, s.name, r.roomNo FROM tbStudent AS s INNER JOIN tbRoom AS r ON r.id = s.rid", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvRollCall.Rows.Add(i, dr["rollNo"].ToString(), dr["name"].ToString(), dr["roomNo"].ToString(), DateTime.Now, "Present");
                dgvRollCall.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy"; // Format the date column
            }
            dr.Close();
            cn.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to submit the attendance?", "Submit Attendance", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cn.Open();
                foreach (DataGridViewRow row in dgvRollCall.Rows)
                {
                    if (row.IsNewRow) continue;

                    string rollNo = row.Cells["rollNo"].Value.ToString();
                    string status = row.Cells["status"].Value.ToString();
                    DateTime attDate = Convert.ToDateTime(row.Cells["date"].Value);

                    // check student ID with roll number
                    SqlCommand sidCmd = new SqlCommand("SELECT stid FROM tbStudent WHERE rollNo=@rollNo", cn);
                    sidCmd.Parameters.AddWithValue("@rollNo", rollNo);
                    int sid = Convert.ToInt32(sidCmd.ExecuteScalar());

                    // Attendance insert
                    SqlCommand cmdAt = new SqlCommand("INSERT INTO tbAttendance (sid, attDate, status) VALUES (@sid, @attDate, @status)", cn);
                    cmdAt.Parameters.AddWithValue("@sid", sid);
                    cmdAt.Parameters.AddWithValue("@attDate", attDate);
                    cmdAt.Parameters.AddWithValue("@status", status);

                    try
                    {
                        cmdAt.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        // if Unique constraint happen ignore or update
                        if (ex.Number == 2627) // unique violation
                        {
                            string updateQuery = @"UPDATE tbAttendance SET status=@status WHERE sid=@sid AND attDate=@attDate";
                            SqlCommand updateCmd = new SqlCommand(updateQuery, cn);
                            updateCmd.Parameters.AddWithValue("@sid", sid);
                            updateCmd.Parameters.AddWithValue("@attDate", attDate);
                            updateCmd.Parameters.AddWithValue("@status", status);
                            updateCmd.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
                cn.Close();
                MessageBox.Show("Attendance Recorded Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
                staff.btnRollCall.Enabled = false; // Disable the Roll Call button after submission
                staff.btnAttendance.PerformClick(); // Refresh the Attendance form
            }
        }
    }
}
