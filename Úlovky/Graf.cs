namespace Úlovky
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Linq;
    using OxyPlot;
    using OxyPlot.Series;
    using System.Collections.Generic;
    using OxyPlot.Axes;
    using System.Windows;
    using System.Collections.ObjectModel;
    public class Graf
    {
        public PlotModel MyModel { get; private set; }
        public PlotModel graf2 { get; private set; }
        public PlotModel grafTime { get; private set; }
       
        Spravce_ulovku spravce_ulovku = new Spravce_ulovku();
        //public ObservableCollection<Ryba> Ulovky = new ObservableCollection<Ryba>();

        public Graf()
        {
            this.MyModel = new PlotModel { Title = "Example 1" };
            this.MyModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
            //Graf2();
            
           //Ulovky = spravce_ulovku.VratUlovky();
            spravce_ulovku.Nacti();
            //spravce_ulovku.ZobrazPocet();
            GrafTime();
        }

        //public void Graf2()
        //{
           
        //    this.Points = new List<DataPoint>
        //                      {
        //                          new DataPoint(0, 4),
        //                          new DataPoint(10, 13),
        //                          new DataPoint(20, 15),
        //                          new DataPoint(30, 16),
        //                          new DataPoint(40, 12),
        //                          new DataPoint(50, 12)
        //                      };
        //}
        //public IList<DataPoint> Points { get; private set; }

        public void GrafTime()
        {
           List<string> casList = new List<string>();
            
            for (int f = 4; f < 24; f++)
            {
                string fs = f.ToString();
                fs += " - ";
                int s = f + 1;
                fs += s.ToString();
                casList.Add(fs);

               
            }
            //int x = spravce_ulovku.Ulovky.Count;
            //MessageBox.Show(x.ToString(), "Chyba", MessageBoxButton.OK, MessageBoxImage.Information);
            int x4 = 0; int x5 = 0; int x6 = 0; int x7 = 0;
            int x8 = 0; int x9 = 0; int x10 = 0; int x11 = 0; int x12 = 0; int x13 = 0; int x14 = 0; int x15 = 0;
            int x16 = 0; int x17 = 0; int x18 = 0; int x19 = 0; int x20 = 0; int x21 = 0; int x22 = 0; int x23 = 0;

            foreach (Ryba y in spravce_ulovku.Ulovky)
            {
                //MessageBox.Show("začátek cyklu", "Chyba", MessageBoxButton.OK, MessageBoxImage.Information);
                //if (y.CasChyceni == "16 - 17")
                //{ x16++;
                //    MessageBox.Show("podmínka splněna", "Chyba", MessageBoxButton.OK, MessageBoxImage.Information);
                //}
                if (y.CasChyceni == "4 - 5") { x4++; }
                else if (y.CasChyceni == "5 - 6") { x5++; }
                else if (y.CasChyceni == "6 - 7") { x6++; }
                else if (y.CasChyceni == "7 - 8") { x7++; }
                else if (y.CasChyceni == "8 - 9") { x8++; }
                else if (y.CasChyceni == "9 - 10") { x9++; }
                else if (y.CasChyceni == "10 - 11") { x10++; }
                else if (y.CasChyceni == "11 - 12") { x11++; }
                else if (y.CasChyceni == "12 - 13") { x12++; }
                else if (y.CasChyceni == "13 - 14") { x13++; }
                else if (y.CasChyceni == "14 - 15") { x14++; }
                else if (y.CasChyceni == "15 - 16") { x15++; }
                else if (y.CasChyceni == "16 - 17") { x16++; }
                else if (y.CasChyceni == "17 - 18") { x17++; }
                else if (y.CasChyceni == "18 - 19") { x18++; }
                else if (y.CasChyceni == "19 - 20") { x19++; }
                else if (y.CasChyceni == "20 - 21") { x20++; }
                else if (y.CasChyceni == "21 - 22") { x21++; }
                else if (y.CasChyceni == "22 - 23") { x22++; }
                else if (y.CasChyceni == "23 - 24") { x23++; }
                //MessageBox.Show("konec cyklu", "Chyba", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            
            this.grafTime = new PlotModel { Title = "V kolik hodin" };
            
            var barSeries = new BarSeries
            {
                
                ItemsSource = new List<BarItem>(new[]
                {
                    new BarItem{ Value = x4 },
                    new BarItem{ Value = x5 },
                    new BarItem{ Value = x6 },
                    new BarItem{ Value = x7 },
                    new BarItem{ Value = x8 },
                    new BarItem{ Value = x9 },
                    new BarItem{ Value = x10 },
                    new BarItem{ Value = x11 },
                    new BarItem{ Value = x12 },
                    new BarItem{ Value = x13 },
                    new BarItem{ Value = x14 },
                    new BarItem{ Value = x15 },
                    new BarItem{ Value = x16 },
                    new BarItem{ Value = x17 },
                    new BarItem{ Value = x18 },
                    new BarItem{ Value = x19 },
                    new BarItem{ Value = x20 },
                    new BarItem{ Value = x21 },
                    new BarItem{ Value = x22 },
                    new BarItem{ Value = x23 },


                }),
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0}",
                
            };
            grafTime.Series.Add(barSeries);

            grafTime.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,


                ItemsSource = casList
                //new[]
                //{
                //    "16 - 17 hodin",
                //    "17 - 18 hodin",
                //    "18 - 19 hodin",
                //    "19 - 20 hodin",
                //    "20 - 21 hodin",
                //    "21 - 22 hodin",
                //    "22 - 23 hodin",
                //    "23 - 24 hodin",
                //}
            });
        }
    }
}




