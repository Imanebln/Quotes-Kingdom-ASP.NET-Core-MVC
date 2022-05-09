using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace jokes3.Quotes
{
    public class QuoteDAO
    {
        //connect to the database
        string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aspnet-jokes3-20220120023237;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //write sql expression
        public string  SelectCategory()
        {
            string result = "";
            string queryString = "SELECT Category FROM dbo.Quotes";

            using(SqlConnection conn = new SqlConnection(connString) )
            {
                SqlCommand cmd = new SqlCommand(queryString,conn);

                //open database and run cmd
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Console.WriteLine(reader["Category"]);
                        result = (string)reader["Category"];
                    }

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                
               
            }
            return result;
        }
        


        

    }
}