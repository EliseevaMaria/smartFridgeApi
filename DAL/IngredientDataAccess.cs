using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class IngredientDataAccess
    {
        const string _connection = "Server = tcp:smartfridge.database.windows.net,1433; Database = smartFridge; User ID = maria@smartfridge; Password = Helloworld123; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        public static List<Ingredient> GetIngredients(int receiptId)
        {
            List<Ingredient> result = new List<Ingredient>();
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT * FROM Ingredient WHERE RecieptId=@ReceiptId", conn);
                cmd.Parameters.AddWithValue("@ReceiptId", receiptId);
                using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (dr.Read())
                    {
                        result.Add(new Ingredient
                        {
                            Id = dr.GetInt32(0),
                            RecieptId = receiptId,
                            ProductId = dr.GetInt32(2),
                            Amount = (float)dr.GetDouble(3)
                        });
                    }
                }
            }
            return result;
        }

        public static void RefreshIngredients(List<IngredientDTO> ingrs)
        {
            string command1 = @"DELETE FROM Ingredient WHERE RecieptId = @ReceiptId";
            string command2 = @"INSERT INTO Ingredient VALUES (@RecieptId, @ProductId, @Amount)";
            if (ingrs.Count > 0)
            {
                using (SqlConnection conn = new SqlConnection(_connection))
                {
                    var cmd = new SqlCommand(command1, conn);
                    cmd.Parameters.AddWithValue("@ReceiptId", ingrs[0].ReceiptId);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    for (int i = 0; i < ingrs.Count; i++)
                    {
                        var cmd2 = new SqlCommand(command2, conn);
                        cmd2.Parameters.AddWithValue("@RecieptId", ingrs[i].ReceiptId);
                        cmd2.Parameters.AddWithValue("@ProductId", ingrs[i].Product.Id);
                        cmd2.Parameters.AddWithValue("@Amount", ingrs[i].Amount);
                        cmd2.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}
