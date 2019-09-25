using System;
using System.Data.SqlClient;
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
        
        const string connectionstring = "Data Source= DESKTOP-AFP1I0T\\SQLEXPRESS; Initial Catalog=exoplanets";
        SqlConnection cnn = new SqlConnection(connectionstring);
        private string property1 = "radial velocity e.g.";
        private string property2 = "radius e.g.";

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
            InitializeComponent();
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
                data_ID.Add((double) reader.GetValue(0));
                data_1.Add((double) reader.GetValue(1));
                data_2.Add((double) reader.GetValue(2));
                data_cluster.Add((double) reader.GetValue(3));
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

            for (var i = 0; i < data_ID.Count; i++)
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
    }
}