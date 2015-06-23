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
    public partial class Coach : Form
    {
        MyUser MyClass = new MyUser();
        public Coach()
        {
            InitializeComponent();
        }

        private void btnSchedule_Click(object sender, EventArgs e)
        {
            //Instanciates the schedule form
            this.Hide();
            Schedule frmSchedule = new Schedule();
            frmSchedule.lstTeams.SelectedIndex = (MyUser._TeamID);
            frmSchedule.ShowDialog();
            this.Show();

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {//Logs the user out
                this.Close();
            }
        }

        private void Coach_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Reloads main form when this form is closed
            frmMainPage.current.Show();
        }

        private void btnMessages_Click(object sender, EventArgs e)
        {
            //Loads Messages Form
            Messages frmMessage = new Messages();
            frmMessage.Show();
        }

       

        private void btnPlayers_Click(object sender, EventArgs e)
        {
            //Loads view team form
            this.Hide();
            ViewTeam frmViewTeam = new ViewTeam();
            //Hides the update button on the view team form
            frmViewTeam.btnUpdate.Visible = false;
            //Pulls the data from the DB based on the teamID
            SqlConnection conn = new SqlConnection(Program.strConnection);
            SqlDataAdapter da = new SqlDataAdapter("Select FirstName, LastName, PhoneNumber, PP, GS, MIN, PPG, OFFR, DEFR, RPG, APG, SPG, BPG, TPG, FPG, PER, FGM, FGA, 3PM, 3PA, FTM, FTA, 2PM, 2PA, PPS, GP from EntireDivision inner join "+ MyUser._Teamname + " on " +MyUser._Teamname+".pid = entiredivision.pid", conn);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "Player");
            conn.Close();
            frmViewTeam.dgvTeam.DataSource = ds;
            frmViewTeam.dgvTeam.DataMember = "Player";
            frmViewTeam.ShowDialog();
            this.Show();
        }

        private void btnPlayerEdit_Click(object sender, EventArgs e)
        {
            //Same form at view team, but Update button is visible
            this.Hide();
            ViewTeam frmViewTeam = new ViewTeam();
            frmViewTeam.btnUpdate.Visible = true;
            SqlConnection conn = new SqlConnection(Program.strConnection);
            SqlDataAdapter da = new SqlDataAdapter("Select " + MyUser._Teamname + ".PID, FirstName, LastName, PhoneNumber, PP, GS, MIN, PPG, OFFR, DEFR, RPG, APG, SPG, BPG, TPG, FPG, PER, FGM, FGA, FTM, FTA, PPS, GP from EntireDivision inner join " + MyUser._Teamname + " on " + MyUser._Teamname + ".pid = entiredivision.pid", conn);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "Player");
            conn.Close();
            frmViewTeam.dgvTeam.DataSource = ds;
            frmViewTeam.dgvTeam.DataMember = "Player";
            frmViewTeam.dgvTeam.Columns[0].Visible = false;
            frmViewTeam.ShowDialog();
            this.Show();
        }

        private void btnPersonalEdit_Click(object sender, EventArgs e)
        {
            EditInfo frmEdit = new EditInfo();
            frmEdit.Show();
        }

        private void Coach_Load(object sender, EventArgs e)
        {
            //Pulls information from DB on formload
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            SqlConnection conn = new SqlConnection(Program.strConnection);
            conn.Open();
            try
            {
                SqlDataReader myReader = null;
                //Gets PID, Name, PhoneNumber, Address, City, State, and Zip from db 
                SqlCommand myCommand = new SqlCommand("Select PID, PhoneNumber, Address, City, State, Zipcode, Profilepic from EntireDivision Where PID = " + MyUser._PID, conn);

                try
                {
                    //SQL commands to avoid SQL injection vulnerabilities

                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        //Stores the correct password and the TeamID into variables
                        lblPhone.Text = myReader["PhoneNumber"].ToString();
                        lblAddress.Text = myReader["Address"].ToString();
                        lblCityStateZip.Text = (myReader["City"].ToString() + ", " + myReader["State"].ToString() + " " + myReader["Zipcode"].ToString());
                       
                    }
                }
                catch
                {
                    //do nothing
                }
            }
            catch (SqlException ex)
            {
                //Catches any sql error
                MessageBox.Show(ex.Message);
            }
            conn.Close();

            try
            {
                //Select the Profilepic based on PID 
                SqlCommand command = new SqlCommand("Select ProfilePic from EntireDivision where PID = " + MyUser._PID, conn);
                SqlDataAdapter da2 = new SqlDataAdapter(command);
                DataSet ds = new DataSet("EntireDivision");
                //Code to convert binary code to image using memorystream
                byte[] ProfilePic = new byte[0];
                da2.Fill(ds, "Image");
                DataRow myRow;
                myRow = ds.Tables["Image"].Rows[0];
                ProfilePic = (byte[])myRow["ProfilePic"];
                MemoryStream ms = new MemoryStream(ProfilePic);
                picCoach.Image = Image.FromStream(ms);
            }
            catch
            {
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        }
    }
