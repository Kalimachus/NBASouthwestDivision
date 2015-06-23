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
    public partial class ViewTeam : Form
    {
        string pp;
        double  gs, min, ppg, offr, defr, rpg, apg, spg, bpg, tpg, fpg, per, fgm, fga, ftm, fta, pps, gp;
        int dgvsize, playerPID;
        public ViewTeam()
        {
            InitializeComponent();
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewTeam_Load(object sender, EventArgs e)
        {
            
                        dgvsize = (dgvTeam.RowCount + 1) * 20;
                        if (dgvsize < 400)
                        {
                            dgvTeam.Size = new Size(1200, dgvsize);
                        }
                        else
                        {
                            dgvTeam.Size = new Size(1200, 400);
                        }
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            SqlConnection conn = new SqlConnection(Program.strConnection);
            conn.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("Update " + MyUser._Teamname + " Set PP = @PP, GS = @GS, MIN = @MIN, PPG = @PPG, OFFR = @OFFR, DEFR = @DEFR, RPG = @RPG, APG = @APG, SPG = @SPG,  BPG = @BPG, TPG = @TPG, FPG = @FPG, PER = @PER, FGM = @FGM, FGA = @FGA, FTM = @FTM, FTA = @FTA, PPS = @PPS, GP = @GP  where PID = " + playerPID, conn);
            myCommand.Parameters.AddWithValue("@PP", pp);
            myCommand.Parameters.AddWithValue("@GS", gs);//4
            myCommand.Parameters.AddWithValue("@MIN", min);
            myCommand.Parameters.AddWithValue("@PPG", ppg);
            myCommand.Parameters.AddWithValue("@OFFR", offr);
            myCommand.Parameters.AddWithValue("@DEFR", defr);//8
            myCommand.Parameters.AddWithValue("@RPG", rpg);
            myCommand.Parameters.AddWithValue("@APG", apg);
            myCommand.Parameters.AddWithValue("@SPG", spg);
            myCommand.Parameters.AddWithValue("@BPG", bpg);//12
            myCommand.Parameters.AddWithValue("@TPG", tpg);
            myCommand.Parameters.AddWithValue("@FPG", fpg);
            myCommand.Parameters.AddWithValue("@PER", per);
            myCommand.Parameters.AddWithValue("@FGM", fgm); //16
            myCommand.Parameters.AddWithValue("@FGA", fga);
            myCommand.Parameters.AddWithValue("@FTM", ftm);
            myCommand.Parameters.AddWithValue("@FTA", fta);
            myCommand.Parameters.AddWithValue("@PPS", pps);//20
            myCommand.Parameters.AddWithValue("@GP", gp);
            myReader = myCommand.ExecuteReader();
            conn.Close();
        }

        private void dgvTeam_SelectionChanged(object sender, EventArgs e)
        {
            try //If cells are not null
            {
                foreach (DataGridViewRow DataRow in dgvTeam.SelectedRows)
                {
                    playerPID = int.Parse(DataRow.Cells[0].Value.ToString());
                    pp = DataRow.Cells[4].Value.ToString();
                    gs = double.Parse(DataRow.Cells[5].Value.ToString());
                    min = double.Parse(DataRow.Cells[6].Value.ToString());
                    ppg = double.Parse(DataRow.Cells[7].Value.ToString());
                    offr = double.Parse(DataRow.Cells[8].Value.ToString());
                    defr = double.Parse(DataRow.Cells[9].Value.ToString());
                    rpg = double.Parse(DataRow.Cells[10].Value.ToString());
                    apg = double.Parse(DataRow.Cells[11].Value.ToString());
                    spg = double.Parse(DataRow.Cells[12].Value.ToString());
                    bpg = double.Parse(DataRow.Cells[13].Value.ToString());
                    tpg = double.Parse(DataRow.Cells[14].Value.ToString());
                    fpg = double.Parse(DataRow.Cells[15].Value.ToString());
                    per = double.Parse(DataRow.Cells[16].Value.ToString());
                    fgm = double.Parse(DataRow.Cells[17].Value.ToString());
                    fga = double.Parse(DataRow.Cells[18].Value.ToString());
                    ftm = double.Parse(DataRow.Cells[19].Value.ToString());
                    fta = double.Parse(DataRow.Cells[20].Value.ToString());
                    pps = double.Parse(DataRow.Cells[21].Value.ToString());
                    gp = double.Parse(DataRow.Cells[22].Value.ToString());
                }
            }
            catch
            {
                //do nothing
            }
        }
    }
}
