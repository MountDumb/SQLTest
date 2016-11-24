using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SQLTest
{
    class Program
    {
        private static string connectionString = "Server=ealdb1.eal.local; Database=ejl23_db; User=ejl23_usr; Password=Baz1nga23;";
        static void Main(string[] args)
        {
            Program prog = new SQLTest.Program();
            prog.Run();
            Console.ReadLine();
            
        }

        private void Run()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand("InsertPet", con);
                    cmd1.CommandType = CommandType.StoredProcedure;
                    cmd1.Parameters.Add("@Petname", SqlDbType.NVarChar);
                    cmd1.Parameters["@PetName"].Value = "Perdy";
                    cmd1.Parameters.Add(new SqlParameter("@PetType", "Cat"));
                    cmd1.Parameters.Add(new SqlParameter("@PetWeight", 2.54m));

                    cmd1.ExecuteNonQuery();
                    //con.Open();
                    //SqlCommand cmd1 = new SqlCommand("InsertPet", con);
                    //cmd1.CommandType = CommandType.StoredProcedure;
                    //cmd1.Parameters.Add("@Petname", SqlDbType.NVarChar);
                    //cmd1.Parameters["@PetName"].Value = "Kalle";
                    //cmd1.Parameters.Add(new SqlParameter("@PetType", "Kalle"));
                    //cmd1.Parameters.Add(new SqlParameter("@PetBreed", "Kalle"));
                    //cmd1.Parameters.Add(new SqlParameter("@PetDOB", DateTime.Now));
                    //cmd1.Parameters.Add(new SqlParameter("@PetWeight", 2.54m));

                    //cmd1.ExecuteNonQuery();

                }
                catch (SqlException e)
                {
                    Console.WriteLine("Ooops, you got the following errormessage: " + e.Message);
                }
            }
        }
    }
}
