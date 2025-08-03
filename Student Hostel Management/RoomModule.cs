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
    public partial class RoomModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBconnect dbcon = new DBconnect();
        Room room;

        public RoomModule(Room rm)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            room = rm;
        }


        public void Clear()
        {
            txtRoomNo.Clear();
            txtRoomNo.Focus();
            txtOccupied.Text = "0";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure want to Add this Room?", "Add Room", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("INSERT INTO tbRoom (roomNo, capacity, occupied, status) VALUES (@roomNo, @capacity, @occupied, @status)", cn);
                    cmd.Parameters.AddWithValue("@roomNo", txtRoomNo.Text);
                    cmd.Parameters.AddWithValue("@capacity", UDCapacity.Value);
                    cmd.Parameters.AddWithValue("@occupied", txtOccupied.Text);
                    cmd.Parameters.AddWithValue("@status", cboStatus.Text);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Room has been saved successful.", "Save Room");
                    Clear();
                    //btnSave.Enabled = true;
                    //btnUpdate.Enabled = false;
                }
                room.LoadRoom();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int Capacity0 = (int)UDCapacity.Value;
            int Occupied0 = int.Parse(txtOccupied.Text);

            if (Capacity0 < Occupied0)
            {
                MessageBox.Show("Capacity can't be less than currently occupied students.", "Invalid Capacity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to update this Room?", "Update Room!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cn.Open();
                cmd = new SqlCommand("UPDATE tbRoom SET roomNo = @roomNo, capacity = @capacity, status = @status WHERE id LIKE'" + lblId.Text + "'", cn);
                cmd.Parameters.AddWithValue("@roomNo", txtRoomNo.Text);
                cmd.Parameters.AddWithValue("@capacity", UDCapacity.Value);
                cmd.Parameters.AddWithValue("@status", cboStatus.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Room has been successfully updated.", "Room Update");
                Clear();
                this.Dispose();// To close this form after update data
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void RoomModule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }
    }
}
