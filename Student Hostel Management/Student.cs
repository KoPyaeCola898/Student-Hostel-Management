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
            dgvStudent.Rows.Clear();
            cmd = new SqlCommand("SELECT s.stid, s.rollNo, s.name, s.major, r.roomNo, s.phNo, s.address FROM tbStudent AS s INNER JOIN tbRoom AS r ON r.id = s.rid WHERE CONCAT(s.rollNo, s.name, s.major, r.roomNo) LIKE '%" + txtSearch.Text + "%'", cn);
            cn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvStudent.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StudentModule module = new StudentModule(this);
            module.btnSave.Enabled = true;
            module.btnUpdate.Enabled = false;
            module.ShowDialog();
        }

        private void dgvStudent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvStudent.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                StudentModule student = new StudentModule(this);
                student.lblId.Text = dgvStudent.Rows[e.RowIndex].Cells[1].Value.ToString();
                student.txtRollNo.Text = dgvStudent.Rows[e.RowIndex].Cells[2].Value.ToString();
                student.txtName.Text = dgvStudent.Rows[e.RowIndex].Cells[3].Value.ToString();
                student.txtMajor.Text = dgvStudent.Rows[e.RowIndex].Cells[4].Value.ToString();
                student.cboRoom.Text = dgvStudent.Rows[e.RowIndex].Cells[5].Value.ToString();
                student.txtPhNo.Text = dgvStudent.Rows[e.RowIndex].Cells[6].Value.ToString();
                student.txtAddress.Text = dgvStudent.Rows[e.RowIndex].Cells[7].Value.ToString();

                //int studentId = Convert.ToInt32(dgvStudent.Rows[e.RowIndex].Cells[1].Value);
                cn.Open();
                SqlCommand cmdp = new SqlCommand("Select * From tbParent WHERE sid LIKE '" + student.lblId.Text + "'", cn);
                SqlDataReader drp = cmdp.ExecuteReader();
                if (drp.Read())
                {
                    student.txtfName.Text = drp["fname"].ToString();
                    student.txtfPhno.Text = drp["fphno"].ToString();
                    student.txtfAddress.Text = drp["faddress"].ToString();
                }
                cn.Close();
                drp.Close();

                student.btnSave.Enabled = false;
                student.btnUpdate.Enabled = true;
                student.ShowDialog();
            }
            else if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to Romove this Student?", "Remove Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();

                    cmd = new SqlCommand("DELETE FROM tbStudent WHERE stid LIKE '" + dgvStudent[1, e.RowIndex].Value.ToString() + "'", cn);
                    cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("DELETE FROM tbParent WHERE sid LIKE '" + dgvStudent[1, e.RowIndex].Value.ToString() + "'", cn);
                    cmd2.ExecuteNonQuery();

                    cn.Close();
                    MessageBox.Show("Student has been successfully Removed.", "Remove Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            LoadStudent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadStudent();
        }
    }
}
