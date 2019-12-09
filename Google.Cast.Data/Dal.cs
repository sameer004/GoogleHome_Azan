using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Cast.Data
{
    public class Dal : IDal
    {

        private SQLiteConnection conn;

        public Dal()
        {
            conn = CreateConnection();
        }
        private SQLiteConnection CreateConnection()
        {

            // Create a new database connection:
            conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {

            }
            return conn;
        }

        public void CreateTable()
        {

            SQLiteCommand sqlite_cmd;
            string Createsql = "CREATE TABLE Azan(Player VARCHAR(20), id INT)";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = Createsql;
            sqlite_cmd.ExecuteNonQuery();

        }

        public void InsertData()
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "INSERT INTO Azan (Player, id) VALUES('Ups ', 1); ";
            sqlite_cmd.ExecuteNonQuery();

        }

        public void DeleteData()
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "Delete From Azan ";
            sqlite_cmd.ExecuteNonQuery();

        }

        public void UpdatePlayer(string player)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "Update Azan set Player=:player where id=1 ";
            sqlite_cmd.Parameters.Add("player", DbType.String).Value = player;
            sqlite_cmd.ExecuteNonQuery();

        }

        public void ReadData()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Azan";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                string myreader = sqlite_datareader.GetString(0);
                Console.WriteLine(myreader);
            }
            conn.Close();
        }


        public string GetPlayer()
        {
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            string myreader = "";
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM Azan where id=1";

            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                myreader = Convert.ToString(sqlite_datareader["player"]);
                Console.WriteLine(myreader);
            }
            conn.Close();

            return myreader;
        }


    }
}
