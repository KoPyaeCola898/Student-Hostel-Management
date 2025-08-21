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
        DBconnect dbcon = new DBconnect();
        SqlDataReader dr;

        public Fee()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
        }

        public void LoadAdmissionFee()
        {
            //int i = 0;
            //dgvFee.Rows.Clear();
            //cmd = new SqlCommand("SELECT s.rollNo, s.name, r.roomNo, s.phNo, s.address FROM tbStudent AS s INNER JOIN tbRoom AS r ON r.id = s.rid WHERE CONCAT(s.rollNo, s.name, s.major, r.roomNo) LIKE '%" + txtSearch.Text + "%'", cn);
            //cn.Open();
            //dr = cmd.ExecuteReader();
            //while (dr.Read())
            //{
            //    i++;
            //    dgvStudent.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            //}
            //dr.Close();
            //cn.Close();
        }
    }
}
