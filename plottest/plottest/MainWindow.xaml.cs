using System;
using System.Data.SqlClient;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using System.Collections.Generic;

namespace Wpf.CartesianChart.ScatterPlot
{
    /// <summary>
    /// Interaction logic for ScatterExample.xaml
    /// </summary>
    
    public partial class ScatterExample : UserControl
    {
        int nclusters = 10;
        const string connectionstring = "Server=localhost\\SQLEXPRESS01;Database=exoplanets; Trusted_Connection=True;";

        //const string connectionstring = "Data Source= DESKTOP-AFP1I0T\\SQLEXPRESS; Initial Catalog=exoplanets";
        SqlConnection cnn = new SqlConnection(connectionstring);
        private string property1 = "fst_mass";
        private string property2 = "fpl_eccen";

        public string prop1
        {
            get { return property1; }
            set { property1 = value; }
        }
        public string prop2
        {
            get { return property2; }
            set { property2 = value; }
        }
        

        public ScatterExample()
        {
            SqlDataReader dataReader;
            List<double> data_ID = new List<double>();
            List<double> data_1 = new List<double>();
            List<double> data_2 = new List<double>();
            List<double> data_cluster = new List<double>();
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "C:\\Program Files\\WindowsApps\\python3\\python.exe";
            string script = @"D:\\documents\\search4solutions\\programtest\\clustering.py";
            string input_var = "fpl_orbperfpl_smaxfpl_eccenfpl_bmassefpl_radefpl_eqtfst_tefffst_massfst_massfst_rad05";
            psi.Arguments = $"\"{script}\" \"{input_var}\"";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            using (Process process = Process.Start(psi))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string stderr = process.StandardError.ReadToEnd();
                    string result = reader.ReadToEnd();
                    if (string.IsNullOrEmpty(stderr)==false) { MessageBox.Show(stderr); }
                }
            }
            List<string> rowid = new List<string>();
            List<string> cluster = new List<string>();
            using (var reader = new StreamReader(@"D:\\documents\\search4solutions\\programtest\\cluster.csv"))
            {
                
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    rowid.Add(values[0]);
                    cluster.Add(values[1]);
                }
            }



            using (cnn)
            {
                InitializeComponent();
                string SQL_query = "SELECT rowid," + property1 + ", " + property2 + ", clusters FROM exoplanets_data WHERE IsNumeric(" + property1 + ")=1 AND IsNumeric(" + property2 + ")=1 ;";
                //string SQL_query = "select rowid from exoplanets_data;";
                SqlCommand command = new SqlCommand(SQL_query, cnn);
                cnn.Open();
                dataReader = command.ExecuteReader();
                string Output = "a";
                double number = 0.0;
                int counter = 0;

                while (dataReader.Read())
                {
                    Output = String.Format("{0}", dataReader.GetString(0));
                    number = Convert.ToDouble(Output);
                    data_ID.Add(number);
                    if (rowid.Contains(Output))
                    {
                        Output = String.Format("{0}", dataReader.GetString(1));
                        number = Convert.ToDouble(Output);
                        data_1.Add(number);
                        Output = String.Format("{0}", dataReader.GetString(2));
                        number = Convert.ToDouble(Output);
                        data_2.Add(number);
                        data_cluster.Add(Convert.ToInt32(cluster[counter]));
                        counter++;
                    }
                    
                    //Output = String.Format("{0}", dataReader.GetString(3));
                    //number = Convert.ToDouble(Output);
                    
                }

            }
            ValuesA = new ChartValues<ObservablePoint>();
            ValuesB = new ChartValues<ObservablePoint>();
            ValuesC = new ChartValues<ObservablePoint>();
            ValuesD = new ChartValues<ObservablePoint>();
            ValuesE = new ChartValues<ObservablePoint>();
            ValuesF = new ChartValues<ObservablePoint>();
            ValuesG = new ChartValues<ObservablePoint>();
            ValuesH = new ChartValues<ObservablePoint>();
            ValuesI = new ChartValues<ObservablePoint>();
            ValuesJ = new ChartValues<ObservablePoint>();
            Values_earth = new ChartValues<ObservablePoint>();
            
            for (var i = 0; i < data_1.Count; i++)
            {
                if (data_cluster[i] == 0) { ValuesA.Add(new ObservablePoint(data_1[i], data_2[i])); }
                else if (data_cluster[i] == 1) { ValuesB.Add(new ObservablePoint(data_1[i], data_2[i])); }
                else if (data_cluster[i] == 2) { ValuesC.Add(new ObservablePoint(data_1[i], data_2[i])); }
                else if (data_cluster[i] == 3) { ValuesD.Add(new ObservablePoint(data_1[i], data_2[i])); }
                else if (data_cluster[i] == 4) { ValuesE.Add(new ObservablePoint(data_1[i], data_2[i])); }
                else if (data_cluster[i] == 5) { ValuesF.Add(new ObservablePoint(data_1[i], data_2[i])); }
                else if (data_cluster[i] == 6) { ValuesG.Add(new ObservablePoint(data_1[i], data_2[i])); }
                else if (data_cluster[i] == 7) { ValuesH.Add(new ObservablePoint(data_1[i], data_2[i])); }
                else if (data_cluster[i] == 8) { ValuesI.Add(new ObservablePoint(data_1[i], data_2[i])); }
                else { ValuesJ.Add(new ObservablePoint(data_1[i], data_2[i])); }
            }

            DataContext = this;
        }

        public ChartValues<ObservablePoint> ValuesA { get; set; }
        public ChartValues<ObservablePoint> ValuesB { get; set; }
        public ChartValues<ObservablePoint> ValuesC { get; set; }
        public ChartValues<ObservablePoint> ValuesD { get; set; }
        public ChartValues<ObservablePoint> ValuesE { get; set; }
        public ChartValues<ObservablePoint> ValuesF { get; set; }
        public ChartValues<ObservablePoint> ValuesG { get; set; }
        public ChartValues<ObservablePoint> ValuesH { get; set; }
        public ChartValues<ObservablePoint> ValuesI { get; set; }
        public ChartValues<ObservablePoint> ValuesJ { get; set; }
        public ChartValues<ObservablePoint> Values_earth { get; set; }
    }
}