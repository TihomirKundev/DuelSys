using SynthesisAssignment.Base_classes;
using SynthesisAssignment.Manager_classes;
using SynthesisAssignment.Upload_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff_app
{
    public partial class MainForm : Form
    {
        TournamentManager tournamentManager;
        public MainForm()
        {
            InitializeComponent();
            this.Text = "Welcome";
            tournamentManager = new TournamentManager(new UploadTournament());
            DataGridPrint(0);
        }
        private void DataGridPrint(int n)
        {
            Tournament[] tournaments = tournamentManager.Tournaments;
            List<Tournament> show = new List<Tournament>();
            dataGridView1.DataSource = 0;
            if (n == 0)//All
            {
                dataGridView1.DataSource = tournaments;
            }else if(n == 1)//Upcoming
            {
                foreach(Tournament t in tournaments)
                {
                    if(t is Upcoming_tournament)
                    {
                        show.Add(t);
                    }
                }
                dataGridView1.DataSource = show;
            }else if(n == 2)//Ongoing
            {
                foreach (Tournament t in tournaments)
                {
                    if (t is Ongoing_tournament)
                    {
                        show.Add(t);
                    }
                }
                dataGridView1.DataSource = show;
            }
            else if(n == 3)//Past
            {
                foreach (Tournament t in tournaments)
                {
                    if (t is Past_tournament)
                    {
                        show.Add(t);
                    }
                }
                dataGridView1.DataSource = show;
            }
            else if(n == 4)//Cancel
            {
                foreach (Tournament t in tournaments)
                {
                    if (t is Canceled_tournament)
                    {
                        show.Add(t);
                    }
                }
                dataGridView1.DataSource = show;
            }
            dataGridView1.Columns["SportType"].Visible = false;
            dataGridView1.Columns["Description"].Visible = false;
            dataGridView1.Columns["MinPlayers"].Visible = false;
            dataGridView1.Columns["MaxPlayers"].Visible = false;
            dataGridView1.Columns["NumGames"].Visible = false;
            dataGridView1.Columns["System"].Visible = false;
            dataGridView1.ReadOnly = true;
        }
        private void CreateBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            CRUDTournament createUpdateForm = new CRUDTournament(null);
            createUpdateForm.Visible = true;
        }
        private void IndexChamge(object sender, EventArgs e)
        {
            string filter = FilterCmb.Text;
            if(filter == "All")
            {
                DataGridPrint(0);
            }else if(filter == "Upcoming")
            {
                DataGridPrint(1);
            }else if(filter == "Ongoing")
            {
                DataGridPrint(2);
            }else if(filter == "Past")
            {
                DataGridPrint(3);
            }else if(filter == "Cancel")
            {
                DataGridPrint(4);
            }
        }
        private void LogOutBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Visible = true;
        }
        private void DataGridClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[row].Cells[0].Value);
            Tournament[] tournaments = tournamentManager.Tournaments;
            foreach(Tournament tournament in tournaments)
            {
                if(tournament.Id == id)
                {
                    this.Close();
                    CRUDTournament cRUD = new CRUDTournament(tournament);
                    cRUD.Visible = true;
                    return;
                }
            }
        }
        private void ResultGridClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView2.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView2.Rows[row].Cells[0].Value);
            Tournament[] tournaments = tournamentManager.Tournaments;
            foreach (Tournament tournament in tournaments)
            {
                if (tournament.Id == id)
                {
                    this.Close();
                    TournamentGames tournamentGames = new TournamentGames(((Ongoing_tournament)tournament));
                    tournamentGames.Show();
                    return;
                }
            }
        }
        private void IndexChange(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                DataGridPrint(0);
            }
            else if (tabControl1.SelectedIndex == 1)
            {
                List<Tournament> show = new List<Tournament>();
                foreach(Tournament t in tournamentManager.Tournaments)
                {
                    if (t is Ongoing_tournament)
                    {
                        show.Add(t);
                    }
                }
                dataGridView2.DataSource = show;
                dataGridView2.Columns["SportType"].Visible = false;
                dataGridView2.Columns["Description"].Visible = false;
                dataGridView2.Columns["MinPlayers"].Visible = false;
                dataGridView2.Columns["MaxPlayers"].Visible = false;
                dataGridView2.Columns["NumGames"].Visible = false;
                dataGridView2.Columns["System"].Visible = false;
                dataGridView2.ReadOnly = true;
            }
        }
    }
}
