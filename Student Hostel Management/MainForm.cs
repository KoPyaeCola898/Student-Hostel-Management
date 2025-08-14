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
    public partial class MainForm : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        DBconnect dbcon = new DBconnect();
        SqlDataReader dr;
        public string _pass;

        public MainForm()
        {
            InitializeComponent();
            //CustomizeDesing();
            cn = new SqlConnection(dbcon.myConnection());
            cn.Open();
            //MessageBox.Show("Database is connected!");
        }

        #region panelSlide
        //private void CustomizeDesing()
        //{
        //    panelSubSetting.Visible = false;
        //}

        //private void HideSubMenu()
        //{
        //    if (panelSubSetting.Visible == true)
        //        panelSubSetting.Visible = false;
        //}

        //private void ShowSubMenu(Panel submenu)
        //{
        //    if (submenu.Visible == false)
        //    {
        //        HideSubMenu();
        //        submenu.Visible = true;
        //    }
        //    else
        //    {
        //        submenu.Visible = false;
        //    }
        //}
        #endregion panelSlide

        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            lblTitle.Text = childForm.Text; // Set the title label to the child form's title
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            openChildForm(new Room());
            
        }

        private void btnStudents_Click(object sender, EventArgs e)
        {
            openChildForm(new Student());
            
        }

        private void btnFee_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRollCall_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            openChildForm(new UserAccount(this));
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Logout Application?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
            }
        }

        private void btnParent_Click(object sender, EventArgs e)
        {
            openChildForm(new Parent());
            
        }

        private void btnPolicy_Click(object sender, EventArgs e)
        {
            openChildForm(new Policy());
        }
    }
}
