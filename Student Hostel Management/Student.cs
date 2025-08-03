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
    public partial class Student : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBconnect dbcon = new DBconnect();
        SqlDataReader dr;

        public Student()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadStudent();
        }

        public void LoadStudent()
        {
            int i = 0;
            dgvRoom.Rows.Clear();
            cmd = new SqlCommand("SELECT s.stid, s.rollNo, s.name, s.major, r.roomNo, s.phNo, s.address FROM tbStudent AS s INNER JOIN tbRoom AS r ON r.id = s.rid WHERE CONCAT(s.rollNo, s.name, s.major, r.roomNo) LIKE '%" + txtSearch.Text + "%'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvRoom.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            cn.Close();
        }
    }
}
