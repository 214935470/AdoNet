using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AdoNet
{
    public class DataAccess
    {
        public string res = "yes";
         public int AddCategory(string connString)
        {
            string category;
            Console.WriteLine("insert a category name");
            category = Console.ReadLine();

            string query = "INSERT INTO Category(CategoryName)" + "VALUES(@CategoryName)";

            using (SqlConnection cn = new SqlConnection(connString))
            using(SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@CategoryName", System.Data.SqlDbType.NChar, 20).Value = category;

                cn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("Do you want to continue?");
                res = Console.ReadLine();

                cn.Close();
                return rowsAffected;
                    
            }
            


        }





        public int AddProduct(string connString)
        {
            int Category_Id;
            Console.WriteLine("insert a categoryID");
            Category_Id = int.Parse(Console.ReadLine());


            string Name;
            Console.WriteLine("insert Name");
            Name = Console.ReadLine();

            string Description;
            Console.WriteLine("insert Description");
            Description = Console.ReadLine();


            float Price;
            Console.WriteLine("insert Price");
            Price = float.Parse(Console.ReadLine());

            string Image;
            Console.WriteLine("insert Image");
            Image = Console.ReadLine();



            string query = "INSERT INTO Product(Category_Id, Name, Description, Price, Image)" + "VALUES(@Category_Id ,@Name, @Description, @Price, @Image)";


            using (SqlConnection cn = new SqlConnection(connString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@Category_Id", System.Data.SqlDbType.Int).Value = Category_Id;
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.NChar,30).Value = Name;
                cmd.Parameters.Add("@Description", System.Data.SqlDbType.NChar, 70).Value = Description;
                cmd.Parameters.Add("@Price", System.Data.SqlDbType.Float).Value = Price;
                cmd.Parameters.Add("@Image", System.Data.SqlDbType.NChar,60).Value = Image;


                cn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                Console.WriteLine("Do you want to continue?");
                res = Console.ReadLine();

                cn.Close();
                return rowsAffected;
            }



        }




        public void readCategoryData(string connString)
        {
            string query = "select * from Category";
            using (SqlConnection cn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, cn);

                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}", reader[0], reader[1]);

                    }
                    reader.Close();
                    res = "no";
                    cn.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(); 
               
            }

        }

        public void readProductData(string connString)
        {
            string query = "select * from Product";
            using (SqlConnection cn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(query, cn);

                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}\t{4}\t{5}", reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);

                    }
                    reader.Close();
                    res = "no";
                    cn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine();

            }

        }

    }




   




}
