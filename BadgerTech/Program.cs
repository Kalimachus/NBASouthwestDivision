using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace BadgerTech
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        //Connection string to Azure DB
              public const string strConnection =  "Server=tcp:elusprmyjo.database.windows.net;Database=NBASouthwestDivision; "+
"User ID=jposey@elusprmyjo;Password=Jaredp1234;Trusted_Connection=False;" +
"Encrypt=True";
        [STAThread]

 
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            SqlConnection conn = new SqlConnection(Program.strConnection);
            conn.Open();
            SqlCommand myCommand = new SqlCommand("Select Max(PID) as Result from EntireDivision", conn);
            myCommand.CommandType = CommandType.Text;

            SqlDataReader dr = myCommand.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    MyUser._MaxPID = int.Parse(dr["Result"].ToString());

                }
            }

            myCommand.Connection.Close();
            conn.Close();
            Application.Run(new frmMainPage());
        }
    }
}
