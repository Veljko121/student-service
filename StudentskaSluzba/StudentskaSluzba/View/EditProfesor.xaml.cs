using StudentskaSluzba.Controller;
using StudentskaSluzba.Model;
using StudentskaSluzba.Observer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for EditProfesor.xaml
    /// </summary>
    public partial class EditProfesor : Window, INotifyPropertyChanged, IObserver
    {
        private ProfesorController _ProfesorController;
        private AdresaController _AdresaContoller;
        private PredmetController _PredmetController;

        public Profesor Profesor { get; set; }
        public Adresa AdresaStanovanja { get; set; }
        public Adresa AdresaKancelarije { get; set; }
        public Profesor ProfesorOriginal { get; set; }
        public Adresa AdresaStanovanjaOriginal { get; set; }
        public Adresa AdresaKancelarijeOriginal { get; set; }
        public ObservableCollection<Predmet> Predmeti { get; set; }
        public Predmet SelectedPredmet { get; set; }
        public EditProfesor(ProfesorController profesorController, AdresaController adresaController, PredmetController predmetController, Profesor SelectedProfesor)
        {
            InitializeComponent();
            DataContext= this;

            _ProfesorController = profesorController;
            _AdresaContoller = adresaController;
            _PredmetController = predmetController;
            _PredmetController.Subscribe(this);

            ProfesorOriginal = SelectedProfesor;
            AdresaStanovanjaOriginal = adresaController.FindByID(ProfesorOriginal.AdresaStanovanjaId);
            AdresaKancelarijeOriginal = adresaController.FindByID(ProfesorOriginal.AdresaKancelarijeId);

            Profesor = new Profesor(ProfesorOriginal);
            AdresaStanovanja = new Adresa(AdresaStanovanjaOriginal);
            AdresaKancelarije = new Adresa(AdresaKancelarijeOriginal);

            Predmeti = new ObservableCollection<Predmet>(SelectedProfesor.SpisakPredmeta);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void EditProfesor_Click(object sender, RoutedEventArgs e)
        {
            if (Profesor.IsValid && AdresaStanovanja.IsValid && AdresaKancelarije.IsValid)
            {
                ProfesorOriginal.Prezime = Profesor.Prezime;
                ProfesorOriginal.Ime = Profesor.Ime;
                ProfesorOriginal.DatumRodjenja = Profesor.DatumRodjenja;
                ProfesorOriginal.AdresaStanovanjaId = Profesor.AdresaStanovanjaId;
                ProfesorOriginal.Telefon = Profesor.Telefon;
                ProfesorOriginal.Email = Profesor.Email;
                ProfesorOriginal.AdresaKancelarijeId = Profesor.AdresaKancelarijeId;
                ProfesorOriginal.BrojLicne = Profesor.BrojLicne;
                ProfesorOriginal.Zvanje = Profesor.Zvanje;
                ProfesorOriginal.GodineStaza = Profesor.GodineStaza;
                ProfesorOriginal.KatedraId = Profesor.KatedraId;

                AdresaStanovanjaOriginal.Ulica = AdresaStanovanja.Ulica;
                AdresaStanovanjaOriginal.Broj = AdresaStanovanja.Broj;
                AdresaStanovanjaOriginal.Grad = AdresaStanovanja.Grad;
                AdresaStanovanjaOriginal.Drzava = AdresaStanovanja.Drzava;

                AdresaKancelarijeOriginal.Ulica = AdresaKancelarije.Ulica;
                AdresaKancelarijeOriginal.Broj = AdresaKancelarije.Broj;
                AdresaKancelarijeOriginal.Grad = AdresaKancelarije.Grad;
                AdresaKancelarijeOriginal.Drzava = AdresaKancelarije.Drzava;

                Close();
            }
            else
            {
                if (!Profesor.IsValid)
                {
                    MessageBox.Show("Profesor se ne može izmeniti, jer nisu sva polja validno popunjena.");
                }
                if (!AdresaStanovanja.IsValid)
                {
                    MessageBox.Show("Adresa stanovanja se ne može izmeniti, jer nisu sva polja validno popunjena.");
                }
                if (!AdresaKancelarije.IsValid)
                {
                    MessageBox.Show("Adresa kancelarije se ne može izmeniti, jer nisu sva polja validno popunjena.");
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddPredmet_Click(object sender, RoutedEventArgs e)
        {
            AddPredmetToProfesor addPredmetToProfesor = new AddPredmetToProfesor(_PredmetController, ProfesorOriginal);
            addPredmetToProfesor.Show();
        }

        private void UpdateList()
        {
            Predmeti.Clear();
            foreach (var ocena in ProfesorOriginal.SpisakPredmeta)
            {
                Predmeti.Add(ocena);
            }
        }

        public void Update()
        {
            UpdateList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPredmet != null)
            {
                MessageBoxResult result = ConfirmPredmetDeletion();

                if (result == MessageBoxResult.Yes)
                {
                    _PredmetController.UkloniPredmetZaProfesora(ProfesorOriginal, SelectedPredmet);
                }
            }
            else
            {
                MessageBox.Show("Odaberite predmet koji želite da obrišete.");
            }
        }

        private MessageBoxResult ConfirmPredmetDeletion()
        {
            string ispis = SelectedPredmet.Sifra + " " + SelectedPredmet.Naziv;
            string sMessageBoxText = $"Da li ste sigurni da želite da izbrišete predmet: {ispis}\n";
            string sCaption = "Potvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }
    }
}
