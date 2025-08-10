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
    public partial class Parent : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBconnect dbcon = new DBconnect();
        SqlDataReader dr;

        public Parent()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadParent();
        }

        public void LoadParent()
        {
            int i = 0;
            dgvParent.Rows.Clear();
            cmd = new SqlCommand("SELECT p.ptid, s.rollNo, s.name, p.fname, p.fphno, p.faddress FROM tbParent AS p INNER JOIN tbStudent AS s ON s.stid = p.sid WHERE CONCAT(s.rollNo, s.name, p.fname) LIKE '%" + txtSearch.Text + "%'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvParent.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void dgvParent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvParent.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                ParentModule parent = new ParentModule(this);
                parent.lblId.Text = dgvParent.Rows[e.RowIndex].Cells[1].Value.ToString();
                parent.txtStRollNo.Text = dgvParent.Rows[e.RowIndex].Cells[2].Value.ToString();
                parent.txtStName.Text = dgvParent.Rows[e.RowIndex].Cells[3].Value.ToString();
                parent.txtName.Text = dgvParent.Rows[e.RowIndex].Cells[4].Value.ToString();
                parent.txtPhNo.Text = dgvParent.Rows[e.RowIndex].Cells[5].Value.ToString();
                parent.txtAddress.Text = dgvParent.Rows[e.RowIndex].Cells[6].Value.ToString();

                parent.btnUpdate.Enabled = true;
                parent.ShowDialog();
            }
            LoadParent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadParent();
        }
    }
}
