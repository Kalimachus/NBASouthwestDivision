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
using System.Reflection;

namespace BadgerTech
{
    public partial class EditSchedule : Form
    {
        
        string strFName, strLName, strTeamID, strHome, strAway, strID, teamName, strPID;
        DateTime strTime;
       
       
        public EditSchedule()
        {
            InitializeComponent();
        }

        public void EditSchedule_Load(object sender, EventArgs e)
        {//Form load
            if (txtEdit.Visible == true) //If commissioner clicked on edit division
            {
                this.BackgroundImage = Properties.Resources.Division1;
                using (StreamReader sr = new StreamReader("about.txt"))
                {
                    //load the about.txt file from the solution
                    string aboutbox = sr.ReadToEnd();

                    txtEdit.Text = aboutbox;
                }
            }
            else //commissioner clicks on any other edit button, loads appropriate datagridview
            {
                if (radSchedule.Checked == true)
                {
                    LoadScheduleDGV();
                }
                if (radCoach.Checked == true)
                {
                    LoadCoachDGV();
                }
                if (radPlayer.Checked == true)
                {
                    LoadPlayerDGV();
                }
            }


        }

        public void dgvEdit_SelectionChanged(object sender, EventArgs e)
        {

            try //If cells are not null
            {
                foreach (DataGridViewRow DataRow in dgvEdit.SelectedRows)
                {
                    if (radSchedule.Checked == true)
                    {
                        //Display selected row data into text boxes and assign values to temporary variables
                        strID = DataRow.Cells[0].Value.ToString();
                        strHome = DataRow.Cells[1].Value.ToString();
                        strAway = DataRow.Cells[2].Value.ToString();
                        strTime = DateTime.Parse(DataRow.Cells[3].Value.ToString());
                    }
                    if (radCoach.Checked == true || radPlayer.Checked == true)
                    {//Display selected row data into text boxes and assign values to temporary variables
                        strPID = DataRow.Cells[0].Value.ToString();
                        strFName = DataRow.Cells[1].Value.ToString();
                        strLName = DataRow.Cells[2].Value.ToString();
                        strTeamID = DataRow.Cells[3].Value.ToString();

                        //Sets the variable teamName to a specific team in order to update that team's table
                        switch (int.Parse(strTeamID))
                        {
                            case 1:
                                {
                                    teamName = "Mavericks";
                                    break;
                                }
                            case 2:
                                {
                                    teamName = "Rockets";
                                    break;
                                }
                            case 3:
                                {
                                    teamName = "Grizzlies";
                                    break;
                                }
                            case 4:
                                {
                                    teamName = "Pelicans";
                                    break;
                                }
                            case 5:
                                {
                                    teamName = "Spurs";
                                    break;
                                }
                        }
                    }
                }
            }
            catch
            {
                //do nothing
            }

        }

        public void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(Program.strConnection);
            SqlDataAdapter da = new SqlDataAdapter();
            if (radSchedule.Checked == true)
            {
                SqlDataAdapter daCoach = new SqlDataAdapter();
                SqlCommandBuilder cb = new SqlCommandBuilder(daCoach);
                SqlConnection connCoach = new SqlConnection(Program.strConnection);
                connCoach.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand;
                //Update or insert a new game into the schedule
                if (strID != "")
                {
                    myCommand = new SqlCommand("Update Schedule Set HomeTeam = @Home, AwayTeam = @Away, GameTime = @Time where ID = @ID", connCoach);
                    myCommand.Parameters.AddWithValue("@ID", strID);
                }
                else
                {
                     myCommand = new SqlCommand("Insert into Schedule (HomeTeam, AwayTeam, Gametime) Values (@Home, @Away, @Time)", connCoach);
                }
                   
                
                myCommand.Parameters.AddWithValue("@Home", strHome);
                myCommand.Parameters.AddWithValue("@Away", strAway);
                myCommand.Parameters.AddWithValue("@Time", strTime.ToString());
                myReader = myCommand.ExecuteReader();
                conn.Close();
            }
            if (radCoach.Checked == true)
            {//Change coaches name or team id
                SqlDataAdapter daCoach = new SqlDataAdapter();
                SqlCommandBuilder cb = new SqlCommandBuilder(daCoach);
                SqlConnection connCoach = new SqlConnection(Program.strConnection);
                connCoach.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("Update EntireDivision Set FirstName = @FirstName, LastName = @LastName, TeamID = @TeamID  where PID = " + strTeamID + 1, connCoach);
                myCommand.Parameters.AddWithValue("@FirstName", strFName);
                myCommand.Parameters.AddWithValue("@LastName", strLName);
                myCommand.Parameters.AddWithValue("@TeamID", strTeamID);
                myReader = myCommand.ExecuteReader();
                conn.Close();
               
            }
            if (radPlayer.Checked == true)
            { //Modify players name or make trades to another team
                SqlDataAdapter daCoach = new SqlDataAdapter();
                SqlCommandBuilder cb = new SqlCommandBuilder(daCoach);
                SqlConnection connCoach = new SqlConnection(Program.strConnection);
                connCoach.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("Update EntireDivision Set FirstName = @FirstName, LastName = @LastName, TeamID = @TeamID  where PID = " + strPID, connCoach);
                myCommand.Parameters.AddWithValue("@FirstName", strFName);
                myCommand.Parameters.AddWithValue("@LastName", strLName);
                myCommand.Parameters.AddWithValue("@TeamID", strTeamID);
                myReader = myCommand.ExecuteReader();
                myReader.Close();
                SqlCommand myCommand1 = new SqlCommand("Update " + teamName + " Set Player = @Name where PID = " + strPID, connCoach);
                myCommand1.Parameters.AddWithValue("@Name", strFName + ' ' + strLName);
                myReader = myCommand1.ExecuteReader();
                myReader.Close();

                conn.Close();
            }
            if(txtEdit.Visible == true)
            { //Display the information that goes in the about form for editing
                using(StreamWriter sw = new StreamWriter("about.txt"))
                {
                    sw.Write(txtEdit.Text);
            }
        }
          
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            if (radSchedule.Checked == true)
            {//Deletes from Schedule table where all three columns match
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                SqlConnection conn = new SqlConnection(Program.strConnection);
                conn.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("Delete from Schedule Where HomeTeam = @Home and AwayTeam = @Away and GameTime = @Time", conn);
                myCommand.Parameters.AddWithValue("@Home", strHome);
                myCommand.Parameters.AddWithValue("@Away", strAway);
                myCommand.Parameters.AddWithValue("@Time", strTime);
                myReader = myCommand.ExecuteReader();
                conn.Close();
                //refreshes the Datagridview
                LoadScheduleDGV();
             }
            if (radPlayer.Checked == true)
            {
                //Code to delete from the Team Table
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                SqlConnection conn = new SqlConnection(Program.strConnection);
                conn.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("Delete from " + teamName + " Where Player = @Name", conn);
                myCommand.Parameters.AddWithValue("@Name", strFName + ' ' + strLName);
                myReader = myCommand.ExecuteReader();
                myReader.Close();
                
                //Then delete from the EntireDivision table
                SqlCommand myCommand1 = new SqlCommand("Delete from entiredivision Where FirstName = @First and LastName = @Last and TeamID = @Team", conn);
                myCommand1.Parameters.AddWithValue("@First", strFName);
                myCommand1.Parameters.AddWithValue("@Last", strLName);
                myCommand1.Parameters.AddWithValue("@Team", strTeamID);
                myReader = myCommand1.ExecuteReader();
                conn.Close();
                
                //reloads the Datagridview
                LoadPlayerDGV();
            }
        }

