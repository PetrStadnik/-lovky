using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Úlovky
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
 
        Spravce_ulovku spravceUlovku = new Spravce_ulovku();
        PridatRybu pridatRybu = new PridatRybu();
        public MainWindow()
        {            
            InitializeComponent();
            DataContext = spravceUlovku;
            spravceUlovku.Nacti();
            
        }

        private void odeslaButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                int delkaInt = int.Parse(delkaComboBox.SelectedItem.ToString());
                //double hmotnostDouble = double.Parse(hmotnostComboBox.SelectedItem.ToString());
                string hmotnostDouble = hmotnostComboBox.SelectedItem.ToString();
                spravceUlovku.PridatUlovek(druhComboBox.Text, delkaInt, hmotnostDouble, datumDatePicker.SelectedDate, casUloveniComboBox.Text, poznamkaTextBox.Text);
            }
            catch
            {
                MessageBox.Show("Ajajaj chybička se vloudila...", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            spravceUlovku.Uloz();
        }
        private void VymazatVseMenuItem_Click(object sender, RoutedEventArgs e)
        {
           if(MessageBox.Show("Vážně vymazat vše???!!!", "Really?!",MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                spravceUlovku.VymazatVse();
           
        }
        private void VymazatMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (ulovkyListView.SelectedItem != null)
            {
                try
                {

                    while (ulovkyListView.SelectedItems.Count != 0)
                    {
                        Ryba rybaKVymazani = (Ryba)ulovkyListView.SelectedItems[0];
                        spravceUlovku.Vymazat(rybaKVymazani);
                        spravceUlovku.Uloz();
                        string a = rybaKVymazani.Druh;
                    }

                    string potvrzeni = "Ryba  byla úspěšně odebrána" ;
                    MessageBox.Show(potvrzeni, "Ok", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }
                catch
                {
                    MessageBox.Show("Ajajaj chybička se vloudila...", "Chyba", MessageBoxButton.OK, MessageBoxImage.Error);
                }



            }

            else
                MessageBox.Show("Úlovek není vybrán, vyberte úlovek v seznamu.", "Chyba", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

       


        private void SeradRadioButton_Click(object sender, RoutedEventArgs e)
        {
            string podle;
            string jak;

            if(delkaRadioButton.IsChecked == true) { podle = "delka"; }
            else if (hmotnostRadioButton.IsChecked == true) { podle = "hmotnost"; }
            else if (druhRadioButton.IsChecked == true) { podle = "druh"; }
            else { podle = "datum"; }

            if (sestupneRadioButton.IsChecked == true) { jak = "sestupne"; }
            else { jak = "vzestupne"; }

            spravceUlovku.Serad(podle, jak);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            GrafWindow grafWindow = new GrafWindow();
           grafWindow.ShowDialog();
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
