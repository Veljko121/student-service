using StudentskaSluzba.Controller;
using StudentskaSluzba.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentskaSluzba.View
{
    /// <summary>
    /// Interaction logic for EditPredmet.xaml
    /// </summary>
    public partial class EditPredmet : Window, INotifyPropertyChanged
    {
        private PredmetController _PredmetController;

        public Predmet Predmet { get; set; }
        public Predmet PredmetOriginal { get; set; }

        public EditPredmet(PredmetController predmetController, Predmet SelectedPredmet)
        {
            InitializeComponent();
            DataContext = this;

            _PredmetController = predmetController;

            PredmetOriginal = SelectedPredmet;

            Predmet = new Predmet(PredmetOriginal);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void EditPredmet_Click(object sender, RoutedEventArgs e)
        {
            if (Predmet.IsValid)
            {
                PredmetOriginal.Sifra = Predmet.Sifra;
                PredmetOriginal.Naziv = Predmet.Naziv;
                PredmetOriginal.Semestar = Predmet.Semestar;
                PredmetOriginal.GodinaStudija = Predmet.GodinaStudija;
                PredmetOriginal.BrojESPB = Predmet.BrojESPB;

                Close();
            }
            else
            {
                MessageBox.Show("Predmet se ne može izmeniti, jer nisu sva polja validno popunjena.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
