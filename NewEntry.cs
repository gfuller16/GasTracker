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
    class NewEntry
    {

        public double miles, gallons, pricepaid;
        public string date;

        public NewEntry(double Miles, double Gallons, double PricePaid, string Date)
        {
            miles = Miles;
            gallons = Gallons;
            pricepaid = PricePaid;
            date = Date;
        }

        public NewEntry()
        {

        }

        public void BeginNewEntry()
        {
            double MI;
            Console.Write("Enter Miles: ");
            var input = Console.ReadLine();

            if (!double.TryParse(input, out MI))
            {
                Console.WriteLine("You have not entered an appropriate value!\n");
            }
            else
                System.Console.WriteLine("Accepted\n");

            //System.Console.ReadKey();

            double GAL;
            Console.Write("Enter Gallons: ");
            var input2 = Console.ReadLine();

            if (!double.TryParse(input2, out GAL))
            {
                Console.WriteLine("You have not entered an appropriate value!\n");
            }
            else
                System.Console.WriteLine("Accepted\n");

            //System.Console.ReadKey();

            double PRICE;
            Console.Write("Enter Price Paid: ");
            var input3 = Console.ReadLine();

            if (!double.TryParse(input3, out PRICE))
            {
                Console.WriteLine("You have not entered an appropriate value!\n");
            }
            else
                System.Console.WriteLine("Accepted\n");

            string DATE;
            Console.Write("Enter Date Filled (mm/dd/yyyy): ");
            DATE = Console.ReadLine();

            System.Console.WriteLine("\nProceed? (y) YES, (n) NO\n");
            var yn = Console.ReadLine();

            if (yn == "y")
            {
                NewEntry newentry = new NewEntry(MI, GAL, PRICE, DATE);
                newentry.InsertNewEntry(MI, GAL, PRICE, DATE);
            }
            else
                System.Console.WriteLine("No, or invalid character entered. Exiting now...\n");

            var beginning = new Program();
            beginning.Menu();
        }

        public void InsertNewEntry(double mi, double gal, double price, string dt)
        {
            mi = miles;
            gal = gallons;
            price = pricepaid;
            dt = date;

            double mpg = mi / gal;

            String connectionString = @"Data Source=(LocalDB)\ProjectsV12;Initial Catalog=Sample1;Integrated Security=true";
            String commandString = "dbo.spNewEntry @Miles, @Gallons, @Price, @Date";

            using (var conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (var cmd = new SqlCommand(commandString, conn))
                    {
                        var param1 = new SqlParameter();
                        param1.ParameterName = "@Miles";
                        param1.SqlDbType = SqlDbType.Decimal;
                        param1.Direction = ParameterDirection.Input;
                        param1.Value = mi;

                        var param2 = new SqlParameter();
                        param2.ParameterName = "@Gallons";
                        param2.SqlDbType = SqlDbType.Decimal;
                        param2.Direction = ParameterDirection.Input;
                        param2.Value = gal;

                        var param3 = new SqlParameter();
                        param3.ParameterName = "@Price";
                        param3.SqlDbType = SqlDbType.Decimal;
                        param3.Direction = ParameterDirection.Input;
                        param3.Value = price;

                        var param4 = new SqlParameter();
                        param4.ParameterName = "@Date";
                        param4.SqlDbType = SqlDbType.VarChar;
                        param4.Direction = ParameterDirection.Input;
                        param4.Value = date;

                        cmd.Parameters.Add(param1);
                        cmd.Parameters.Add(param2);
                        cmd.Parameters.Add(param3);
                        cmd.Parameters.Add(param4);

                        cmd.ExecuteNonQuery();

                        System.Console.WriteLine("Connection and Query Execution Successful.\n");
                    }
                }

                catch(Exception e)
                {
                    System.Console.WriteLine("{0}\n", e);
                }
        
            }

        }
    }
}
