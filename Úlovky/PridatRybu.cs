using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Úlovky
{
    public class PridatRybu
    { 
        public string NazevDruhu { get; set; }
        public int MinDelka { get; set; }


       
        public List<PridatRybu> druhyRyby;
        public List<int> delkyList;
        public List<string> hmotnostList;
        public List<string> casList;

        //haha

        public PridatRybu(string nazevDruhu, int minDelka)
        {
            NazevDruhu = nazevDruhu;
            MinDelka = minDelka;
        }
        public PridatRybu()
        {
           
        }

        public List<PridatRybu> NazevToInput
        {
            get
            {

                druhyRyby = new List<PridatRybu>();
                druhyRyby.Add(new PridatRybu("Kapr", 40));
                druhyRyby.Add(new PridatRybu("Cejn", 30));
                druhyRyby.Add(new PridatRybu("Candát", 45));
                return druhyRyby;
            }
        }

        public List<int> DelkaToInput
        {
            get
            {

                delkyList = new List<int>();
                for (int d = MinDelka; d < 101; d++)
                {
                    delkyList.Add(d);
                }

                return delkyList;


            }
        }
        public List<string> HmotnostToInput
        {
            get
            {
                hmotnostList = new List<string>();
                hmotnostList.Add("Nezměřeno");
                for (double h = 1.0; h < 5.0; h += 0.1)
                {
                    double hz = Math.Round(h, 2);
                    hmotnostList.Add(hz.ToString());
                }

                return hmotnostList;
            } 
        }
        public List<string> PoznamkaToInput { get; set; }
        public DateTime DatumToInput
        {
            get
            {
                return DateTime.Now;
             
            }
        }
        public List<string> CasUloveniToInput
        {
            get
            {
                casList = new List<string>();
                for (int f = 4; f < 24; f++)
                {
                    string fs = f.ToString();
                    fs +=" - ";
                    int s = f + 1;
                    fs += s.ToString();
                    casList.Add(fs);
                }
                return casList;
            } 
        }
       

    }

    
}
