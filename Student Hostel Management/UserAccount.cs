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
    public partial class UserAccount : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBconnect dbcon = new DBconnect();
        SqlDataReader dr;

        public UserAccount()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
        }

        public void Clear()
        {
            txtName.Clear();
            txtPass.Clear();
            txtRePass.Clear();
            txtUsername.Clear();
            cbRole.Text = ""; // Clear the role selection
            txtUsername.Focus(); // Set focus back to the username field
        }

        private void btnAccSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPass.Text != txtRePass.Text) 
                {
                    MessageBox.Show("Passwords did not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }
                cn.Open(); 
                cmd = new SqlCommand("INSERT INTO tbUser (username, password, role, name) VALUES (@username, @password, @role, @name)", cn);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text); // Add username parameter
                cmd.Parameters.AddWithValue("@password", txtPass.Text); // Add password parameter
                cmd.Parameters.AddWithValue("@role", cbRole.Text); // Add role parameter
                cmd.Parameters.AddWithValue("@name", txtName.Text); // Add name parameter
                cmd.ExecuteNonQuery(); 
                cn.Close(); 
                MessageBox.Show("New account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // My Code: Show error message if an exception occurs
            }
        }

        private void btnAccCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
