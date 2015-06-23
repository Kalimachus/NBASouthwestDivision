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
using System.IO;

namespace BadgerTech
{
    public partial class Commissioner : Form
    {
        int x = 0;
        public Commissioner()
        {
            InitializeComponent();
        }

      
     

     
        public void Commissioner_Load(object sender, EventArgs e)
        {
            x = 0;
            btnSchedule.Visible = false;
            btnDivision.Visible = false;
            btnCoach.Visible = false;
            btnTeam.Visible = false;
            btnLogOut.Visible = false;
            tmrImage.Enabled = true;
            
        }

      

        public void btnSchedule_Click(object sender, EventArgs e)
        {
            //Load edit form with schedule information
            this.Hide();
            EditSchedule frmEdit = new EditSchedule();
            frmEdit.radSchedule.Checked = true;
            frmEdit.ShowDialog();
            this.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {//Logs the user out
                this.Close();
            }
            
        }

       

        private void Commissioner_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Reloads main form when this form is closed
            frmMainPage.current.Show();
        }

        public void tmrImage_Tick(object sender, EventArgs e)
        {
            //while (x <= 4)
            //Timer to make the buttons appear
                x++;
                switch (x)
                {
                    case 1:
                        {
                            btnSchedule.Visible = true;
                            break;
                        }
                    case 2:
                        {
                            btnDivision.Visible = true;
                            break;
                        }
                    case 3:
                        {
                            btnCoach.Visible = true;
                            break;
                        }
                    case 4:
                        {
                            btnTeam.Visible = true;
                            break;
                        }
                    case 5:
                        {
                            btnLogOut.Visible = true;
                            break;
                        }
                    default:
                        {
                            tmrImage.Enabled = false;
                            break;
                        }
                }
            
        }

        private void btnDivision_Click(object sender, EventArgs e)
        { //load edit form with the division text box
            this.Hide();
            EditSchedule frmEdit = new EditSchedule();
            frmEdit.dgvEdit.Visible = false;
            frmEdit.grpSelection.Visible = false;
            frmEdit.btnDelete.Visible = false;
            frmEdit.txtEdit.Visible = true;
            frmEdit.ShowDialog();
            this.Show();
        }

        private void btnCoach_Click(object sender, EventArgs e)
        { //Load edit form with coaches information
            this.Hide();
            EditSchedule frmEdit = new EditSchedule();
            frmEdit.radCoach.Checked = true;
            frmEdit.ShowDialog();
            this.Show();
        }

        private void btnTeam_Click(object sender, EventArgs e)
        {
            //Load Edit form with players info
            this.Hide();
            EditSchedule frmEdit = new EditSchedule();
            frmEdit.radPlayer.Checked = true;
            frmEdit.ShowDialog();
            this.Show();
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            //Load messages form
            Messages frmMessage = new Messages();
            frmMessage.Show();
        }

       
       

       

       
      
      

    
    }
}
