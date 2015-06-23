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
    public partial class Players : Form
    {
        public Players()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {//Logs the user out
                this.Close();
            }
       
        }

        private void Players_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Reloads main form when this form is closed
            frmMainPage.current.Show();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            this.Hide();
            Schedule TeamSchedule = new Schedule();
            TeamSchedule.lstTeams.SelectedIndex = MyUser._TeamID;
            TeamSchedule.ShowDialog();
            this.Show();
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditInfo editplayer = new EditInfo();
            editplayer.Show();
        }

        private void Players_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = MyUser._Name + "'s Page";
            switch(MyUser._TeamID) //sets team logo image based on teamid
            {
                case 1:
                    {
                        picTeamLogo.Image = Properties.Resources.Dallas_Mavericks;
                        break;
                    }
                case 2:
                    {
                        picTeamLogo.Image = Properties.Resources.Houston_Rockets;
                        break;
                    }         
                case 3:
                    {
                        picTeamLogo.Image = Properties.Resources.Memphis_Grizzlies;
                        break;
                    }
                case 4:
                    {
                        picTeamLogo.Image = Properties.Resources.New_Orleans_Pelicans;
                        break;
                    }
                case 5:
                    {
                        picTeamLogo.Image = Properties.Resources.San_Antonio_Spurs;
                        break;
                    }
            }
        }

        private void btnTeam_Click(object sender, EventArgs e)
        {
            //Views team infomation that contains no Personal Identifiable Information
            this.Hide();
            ViewTeam frmViewTeam = new ViewTeam();
            frmViewTeam.btnUpdate.Visible = false;
            SqlConnection conn = new SqlConnection(Program.strConnection);
            SqlDataAdapter da = new SqlDataAdapter("Select FirstName, LastName, PP, GS, MIN, PPG, OFFR, DEFR, RPG, APG, SPG, BPG, TPG, FPG, PER, FGM, FGA, 3PM, 3PA, FTM, FTA, 2PM, 2PA, PPS, GP from EntireDivision inner join " + MyUser._Teamname + " on " + MyUser._Teamname + ".pid = entiredivision.pid", conn);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "Player");
            conn.Close();
            frmViewTeam.dgvTeam.DataSource = ds;
            frmViewTeam.dgvTeam.DataMember = "Player";

            frmViewTeam.ShowDialog();
            this.Show();

        }

        private void Players_Activated(object sender, EventArgs e)
        {
            //Connect to Azure DB
            SqlConnection con = new SqlConnection(Program.strConnection);
            //Select the Profilepic based on PID 
            SqlCommand command = new SqlCommand("Select ProfilePic from EntireDivision where PID = " + MyUser._PID, con);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet("EntireDivision");
            //Code to convert binary code to image using memorystream
            try
            {
                byte[] ProfilePic = new byte[0];
                da.Fill(ds, "Image");
                DataRow myRow;
                myRow = ds.Tables["Image"].Rows[0];
                ProfilePic = (byte[])myRow["ProfilePic"];
                MemoryStream ms = new MemoryStream(ProfilePic);
                picProfile.Image = Image.FromStream(ms);
            }
            catch
            { }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
