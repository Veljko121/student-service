using StudentskaSluzba.Controller;
using StudentskaSluzba.Model;
using StudentskaSluzba.Observer;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentskaSluzba.View
{
    /// <summary>
    /// Interaction logic for EditPredmet.xaml
    /// </summary>
    public partial class EditPredmet : Window, INotifyPropertyChanged, IObserver
    {
        private PredmetController _PredmetController;
        private ProfesorController _ProfesorController;

        public Predmet Predmet { get; set; }
        public Predmet PredmetOriginal { get; set; }

        public EditPredmet(PredmetController predmetController, ProfesorController profesorController, Predmet SelectedPredmet)
        {
            InitializeComponent();
            DataContext = this;

            _PredmetController = predmetController;
            _PredmetController.Subscribe(this);
            _ProfesorController = profesorController;
            _ProfesorController.Subscribe(this);

            PredmetOriginal = SelectedPredmet;

            Predmet = new Predmet(PredmetOriginal);

            CheckProfesor();
        }

        private void CheckProfesor()
        {
            if (PredmetOriginal.PredmetniProfesorId == -1)
            {
                Plus_Button.IsEnabled = true;
                Minus_Button.IsEnabled = false;
                ProfesorTextBox.Text = "";
            }
            else
            {
                Plus_Button.IsEnabled = false;
                Minus_Button.IsEnabled = true;
                ProfesorTextBox.Text = PredmetOriginal.PredmetniProfesor.Ime + " " + PredmetOriginal.PredmetniProfesor.Prezime;
            }
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
                MessageBox.Show("SelectedPredmet se ne može izmeniti, jer nisu sva polja validno popunjena.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddProfesor_Click(object sender, RoutedEventArgs e)
        {
            AddProfesorToPredmet addProfesorToPredmet = new AddProfesorToPredmet(_ProfesorController, _PredmetController, PredmetOriginal);
            addProfesorToPredmet.Show();

            //CheckProfesor();
        }

        private void DelteProfesor_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = ConfirmProfesorDeletion();

            if (result == MessageBoxResult.Yes)
            {
                _PredmetController.DeleteProfesorFromPredmet(PredmetOriginal);
                CheckProfesor();
            }
        }

        private MessageBoxResult ConfirmProfesorDeletion()
        {
            string sMessageBoxText = $"Da li ste sigurni?\n";
            string sCaption = "Potvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

        public void Update()
        {
            CheckProfesor();
        }
    }
}
