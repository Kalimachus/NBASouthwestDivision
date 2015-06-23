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
using System.Security.Cryptography;
using System.IO;

namespace BadgerTech
{


    public partial class Login : Form
    {
        int intPID, intTeamID, intType = 0; //Holds PID and TeamID as integers to store into MyClass
        //PID is used to differentiate between players when calling for their profile information
        string Firstname, Lastname;
        bool blnLoginFlag = false;
        public Login()
        {
            InitializeComponent();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //closes the form
            this.Close();
        }


        public void btnEnter_Click(object sender, EventArgs e)
        {   
            

            //Login 
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            SqlConnection conn = new SqlConnection(Program.strConnection);
            conn.Open();
            try
            {
                SqlDataReader myReader = null;
                //Gets PID, Username, Password and TeamID from db 
                SqlCommand myCommand = new SqlCommand("Select PID, Firstname, Lastname, Username, TeamID, Hash, Salt from EntireDivision Where Username = @username", conn);

                try
                {
                    //SQL commands to avoid SQL injection vulnerabilities
                    myCommand.Parameters.AddWithValue("@username", txtUsername.Text);
                    myCommand.Parameters.AddWithValue("@password", txtPassword.Text);
                    intPID = int.Parse(((double)myCommand.ExecuteScalar()).ToString());
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        //Stores the correct password and the TeamID into variables
                        MyUser._TeamID = int.Parse(myReader["TeamID"].ToString());
                        intTeamID = MyUser._TeamID;
                        MyUser._Salt = myReader["Salt"].ToString();
                        MyUser._Hash = myReader["Hash"].ToString();
                        Firstname = myReader["Firstname"].ToString();
                        Lastname = myReader["Lastname"].ToString();
                        MyUser._Name = Firstname + ' ' + Lastname;
                    }

                    //pulls salt and hash. runs it through hash function and compares end values.
                    blnLoginFlag = PasswordManager.Verify(MyUser._Salt, txtPassword.Text);

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
            MyUser._PID = intPID;
            if (MyUser._PID == 1)
            {
                intType = 1;
            }
            if (MyUser._PID > 1 && MyUser._PID < 7)
            {
                intType = 2;
            }
            if (MyUser._PID > 6)
            {
                intType = 3;
            }

            // nest this case statment inside the login boolean statement -- kyle

            switch (intType) //Switch case based off of PID
            {
                case 1: //Commissioner
                    {
                        if (blnLoginFlag == true) //Checks password from DB
                        {
                            frmMainPage.current.Hide();//Hides Main Page
                            MyUser._Username = txtUsername.Text; //Assigns Username to Global Class Variable
                            MyUser._Password = txtPassword.Text; //Assigns the Password to a Glabal Class Variable
                            this.Close(); //closes the login form
                            Commissioner commissioner = new Commissioner(); //Instantiates the commissioner form
                            commissioner.Show(); //Displays the commissioner form
                            break;
                        }
                        else //Password doesnt match db
                        {
                            goto default; //jump to default case
                        }
                    }
                case 2: //Coaches
                     {
                        if (blnLoginFlag == true) //Checks password 
                        {
                            frmMainPage.current.Hide();
                            MyUser._Username = txtUsername.Text;
                            MyUser._Password = txtPassword.Text;
                            MyUser._TeamID = intTeamID;
                            switch (intTeamID) //Sets the teamname to a global class variable based off teamid
                            {
                                case 1:
                                    {
                                        MyUser._Teamname = "Mavericks";
                                        break;
                                    }
                                case 2:
                                    {
                                        MyUser._Teamname = "Rockets";
                                        break;
                                    }
                                case 3:
                                    {
                                        MyUser._Teamname = "Grizzlies";
                                        break;
                                    }
                                case 4:
                                    {
                                        MyUser._Teamname = "Pelicans";
                                        break;
                                    }
                                case 5:
                                    {
                                        MyUser._Teamname = "Spurs";
                                        break;
                                    }
                            }
                            this.Close();
                            Coach coach = new Coach(); //Instantiates the coach form
                            coach.Show();
                            break;
                        }
                        else //password is invalid
                        {
                            goto default;
                        }
                    }

                case 3: //Players
                   {
                        if (blnLoginFlag == true)
                        {
                            switch (intTeamID) //Sets the teamname to a global class variable based off teamid
                            {
                                case 1:
                                    {
                                        MyUser._Teamname = "Mavericks";
                                        break;
                                    }
                                case 2:
                                    {
                                        MyUser._Teamname = "Rockets";
                                        break;
                                    }
                                case 3:
                                    {
                                        MyUser._Teamname = "Grizzlies";
                                        break;
                                    }
                                case 4:
                                    {
                                        MyUser._Teamname = "Pelicans";
                                        break;
                                    }
                                case 5:
                                    {
                                        MyUser._Teamname = "Spurs";
                                        break;
                                    }
                            }
                            frmMainPage.current.Hide();
                            MyUser._TeamID = intTeamID;
                             this.Close();
                            Players play = new Players();
                            play.Show();
                            break;
                        }
                        else
                        {
                            goto default;
                        }
                    }
                default:
                    {
                        MessageBox.Show("Invalid Username or Password");
                        txtPassword.Clear();
                        txtUsername.Clear();
                        txtUsername.Focus();
                        break;
                    }

            }

        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clears the text boxes and resets the focus
            txtPassword.Clear();
            txtUsername.Clear();
            txtUsername.Focus();
        }

        private void lblForgot_Click(object sender, EventArgs e)
        {
            //User forgot password
            
            ForgotPass passrecover = new ForgotPass();
            passrecover.Show();
            this.Close();
            
        }

        private void lblNewAccount_Click(object sender, EventArgs e)
        {
            //Loads Account Creation form
            this.Hide();
            NewAccount frmNew = new NewAccount();
            frmNew.ShowDialog();
            this.Show();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        //encryption one time delete after
        #region devarea
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    List<string> Userpasswords = new List<string>();
        //    List<string> Usernames = new List<string>();
        //    int intPID = 1;
        //    int intIndex = 0;
        //    string strHash;
        //    string strSalt;



        //    SqlDataAdapter da = new SqlDataAdapter();
        //    SqlCommandBuilder cb = new SqlCommandBuilder(da);
        //    SqlConnection conn = new SqlConnection(Program.strConnection);
        //    SqlDataReader myReader = null;
        //    //Gets PID, Username, Password and TeamID from db 
        //    SqlCommand myCommand = new SqlCommand("Select PID, Username, password from EntireDivision", conn);

        //    conn.Open();
        //    try
        //    {
        //        //SQL commands to avoid SQL injection vulnerabilities
        //        myReader = myCommand.ExecuteReader();

        //        while (myReader.Read())
        //        {
        //            Userpasswords.Add(myReader["password"].ToString());
        //            Usernames.Add(myReader["username"].ToString());
        //        }

        //    }

        //    catch (SqlException SqlEx)
        //    {
        //        MessageBox.Show(SqlEx.Message);
        //    }
        //    conn.Close();


        //    SqlDataAdapter da2 = new SqlDataAdapter();
        //    SqlCommandBuilder cb2 = new SqlCommandBuilder(da2);
        //    SqlConnection conn2 = new SqlConnection(Program.strConnection);
        //    SqlDataReader secondreader;


        //    try
        //    {

        //        foreach (string thepassword in Userpasswords)
        //        {
        //            conn2.Open();
        //            strSalt = PasswordManager.CreateSalt(Usernames[intIndex]);
        //            strHash = PasswordManager.HashPassword(strSalt, Userpasswords[intIndex]);
        //            SqlCommand writeEncrypts = new SqlCommand("Update EntireDivision Set Hash ='" + strHash + "',salt='" + strSalt + "' where PID =" + intPID.ToString(), conn2);
        //            secondreader = writeEncrypts.ExecuteReader();
        //            while (secondreader.Read())
        //            {

        //            }
        //            conn2.Close();
        //            intIndex++;
        //            intPID++;

        //        }


        //    }

        //    catch (SqlException SqlEx)
        //    {
        //        MessageBox.Show(SqlEx.Message);
        //    }
        //    conn.Close();

        //}
#endregion
        //encryption one time, delete after
        
    }
}
