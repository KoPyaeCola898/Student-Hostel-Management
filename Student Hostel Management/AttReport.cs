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
    public partial class AttReport : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBconnect dbcon = new DBconnect();
        SqlDataReader dr;

        public AttReport()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadAtt();
        }

        public void LoadAtt()
        {
            int i = 0;
            dgvAtt.Rows.Clear();
            string joinQuery = "SELECT s.rollNo, s.name, r.roomNo, a.attdate, a.status FROM tbAttendance AS a INNER JOIN tbStudent AS s ON a.sid = s.stid INNER JOIN tbRoom AS r ON s.rid = r.id WHERE attdate BETWEEN '" + dtFrom.Value + "' AND '" + dtTo.Value + "'";
            cmd = new SqlCommand(joinQuery, cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvAtt.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), Convert.ToDateTime(dr["attdate"]), dr[4].ToString());
                dgvAtt.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy"; // Format the date column
            }
            dr.Close();
            cn.Close();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            LoadAtt();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            LoadAtt();
        }
    }
}
