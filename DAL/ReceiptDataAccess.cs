using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DAL
{
    public class ReceiptDataAccess
    {
        const string _connection = "Server = tcp:smartfridge.database.windows.net,1433; Database = smartFridge; User ID = maria@smartfridge; Password = Helloworld123; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        public static List<Receipt> GetReceipts(string email)
        {
            List<Receipt> result = new List<Receipt>();
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT * FROM Reciept WHERE UserEmail=@Email", conn);
                cmd.Parameters.AddWithValue("@Email", email);
                using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (dr.Read())
                    {
                        result.Add(new Receipt
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            UserEmail = dr.GetString(2),
                            IsPrivate = dr.GetBoolean(3),
                            Type = dr.GetString(4)
                        });
                    }
                }
            }
            return result;
        }

        public static string GetUser(int id)
        {
            string result = "";
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT * FROM Reciept WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        result = dr.GetString(2);
                    }
                }
            }
            return result;
        }

        public static void UpdateReceipt(Receipt receipt)
        {
            string command = @"UPDATE Reciept SET Name = @Name, IsPrivate = @IsPrivate, Type = @Type WHERE Id = @Id";
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                var cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@Id", receipt.Id);
                cmd.Parameters.AddWithValue("@Name", receipt.Name);
                cmd.Parameters.AddWithValue("@IsPrivate", receipt.IsPrivate);
                cmd.Parameters.AddWithValue("@Type", receipt.Type);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
