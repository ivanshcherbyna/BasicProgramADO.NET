using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADOnetHomeWork1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection();
            try
            {
               // Console.WriteLine("Имеются такие : ");
                Console.WriteLine("Введите имя базы данных, например books, library: ");
                string cataloge = Console.ReadLine();
                string connectionParam1 = "Data Source = localhost; Initial Catalog =";
                string connectionParam2 = "; Integrated Security = true";
                string connectionParam = connectionParam1 + cataloge + connectionParam2;


                // con.ConnectionString = "Data Source = localhost; Initial Catalog = books; Integrated Security = true";
                con.ConnectionString = connectionParam;
                con.Open();
                Console.WriteLine("Введите имя таблицы например books, themes: ");
                string table = Console.ReadLine();
                SqlCommand SelectBooks = new SqlCommand("SELECT TOP 4* FROM "+table, con);
                SqlDataReader reader = SelectBooks.ExecuteReader();
                while (reader.Read()!=false)
                {
                    Console.WriteLine(reader[1]+"\t \t"+reader[3]);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
