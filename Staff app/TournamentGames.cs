using Synthesis_assignment.Base_classes;
using Synthesis_assignment.Manager_classes;
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
    public partial class TournamentGames : Form
    {
        private Ongoing_tournament tour;
        public TournamentGames(Ongoing_tournament tournament)
        {
            InitializeComponent();
            tour =tournament;
            dataGridView1.DataSource = tour.GetUnfinishedGames();
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.ReadOnly = true;
        }
        private void GoBackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }
        private void GridClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dataGridView1.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[row].Cells[0].Value);
            this.Close();
            GameResult gameResult = new GameResult(tour.GetGame(id));
            gameResult.Show();
        }
    }
}
