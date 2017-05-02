using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Collections;

namespace Úlovky
{
    public class Ryba
    {

        public string Druh { get; set; }
        public int Delka { get; set; }
        //public double Hmotnost { get; set; }
        public string Hmotnost { get; set; }
        public string DatumChyceni { get; set; }
        public string CasChyceni { get; set; }
        public string Poznamka { get; set; }
        public DateTime? DatumChyceniDateTime { get; set; }

        //public Ryba(string druh, int delka, double hmotnost, DateTime? datumChyceni, string casChyceni, string poznamka)
        public Ryba(string druh, int delka, string hmotnost, DateTime? datumChyceni, string casChyceni, string poznamka)
        {
            Druh = druh;
            Delka = delka;
            Hmotnost = hmotnost;
            CasChyceni = casChyceni;           
            Poznamka = poznamka;
            DatumChyceniDateTime = datumChyceni;            
            DatumChyceni = datumChyceni.ToString().Substring(0, 10);
            
        }
        public Ryba() { }

      

        public override string ToString()
        {
            return Druh;
        }

       

        
    }

  
}
