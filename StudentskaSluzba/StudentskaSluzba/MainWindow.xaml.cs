using StudentskaSluzba.Controller;
using StudentskaSluzba.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using StudentskaSluzba.Observer;
using StudentskaSluzba.View;

namespace StudentskaSluzba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IObserver
    {
        private StudentController _StudentController;
        private ProfesorController _ProfesorController;
        private PredmetController _PredmetController;
        private AdresaController _AdresaController;
        public ObservableCollection<Student> Studenti { get; set; }
        public ObservableCollection<Profesor>  Profesori { get; set; }
        public ObservableCollection<Predmet> Predmeti { get; set; }
        public Student SelectedStudent { get; set; }
        public Profesor SelectedProfesor { get; set; }
        public Predmet SelectedPredmet { get; set; }

        public int SelectedTab { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            SelectedTab = 1;

            _StudentController = new StudentController();
            _StudentController.Subscribe(this);
            Studenti = new ObservableCollection<Student>(_StudentController.GetAllStudents());

            _ProfesorController = new ProfesorController();
            _ProfesorController.Subscribe(this);
            Profesori = new ObservableCollection<Profesor>(_ProfesorController.GetAllProfesori());

            _PredmetController = new PredmetController();
            _PredmetController.Subscribe(this);
            Predmeti = new ObservableCollection<Predmet>(_PredmetController.GetAllPredmeti());

            _AdresaController = new AdresaController();
        }

        private void VremeDatum(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, (object s, EventArgs ev) =>
            {
                this.myDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy     hh:mm:ss");
            }, this.Dispatcher);
            timer.Start();
        }

        private void TabStudenti_Click(object sender, RoutedEventArgs e)
        {
            this.StatusBarTextBlock.Text = "Studentska sluzba - Studenti";

            SelectedTab = 1;
            _StudentController = new StudentController();
            _StudentController.Subscribe(this);
            Studenti = new ObservableCollection<Student>(_StudentController.GetAllStudents());
        }
        private void TabPredmeti_Click(object sender, RoutedEventArgs e)
        {
            this.StatusBarTextBlock.Text = "Studentska sluzba - Predmeti";

            SelectedTab = 3;
        }
        private void TabProfesori_Click(object sender, RoutedEventArgs e)
        {
            this.StatusBarTextBlock.Text = "Studentska sluzba - Profesori";

            SelectedTab = 2;
        }

        private void CreateWindow_Click(object sender, RoutedEventArgs e)
        {
            switch (SelectedTab)
            {
                case 1:
                    CreateStudent createStudent = new CreateStudent(_StudentController, _AdresaController);
                    createStudent.Show();
                    break;
                case 2:
                    CreateProfesor createProfesor = new CreateProfesor(_ProfesorController, _AdresaController);
                    createProfesor.Show();
                    break;
                case 3:
                    CreatePredmet createPredmet= new CreatePredmet(_PredmetController);
                    createPredmet.Show();
                    break;
            }
        }

        public void Update()
        {
            //UpdateStudentsList();
        }
    }
}
