using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FulfillData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<string, List<CSVdata>> Data = new Dictionary<string, List<CSVdata>>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            string path = Environment.GetEnvironmentVariable("USERPROFILE") + @"\Downloads"; //gets paths to downloads directory

            OpenFileDialog OFD = new OpenFileDialog();
            OFD.InitialDirectory = path;
            OFD.Filter = "Comma Seperated Value Documents (.csv)|*.csv";

            if (OFD.ShowDialog() == true)
            {
                PopulateData(OFD.FileName);

                PopulateDataListBox("Male", lstMale);
                PopulateDataListBox("Female", lstFemale);
                PopulateDataListBox("Both", lstBoth);
                PopulateDataListBoxForMeanGreaterThan();//haha

            }

        }

        private void PopulateDataListBox(string gender, ListBox lst)
        {

            double maxMean = 0;

            foreach (var item in Data.Keys)
            {
                foreach (var gen in Data[item])
                {
                    if (gender.ToLower() == gen.Gender.ToLower())
                    {
                        if (gen.Mean > maxMean)
                        {
                            
                            maxMean = gen.Mean;
                        }
                    }
                }
            }

            foreach (var state in Data.Keys)
            {
                foreach (var gen in Data[state])
                {
                    if (gender.ToLower() == gen.Gender.ToLower())
                    {
                        if (gen.Mean == maxMean)
                        {
                            lstMale.Items.Add(state);

                            /*                          
                             *                          
                             *                          
                             *                          switch (gender)
                                                        {
                                                            case "males":
                                                                lstMale.Items.Add(state);
                                                                break;
                                                            case "females":
                                                                lstFemale.Items.Add(state);
                                                                break;
                                                            case "both":
                                                                lstBoth.Items.Add(state);
                                                                break;
                                                        }*/
                        }
                    }
                }
            }



        }

        private void PopulateDataListBoxForMeanGreaterThan()
        {
            double mean = 8;
           
            foreach (var state in Data.Keys)
            {
                foreach (var gen in Data[state])
                {
                    if ("both".ToLower() == gen.Gender.ToLower())
                    {
                        if (gen.Mean >= mean)
                        {
                            lstEight.Items.Add(state);

                        }
                    }
                }
            }



        }
        private void PopulateData(string file)
        {
            var lines = File.ReadAllLines(file);

            string state = "";



            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                var pieces = line.Split(',');
                if (string.IsNullOrWhiteSpace(pieces[0]) == false)
                {
                    state = pieces[0];
                }
                double mean;
                int n;

                if (double.TryParse(pieces[2], out mean) == false)
                {
                    continue;
                }

                if (int.TryParse(pieces[3], out n) == false)
                {
                    continue;
                }



                if (Data.ContainsKey(state) == false)
                {
                    Data.Add(state, new List<CSVdata>());


                }

                Data[state].Add(new CSVdata()
                {
                    State = state,
                    Gender = pieces[1],
                    Mean = mean,
                    N = n 


                });

            }
        }
    }
}