        public void LoadScheduleDGV()
        {//Pulls the schedule information from the database
            SqlConnection conn = new SqlConnection(Program.strConnection);
                SqlDataAdapter da = new SqlDataAdapter("Select ID, HomeTeam, AwayTeam, GameTime from Schedule", conn);
                DataSet ds = new DataSet();
                conn.Open();
                da.Fill(ds, "Schedule");
                conn.Close();
                dgvEdit.DataSource = ds;
                dgvEdit.DataMember = "Schedule";
                dgvEdit.Size = new Size(528, 220);
           //hides the ID column
                dgvEdit.Columns[0].Visible = false;
                dgvEdit.Columns[1].Width = 150;
                dgvEdit.Columns[2].Width = 150;
                dgvEdit.Columns[3].Width = 208;
                dgvEdit.Location = new Point(436, 167);
           //Sets the Background
                this.BackgroundImage = Properties.Resources.Schedule;


        }

        public void LoadCoachDGV()
       {//Pulls the coaches data from the database
           SqlConnection conn = new SqlConnection(Program.strConnection);
           SqlDataAdapter da = new SqlDataAdapter("Select PID, FirstName, LastName, TeamID from EntireDivision Where PID between 2 and 6", conn);
           DataSet ds = new DataSet();
           conn.Open();
           da.Fill(ds, "Coach");
           conn.Close();
           dgvEdit.DataSource = ds;
           dgvEdit.DataMember = "Coach";
           dgvEdit.Size = new Size(300, 120);
           dgvEdit.Columns[0].Visible = false;
           dgvEdit.Columns[1].Width = 100;
           dgvEdit.Columns[2].Width = 100;
           dgvEdit.Columns[3].Width = 80;
           dgvEdit.Location = new Point(544, 185);
           this.BackgroundImage = Properties.Resources.CoachBck;
           btnDelete.Visible = false;
       }

        public void LoadPlayerDGV()
        {//Code to fill Datagrid with Players information
           SqlConnection conn = new SqlConnection(Program.strConnection);
           SqlDataAdapter da = new SqlDataAdapter("Select PID, FirstName, LastName, TeamID from EntireDivision Where PID > 6 order by TeamID ASC", conn);
           DataSet ds = new DataSet();
           conn.Open();
           
           da.Fill(ds, "Player");
           conn.Close();
           dgvEdit.DataSource = ds;
           dgvEdit.DataMember = "Player";
            //Resizes the Datagrid 
           dgvEdit.Size = new Size(300, 120);
            //Hides the PID column
           dgvEdit.Columns[0].Visible = false;
           dgvEdit.Columns[1].Width = 100;
           dgvEdit.Columns[2].Width = 100;
           dgvEdit.Columns[3].Width = 80;
           dgvEdit.Location = new Point(544, 185);
            //Sets the background
           this.BackgroundImage = Properties.Resources.team1;
           





        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Doesn't save any changes
            this.Close();
        }

        
    }
}
