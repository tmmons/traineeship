using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace plotter
{
    class Program
    {
        static void Main(string[] args)
        {
            int nclusters = 10;
            string connectionstring = "";
            string cnn = "";
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
                    string SQL_query = "SELECT " + property1 + ", " + property2 + ", clusters WHERE IsNumeric(" + property1 + ")=1 AND IsNumeric(" + property2 + ")=1 FROM exoplanets";
                    SqlCommand command = new SqlCommand(SQL_query, cnn);
                    SqlDataReader reader;
                    reader = command.ExecuteReader();
                    List<double> data_ID = new List<double>();
                    List<double> data_1 = new List<double>();
                    List<double> data_2 = new List<double>();
                    List<double> data_cluster = new List<double>();
                    while (reader.Read())
                    {
                        data_ID.Add(double(reader.GetValue(0)));
                        data_1.Add(double(reader.GetValue(1)));
                        data_2.Add(double(reader.GetValue(2)));
                        data_cluster.Add(double(reader.GetValue(3)));
                    }
                    command.Dispose();
                    cnn.Close();

                    values = new ChartValues<ObservablePoint>();

                    for (int i = 0; i < data_1.Length(); i++)
                    {
                        values.Add(new ObservablePoint(data_1[i], data_2[i]));
                    }
                    DataContext = this;
                }
                else
                {
                    string SQL_query = "SELECT " + property1 + ", " + property2 + "WHERE IsNumeric(" + property1 + ") = 1 AND IsNumeric(" + property2 + ")= 1 FROM exoplanets";
                    SqlCommand command = new SqlCommand(SQL_query, cnn);
                    SqlDataReader reader;
                    reader = command.ExecuteReader();
                    List<double> data_ID = new List<double>();
                    List<double> data_1 = new List<double>();
                    List<double> data_2 = new List<double>();
                    while (reader.Read())
                    {
                        data_ID.Add(double(reader.GetValue(0)));
                        data_1.Add(double(reader.GetValue(1)));
                        data_2.Add(double(reader.GetValue(2)));
                    }
                    command.Dispose();
                    cnn.Close();

                    values = new ChartValues<ObservablePoint>();

                    for (int i = 0; i < data_1.Length(); i++)
                    {
                        values.Add(new ObservablePoint(data_1[i], data_2[i]));
                    }
                    DataContext = this;
                }

            }

        }
                     
    }
}
/*Useful stuff from this program
 * using System.Data.SqlClient;
 * int nclusters = 10;
            string connectionstring = "";
            string cnn = "";
 * 
 * string SQL_query = "SELECT " + property1 + ", " + property2 + ", clusters WHERE IsNumeric(" + property1 + ")=1 AND IsNumeric(" + property2 + ")=1 FROM exoplanets";
                    SqlCommand command = new SqlCommand(SQL_query, cnn);
                    SqlDataReader reader;
                    reader = command.ExecuteReader();
                    List<double> data_ID = new List<double>();
                    List<double> data_1 = new List<double>();
                    List<double> data_2 = new List<double>();
                    List<double> data_cluster = new List<double>();
                    while (reader.Read())
                    {
                        data_ID.Add(double(reader.GetValue(0)));
                        data_1.Add(double(reader.GetValue(1)));
                        data_2.Add(double(reader.GetValue(2)));
                        data_cluster.Add(double(reader.GetValue(3)));
                    }
                    command.Dispose();
                    cnn.Close();
 * */
