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
    }
}
