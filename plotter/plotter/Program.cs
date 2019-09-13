using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Wpf;

namespace plotter
{
    class Program
    {
        static void Main(string[] args)
        {
            int nclusters = 10;
            Console.WriteLine("Do you want to make a scatterplot, answer yes or no?");
            string answer = Console.ReadLine();
            if (answer == "yes" || answer == "Yes")
            {
                Console.WriteLine("This program will first make scatterplots of two chosen properties");

                Console.WriteLine("Please enter the first properties to make a scatterplot of");
                string property1 = Console.ReadLine();
                string property2 = Console.ReadLine();

                Console.WriteLine("Do you want to separate the data into clusters?");
                answer = Console.ReadLine();
                if (answer == "yes" || answer == "Yes")
                {
                    string SQL_query = "SELECT " + property1 + ", " + property2 + ", clusters FROM";
                    double[,] values = new double[nclusters, 10000];

                    for (int i = 0; i < data.Length(); i++)
                    {

                    }
                }
                else
                {
                    string SQL_query = "SELECT " + property1 + ", " + property2 + " FROM";

                    values = new ChartValues<ObservablePoint>();

                    for (int i = 0; i < data.Length(); i++)
                    {
                        values.Add(new ObservablePoint(data[i][0], data[i][1]));
                    }
                     public ChartValues<ObservablePoint> values { get; set; }
                
                }
            }
                   
        }
    }
}
