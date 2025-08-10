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

        public StudentModule(Student st)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadRoom();
            student = st;
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
            txtfName.Clear();
            txtfPhno.Clear();
            txtfAddress.Clear();

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
                    cmd = new SqlCommand(@"INSERT INTO tbStudent (rollNo, name, major, rid, phNo, address) VALUES (@rollNo, @name, @major, @rid, @phNo, @address); SELECT SCOPE_IDENTITY();", cn);
                    cmd.Parameters.AddWithValue("@rollNo", txtRollNo.Text);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@major", txtMajor.Text);
                    cmd.Parameters.AddWithValue("@rid", cboRoom.SelectedValue);
                    cmd.Parameters.AddWithValue("@phNo", txtPhNo.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    //cmd.ExecuteNonQuery();

                    int newSid = Convert.ToInt32(cmd.ExecuteScalar()); // Student id

                    // Insert parent 
                    SqlCommand cmdParent = new SqlCommand("INSERT INTO tbParent (sid, fname, fphno, faddress) VALUES (@sid, @fname, @fphno, @faddress)", cn);
                    cmdParent.Parameters.AddWithValue("@sid", newSid);
                    cmdParent.Parameters.AddWithValue("@fname", txtfName.Text);
                    cmdParent.Parameters.AddWithValue("@fphno", txtfPhno.Text);
                    cmdParent.Parameters.AddWithValue("@faddress", txtfAddress.Text);
                    cmdParent.ExecuteNonQuery();

                    // Update occupied count (+1)
                    SqlCommand cmd2 = new SqlCommand("UPDATE tbRoom SET occupied = occupied + 1 WHERE id = @rid", cn);
                    cmd2.Parameters.AddWithValue("@rid", cboRoom.SelectedValue);
                    cmd2.ExecuteNonQuery();

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
                    cn.Close();

                    MessageBox.Show("Student has been saved successfully.", "Save Student");
                    Clear();
                    this.Dispose();
                }
                student.LoadStudent();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure want to update this Student?", "Update Student", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();

                    // Get old room ID
                    SqlCommand getOldRoom = new SqlCommand("SELECT rid FROM tbStudent WHERE stid = @id", cn);
                    getOldRoom.Parameters.AddWithValue("@id", Convert.ToInt32(lblId.Text));
                    object result = getOldRoom.ExecuteScalar();
                    int oldRoomId = Convert.ToInt32(result);
                    int newRoomId = Convert.ToInt32(cboRoom.SelectedValue);

                    // Update Student Info
                    cmd = new SqlCommand("UPDATE tbStudent SET rollNo = @rollNo, name = @name, major = @major, rid = @rid, phNo = @phNo, address = @address WHERE stid = @stid", cn);
                    cmd.Parameters.AddWithValue("@rollNo", txtRollNo.Text);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@major", txtMajor.Text);
                    cmd.Parameters.AddWithValue("@rid", newRoomId);
                    cmd.Parameters.AddWithValue("@phNo", txtPhNo.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@stid", lblId.Text);
                    cmd.ExecuteNonQuery();

                    // Update Parent Info
                    SqlCommand cmdparent = new SqlCommand("UPDATE tbParent SET fname = @fname, fphno = @fphno, faddress = @faddress WHERE sid = @sid", cn);
                    cmdparent.Parameters.AddWithValue("@fname", txtfName.Text);
                    cmdparent.Parameters.AddWithValue("@fphno", txtfPhno.Text);
                    cmdparent.Parameters.AddWithValue("@faddress", txtfAddress.Text);
                    cmdparent.Parameters.AddWithValue("@sid", lblId.Text);
                    cmdparent.ExecuteNonQuery();

                    // Room Change Logic
                    if (oldRoomId != newRoomId)
                    {
                        // Old Room - occupied minus 1
                        SqlCommand cmdOld = new SqlCommand("UPDATE tbRoom SET occupied = occupied - 1 WHERE id = @oldId", cn);
                        cmdOld.Parameters.AddWithValue("@oldId", oldRoomId);
                        cmdOld.ExecuteNonQuery();

                        // New Room - occupied plus 1
                        SqlCommand cmdNew = new SqlCommand("UPDATE tbRoom SET occupied = occupied + 1 WHERE id = @newId", cn);
                        cmdNew.Parameters.AddWithValue("@newId", newRoomId);
                        cmdNew.ExecuteNonQuery();

                        // -- Check New Room full?
                        SqlCommand checkNewRoom = new SqlCommand("SELECT capacity, occupied FROM tbRoom WHERE id = @newId", cn);
                        checkNewRoom.Parameters.AddWithValue("@newId", newRoomId);
                        SqlDataReader reader = checkNewRoom.ExecuteReader();
                        if (reader.Read())
                        {
                            int capacity = Convert.ToInt32(reader["capacity"]);
                            int occupied = Convert.ToInt32(reader["occupied"]);
                            reader.Close();

                            if (occupied == capacity)
                            {
                                SqlCommand setUnavailable = new SqlCommand("UPDATE tbRoom SET status = 'Unavailable' WHERE id = @newId", cn);
                                setUnavailable.Parameters.AddWithValue("@newId", newRoomId);
                                setUnavailable.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            reader.Close();
                        }

                        // -- Check Old Room open?
                        SqlCommand checkOldRoom = new SqlCommand("SELECT capacity, occupied FROM tbRoom WHERE id = @oldId", cn);
                        checkOldRoom.Parameters.AddWithValue("@oldId", oldRoomId);
                        SqlDataReader reader2 = checkOldRoom.ExecuteReader();
                        if (reader2.Read())
                        {
                            int capacity = Convert.ToInt32(reader2["capacity"]);
                            int occupied = Convert.ToInt32(reader2["occupied"]);
                            reader2.Close();

                            if (occupied < capacity)
                            {
                                SqlCommand setAvailable = new SqlCommand("UPDATE tbRoom SET status = 'Available' WHERE id = @oldId", cn);
                                setAvailable.Parameters.AddWithValue("@oldId", oldRoomId);
                                setAvailable.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            reader2.Close();
                        }
                    }

                    cn.Close();
                    MessageBox.Show("Student updated successfully!", "Update Student");

                    Clear();
                    student.LoadStudent();
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
