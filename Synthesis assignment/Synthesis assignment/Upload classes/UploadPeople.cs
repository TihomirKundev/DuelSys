using MySql.Data.MySqlClient;
using SynthesisAssignment.Base_classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisAssignment.Upload_classes
{
    public class UploadPeople : IUploadPeople
    {
        public People Login(string email, string password, string type)
        {
            People person = null;
            MySqlConnection conn = new MySqlConnection(new DatabaseLink().Link);
            conn.Open();
            MySqlCommand cmd;
            if(type == "Staff")
            {
                cmd = new MySqlCommand("SELECT * FROM Staff Where Email = @Email AND Password = @Password", conn);
            }
            else
            {
                cmd = new MySqlCommand("SELECT * FROM Players Where Email = @Email AND Password = @Password", conn);
            }
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Password", password);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                string firstName = Convert.ToString(dr["FirstName"]);
                string lastName = Convert.ToString(dr["LastName"]);
                string email2 = Convert.ToString(dr["Email"]);
                string password2 = Convert.ToString(dr["Password"]);
                person = new People(firstName, lastName, email2, password2);
            }
            conn.Close();
            return person;
        }
        public People RegisterPlayer(People people)
        {
            MySqlConnection conn = new MySqlConnection(new DatabaseLink().Link);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT Count(1) FROM Players WHERE Email = '" + people.Email + "'", conn);
            int exist = (int)cmd.ExecuteScalar();
            if (exist == 0)
            {
                MySqlCommand cmd2 = new MySqlCommand("INSERT INTO PLayers(FirstName, LastName, Email, Password) VALUES(@FirstName, @LastName, @Email, @Password);", conn);
                cmd2.Parameters.AddWithValue("@FirstName", people.Fname);
                cmd2.Parameters.AddWithValue("@LastName", people.Lname);
                cmd2.Parameters.AddWithValue("@Email", people.Email);
                cmd2.Parameters.AddWithValue("@Password", people.Password);
                cmd2.ExecuteNonQuery();
                conn.Close();
                return Login(people.Email, people.Password, "Player");
            }
            else
            {
                conn.Close();
                return null;
            }
        }
    }
}
