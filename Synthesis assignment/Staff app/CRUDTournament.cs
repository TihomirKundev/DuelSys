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
    public partial class CRUDTournament : Form
    {
        private TournamentManager tournamentManager;
        Tournament tournament1;
        public CRUDTournament(Tournament tournament)
        {
            InitializeComponent();
            tournamentManager = new TournamentManager(new UploadTournament());
            if(tournament == null)
            {
                CreateFormShow();
            }else if(tournament.GetType() == typeof(Upcoming_tournament))
            {
                UpdateUpcomingFormShow((Upcoming_tournament)tournament);
                tournament1 = tournament;
            }else if(tournament.GetType() == typeof(Ongoing_tournament))
            {
                UpdateOngoingFormShow((Ongoing_tournament)tournament);
            }else if(tournament.GetType() == typeof(Past_tournament))
            {
                DeleteTournamentShow((Past_tournament)tournament);
                tournament1= tournament;
            }else if(tournament.GetType() == typeof(Canceled_tournament))
            {
                DeleteTournamentShow((Canceled_tournament)tournament);
                tournament1 = tournament;
            }
        }
        private void CreateFormShow()
        {
            UpdateBtn.Visible = false;
            DeleteBtn.Visible = false;
            SportTypeTxt.Visible = false;
        }
        private void UpdateUpcomingFormShow(Upcoming_tournament tournament)
        {
            LoadTournamentInfo(tournament);
            List<string> names = new List<string>();
            foreach(People people in tournament.Participants)
            {
                names.Add(people.Fname + " " + people.Lname);
            }
            ParticipantsList.DataSource = names;
            CreateBtn.Visible = false;
            IDTxt.ReadOnly = true;
            SportTypeCmb.Visible = false;
            SportTypeTxt.ReadOnly = true;
            TourSysTxt.ReadOnly = true;
            MinPlayersTxt.ReadOnly = true;
            MaxPlayersTxt.ReadOnly = true;
            LocationTxt.ReadOnly = true;
        }
        private void UpdateOngoingFormShow(Ongoing_tournament tournament)
        {
            LoadTournamentInfo(tournament);
            List<string> names = new List<string>();
            foreach (People people in tournament.Players)
            {
                names.Add(people.Fname + " " + people.Lname);
            }
            ParticipantsList.DataSource = names;
            CreateBtn.Visible = false;
            DeleteBtn.Visible = false;
            IDTxt.ReadOnly = true;
            SportTypeCmb.Visible = false;
            SportTypeTxt.ReadOnly = true;
            TourSysTxt.ReadOnly = true;
            MinPlayersTxt.ReadOnly = true;
            MaxPlayersTxt.ReadOnly = true;
            StartDatePicker.Visible = false;
            HidenStartLb.Visible = true;
            LocationTxt.ReadOnly = true;
        }
        private void DeleteTournamentShow(Tournament tournament)
        {
            LoadTournamentInfo(tournament);
            if(tournament is Past_tournament)
            {
                List<string> names = new List<string>();
                foreach (People people in ((Past_tournament)tournament).Players)
                {
                    names.Add(people.Fname + " " + people.Lname);
                }
                ParticipantsList.DataSource = names;
            }else
            {
                List<string> names = new List<string>();
                foreach (People people in ((Canceled_tournament)tournament).Participants)
                {
                    names.Add(people.Fname + " " + people.Lname);
                }
                ParticipantsList.DataSource = names;
            }
            CreateBtn.Visible = false;
            UpdateBtn.Visible = false;
            IDTxt.ReadOnly = true;
            SportTypeCmb.Visible = false;
            SportTypeTxt.ReadOnly = true;
            TourSysTxt.ReadOnly = true;
            MinPlayersTxt.ReadOnly = true;
            MaxPlayersTxt.ReadOnly = true;
            LocationTxt.ReadOnly = true;
            DescTxt.ReadOnly = true;
            StartDatePicker.Visible = false;
            HidenStartLb.Visible = true;
            EndDatePicker.Visible = false;
        }
        private void LoadTournamentInfo(Tournament tournament)
        {
            IDTxt.Text = tournament.Id.ToString();
            SportTypeTxt.Text = tournament.SportType;
            TourSysTxt.Text = tournament.System;
            MinPlayersTxt.Text = tournament.MinPlayers.ToString();
            MaxPlayersTxt.Text = tournament.MaxPlayers.ToString();
            LocationTxt.Text = tournament.Location.ToString();
            DescTxt.Text = tournament.Description;
            GamesTxt.Text = tournament.NumGames.ToString();
            StartDateLb.Visible = false;
            StartDatePicker.Value = tournament.StartDate;
            EndDatePicker.Value = tournament.EndDate;
        }
        private void CreateBtn_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(IDTxt.Text) || String.IsNullOrEmpty(TourSysTxt.Text) || String.IsNullOrEmpty(MinPlayersTxt.Text) || String.IsNullOrEmpty(MaxPlayersTxt.Text) || String.IsNullOrEmpty(LocationTxt.Text) || String.IsNullOrEmpty(GamesTxt.Text))
            {
                MessageBox.Show("Some of the data is missing!");
            }else if(StartDatePicker.Value <= DateTime.Today)
            {
                MessageBox.Show("Start date can not be past date!");
            }else if(EndDatePicker.Value <= DateTime.Today)
            {
                MessageBox.Show("End date can not be past date!");

            }else if(StartDatePicker.Value >= EndDatePicker.Value)
            {
                MessageBox.Show("Start date can not be after end date!");
            }else if(TourSysTxt.Text != "Round-robin")
            {
                MessageBox.Show("For now you can only choose Round-robin!");
                TourSysTxt.Text = "Round-robin";
            }
            else
            {
                int exc = 0;
                int id;
                int min;
                int max;
                int games;
                try
                {
                    id = Convert.ToInt32(IDTxt.Text);
                    min = Convert.ToInt32(MinPlayersTxt.Text);
                    max = Convert.ToInt32(MaxPlayersTxt.Text);
                    games = Convert.ToInt32(GamesTxt.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Input numbers in the right fields!");
                    exc = 1;
                }
                if(exc == 0)
                {
                    id = Convert.ToInt32(IDTxt.Text);
                    min = Convert.ToInt32(MinPlayersTxt.Text);
                    max = Convert.ToInt32(MaxPlayersTxt.Text);
                    games = Convert.ToInt32(GamesTxt.Text);
                    if (min < 3 || min > max)
                    {
                        MessageBox.Show("Invalid number of players!");
                    }
                    else
                    {
                        if (games == 1 || games == 3 || games == 5)
                        {
                            string result = "";
                            int pas = 0;

                            if (SportTypeCmb.SelectedItem.ToString() == "Badminton")
                            {
                                Upcoming_tournament upcoming_Tournament = new Upcoming_tournament(id, "Badminton", DescTxt.Text, StartDatePicker.Value, EndDatePicker.Value, min, max, LocationTxt.Text, games, new List<People>());
                                result = tournamentManager.CreateUpcoming(upcoming_Tournament);
                                pas = 1;
                            }
                            else if (SportTypeCmb.SelectedItem.ToString() == "Football")
                            {
                                Upcoming_tournament upcoming_Tournament = new Upcoming_tournament(id, "Football", DescTxt.Text, StartDatePicker.Value, EndDatePicker.Value, min, max, LocationTxt.Text, games, new List<People>());
                                result = tournamentManager.CreateUpcoming(upcoming_Tournament);
                                pas = 1;
                            }
                            if (pas == 1)
                            {
                                if (result == "Complete")
                                {
                                    this.Close();
                                    MainForm mainForm = new MainForm();
                                    mainForm.Show();
                                }
                                else
                                {
                                    MessageBox.Show(result);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please select value for sport type!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("For now only options for num of games are 1/3/5!");
                        }
                    }
                }
            }
        }
        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if(StartDatePicker.Visible == false)//Ongoing
            {
                if (String.IsNullOrEmpty(DescTxt.Text))
                {
                    MessageBox.Show("Can not have empty description!");
                }
                else if (EndDatePicker.Value <= DateTime.Today)
                {
                    MessageBox.Show("End date can not be past date!");
                }
                else
                {
                    int id = Convert.ToInt32(IDTxt.Text);
                    int min = Convert.ToInt32(MinPlayersTxt.Text);
                    int max = Convert.ToInt32(MaxPlayersTxt.Text);
                    int games = Convert.ToInt32(GamesTxt.Text);
                    tournamentManager.Update(new Ongoing_tournament(id,SportTypeTxt.Text,DescTxt.Text,StartDatePicker.Value,EndDatePicker.Value,min,max,LocationTxt.Text,games,new Dictionary<People, int>(), new List<Game>()));
                    this.Close();
                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
            }
            else
            {
                if (String.IsNullOrEmpty(DescTxt.Text))
                {
                    MessageBox.Show("Can not have empty description!");
                }
                else if (StartDatePicker.Value <= DateTime.Today)
                {
                    MessageBox.Show("Start date can not be past date!");
                }
                else if (EndDatePicker.Value <= DateTime.Today)
                {
                    MessageBox.Show("End date can not be past date!");
                }else if(StartDatePicker.Value >= EndDatePicker.Value)
                {
                    MessageBox.Show("End date can not be before start date!");
                }
                else
                {
                    int err = 0;
                    try
                    {
                        int i = Convert.ToInt32(GamesTxt.Text);
                    }
                    catch (Exception)
                    {
                        err = 1;
                    }
                    if(err == 0)
                    {
                        int games = Convert.ToInt32(GamesTxt.Text);
                        if(games == 1 || games == 3 || games == 5)
                        {
                            int id = Convert.ToInt32(IDTxt.Text);
                            int min = Convert.ToInt32(MinPlayersTxt.Text);
                            int max = Convert.ToInt32(MaxPlayersTxt.Text);
                            tournamentManager.Update(new Upcoming_tournament(id,SportTypeTxt.Text, DescTxt.Text, StartDatePicker.Value, EndDatePicker.Value, min, max, LocationTxt.Text, games, new List<People>()));
                            this.Close();
                            MainForm mainForm = new MainForm();
                            mainForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("For now only options for num of games are 1/3/5!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid type of num games!");
                    }
                }
            }
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            tournamentManager.Delete(tournament1);
            this.Close();
            MainForm form = new MainForm();
            form.Show();
        }
        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            MainForm form = new MainForm();
            form.Show();
        }
    }
}
