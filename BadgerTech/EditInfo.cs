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
using System.Drawing.Imaging;
using System.Text.RegularExpressions;



namespace BadgerTech
{
    public partial class EditInfo : Form
    {
        public EditInfo()
        {
            InitializeComponent();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            //Open file dialog to allow user to select their own profile picture
            if (ofdOpen.ShowDialog() == DialogResult.OK)
            {
                picProfile.Image = new Bitmap(ofdOpen.FileName);


                SqlConnection con = new SqlConnection(Program.strConnection);
                //SQL command to update the profilepic column based on PID
                SqlCommand com = new SqlCommand("Update [EntireDivision] Set ProfilePic= @Picture Where PID = " + MyUser._PID, con);
                //Code to convert Image to binary to store in the DB using memorystream
                MemoryStream ms = new MemoryStream();
                picProfile.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] profilepic = ms.ToArray();
                com.Parameters.AddWithValue("@Picture", profilepic);
                try
                {
                    con.Open();
                    com.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }

                //Updates the profile pic on the players main page
                
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //closes the form
            this.Close();
        }

        private void EditPlayer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Players frmPlayer = new Players();
            frmPlayer.Refresh();
            
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Confirm with user to update profile info
            if (IsPhoneValid(txtPhone.Text) == true && IsZipValid(txtZip.Text)==true)
            {
                if (MessageBox.Show("Are you sure you want to update this information?", "Confirm", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    //Updates players profile !!!!!WARNING!!!!! will place blank data if fields are left blank!!!!!! 
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    SqlConnection conn = new SqlConnection(Program.strConnection);
                    conn.Open();
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand("Update EntireDivision Set PhoneNumber = @Phone, Address = @Address, City = @City, State = @State, Zipcode = @Zip, SecurityQuestion = @RecoveryQ, SecurityAnswer = @RecoveryA  where PID = " + MyUser._PID, conn);
                    try
                    {
                        myCommand.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        myCommand.Parameters.AddWithValue("@Address", txtAddress.Text);
                        myCommand.Parameters.AddWithValue("@City", txtCity.Text);
                        myCommand.Parameters.AddWithValue("@State", txtState.Text);
                        myCommand.Parameters.AddWithValue("@Zip", txtZip.Text);
                        myCommand.Parameters.AddWithValue("@RecoveryQ", cmbRecovery.SelectedItem.ToString());
                        myCommand.Parameters.AddWithValue("@RecoveryA", txtRecoveryA.Text);
                        myReader = myCommand.ExecuteReader();
                    }
                    catch
                    {
                        MessageBox.Show("Please fill in all fields");
                    }
                    conn.Close();
                }
                else//User selects no or cancel
                {
                    MessageBox.Show("No changes were made to your profile");
                }
            }
            else
            {
                if(IsPhoneValid(txtPhone.Text)== false)
                {
                MessageBox.Show("Phone Number must be in the following format: ###-###-####");
                }
                else
                {
                    MessageBox.Show("Zip code must be in the following format: #####");
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clears the form and resets the focus
            txtAddress.Clear();
            txtCity.Clear();
            txtPhone.Clear();
            txtState.Clear();
            txtZip.Clear();
            txtPhone.Focus();
        }

        private void EditInfo_Load(object sender, EventArgs e)
        {
            //Pulls information from DB on formload
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            SqlConnection conn = new SqlConnection(Program.strConnection);
            conn.Open();
            try
            {
                SqlDataReader myReader = null;
                //Gets PID, Name, PhoneNumber, Address, City, State, Zip, Security Question and Answer from db 
                SqlCommand myCommand = new SqlCommand("Select PID, PhoneNumber, Address, City, State, Zipcode, SecurityQuestion, SecurityAnswer from EntireDivision Where PID = " + MyUser._PID, conn);

                try
                {
                    //SQL commands to avoid SQL injection vulnerabilities
                   
                    myReader = myCommand.ExecuteReader();

                    while (myReader.Read())
                    {
                        //Stores the correct password and the TeamID into variables
                        txtPhone.Text = myReader["PhoneNumber"].ToString();
                        txtAddress.Text = myReader["Address"].ToString();
                        txtCity.Text = myReader["City"].ToString();
                        txtState.Text = myReader["State"].ToString();
                        txtZip.Text = myReader["Zipcode"].ToString();
                        cmbRecovery.SelectedItem = myReader["SecurityQuestion"];
                        txtRecoveryA.Text = myReader["SecurityAnswer"].ToString();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    //do nothing
                }
            }
            catch (SqlException ex)
            {
                //Catches any sql error
                MessageBox.Show(ex.Message);
            }

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        public bool IsPhoneValid(string strNum)
        {
            bool blnStatus = false;
            string Pattern = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            if(Regex.IsMatch(strNum, Pattern))
            {
                blnStatus = true;
            }

            return blnStatus;

        }

       

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPhone.TextLength == 3 || txtPhone.TextLength == 7)
           
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                txtPhone.AppendText("-");
            
                }
            }
        }

        public bool IsZipValid(string strZip)
        {
            bool blnStatus = false;
            string Pattern = @"^\d{5}$";
            if (Regex.IsMatch(strZip, Pattern))
            {
                blnStatus = true;
            }

            return blnStatus;

        }

    }
}
