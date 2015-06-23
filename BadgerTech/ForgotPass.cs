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
    public partial class ForgotPass : Form
    {
        string correctPass, securityQ = null, securityA = null, newPass;
        int x = 0;
        
        public ForgotPass()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            NewAccount frmNew = new NewAccount();

            if (frmNew.UsernameAvailable(txtUsername.Text) == false)
            {
                //On form load, txtUsername is visible, txtSecurityA and txtNewPass are invisible
                if (txtSecurityA.Visible == false && txtNewPass.Visible == false) //first time clicking accept
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    SqlConnection conn = new SqlConnection(Program.strConnection);
                    conn.Open();
                    SqlDataReader myReader = null;
                    //Retrieve Username, password, security question and answer from database
                    SqlCommand myCommand = new SqlCommand("Select username, SecurityQuestion, SecurityAnswer from EntireDivision Where Username = @username", conn);
                    myCommand.Parameters.AddWithValue("@username", txtUsername.Text);
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        //Stores the correct password Security Question and Security Answer into variables
                        securityQ = myReader["SecurityQuestion"].ToString();
                        securityA = myReader["SecurityAnswer"].ToString();
                    }
                    txtUsername.Visible = false; //Hides username label and textbox
                    lblUsername.Visible = false;
                    txtSecurityA.Visible = true; //Displays the Security Question and answer boxes
                    lblSecurityQ.Visible = true;
                    lblSecurityQ.Text = securityQ; //Fills the Security Question label with the question from the database
                    txtSecurityA.Focus();
                }
                else //Second, third, and fourth time clicking accept
                {
                    if (txtSecurityA.Visible == true) //Second time
                    {
                        //compare data from database to see if answer matches up
                        if (securityA == txtSecurityA.Text) //if the answer the user types matches what is in the database
                        {

                            txtSecurityA.Visible = false; //hide security answer txtbox and display the textbox for the newpassword
                            lblSecurityQ.Text = "Enter a new password";
                            txtNewPass.Visible = true;
                            txtNewPass.Focus();
                            txtNewPass.PasswordChar = '*'; //assign the password character to the textbox
                            newPass = txtNewPass.Text;
                        }
                        else //User types different answer than what is in the database
                        {

                            MessageBox.Show("Question and answer do not match");
                            txtSecurityA.Clear();
                            txtSecurityA.Focus();
                        }

                    }
                    else //Third and fourth time user clicks accept
                    {
                        if (x == 0) //Third time user clicked accept
                        {
                            lblSecurityQ.Text = "Confirm new password"; //Display confirm password
                            newPass = txtNewPass.Text; //Assign what the user typed as a new password into a variable
                            txtNewPass.Clear();
                            txtNewPass.Focus();
                            x++; //increment x
                        }
                        else //Fourth and final time user clicked accept
                        {
                            if (newPass == txtNewPass.Text) //If user types the same password twice
                            {
                                //Hash the new password and store the new password, hash and salt into the database
                                string strPass = txtNewPass.Text;
                                string strUsername = txtUsername.Text;
                                string strSalt;
                                string strHash;
                                strSalt = PasswordManager.CreateSalt(strUsername);
                                strHash = PasswordManager.HashPassword(strSalt, strPass);

                                SqlDataAdapter da = new SqlDataAdapter();
                                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                                SqlConnection conn = new SqlConnection(Program.strConnection);
                                conn.Open();
                                SqlDataReader myReader = null;
                                SqlCommand myCommand = new SqlCommand("Update EntireDivision set salt = @salt, hash = @hash Where Username = @username", conn);
                               // myCommand.Parameters.AddWithValue("@password", strPass);
                                myCommand.Parameters.AddWithValue("@salt", strSalt);
                                myCommand.Parameters.AddWithValue("@hash", strHash);
                                myCommand.Parameters.AddWithValue("@username", strUsername);
                                myReader = myCommand.ExecuteReader();
                                //Confirm with user the password change was successful and close the forgot password form
                                MessageBox.Show("Password has been successfully changed", "Success");
                                
                                
                            }
                            else
                            {
                                MessageBox.Show("Passwords did not match");
                            }
                            
                            this.Close();
                        }
                    }
                }

            }
            else
            {
                MessageBox.Show("Username doesn't exist");
                txtUsername.Clear();
                txtUsername.Focus();
            }
                   

            

        }

        private void ForgotPass_Load(object sender, EventArgs e)
        {//sets the focus to the username textbox on formload
            txtUsername.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ForgotPass_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login newLogin = new Login();
            newLogin.Show();
        }

        

         }
}
