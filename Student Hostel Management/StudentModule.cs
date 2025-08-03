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
    public partial class StudentModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBconnect dbcon = new DBconnect();
        SqlDataReader dr;
        Student student;

        public StudentModule()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadRoom();
            //student = st;
        }

        public void LoadRoom()
        {
            cboRoom.Items.Clear();
            cboRoom.DataSource = dbcon.GetTable("SELECT * FROM tbRoom WHERE occupied < capacity AND status = 'Available'");
            cboRoom.DisplayMember = "roomNo";
            cboRoom.ValueMember = "id";
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Clear()
        {
            txtRollNo.Clear();
            txtPhNo.Clear();
            txtName.Clear();
            txtMajor.Clear();
            cboRoom.SelectedIndex = 0;
            txtAddress.Clear();

            txtRollNo.Enabled = true;
            txtRollNo.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure want to save this Student?", "Save Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();

                    // insert student
                    cmd = new SqlCommand("INSERT INTO tbStudent (rollNo, name, major, rid, phNo, address) VALUES (@rollNo, @name, @major, @rid, @phNo, @address)", cn);
                    cmd.Parameters.AddWithValue("@rollNo", txtRollNo.Text);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@major", txtMajor.Text);
                    cmd.Parameters.AddWithValue("@rid", cboRoom.SelectedValue);
                    cmd.Parameters.AddWithValue("@phNo", txtPhNo.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.ExecuteNonQuery();

                    // Update occupied count (+1)
                    SqlCommand cmd2 = new SqlCommand("UPDATE tbRoom SET occupied = occupied + 1 WHERE id = @rid", cn);
                    cmd2.Parameters.AddWithValue("@rid", cboRoom.SelectedValue);
                    cmd2.ExecuteNonQuery();
                    cn.Close();

                    // Check if occupied == capacity => then set status = 'Unavailable'
                    SqlCommand cmd3 = new SqlCommand("SELECT capacity, occupied FROM tbRoom WHERE id = @rid", cn);
                    cmd3.Parameters.AddWithValue("@rid", cboRoom.SelectedValue);
                    dr = cmd3.ExecuteReader();

                    if (dr.Read())
                    {
                        int capacity = Convert.ToInt32(dr["capacity"]);
                        int occupied = Convert.ToInt32(dr["occupied"]);
                        dr.Close();

                        if (occupied == capacity)
                        {
                            SqlCommand cmd4 = new SqlCommand("UPDATE tbRoom SET status = 'Unavailable' WHERE id = @rid", cn);
                            cmd4.Parameters.AddWithValue("@rid", cboRoom.SelectedValue);
                            cmd4.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        dr.Close();
                    }

                    MessageBox.Show("Student has been saved successfully.", "Save Student");
                    Clear();
                    //btnSave.Enabled = true;
                    //btnUpdate.Enabled = false;
                }
                student.LoadStudent();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
