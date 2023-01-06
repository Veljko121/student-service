using StudentskaSluzba.Controller;
using StudentskaSluzba.Model;
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
    public partial class EditStudent : Window, INotifyPropertyChanged
    {
        private StudentController _StudentController;
        private AdresaController _AdresaController;

        public Student Student { get; set; }
        public Adresa AdresaStanovanja { get; set; }
        public Student StudentOriginal { get; set; }
        public Adresa AdresaOriginal { get; set; }

        public EditStudent(StudentController StudentController, AdresaController AdresaController, Student SelectedStudent)
        {
            InitializeComponent();
            DataContext = this; 

            _StudentController = StudentController;
            _AdresaController = AdresaController;

            StudentOriginal = SelectedStudent;
            AdresaOriginal = _AdresaController.FindByID(StudentOriginal.AdresaStanovanjaId);

            Student = new Student(StudentOriginal);
            AdresaStanovanja = new Adresa(AdresaOriginal);
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
    }
}
