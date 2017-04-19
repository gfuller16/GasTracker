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
    class QueryTable
    {
        public void GetDataSet(int x)
        {
            if (x == 0)
            {
                String connectionString = @"Data Source=(LocalDB)\ProjectsV12;Initial Catalog=Sample1;Integrated Security=true";
                String commandString = "SELECT gID AS ID, CONVERT(DECIMAL(4,1),gMiles) as Miles, CONVERT(DECIMAL(5,3),gGallons) as Gallons, CONVERT(DECIMAL(4,2),gMPG) as MPG, CONVERT(DECIMAL(3,2),gPricePaid) as PricePaid, gDate as [Date], gDaysBetween as [DaysSince] FROM [dbo].[tblGasTracker]";
                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        using (var cmd = new SqlCommand(commandString, conn))
                        {
                            SqlDataReader reader;

                            reader = cmd.ExecuteReader();

                            System.Console.WriteLine("\nID".PadRight(7) + "Miles".PadRight(8) + "Gallons".PadRight(10) + "MPG".PadRight(9) + "PricePaid".PadRight(12) + "Date".PadRight(24) + "Days Since");
                            System.Console.WriteLine("---".PadRight(6) + "-----".PadRight(8) + "------".PadRight(10) + "----".PadRight(9) + "---------".PadRight(12) + "----".PadRight(24) + "---------");

                            while (reader.Read())
                            {
                                string id =  reader["ID"].ToString();
                                string mi =  reader["Miles"].ToString();
                                string gl =  reader["Gallons"].ToString();
                                string mpg = reader["MPG"].ToString();
                                string pr =  reader["PricePaid"].ToString();
                                string dt =  reader["Date"].ToString();
                                string ds = reader["DaysSince"].ToString();

                                System.Console.WriteLine(id.PadRight(6) + mi.PadRight(8) + gl.PadRight(10) + mpg.PadRight(9) + pr.PadRight(12) + dt.PadRight(24) + ds);
                            }
                        }
                    }

                    catch (Exception e)
                    {
                        Console.Clear();
                        System.Console.WriteLine("\n{0}\n", e);
                        System.Console.ReadKey();
                    }
                }
            }

            else
            {
                String connectionString = @"Data Source=(LocalDB)\ProjectsV12;Initial Catalog=Sample1;Integrated Security=true";
                String commandString = "SELECT gID AS ID, CONVERT(DECIMAL(4,1),gMiles) as Miles, CONVERT(DECIMAL(5,3),gGallons) as Gallons, CONVERT(DECIMAL(4,2),gMPG) as MPG, CONVERT(DECIMAL(3,2),gPricePaid) as PricePaid, gDate as [Date], gDaysBetween as [DaysSince] FROM [dbo].[tblGasTracker]";
                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        using (var cmd = new SqlCommand(commandString, conn))
                        {
                            SqlDataReader reader;

                            reader = cmd.ExecuteReader();

                            System.Console.WriteLine("\nID".PadRight(7) + "Miles".PadRight(8) + "Gallons".PadRight(10) + "MPG".PadRight(9) + "PricePaid".PadRight(12) + "Date".PadRight(24) + "Days Since");
                            System.Console.WriteLine("---".PadRight(6) + "-----".PadRight(8) + "------".PadRight(10) + "----".PadRight(9) + "---------".PadRight(12) + "----".PadRight(24) + "---------");

                            while (reader.Read())
                            {
                                string id = reader["ID"].ToString();
                                string mi = reader["Miles"].ToString();
                                string gl = reader["Gallons"].ToString();
                                string mpg = reader["MPG"].ToString();
                                string pr = reader["PricePaid"].ToString();
                                string dt = reader["Date"].ToString();
                                string ds = reader["DaysSince"].ToString();

                                System.Console.WriteLine(id.PadRight(6) + mi.PadRight(8) + gl.PadRight(10) + mpg.PadRight(9) + pr.PadRight(12) + dt.PadRight(24) + ds);
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
                    exit.Exit(0);
                }
            }
        }

        public void DeleteRecord()
        {
            GetDataSet(0);
            Console.Write("\nEnter ID to delete: ");
            var id = Console.ReadLine();

            System.Console.WriteLine("Proceed? (y) YES, (n) NO\n");
            var yn = Console.ReadLine();

            if (yn == "y")
            {

                String connectionString = @"Data Source=(LocalDB)\ProjectsV12;Initial Catalog=Sample1;Integrated Security=true";
                String commandString = "DELETE FROM [Sample1].[dbo].[tblGasTracker] WHERE gID = @ID";

                using (var conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();

                        using (var cmd = new SqlCommand(commandString, conn))
                        {
                            var param1 = new SqlParameter();
                            param1.ParameterName = "@ID";
                            param1.SqlDbType = SqlDbType.Int;
                            param1.Direction = ParameterDirection.Input;
                            param1.Value = id;

                            cmd.Parameters.Add(param1);

                            cmd.ExecuteNonQuery();

                            System.Console.WriteLine("\nConnection and Query Execution Successful.\n");
                        }
                    }

                    catch (Exception e)
                    {
                        System.Console.WriteLine("{0}\n", e);
                    }

                    var beginning = new Program();
                    beginning.Menu();
                }
            }
            else
            {
                System.Console.WriteLine("No, or invalid character entered. Exiting now...\n");
                var beginning = new Program();
                beginning.Menu();
            }
        }
    }
}
