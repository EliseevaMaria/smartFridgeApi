using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductDataAccess
    {
        const string _connection = "Server = tcp:smartfridge.database.windows.net,1433; Database = smartFridge; User ID = maria@smartfridge; Password = Helloworld123; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";

        public static Product GetProduct(int id)
        {
            Product result = null;
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT * FROM Product WHERE Id=@Id", conn);
                cmd.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        result = new Product
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            Measure = dr.GetString(2),
                            StorageLife = dr.GetInt32(3)
                        };
                    }
                }
            }
            return result;
        }

        public static List<Product> GetProducts()
        {
            List<Product> result = new List<Product>();
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT * FROM Product", conn);
                using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (dr.Read())
                    {
                        result.Add(new Product
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            Measure = dr.GetString(2),
                            StorageLife = dr.GetInt32(3)
                        });
                    }
                }
            }
            return result;
        }

        public static List<FridgeProduct> GetFridgeProducts(string email)
        {
            List<FridgeProduct> result = new List<FridgeProduct>();
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                conn.Open();
                var cmd = new SqlCommand(@"SELECT * FROM FridgeProduct WHERE User_email=@Email", conn);
                cmd.Parameters.AddWithValue("@Email", email);
                using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                {
                    while (dr.Read())
                    {
                        result.Add(new FridgeProduct
                        {
                            Id = dr.GetInt32(0),
                            ProductId = dr.GetInt32(1),
                            UserEmail = dr.GetString(2),
                            DateMade = dr.GetDateTime(3),
                            Amount = (float)dr.GetDouble(4),
                            MinAmount = 0
                        });
                    }
                }
            }
            return result;
        }

        public static void AddProduct(Product product)
        {
            string command = @"INSERT INTO Product VALUES (@Name, @Measure, @StorageLife)";
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                var cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Measure", product.Measure);
                cmd.Parameters.AddWithValue("@StorageLife", product.StorageLife);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void AddFridgeProduct(FridgeProductDTO product)
        {
            string command = @"INSERT INTO FridgeProduct VALUES (@ProductId, @User_email, @Date_made, @Amount, @Min_amount)";
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                var cmd = new SqlCommand(command, conn);
                cmd.Parameters.AddWithValue("@ProductId", product.Product.Id);
                cmd.Parameters.AddWithValue("@User_email", "maria97.55ua@gmail.com");
                cmd.Parameters.AddWithValue("@Date_made", product.DateMade);
                cmd.Parameters.AddWithValue("@Amount", product.Amount);
                cmd.Parameters.AddWithValue("@Min_amount", product.MinAmount);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void SetAmounts(int[] ids, float[] amounts)
        {
            string command = @"UPDATE FridgeProduct SET Amount = @Amount WHERE Id = @Id";
            using (SqlConnection conn = new SqlConnection(_connection))
            {
                var cmd = new SqlCommand(command, conn);
                for (int i = 0; i < ids.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@Id", ids[i]);
                    cmd.Parameters.AddWithValue("@Amount", amounts[i]);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
