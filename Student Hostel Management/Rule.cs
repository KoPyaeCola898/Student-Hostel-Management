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
    public partial class Rule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBconnect dbcon = new DBconnect();
        SqlDataReader dr;

        public Rule()
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
    }
}
