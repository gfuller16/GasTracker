using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            var start = new Program();
            start.Menu();
        }

        public void Menu()
        {
            Console.Clear();
            System.Console.WriteLine("\nWelcome to Gas Tracker! Select an Option from the Menu...\n\n");
            System.Console.WriteLine("1) New Entry");
            System.Console.WriteLine("2) View Stats");
            System.Console.WriteLine("3) View Table Entries");
            System.Console.WriteLine("4) Delete Table Entries");
            System.Console.WriteLine("5) Commute Cost Calculator");
            System.Console.WriteLine("6) Exit\n");

            int myInt = int.Parse(Console.ReadLine());

            if (myInt == 1)
            {
                var newentry = new NewEntry();
                Console.Clear();
                newentry.BeginNewEntry();
            }

            else if (myInt == 2)
            {
                var newstat = new ViewStats();
                Console.Clear();
                newstat.StatsMenu();
            }

            else if (myInt == 3)
            {
                var newquery = new QueryTable();
                Console.Clear();
                newquery.GetDataSet(1);
            }

            else if (myInt == 4)
            {
                var newquery = new QueryTable();
                Console.Clear();
                newquery.DeleteRecord();
            }

            else if (myInt == 5)
            {
                var newquery = new QueryTable();
                Console.Clear();
                newquery.ComCostCalc();
            }

            else
            {
                System.Console.WriteLine("\nAre you sure you want to exit? (y) YES, (n) NO\n");
                var exit = Console.ReadLine();

                if (exit == "y")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Menu();
                }
            }
        }

        public void Exit(int x)
        {
            //0 = GetDataSet; 1 = DeleteRecord; 2 = ViewStats
            System.Console.WriteLine("\n1) Main Menu");
            System.Console.WriteLine("2) Back");
            System.Console.WriteLine("3) Exit\n");

            int beg = int.Parse(Console.ReadLine());
            if (beg == 1)
            {
                var beginning = new Program();
                beginning.Menu();
            }
            else if (beg == 2)
            {
                switch (x)
                {
                    case 0:
                        var beginning = new Program();
                        beginning.Menu();
                        break;
                    case 1:

                        break;
                    case 2:
                        var newstat = new ViewStats();
                        Console.Clear();
                        newstat.StatsMenu();
                        break;
                    //default:
                }
            }
            else
            {
                System.Console.WriteLine("\nAre you sure you want to exit? (y) YES, (n) NO\n");
                var exit = Console.ReadLine();

                if (exit == "y")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Menu();
                }
            }
        }
    }
}
