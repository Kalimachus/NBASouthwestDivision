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
    public partial class Messages : Form
    {
        int dgsize, nextID;
        DateTime date = DateTime.Now;
        string strSender, strRecipient, strMessage;
       
        public Messages()
        {
            InitializeComponent();
        }

        public void Messages_Load(object sender, EventArgs e)
        {
            //Gathers all messages from the Messaging table
            SqlConnection conn = new SqlConnection(Program.strConnection);
            SqlDataAdapter da = new SqlDataAdapter("Select Timestamp, Sender, Recipient, Body from Messaging", conn);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "Messaging");
            conn.Close();
            dgvMessages.DataSource = ds;
            dgvMessages.DataMember = "Messaging";
            //Adjusts the height of the Datagridview to a certain point, then addds a scrollbar after that point
            dgsize = (dgvMessages.RowCount + 1) * 20;
            if (dgsize <= 200)
            {
                dgvMessages.Size = new Size(720, dgsize);
            }
            dgvMessages.Columns[0].Width = 120;
            dgvMessages.Columns[1].Width = 110;
            dgvMessages.Columns[2].Width = 110;
            dgvMessages.Columns[3].Width = 380;

            nextID = dgvMessages.RowCount + 1;
            //Filters results to only include the user that is logged in
            LoadMessage();

            //Removes the currently logged in user from the selection choice
            lstRecipient.Items.Remove(MyUser._Username);


        }

        private void btnSend_Click(object sender, EventArgs e)
        {//Adding a new message to the Messaging table
            //variable to hold selected recipient
            try
            {
                string recipient = lstRecipient.SelectedItem.ToString();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                SqlConnection conn = new SqlConnection(Program.strConnection);
                conn.Open();
                //Code to insert into SQL table
                using (SqlCommand myCommand = new SqlCommand("Insert INTO Messaging(Timestamp, Sender, Recipient, Body) Values (@Time, @Sender, @Recipient, @Message)", conn))
                {
                    try
                    {

                        myCommand.Parameters.AddWithValue("@Time", date);
                        myCommand.Parameters.AddWithValue("@Sender", MyUser._Username);
                        myCommand.Parameters.AddWithValue("@Recipient", recipient);
                        myCommand.Parameters.AddWithValue("@Message", txtMessage.Text.ToString());



                        myCommand.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    LoadMessage();
                }
            }
            catch
            {
                MessageBox.Show("Please select a user from the list");
            }
        }

        private void LoadMessage()
        {//Filters displayed results based on the user that is logged in and resizes the datagridview
            SqlConnection conn = new SqlConnection(Program.strConnection);
            SqlDataAdapter da = new SqlDataAdapter("Select Timestamp, Sender, Recipient, Body from Messaging where Sender = '" + MyUser._Username + "' or Recipient = '" + MyUser._Username + "'", conn);
            DataSet ds = new DataSet();
            conn.Open();
            da.Fill(ds, "Messaging");
            conn.Close();
            dgvMessages.DataSource = ds;
            dgvMessages.DataMember = "Messaging";
            dgsize = (dgvMessages.RowCount + 1) * 20;
            if (dgsize <= 200)
            {
                dgvMessages.Size = new Size(720, dgsize);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
               SqlDataAdapter da = new SqlDataAdapter();
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                SqlConnection conn = new SqlConnection(Program.strConnection);
                conn.Open();
                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("Delete from Messaging Where Sender = @Sender and Recipient = @Recipient and Body = @Message", conn);
                myCommand.Parameters.AddWithValue("@Sender", strSender);
                myCommand.Parameters.AddWithValue("@Recipient", strRecipient);
                myCommand.Parameters.AddWithValue("@Message", strMessage);
                myReader = myCommand.ExecuteReader();
                conn.Close();
            
                LoadMessage();
            
        }

        private void dgvMessages_SelectionChanged(object sender, EventArgs e)
        {
            try //If cells are not null
            {
                foreach (DataGridViewRow DataRow in dgvMessages.SelectedRows)
                {
                 //set variables each time a new row is selected in the datagrid  
                    strSender = DataRow.Cells[1].Value.ToString();
                    strRecipient = DataRow.Cells[2].Value.ToString();
                    strMessage = DataRow.Cells[3].Value.ToString();

                }
            }
            catch
            {
                //do nothing
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
