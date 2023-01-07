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
    /// Interaction logic for EditStudent.xaml
    /// </summary>
    public partial class EditStudent : Window, INotifyPropertyChanged, IObserver
    {
        private StudentController _StudentController;
        private AdresaController _AdresaController;
        private OcenaController _OcenaController;
        private PredmetController _PredmetController;

        public ObservableCollection<Ocena> Polozeni { get; set; }
        public ObservableCollection<Ocena> Nepolozeni { get; set; }
        public Ocena SelectedPolozeni { get; set; }
        public Ocena SelectedNepolozeni { get; set; }

        public Student Student { get; set; }
        public Adresa AdresaStanovanja { get; set; }
        public Student StudentOriginal { get; set; }
        public Adresa AdresaOriginal { get; set; }

        public int SelectedTab { get; set; }

        public EditStudent(StudentController StudentController, AdresaController AdresaController, OcenaController OcenaController, PredmetController PredmetController, Student SelectedStudent)
        {
            InitializeComponent();
            DataContext = this; 

            _StudentController = StudentController;
            _AdresaController = AdresaController;
            _OcenaController = OcenaController;
            _PredmetController = PredmetController;
            _OcenaController.Subscribe(this);

            Polozeni = new ObservableCollection<Ocena>(SelectedStudent.PolozeniIspiti);
            Nepolozeni = new ObservableCollection<Ocena>(SelectedStudent.NepolozeniIspiti);

            StudentOriginal = SelectedStudent;
            AdresaOriginal = _AdresaController.FindByID(StudentOriginal.AdresaStanovanjaId);

            Student = new Student(StudentOriginal);
            AdresaStanovanja = new Adresa(AdresaOriginal);
        }

        private void TabNepolozeni_Click(object sender, RoutedEventArgs e)
        {
            SelectedTab = 1;
        }

        private void TabPolozeni_Click(object sender, RoutedEventArgs e)
        {
            SelectedTab = 2;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void EditStudent_Click(object sender, RoutedEventArgs e)
        {
            if (Student.IsValid && AdresaStanovanja.IsValid)
            {
                StudentOriginal.Prezime = Student.Prezime;
                StudentOriginal.Ime = Student.Ime;
                StudentOriginal.DatumRodjenja = Student.DatumRodjenja;
                StudentOriginal.AdresaStanovanjaId = Student.AdresaStanovanjaId;
                StudentOriginal.KontaktTelefon = Student.KontaktTelefon;
                StudentOriginal.Email = Student.Email;
                StudentOriginal.BrojIndeksa = Student.BrojIndeksa;
                StudentOriginal.GodinaUpisa = Student.GodinaUpisa;
                StudentOriginal.TrenutnaGodinaStudija = Student.TrenutnaGodinaStudija;
                StudentOriginal.Status = Student.Status;
                StudentOriginal.ProsecnaOcena = Student.ProsecnaOcena;

                AdresaOriginal.Ulica = AdresaStanovanja.Ulica;
                AdresaOriginal.Broj= AdresaStanovanja.Broj;
                AdresaOriginal.Grad = AdresaStanovanja.Grad;
                AdresaOriginal.Drzava = AdresaStanovanja.Drzava;

                Close();
            }
            else
            {
                if (!Student.IsValid)
                {
                    MessageBox.Show("Student se ne može izmeniti, jer nisu sva polja validno popunjena.");
                }
                if (!AdresaStanovanja.IsValid)
                {
                    MessageBox.Show("Adresa stanovanja se ne može izmeniti, jer nisu sva polja validno popunjena.");
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PonistiOcenu_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPolozeni != null)
            {
                MessageBoxResult result = ConfirmOcenaDeletion();

                if (result == MessageBoxResult.Yes)
                {
                    //SelectedPolozeni.VrednostOcene = 5;
                    //StudentOriginal.PolozeniIspiti.Remove(SelectedPolozeni);
                    //StudentOriginal.NepolozeniIspiti.Add(SelectedPolozeni);
                    //Polozeni.Remove(SelectedPolozeni);
                    //Nepolozeni.Add(SelectedPolozeni);
                    _OcenaController.PonistiOcenu(SelectedPolozeni, StudentOriginal);
                    _StudentController.IzracunajProsek(StudentOriginal);
                }
            }
            else
            {
                MessageBox.Show("Odaberite ocenu kojeg želite da poništite.");
            }
            
        }

        private void DodajStudentPredmet_Click(object sender, RoutedEventArgs e)
        {
            List<Predmet> predmeti = _PredmetController.GetPredmetiWhereNotStudent(_OcenaController.GetOceneForStudent(Student));
            AddStudentToPredmet addStudentToPredmet = new AddStudentToPredmet();
            addStudentToPredmet.Show();
        }

        private void ObrisiStudentPredmet_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Polaganje_Click(object sender, RoutedEventArgs e)
        {
        }

        private MessageBoxResult ConfirmOcenaDeletion()
        {
            string sMessageBoxText = $"Da li ste sigurni da želite da poništite ocenu:\n{SelectedPolozeni}";
            string sCaption = "Potvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }


        private void UpdateList()
        {
            Polozeni.Clear();
            foreach (var ocena in StudentOriginal.PolozeniIspiti)
            {
                Polozeni.Add(ocena);
            }

            Nepolozeni.Clear();
            foreach (var ocena in StudentOriginal.NepolozeniIspiti)
            {
                Nepolozeni.Add(ocena);
            }
        }

        public void Update()
        {
            UpdateList();
        }
    }
}
