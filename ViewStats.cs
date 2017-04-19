using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace ConsoleApplication5
{
    class ViewStats
    {

        public int type1, type2, stat;

        public void getStats(int x, int y)
        {
            String connectionString = @"Data Source=(LocalDB)\ProjectsV12;Initial Catalog=Sample1;Integrated Security=true";

            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (var cmd = new SqlCommand("spGetStats", conn))
                    {
                        var typeparam1 = new SqlParameter();
                        typeparam1.ParameterName = "@type1";
                        typeparam1.SqlDbType = SqlDbType.Int;
                        typeparam1.Direction = ParameterDirection.Input;
                        typeparam1.Value = x;

                        var typeparam2 = new SqlParameter();
                        typeparam2.ParameterName = "@type2";
                        typeparam2.SqlDbType = SqlDbType.Int;
                        typeparam2.Direction = ParameterDirection.Input;
                        typeparam2.Value = y;
                        SqlDataReader reader;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(typeparam1);
                        cmd.Parameters.Add(typeparam2);
                        
                        reader = cmd.ExecuteReader();
                        Console.Clear();
                        switch (stat)
                        {
                            case 0:
                                while (reader.Read())
                                {
                                    string mi = reader["AvgMiles"].ToString();
                                    string gl = reader["AvgGallons"].ToString();
                                    string mpg = reader["AvgMPG"].ToString();
                                    string pr = reader["AvgPrice"].ToString();

                                    System.Console.WriteLine("\nMiles".PadRight(11) + "Gallons".PadRight(10) + "MPG".PadRight(9) + "PricePaid");
                                    System.Console.WriteLine("-----".PadRight(10) + "------".PadRight(10) + "----".PadRight(9) + "---------");
                                    System.Console.WriteLine(mi.PadRight(10) + gl.PadRight(10) + mpg.PadRight(9) + pr);
                                    //System.Console.WriteLine("\nConnection and Query Execution Successful.\n");
                                }
                                break;
                            case 1:
                                while (reader.Read())
                                {
                                    string mi = reader["MaxMiles"].ToString();
                                    string gl = reader["MaxGallons"].ToString();
                                    string mpg = reader["MaxMPG"].ToString();
                                    string pr = reader["MaxPrice"].ToString();

                                    System.Console.WriteLine("\nMiles".PadRight(11) + "Gallons".PadRight(10) + "MPG".PadRight(9) + "PricePaid");
                                    System.Console.WriteLine("-----".PadRight(10) + "------".PadRight(10) + "----".PadRight(9) + "---------");
                                    System.Console.WriteLine(mi.PadRight(10) + gl.PadRight(10) + mpg.PadRight(9) + pr);
                                    //System.Console.WriteLine("\nConnection and Query Execution Successful.\n");
                                }
                                break;
                            case 2:
                                while (reader.Read())
                                {
                                    string mi = reader["MinMiles"].ToString();
                                    string gl = reader["MinGallons"].ToString();
                                    string mpg = reader["MinMPG"].ToString();
                                    string pr = reader["MinPrice"].ToString();

                                    System.Console.WriteLine("\nMiles".PadRight(11) + "Gallons".PadRight(10) + "MPG".PadRight(9) + "PricePaid");
                                    System.Console.WriteLine("-----".PadRight(10) + "------".PadRight(10) + "----".PadRight(9) + "---------");
                                    System.Console.WriteLine(mi.PadRight(10) + gl.PadRight(10) + mpg.PadRight(9) + pr);
                                    //System.Console.WriteLine("\nConnection and Query Execution Successful.\n");
                                }                                
                                break;
                            case 3:
                                while (reader.Read())
                                {
                                    string mi = reader["MaxMiles"].ToString();
                                    string gl = reader["gGallons"].ToString();
                                    string mpg = reader["gMPG"].ToString();
                                    string pr = reader["gPricePaid"].ToString();
                                    string dt = reader["gDate"].ToString();

                                    System.Console.WriteLine("\nMiles".PadRight(11) + "Gallons".PadRight(10) + "MPG".PadRight(9) + "PricePaid".PadRight(12) + "Date");
                                    System.Console.WriteLine("-----".PadRight(10) + "------".PadRight(10) + "----".PadRight(9) + "---------".PadRight(12) + "----");
                                    System.Console.WriteLine(mi.PadRight(10) + gl.PadRight(10) + mpg.PadRight(9) + pr.PadRight(12) + dt);
                                    //System.Console.WriteLine("\nConnection and Query Execution Successful.\n");
                                }
                                break;

                            case 4:
                                while (reader.Read())
                                {
                                    string mi = reader["gMiles"].ToString();
                                    string gl = reader["MaxGallons"].ToString();
                                    string mpg = reader["gMPG"].ToString();
                                    string pr = reader["gPricePaid"].ToString();
                                    string dt = reader["gDate"].ToString();

                                    System.Console.WriteLine("\nMiles".PadRight(11) + "Gallons".PadRight(10) + "MPG".PadRight(9) + "PricePaid".PadRight(12) + "Date");
                                    System.Console.WriteLine("-----".PadRight(10) + "------".PadRight(10) + "----".PadRight(9) + "---------".PadRight(12) + "----");
                                    System.Console.WriteLine(mi.PadRight(10) + gl.PadRight(10) + mpg.PadRight(9) + pr.PadRight(12) + dt);
                                    //System.Console.WriteLine("\nConnection and Query Execution Successful.\n");
                                }
                                break;

                            case 5:
                                while (reader.Read())
                                {
                                    string mi = reader["gMiles"].ToString();
                                    string gl = reader["gGallons"].ToString();
                                    string mpg = reader["MaxMPG"].ToString();
                                    string pr = reader["gPricePaid"].ToString();
                                    string dt = reader["gDate"].ToString();

                                    System.Console.WriteLine("\nMiles".PadRight(11) + "Gallons".PadRight(10) + "MPG".PadRight(9) + "PricePaid".PadRight(12) + "Date");
                                    System.Console.WriteLine("-----".PadRight(10) + "------".PadRight(10) + "----".PadRight(9) + "---------".PadRight(12) + "----");
                                    System.Console.WriteLine(mi.PadRight(10) + gl.PadRight(10) + mpg.PadRight(9) + pr.PadRight(12) + dt);
                                }
                                break;

                            case 6:
                                while (reader.Read())
                                {
                                    string mi = reader["gMiles"].ToString();
                                    string gl = reader["gGallons"].ToString();
                                    string mpg = reader["gMPG"].ToString();
                                    string pr = reader["MaxPrice"].ToString();
                                    string dt = reader["gDate"].ToString();

                                    System.Console.WriteLine("\nMiles".PadRight(11) + "Gallons".PadRight(10) + "MPG".PadRight(9) + "PricePaid".PadRight(12) + "Date");
                                    System.Console.WriteLine("-----".PadRight(10) + "------".PadRight(10) + "----".PadRight(9) + "---------".PadRight(12) + "----");
                                    System.Console.WriteLine(mi.PadRight(10) + gl.PadRight(10) + mpg.PadRight(9) + pr.PadRight(12) + dt);
                                }
                                break;

                            case 7:
                                while (reader.Read())
                                {
                                    string mi = reader["MinMiles"].ToString();
                                    string gl = reader["gGallons"].ToString();
                                    string mpg = reader["gMPG"].ToString();
                                    string pr = reader["gPricePaid"].ToString();
                                    string dt = reader["gDate"].ToString();

                                    System.Console.WriteLine("\nMiles".PadRight(11) + "Gallons".PadRight(10) + "MPG".PadRight(9) + "PricePaid".PadRight(12) + "Date");
                                    System.Console.WriteLine("-----".PadRight(10) + "------".PadRight(10) + "----".PadRight(9) + "---------".PadRight(12) + "----");
                                    System.Console.WriteLine(mi.PadRight(10) + gl.PadRight(10) + mpg.PadRight(9) + pr.PadRight(12) + dt);
                                }
                                break;

                            case 8:
                                while (reader.Read())
                                {
                                    string mi = reader["gMiles"].ToString();
                                    string gl = reader["MinGallons"].ToString();
                                    string mpg = reader["gMPG"].ToString();
                                    string pr = reader["gPricePaid"].ToString();
                                    string dt = reader["gDate"].ToString();

                                    System.Console.WriteLine("\nMiles".PadRight(11) + "Gallons".PadRight(10) + "MPG".PadRight(9) + "PricePaid".PadRight(12) + "Date");
                                    System.Console.WriteLine("-----".PadRight(10) + "------".PadRight(10) + "----".PadRight(9) + "---------".PadRight(12) + "----");
                                    System.Console.WriteLine(mi.PadRight(10) + gl.PadRight(10) + mpg.PadRight(9) + pr.PadRight(12) + dt);
                                }
                                break;

                            case 9:
                                while (reader.Read())
                                {
                                    string mi = reader["gMiles"].ToString();
                                    string gl = reader["gGallons"].ToString();
                                    string mpg = reader["MinMPG"].ToString();
                                    string pr = reader["gPricePaid"].ToString();
                                    string dt = reader["gDate"].ToString();

                                    System.Console.WriteLine("\nMiles".PadRight(11) + "Gallons".PadRight(10) + "MPG".PadRight(9) + "PricePaid".PadRight(12) + "Date");
                                    System.Console.WriteLine("-----".PadRight(10) + "------".PadRight(10) + "----".PadRight(9) + "---------".PadRight(12) + "----");
                                    System.Console.WriteLine(mi.PadRight(10) + gl.PadRight(10) + mpg.PadRight(9) + pr.PadRight(12) + dt);
                                }
                                break;

                            case 10:
                                while (reader.Read())
                                {
                                    string mi = reader["gMiles"].ToString();
                                    string gl = reader["gGallons"].ToString();
                                    string mpg = reader["gMPG"].ToString();
                                    string pr = reader["MinPricePaid"].ToString();
                                    string dt = reader["gDate"].ToString();

                                    System.Console.WriteLine("\nMiles".PadRight(11) + "Gallons".PadRight(10) + "MPG".PadRight(9) + "PricePaid".PadRight(12) + "Date");
                                    System.Console.WriteLine("-----".PadRight(10) + "------".PadRight(10) + "----".PadRight(9) + "---------".PadRight(12) + "----");
                                    System.Console.WriteLine(mi.PadRight(10) + gl.PadRight(10) + mpg.PadRight(9) + pr.PadRight(12) + dt);
                                }
                                break;

                            default:
                                Console.WriteLine("\nInvalid Argument passed.\n");
                                break;
                        }                                                             
                    }
                }

                catch (Exception e)
                {
                    Console.Clear();
                    System.Console.WriteLine("\n{0}\n", e);
                    System.Console.ReadKey();
                }

                var exit = new Program();
                exit.Exit(2);
            }
        }

        public void StatsMenu()
        {
            System.Console.WriteLine("\nSelect Desired Statistic to view: \n");
            System.Console.WriteLine(" 0) Overall Averages");           // 0,0
            System.Console.WriteLine(" 1) Overall Maximums");           // 1,0
            System.Console.WriteLine(" 2) Overall Minimums");           // 2,0
            System.Console.WriteLine(" 3) Top Miles Recorded");         // 0,1
            System.Console.WriteLine(" 4) Top Gallons Recorded");       // 1,1
            System.Console.WriteLine(" 5) Top MPG Recorded");           // 2,1
            System.Console.WriteLine(" 6) Top Price Recorded");         // 3,1
            System.Console.WriteLine(" 7) Lowest Miles Recorded");      // 0,2
            System.Console.WriteLine(" 8) Lowest Gallons Recorded");    // 1,2
            System.Console.WriteLine(" 9) Lowest MPG Recorded");        // 2,2
            System.Console.WriteLine("10) Lowest Price Recorded\n");    // 3,2
            System.Console.WriteLine("11) Main Menu");
            System.Console.WriteLine("12) Exit\n");

            stat = int.Parse(Console.ReadLine());

            switch (stat)
            {
                case 0:
                    type1 = 0;
                    type2 = 0;
                    getStats(type1, type2);
                    break;
                case 1:
                    type1 = 1;
                    type2 = 0;
                    getStats(type1, type2);
                    break;
                case 2:
                    type1 = 2;
                    type2 = 0;
                    getStats(type1, type2);
                    break;
                case 3:
                    type1 = 0;
                    type2 = 1;
                    getStats(type1, type2);
                    break;

                case 4:
                    type1 = 1;
                    type2 = 1;
                    getStats(type1, type2);
                    break;

                case 5:
                    type1 = 2;
                    type2 = 1;
                    getStats(type1, type2);
                    break;

                case 6:
                    type1 = 3;
                    type2 = 1;
                    getStats(type1, type2);
                    break;

                case 7:
                    type1 = 0;
                    type2 = 2;
                    getStats(type1, type2);
                    break;

                case 8:
                    type1 = 1;
                    type2 = 2;
                    getStats(type1, type2);
                    break;

                case 9:
                    type1 = 2;
                    type2 = 2;
                    getStats(type1, type2);
                    break;

                case 10:
                    type1 = 3;
                    type2 = 2;
                    getStats(type1, type2);
                    break;
                case 11:
                    var beginning = new Program();
                    beginning.Menu();
                    break;
                case 12:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nInvalid Argument passed.\n");
                    break;
            }
        }
    }
}
