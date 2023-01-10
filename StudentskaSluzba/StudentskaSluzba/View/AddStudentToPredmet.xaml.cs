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

        public ObservableCollection<Predmet> Predmeti { get; set;  }

        private PredmetController _PredmetController;
        private OcenaController _OcenaController;

        public Predmet SelectedPredmet { get; set; }
        private Student Student;
        private Ocena Ocena;
        public AddStudentToPredmet(PredmetController predmetController, OcenaController ocenaController, Student student)
        {
            InitializeComponent();
            DataContext= this;

            _OcenaController = ocenaController;
            _PredmetController = predmetController;

            Predmeti = new ObservableCollection<Predmet>(_PredmetController.GetPredmetiWhereNotStudent(_OcenaController.GetOceneForStudent(student)));

            Ocena = new Ocena();
            this.Student = student;
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
                //Ocena.Predmet = SelectedPredmet;
                //Ocena.PredmetId = SelectedPredmet.Id;
                //Ocena.Student = Student;
                //Ocena.StudentId = Student.Id;
                //Student.NepolozeniIspiti.Add(Ocena);
                //_OcenaController.Create(Ocena);
                _OcenaController.DodajPredmetStudentu(Student, Ocena, SelectedPredmet);

                Close();
            }
            else
            {
                MessageBox.Show("Odaberite Predmet na koji želite da dodate studenta.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
