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
    public partial class Schedule : Form
    {
        int dgsize;
        public Schedule()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //closes the form
            this.Close();
        }

        

        private void lstTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Changes the DataGridView based on the selected team

            switch (lstTeams.SelectedIndex)
            {
                case 0: //All selected
                    {
                        picTeamLogo.Image = null; //No Image displayed
                        //Connection to Azure DB
                        SqlConnection conn = new SqlConnection(Program.strConnection);
                        //SQL command to select data from Schedule table for all teams
                        SqlDataAdapter da = new SqlDataAdapter("Select HomeTeam, AwayTeam, ScoreHome, ScoreAway, GameTime from Schedule", conn);
                        DataSet ds = new DataSet();
                        conn.Open();
                        da.Fill(ds, "Schedule");
                        conn.Close();
                        dgvSchedule.DataSource = ds;
                        dgvSchedule.DataMember = "Schedule";
                        //Resizes the DGV based on number of rows
                        dgsize = (dgvSchedule.RowCount + 1) * 20;
                        dgvSchedule.Size = new Size(570, dgsize+3);
                        break;
                    }
                case 1://Dallas Mavericks Selected
                    {
                        //Display logo and record
                        picTeamLogo.Image = Properties.Resources.Dallas_Mavericks;
                        SqlConnection conn = new SqlConnection(Program.strConnection);
                        SqlDataAdapter da = new SqlDataAdapter("Select HomeTeam, AwayTeam, ScoreHome, ScoreAway, GameTime from Schedule Where HomeTeam like '%aver%' or AwayTeam like '%aver%'", conn);
                        DataSet ds = new DataSet();
                        conn.Open();
                        da.Fill(ds, "Schedule");
                        conn.Close();
                        dgvSchedule.DataSource = ds;
                        dgvSchedule.DataMember = "Schedule";
                        dgsize = (dgvSchedule.RowCount + 1) * 20;
                        dgvSchedule.Size = new Size(570, dgsize+3);
                        break;
                    }
                case 2://Houston Rockets
                    {
                        picTeamLogo.Image = Properties.Resources.Houston_Rockets;
                        SqlConnection conn = new SqlConnection(Program.strConnection);
                        SqlDataAdapter da = new SqlDataAdapter("Select HomeTeam, AwayTeam, ScoreHome, ScoreAway, GameTime from Schedule Where HomeTeam like '%rocket%' or AwayTeam like '%rocket%'", conn);
                        DataSet ds = new DataSet();
                        conn.Open();
                        da.Fill(ds, "Schedule");
                        conn.Close();
                        dgvSchedule.DataSource = ds;
                        dgvSchedule.DataMember = "Schedule";
                        dgsize = (dgvSchedule.RowCount + 1) * 20;
                        dgvSchedule.Size = new Size(570, dgsize+3);
                        break;
                    }
                case 3://Memphis Grizzlies
                    {
                        
                        picTeamLogo.Image = Properties.Resources.Memphis_Grizzlies;
                       SqlConnection conn = new SqlConnection(Program.strConnection);
                        SqlDataAdapter da = new SqlDataAdapter("Select HomeTeam, AwayTeam, ScoreHome, ScoreAway, GameTime from Schedule Where HomeTeam like '%grizz%' or AwayTeam like '%grizz%'", conn);
                        DataSet ds = new DataSet();
                        conn.Open();
                        da.Fill(ds, "Schedule");
                        conn.Close();
                        dgvSchedule.DataSource = ds;
                        dgvSchedule.DataMember = "Schedule";
                        dgsize = (dgvSchedule.RowCount + 1) * 20;
                        dgvSchedule.Size = new Size(570, dgsize+3);
                        break;
                    }
                case 4: //New Orleans Pelicans
                    {
                        picTeamLogo.Image = Properties.Resources.New_Orleans_Pelicans;
                        SqlConnection conn = new SqlConnection(Program.strConnection);
                        SqlDataAdapter da = new SqlDataAdapter("Select HomeTeam, AwayTeam, ScoreHome, ScoreAway, GameTime from Schedule Where HomeTeam like '%pelic%' or AwayTeam like '%pelic%'", conn);
                        DataSet ds = new DataSet();
                        conn.Open();
                        da.Fill(ds, "Schedule");
                        conn.Close();
                        dgvSchedule.DataSource = ds;
                        dgvSchedule.DataMember = "Schedule";
                        dgsize = (dgvSchedule.RowCount + 1) * 20;
                        dgvSchedule.Size = new Size(570, dgsize+3);
                        break; 
                    }
                case 5://San Antonio Spurs
                    {
                        
                        picTeamLogo.Image = Properties.Resources.San_Antonio_Spurs;
                        SqlConnection conn = new SqlConnection(Program.strConnection);
                        SqlDataAdapter da = new SqlDataAdapter("Select HomeTeam, AwayTeam, ScoreHome, ScoreAway, GameTime from Schedule Where HomeTeam like '%spur%' or AwayTeam like '%spur%'", conn);
                        DataSet ds = new DataSet();
                        conn.Open();
                        da.Fill(ds, "Schedule");
                        conn.Close();
                        dgvSchedule.DataSource = ds;
                        dgvSchedule.DataMember = "Schedule";
                        dgsize = (dgvSchedule.RowCount + 1) * 20;
                        dgvSchedule.Size = new Size(570, dgsize+3);
                        break;   
                    }
                

            }

        }

        public void Schedule_Load(object sender, EventArgs e)
        {
            //Sets focus to the listbox on the formload
            lstTeams.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
                              
    }
}
