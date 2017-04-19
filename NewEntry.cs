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

        public NewEntry(double Miles, double Gallons, double PricePaid)
        {
            miles = Miles;
            gallons = Gallons;
            pricepaid = PricePaid;
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
                Console.WriteLine("You have not entered an appropriate value!/n");
            }
            else
                System.Console.WriteLine("Accepted\n");

            //System.Console.ReadKey();

            double GAL;
            Console.Write("Enter Gallons: ");
            var input2 = Console.ReadLine();

            if (!double.TryParse(input2, out GAL))
            {
                Console.WriteLine("You have not entered an appropriate value!/n");
            }
            else
                System.Console.WriteLine("Accepted\n");

            //System.Console.ReadKey();

            double PRICE;
            Console.Write("Enter Price Paid: ");
            var input3 = Console.ReadLine();

            if (!double.TryParse(input3, out PRICE))
            {
                Console.WriteLine("You have not entered an appropriate value!/n");
            }
            else
                System.Console.WriteLine("Accepted\n");

            System.Console.WriteLine("Proceed? (y) YES, (n) NO\n");
            var yn = Console.ReadLine();

            if (yn == "y")
            {
                NewEntry newentry = new NewEntry(MI, GAL, PRICE);
                newentry.InsertNewEntry(MI, GAL, PRICE);
            }
            else
                System.Console.WriteLine("No, or invalid character entered. Exiting now...\n");

            var beginning = new Program();
            beginning.Menu();
        }

        public void InsertNewEntry(double mi, double gal, double price)
        {
            mi = miles;
            gal = gallons;
            price = pricepaid;

            double mpg = mi / gal;

            System.Console.WriteLine("\nMPG = {0}\n", mpg.ToString());
            System.Console.WriteLine("Price Paid = ${0}\n", price.ToString());

            String connectionString = @"<Database Connection String>";
            String commandString = "dbo.spNewEntry @Miles, @Gallons, @Price";

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

                        cmd.Parameters.Add(param1);
                        cmd.Parameters.Add(param2);
                        cmd.Parameters.Add(param3);

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
