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
    /// Interaction logic for AddStudentToPredmet.xaml
    /// </summary>
    public partial class AddStudentToPredmet : Window, INotifyPropertyChanged
    {

        ObservableCollection<Predmet> Predmeti { get; set;  }

        PredmetController _PredmetController;
        OcenaController _OcenaController;

        Predmet SelectedPredmet;
        Student Student;
        Ocena Ocena;
        public AddStudentToPredmet(PredmetController PredmetController, OcenaController OcenaController, Student student)
        {
            InitializeComponent();

            _OcenaController = OcenaController;
            _PredmetController = PredmetController;

            Predmeti = new ObservableCollection<Predmet>(PredmetController.GetPredmetiWhereNotStudent(OcenaController.GetOceneForStudent(student)));

            Ocena = new Ocena();
            Student = student;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPredmet != null)
            {
                Ocena.Predmet = SelectedPredmet;
                Ocena.PredmetId = SelectedPredmet.Id;
                Ocena.Student = Student;
                Ocena.StudentId = Student.Id;
                _OcenaController.Create(Ocena);

                Close();
            }
            else
            {
                MessageBox.Show("Odaberite predmet na koji želite da dodate studenta.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

    
}
