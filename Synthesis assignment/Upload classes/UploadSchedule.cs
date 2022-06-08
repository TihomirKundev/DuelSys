using Synthesis_assignment.Base_classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesis_assignment.Upload_classes
{
    public class UploadSchedule : IUploadSchedule
    {
        public void UploadMatchResults(int gameID, int matchId, int player1Points, int player2Points)
        {
            SqlConnection conn = new SqlConnection(new DatabaseLink().Link);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Matches SET Player1Points = @Player1Points, Player2Points = @Player2Points WHERE GameID = @GameID AND MatchID = @MatchID", conn);
            cmd.Parameters.AddWithValue("@GameID", gameID);
            cmd.Parameters.AddWithValue("@MatchID", matchId);
            cmd.Parameters.AddWithValue("@Player1Points", player1Points);
            cmd.Parameters.AddWithValue("@Player2Points", player2Points);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void AddWin(int tournamentID, string playerEmail)
        {
            SqlConnection conn = new SqlConnection(new DatabaseLink().Link);
            conn.Open();
            SqlCommand cmd2 = new SqlCommand("Update Leaderboard SET GamesWon += 1 WHERE TournamentID = @TournamentID AND Email = @Email", conn);
            cmd2.Parameters.AddWithValue("@TournamentID", tournamentID);
            cmd2.Parameters.AddWithValue("@Email", playerEmail);
            cmd2.ExecuteNonQuery();
            conn.Close();
        }
    }
}
