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
using System.Text.RegularExpressions;

namespace BadgerTech
{
    public partial class NewAccount : Form
    {   
        //string variables that will hold text in textboxes
        string strTeam, strState, strPosition, strFName,
        strLName, strPhoneNumber, strAddress, strCity,
        strZip, strUsername, strPassword, strSalt,
        strHash = null;

        //initizialize form;
        public NewAccount()
        {
            InitializeComponent();
        }

        //validate input and upload data
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //input validation & flags
            #region UserInputValidation
            //input validation flags
            bool blnAllFieldsFlag = true;
            bool blnZipcode = true;
            bool blnValidUsername;
            int intZipcode;

            if (IsPhoneValid(txtPhone.Text) == true && IsZipValid(txtZip.Text) == true)
            {
                //check for all fields entered
                foreach (Control control in this.Controls)
                {
                    // if the control examined is a textbox
                    if (control is TextBox)
                    {
                        //if the control box is empty, return prompt and break examination loop
                        TextBox textbox = control as TextBox;
                        if (string.IsNullOrWhiteSpace(textbox.Text))
                        {
                            blnAllFieldsFlag = false;
                            MessageBox.Show(textbox.Tag + " is not filled out");
                            break;
                        }
                        //if input was made for the zipcode..
                        if (textbox.Name == "txtZip")
                        {
                            //try to convert it and return a boolean value
                            blnZipcode = int.TryParse(textbox.Text.Trim(), out intZipcode);
                            //if input was a valid number (true) and the length is atleast 5 numbers long
                            if (blnZipcode == true && textbox.Text.Trim().Length >= 5)
                            {
                                strZip = intZipcode.ToString();
                            }
                            else
                            {
                                blnAllFieldsFlag = false;
                                MessageBox.Show("Invalid Zipcode");
                                break;
                            }
                        }

                    }
                    // if the control examined is a combobox
                    if (control is ComboBox)
                    {
                        ComboBox combobox = control as ComboBox;
                        if (combobox.Text == null)
                        {
                            blnAllFieldsFlag = false;
                            MessageBox.Show(combobox.Tag + " is not valid");
                            break;
                        }
                    }
                }
            }
           
