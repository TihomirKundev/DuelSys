﻿using Synthesis_assignment.Base_classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesis_assignment.Upload_classes
{
    public class UploadTournament : IUploadTournament
    {
        public List<Tournament> GetTournaments()
        {
            List<Tournament> tournaments = new List<Tournament>();
            SqlConnection conn = new SqlConnection(new DatabaseLink().Link);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tournaments", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int id = Convert.ToInt32(dr["ID"]);
                string desc = Convert.ToString(dr["Description"]);
                DateTime startDate = Convert.ToDateTime(dr["StartDate"]);
                DateTime endDate = Convert.ToDateTime(dr["EndDate"]);
                int minPlayers = Convert.ToInt32(dr["MinPlayers"]);
                int maxPlayers = Convert.ToInt32(dr["MaxPlayers"]);
                string location = Convert.ToString(dr["Location"]);
                int numGames = Convert.ToInt32(dr["NumGames"]);
                if(startDate > DateTime.Today)
                {
                    List<People> people = GetParticipants(id);
                    tournaments.Add(new Upcoming_tournament(id, desc, startDate, endDate, minPlayers, maxPlayers, location, numGames, people));
                }
                else
                {
                    Dictionary<People, int> leaderboard = GetLeaderboard(id);
                    if(leaderboard.Count < minPlayers)
                    {
                        tournaments.Add(new Canceled_tournament(id, desc, startDate, endDate, minPlayers, maxPlayers, location, numGames, leaderboard.Keys.ToList()));
                    }
                    else if (endDate >= DateTime.Today)
                    {
                        List<Game> schedule = GetSchedule(id);
                        if(schedule == null)
                        {
                            List<Game> trial = new List<Game>();
                            for(int i = 0; i < leaderboard.Keys.Count - 1; i++)
                            {
                                for(int j = i+1; j < leaderboard.Keys.Count; j++)
                                {
                                    trial.Add(new Game(0, leaderboard.Keys.ToArray()[i].Email, leaderboard.Keys.ToArray()[j].Email,new int[numGames], new int[numGames]));
                                }
                            }
                            schedule = GenerateSchedule(id,trial);
                        }
                        tournaments.Add(new Ongoing_tournament(id,desc,startDate, endDate, minPlayers, maxPlayers, location, numGames, leaderboard, schedule));
                    }
                    else
                    {
                        tournaments.Add(new Past_tournament(id, desc, startDate, endDate, minPlayers, maxPlayers, location, numGames, leaderboard));
                    }
                }
            }
            conn.Close();
            return tournaments;
        }
        private List<People> GetParticipants(int tournamentID)
        {
            List<People> participants = new List<People>();
            List<string> emails = new List<string>();
            SqlConnection conn = new SqlConnection(new DatabaseLink().Link);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Email FROM Leaderboard WHERE TournamentID = @Tournament", conn);
            cmd.Parameters.AddWithValue("@Tournament", tournamentID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                string email = Convert.ToString(dr["Email"]);
                emails.Add(email);
            }
            foreach(string email in emails)
            {
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM Players WHERE Email = '" + email + "'", conn);
                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                foreach (DataRow dr in dt2.Rows)
                {
                    string firstName = Convert.ToString(dr["FirstName"]);
                    string lastName = Convert.ToString(dr["LastName"]);
                    string password= Convert.ToString(dr["Password"]);
                    participants.Add(new People(firstName,lastName,email,password));
                }
            }
            conn.Close();
            return participants;
        }
        private Dictionary<People, int> GetLeaderboard(int tournamentID)
        {
            Dictionary<People, int> leaderboard = new Dictionary<People, int>();
            List<People> participants = GetParticipants(tournamentID);
            SqlConnection conn = new SqlConnection(new DatabaseLink().Link);
            conn.Open();
            foreach(People person in participants)
            {
                SqlCommand cmd = new SqlCommand("SELECT GamesWon FROM Leaderboard WHERE TournamentID = '" + tournamentID + "' AND Email = '" + person.Email + "'", conn);
                int gamesWon = (int)cmd.ExecuteScalar();
                leaderboard.Add(person, gamesWon);
            }
            conn.Close ();
            return leaderboard;
        }
        private List<Game> GetSchedule(int tournamentID)
        {
            Dictionary<int, List<string>> one = new Dictionary<int, List<string>>();
            Dictionary<int, List<int>> player1Points = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> player2Points = new Dictionary<int, List<int>>();
            List<Game> schedule = new List<Game> { };
            SqlConnection conn = new SqlConnection(new DatabaseLink().Link);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Matches WHERE TournamentID = @TournamentID", conn);
            cmd.Parameters.AddWithValue("@TournamentID", tournamentID);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                conn.Close();
                return null;
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int gameID = Convert.ToInt32(dr["GameID"]);
                    if (one.Keys.Contains(gameID))
                    {
                        int player1Point = Convert.ToInt32(dr["Player1Points"]);
                        int player2Point = Convert.ToInt32(dr["Player2Points"]);
                        player1Points[gameID].Add(player1Point);
                        player2Points[gameID].Add(player2Point);
                    }
                    else
                    {
                        string player1Email = Convert.ToString(dr["Player1Email"]);
                        string player2Email = Convert.ToString(dr["Player2Email"]);
                        int player1Point = Convert.ToInt32(dr["Player1Points"]);
                        int player2Point = Convert.ToInt32(dr["Player2Points"]);
                        one.Add(gameID, new List<string> { player1Email, player2Email });
                        player1Points.Add(gameID, new List<int> { player1Point });
                        player2Points.Add(gameID, new List<int> { player2Point });
                    }
                }
                foreach (int id in one.Keys)
                {
                    schedule.Add(new Game(id, one[id].First(), one[id].Last(), player1Points[id].ToArray(), player2Points[id].ToArray()));
                }
                conn.Close();
                return schedule;
            }

        }
        private List<Game> GenerateSchedule(int tournamentID, List<Game> games)
        {
            int lastid;
            SqlConnection conn = new SqlConnection(new DatabaseLink().Link);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT GameID FROM Matches ORDER BY GameID DESC", conn);
            lastid = (int)cmd.ExecuteScalar();
            foreach (Game game in games)
            {
                lastid++;
                for (int i = 1; i <= game.Result().Item1.Length; i++)
                {
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO Matches(GameID,MatchID,TournamentID,Player1Email,Player2Email,Player1Points,Player2Points) VALUES(" + lastid + "," + i + "," + tournamentID + ",'" + game.player1Email + "','" + game.player2Email + "'," + 0 + "," + 0 + ")", conn);
                    cmd2.ExecuteNonQuery();
                }
            }
            conn.Close();
            return GetSchedule(tournamentID);
        }
        public void Create(Upcoming_tournament tournament)
        {
            SqlConnection conn = new SqlConnection(new DatabaseLink().Link);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Tournaments(ID, SportType, Description, StartDate, EndDate, MinPlayers, MaxPlayers, Location, System, NumGames) VALUES(@ID, @SportType, @Description, @StartDate, @EndDate, @MinPlayers, @MaxPlayers, @Location, @System, @NumGames)", conn);
            cmd.Parameters.AddWithValue("@ID", tournament.Id);
            cmd.Parameters.AddWithValue("@SportType", tournament.SportType);
            cmd.Parameters.AddWithValue("@Description", tournament.Description);
            cmd.Parameters.AddWithValue("@StartDate", tournament.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", tournament.EndDate);
            cmd.Parameters.AddWithValue("@MinPlayers", tournament.MinPlayers);
            cmd.Parameters.AddWithValue("@MaxPlayers", tournament.MaxPlayers);
            cmd.Parameters.AddWithValue("@Location", tournament.Location);
            cmd.Parameters.AddWithValue("@System", tournament.System);
            cmd.Parameters.AddWithValue("@NumGames", tournament.NumGames);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void Update(Tournament tournament)
        {
            SqlConnection conn = new SqlConnection(new DatabaseLink().Link);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Tournaments SET Description = @Description, StartDate = @StartDate, EndDate = @EndDate, NumGames = @NumGames WHERE ID = @TournamentID", conn);
            cmd.Parameters.AddWithValue("@Description", tournament.Description);
            cmd.Parameters.AddWithValue("@StartDate", tournament.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", tournament.EndDate);
            cmd.Parameters.AddWithValue("@NumGames", tournament.NumGames);
            cmd.Parameters.AddWithValue("@TournamentID", tournament.Id);
            cmd.ExecuteNonQuery();
            conn.Close ();
        }
        public void DeleteTournament(Tournament tournament)
        {
            SqlConnection conn = new SqlConnection(new DatabaseLink().Link);
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM Tournaments WHERE ID = @ID",conn);
            cmd.Parameters.AddWithValue("@ID", tournament.Id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void AddPlayer(int tournamentID, People player)
        {
            SqlConnection conn = new SqlConnection(new DatabaseLink().Link);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Leaderboard(TournamentID, Email, GamesWon) VALUES(@ID, @Email, @GamesWon)", conn);
            cmd.Parameters.AddWithValue("@ID", tournamentID);
            cmd.Parameters.AddWithValue("@Email", player.Email);
            cmd.Parameters.AddWithValue("@GamesWon", 0);
            cmd.ExecuteNonQuery ();
            conn.Close ();
        }
    }
}