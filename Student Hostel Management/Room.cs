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
    public partial class Room : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBconnect dbcon = new DBconnect();
        SqlDataReader dr;

        public Room()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadRoom();
        }

        public void LoadRoom()
        {
            int i = 0;
            dgvRoom.Rows.Clear();
            cn.Open();
            cmd = new SqlCommand("SELECT * FROM tbRoom ORDER BY roomNo", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvRoom.Rows.Add(i, dr["id"].ToString(), dr["roomNo"].ToString(), dr["capacity"].ToString(), dr["occupied"].ToString(), dr["status"].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
