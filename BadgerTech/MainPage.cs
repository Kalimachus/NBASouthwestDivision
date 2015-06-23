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

namespace BadgerTech
{
    public partial class frmMainPage : Form
    {
      
        public static frmMainPage current;

        public frmMainPage()
        {
            current = this;
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
           //closes the form
           this.Close();
            
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            //Loads the About form
            AboutBox frmAbout = new AboutBox();
            frmAbout.Show();
        }

       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Loads Login form
            Login frmLogin = new Login();
            frmLogin.Show();
            
          
        }
               

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            //Loads Schedule form
            this.Hide();
            Schedule frmSchedule = new Schedule();
            frmSchedule.lstTeams.SelectedItem = "All";
            frmSchedule.ShowDialog();
            this.Show();
        }

   
       

     

       

       



    }
}
