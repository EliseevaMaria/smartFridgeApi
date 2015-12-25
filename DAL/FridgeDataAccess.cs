using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Models;

namespace DAL
{
    public static class FridgeDataAccess
    {
        const string _connection = "Server = tcp:smartfridge.database.windows.net,1433; Database = smartFridge; User ID = maria@smartfridge; Password = Helloworld123; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        public static Fridge GetFridge(int id)
        {
            Fridge result = null;
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT * FROM Fridge WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        result = new Fridge
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            FridgeTemp = dr.GetInt32(2),
                            FreezerTemp = dr.GetInt32(3),
                            Alarm = dr.GetBoolean(4),
                            FridgeOpened = dr.GetBoolean(5),
                            FreezerOpened = dr.GetBoolean(6),
                            TimeFridgeOpened = dr.GetDateTime(7),
                            TimeFreezerOpened = dr.GetDateTime(8),
                            UserEmail = dr.GetString(9)
                        };
                    }
                }
            }
            return result;
        }

        public static List<Fridge> GetFridges(string email)
        {
            List<Fridge> result = new List<Fridge>();
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT * FROM Fridge WHERE UserEmail=@Email", conn);
                cmd.Parameters.AddWithValue("@Email", email);
                using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (dr.Read())
                    {
                        result.Add(new Fridge
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            FridgeTemp = dr.GetInt32(2),
                            FreezerTemp = dr.GetInt32(3),
                            Alarm = dr.GetBoolean(4),
                            FridgeOpened = dr.GetBoolean(5),
                            FreezerOpened = dr.GetBoolean(6),
                            TimeFridgeOpened = dr.GetDateTime(7),
                            TimeFreezerOpened = dr.GetDateTime(8),
                            UserEmail = dr.GetString(9)
                        });
                    }
                }
            }
            return result;
        }

        public static void ChangeFridge(string command, Fridge fridge)
        {
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                var cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@Id", fridge.Id);
                cmd.Parameters.AddWithValue("@Name", fridge.Name);
                cmd.Parameters.AddWithValue("@FridgeTemp", fridge.FridgeTemp);
                cmd.Parameters.AddWithValue("@FreezerTemp", fridge.FreezerTemp);
                cmd.Parameters.AddWithValue("@Alarm", fridge.Alarm);
                cmd.Parameters.AddWithValue("@FridgeOpened", fridge.FridgeOpened);
                cmd.Parameters.AddWithValue("@FreezerOpened", fridge.FreezerOpened);
                cmd.Parameters.AddWithValue("@TimeFridgeOpened", fridge.TimeFridgeOpened);
                cmd.Parameters.AddWithValue("@TimeFreezerOpened", fridge.TimeFreezerOpened);
                cmd.Parameters.AddWithValue("@UserEmail", fridge.UserEmail);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