            #endregion
            //submit data once valid
            #region UserInformationSubmission
            //submit data
             if (IsPhoneValid(txtPhone.Text) == true && IsZipValid(txtZip.Text) == true)
            {

            if (blnAllFieldsFlag == true)
            {
                //assign values from fields
                strFName = txtFName.Text.Trim();
                strLName = txtLName.Text.Trim();
                strPhoneNumber = txtPhone.Text.Trim();
                strAddress = txtAddress.Text.Trim();
                strCity = txtCity.Text.Trim();
                //username is the First.Last concantenated
                strUsername = strFName.Substring(0, 1).ToUpper() + strFName.Substring(1) + "." + strLName.Substring(0, 1).ToUpper() + strLName.Substring(1);
                strPassword = txtPassword.Text.Trim();
                strSalt = PasswordManager.CreateSalt(strUsername);
                strHash = PasswordManager.HashPassword(strSalt, strPassword);
                strTeam = cmbTeam.SelectedItem.ToString();
                strState = cmbState.SelectedItem.ToString();
                strPosition = cmbPosition.SelectedItem.ToString();

                //check if user name is valid
                blnValidUsername = UsernameAvailable(strUsername);


                if (blnValidUsername == true)
                {
                    
                    switch (strTeam)
                    {
                        case "Mavericks":
                            {
                                MyUser._TeamID = 1;
                                break;
                            }
                        case "Rockets":
                            {
                                MyUser._TeamID = 2;
                                break;
                            }
                        case "Grizzlies":
                            {
                                MyUser._TeamID = 3;
                                break;
                            }
                        case "Pelicans":
                            {
                                MyUser._TeamID = 4;
                                break;
                            }
                        case "Spurs":
                            {
                                MyUser._TeamID = 5;
                                break;
                            }
                    }

                    SqlConnection conn = new SqlConnection(Program.strConnection);
                    SqlDataReader myReader = null;
                    conn.Open();
                    SqlCommand myCommand1 = new SqlCommand("Insert into EntireDivision (PID, FirstName, LastName, TeamID, PhoneNumber, Address, City, State, Zipcode, Username, Salt, Hash) Values (@PID, @FName, @LName, @TeamID, @Phone, @Address, @City, @State, @Zip, @Username, @Salt, @Hash)", conn);
                    myCommand1.Parameters.AddWithValue("@PID", MyUser._MaxPID + 1);
                    myCommand1.Parameters.AddWithValue("@FName", strFName);
                    myCommand1.Parameters.AddWithValue("@LName", strLName);
                    myCommand1.Parameters.AddWithValue("@TeamID", MyUser._TeamID);
                    myCommand1.Parameters.AddWithValue("@Phone", strPhoneNumber);
                    myCommand1.Parameters.AddWithValue("@Address", strAddress);
                    myCommand1.Parameters.AddWithValue("@City", strCity);
                    myCommand1.Parameters.AddWithValue("@State", strState);
                    myCommand1.Parameters.AddWithValue("@Zip", strZip);
                    myCommand1.Parameters.AddWithValue("@Username", strUsername);
                  //  myCommand1.Parameters.AddWithValue("@Password", strPassword);
                    myCommand1.Parameters.AddWithValue("@Salt", strSalt);
                    myCommand1.Parameters.AddWithValue("@Hash", strHash);
                    myReader = myCommand1.ExecuteReader();
                    conn.Close();
                    conn.Open();
                    SqlCommand myCommand2 = new SqlCommand("Insert into " + strTeam + " (PID, Player, PP) Values (@PID, @Name, @Position)", conn);
                    myCommand2.Parameters.AddWithValue("@Name", strFName + " " + strLName);
                    myCommand2.Parameters.AddWithValue("@Position", strPosition);
                    myCommand2.Parameters.AddWithValue("@PID", MyUser._MaxPID + 1);
                    myReader = myCommand2.ExecuteReader();
                    conn.Close();
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommandBuilder cb = new SqlCommandBuilder(da);
                    conn.Open();
                    SqlCommand myCommand3 = new SqlCommand("Select Max(PID) as Result from EntireDivision", conn);
                    myCommand3.CommandType = CommandType.Text;

                    SqlDataReader dr = myCommand3.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            MyUser._MaxPID = int.Parse(dr["Result"].ToString());
                        }
                    }
                    conn.Close();
                    MessageBox.Show("Your login is: " + strUsername + "\nYour Password is: " + strPassword, "Account created!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Username is already taken.");
                }
            }
            }
             else
             {
                 if (IsPhoneValid(txtPhone.Text) == false)
                 {
                     MessageBox.Show("Phone Number must be in the following format: ###-###-####");
                 }
                 else
                 {
                     MessageBox.Show("Zip code must be in the following format: #####");
                 }
             }
            #endregion
        }


        //Functions Area
        //verify username is available
        public bool UsernameAvailable(string Username)
        {      
            
            SqlConnection conn2 = new SqlConnection(Program.strConnection);
            SqlCommand myCommand = new SqlCommand("select username from entiredivision where username= @username", conn2);
            myCommand.Parameters.AddWithValue("@username", Username);
            conn2.Open();
            SqlDataReader reader = myCommand.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            int rowCount = dataTable.Rows.Count;
            if(rowCount <= 0)
            {
                return true;
            }
            conn2.Close();
            return false;
        }
        //End Functions Area

        //UI / UX code
        #region UI & UX Code
        private void NewAccount_Load(object sender, EventArgs e)
        {
            //sets the focus on form load
            txtFName.Focus();
        }
        private void btnClearForm_Click(object sender, EventArgs e)
        {
                //Clears the form and resets the focus
                txtFName.Clear();
                txtLName.Clear();
                txtPhone.Clear();
                txtAddress.Clear();
                txtCity.Clear();
                txtZip.Clear();
                lblUsername.Text = string.Empty;
                txtPassword.Clear();
                cmbPosition.SelectedItem = null;
                cmbState.SelectedItem = null;
                cmbTeam.SelectedItem = null;
                txtFName.Focus();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void txtFName_Enter(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFName.Text) && !string.IsNullOrWhiteSpace(txtLName.Text))
            {
                strFName = txtFName.Text;
                strLName = txtLName.Text;
                lblUsername.Text = strFName.Substring(0, 1).ToUpper() + strFName.Substring(1) + "." + strLName.Substring(0, 1).ToUpper() + strLName.Substring(1);
            }
        }
        private void txtFName_Leave(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtFName.Text) && !string.IsNullOrWhiteSpace(txtLName.Text))
            {
                strFName = txtFName.Text;
                strLName = txtLName.Text;
                lblUsername.Text = strFName.Substring(0, 1).ToUpper() + strFName.Substring(1) + "." + strLName.Substring(0, 1).ToUpper() + strLName.Substring(1);
            }
        }
        private void txtLName_Enter(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(txtFName.Text) && !string.IsNullOrWhiteSpace(txtLName.Text))
            {
                strFName = txtFName.Text;
                strLName = txtLName.Text;
                lblUsername.Text = strFName.Substring(0, 1).ToUpper() + strFName.Substring(1) + "." + strLName.Substring(0, 1).ToUpper() + strLName.Substring(1);
            }
        }
        private void txtLName_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFName.Text) && !string.IsNullOrWhiteSpace(txtLName.Text))
            {
                strFName = txtFName.Text;
                strLName = txtLName.Text;
                lblUsername.Text = strFName.Substring(0, 1).ToUpper() + strFName.Substring(1) + "." + strLName.Substring(0, 1).ToUpper() + strLName.Substring(1);
            }
        }
        #endregion

      

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            //helps ensure the phone number is in the proper ###-###-#### format
            if (txtPhone.TextLength == 3 || txtPhone.TextLength == 7)
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    txtPhone.AppendText("-");

                }
            }
        }

        public bool IsPhoneValid(string Phone)
        {//checks for valid phone number format (###-###-####)
            bool blnStatus = false;
            string Pattern = @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            if (Regex.IsMatch(Phone, Pattern))
            {
                blnStatus = true;
            }

            return blnStatus;
        }

        public bool IsZipValid(string Zip)
        {//checks for valid zip format (#####)
            bool blnStatus = false;
            string Pattern = @"^\d{5}$";
            if (Regex.IsMatch(Zip, Pattern))
            {
                blnStatus = true;
            }

            return blnStatus;
        }

    }
}
