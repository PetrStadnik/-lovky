using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Linq;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay;
using System.Windows;

namespace Úlovky
{
    public class Spravce_ulovku : INotifyPropertyChanged
    {

        private string cesta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "UlovkyApp1");
        public event PropertyChangedEventHandler PropertyChanged;
        protected void VyvolejZmenu(string vlastnost)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(vlastnost));
        }


        public ObservableCollection<Ryba> Ulovky { get; set; }


        DateTime datum2 = new DateTime(2015, 4, 20);
        public void Uloz()
        {
            XmlSerializer serializer = new XmlSerializer(Ulovky.GetType());
            using (StreamWriter sw = new StreamWriter(Path.Combine(cesta, "dataUlovku.xml")))
            {
                serializer.Serialize(sw, Ulovky);
            }
        }

        public void Nacti()
        {
            if (!Directory.Exists(cesta))
                Directory.CreateDirectory(cesta);
            XmlSerializer serializer = new XmlSerializer(Ulovky.GetType());
            if (File.Exists(Path.Combine(cesta, "dataUlovku.xml")))
            {
                using (StreamReader sr = new StreamReader(Path.Combine(cesta, "dataUlovku.xml")))
                {
                    Ulovky = (ObservableCollection<Ryba>)serializer.Deserialize(sr);


                }
            }
            else
                Ulovky = new ObservableCollection<Ryba>();

        }

        public Spravce_ulovku()
        {
            Ulovky = new ObservableCollection<Ryba>();
        }

        //public void PridatUlovek(string druh, int delka, double hmotnost, DateTime? datumChyceni, string casUloveni, string poznamka)
        public void PridatUlovek(string druh, int delka, string hmotnost, DateTime? datumChyceni, string casUloveni, string poznamka)
        {
            Ulovky.Add(new Ryba(druh, delka, hmotnost, datumChyceni, casUloveni, poznamka));
            Ulovky = new ObservableCollection<Ryba>(Ulovky.OrderBy(Ryba => Ryba.DatumChyceniDateTime));
            VyvolejZmenu("Ulovky");
            Serad("datum", "sestupne");

        }

        //public void ZobrazPocet()
        //{
        //    int x = Ulovky.Count;
        //    MessageBox.Show(x.ToString(), "Chyba", MessageBoxButton.OK, MessageBoxImage.Information);
        //}

        public void Vymazat(Ryba ryba)
        { 
            Ulovky.Remove(ryba);
            Uloz();
        }
        public void VymazatVse()
        {
            Ulovky = new ObservableCollection<Ryba>();
            Uloz();
            VyvolejZmenu("Ulovky");
        }

        public void Serad(string podle, string jak)
        {
            if(podle == "delka")
                Ulovky = new ObservableCollection<Ryba>(Ulovky.OrderBy(Ryba => Ryba.Delka));
            else if(podle == "druh")
                Ulovky = new ObservableCollection<Ryba>(Ulovky.OrderBy(Ryba => Ryba.Druh));
            else if (podle == "hmotnost")
                Ulovky = new ObservableCollection<Ryba>(Ulovky.OrderBy(Ryba => Ryba.Hmotnost));
            else if (podle == "datum")
                Ulovky = new ObservableCollection<Ryba>(Ulovky.OrderBy(Ryba => Ryba.DatumChyceniDateTime));

            if(jak == "sestupne")
                Ulovky = new ObservableCollection<Ryba>(Ulovky.Reverse());


            VyvolejZmenu("Ulovky");
        }

        //public ObservableCollection<Ryba> VratUlovky()
        //{
        //    int x = Ulovky.Count;
        //    MessageBox.Show(x.ToString(), "Chyba", MessageBoxButton.OK, MessageBoxImage.Information);
        //    return Ulovky;
        //}
        
        
    }
}
