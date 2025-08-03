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
            RoomModule module = new RoomModule(this);
            module.btnSave.Enabled = true;
            module.btnUpdate.Enabled = false;
            module.ShowDialog();
        }

        private void dgvRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvRoom.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this Room?", "Delete Room", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cmd = new SqlCommand("DELETE FROM tbRoom WHERE id LIKE '" + dgvRoom[1, e.RowIndex].Value.ToString() + "'", cn);
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Room has been successfully deleted.", "Delete Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (colName == "Edit")
            {
                RoomModule module = new RoomModule(this);
                module.lblId.Text = dgvRoom[1, e.RowIndex].Value.ToString();
                module.txtRoomNo.Text = dgvRoom[2, e.RowIndex].Value.ToString();
                module.UDCapacity.Value = int.Parse(dgvRoom[3, e.RowIndex].Value.ToString());
                module.txtOccupied.Text = dgvRoom[4, e.RowIndex].Value.ToString();
                module.cboStatus.Text = dgvRoom[5, e.RowIndex].Value.ToString();
                module.btnSave.Enabled = false;
                module.btnUpdate.Enabled = true;
                module.ShowDialog();
            }
            LoadRoom();
        }
    }
}
