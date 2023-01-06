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
        private OcenaController _OcenaController;
        private StudentController _StudentController;
        private ProfesorController _ProfesorController;
        private PredmetController _PredmetController;
        private AdresaController _AdresaController;
        public ObservableCollection<Student> Studenti { get; set; }
        public ObservableCollection<Profesor>  Profesori { get; set; }
        public ObservableCollection<Predmet> Predmeti { get; set; }
        public ObservableCollection<Ocena> Ocene { get; set; }
        public Student SelectedStudent { get; set; }
        public Profesor SelectedProfesor { get; set; }
        public Predmet SelectedPredmet { get; set; }

        public int SelectedTab { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            SelectedTab = 1;

            _OcenaController = new OcenaController();
            _OcenaController.Subscribe(this);
            Ocene = new ObservableCollection<Ocena>(_OcenaController.GetAllOcene());

            _StudentController = new StudentController(_OcenaController);
            _StudentController.Subscribe(this);
            Studenti = new ObservableCollection<Student>(_StudentController.GetAllStudents());

            _ProfesorController = new ProfesorController();
            _ProfesorController.Subscribe(this);
            Profesori = new ObservableCollection<Profesor>(_ProfesorController.GetAllProfesori());

            _PredmetController = new PredmetController(_OcenaController);
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

        private void EditWindow_Click(object sender, RoutedEventArgs e)
        {
            switch (SelectedTab)
            {
                case 1:
                    if (SelectedStudent != null)
                    {
                        EditStudent editStudent = new EditStudent(_StudentController, _AdresaController, SelectedStudent);
                        editStudent.Show();
                    }
                    else
                    {
                        MessageBox.Show("Odaberite studenta kojeg želite da izmenite.");
                    }
                    break;
                case 2:
                    if (SelectedProfesor != null)
                    {
                        EditProfesor editProfesor = new EditProfesor(_ProfesorController, _AdresaController, SelectedProfesor);
                        editProfesor.Show();
                    }
                    else
                    {
                        MessageBox.Show("Odaberite profesora kojeg želite da izmenite.");
                    }
                    break;
                case 3:
                    if (SelectedPredmet != null)
                    {
                        EditPredmet editPredmet = new EditPredmet(_PredmetController, SelectedPredmet);
                        editPredmet.Show();
                    }
                    else
                    {
                        MessageBox.Show("Odaberite predmet koji želite da izmenite.");
                    }
                    break;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            switch (SelectedTab)
            {
                case 1:
                    if (SelectedStudent != null)
                    {
                        MessageBoxResult result = ConfirmStudentDeletion();

                        if (result == MessageBoxResult.Yes)
                        {
                            _AdresaController.Delete(_AdresaController.FindByID(SelectedStudent.AdresaStanovanjaId));
                            _StudentController.Delete(SelectedStudent);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Odaberite studenta kojeg želite da obrišete.");
                    }
                    break;
                case 2:
                    if (SelectedProfesor != null)
                    {
                        MessageBoxResult result = ConfirmProfesorDeletion();

                        if (result == MessageBoxResult.Yes)
                        {
                            _AdresaController.Delete(_AdresaController.FindByID(SelectedProfesor.AdresaStanovanjaId));
                            _AdresaController.Delete(_AdresaController.FindByID(SelectedProfesor.AdresaKancelarijeId));
                            _ProfesorController.Delete(SelectedProfesor);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Odaberite profesora kojeg želite da obrišete.");
                    }
                    break;
                case 3:
                    if (SelectedPredmet != null)
                    {
                        MessageBoxResult result = ConfirmPredmetDeletion();

                        if (result == MessageBoxResult.Yes)
                            _PredmetController.Delete(SelectedPredmet);
                    }
                    else
                    {
                        MessageBox.Show("Odaberite predmet koji želite da obrišete.");
                    }
                    break;
            }
        }

        private MessageBoxResult ConfirmStudentDeletion()
        {
            string sMessageBoxText = $"Da li ste sigurni da želite da izbrišete studenta: \n{SelectedStudent}";
            string sCaption = "Potvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

        private MessageBoxResult ConfirmProfesorDeletion()
        {
            string sMessageBoxText = $"Da li ste sigurni da želite da izbrišete profesora: \n{SelectedProfesor}";
            string sCaption = "Potvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

        private MessageBoxResult ConfirmPredmetDeletion()
        {
            string sMessageBoxText = $"Da li ste sigurni da želite da izbrišete predmet: \n{SelectedPredmet}";
            string sCaption = "Potvrda brisanja";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);
            return result;
        }

        private void UpdateList()
        {
            switch (SelectedTab)
            {
                case 1:
                    Studenti.Clear();
                    foreach (var student in _StudentController.GetAllStudents())
                    {
                        Studenti.Add(student);
                    }

                    Ocene.Clear();
                    foreach (var ocena in _OcenaController.GetAllOcene())
                    {
                        Ocene.Add(ocena);
                    }
                    break;
                case 2:
                    Profesori.Clear();
                    foreach (var student in _ProfesorController.GetAllProfesori())
                    {
                        Profesori.Add(student);
                    }
                    break;
                case 3:
                    Predmeti.Clear();
                    foreach (var student in _PredmetController.GetAllPredmeti())
                    {
                        Predmeti.Add(student);
                    }
                    break;
            }
        }

        public void Update()
        {
            UpdateList();
        }
    }
}
