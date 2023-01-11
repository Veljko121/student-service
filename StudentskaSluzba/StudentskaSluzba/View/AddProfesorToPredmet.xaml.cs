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
    /// Interaction logic for AddProfesorToPredmet.xaml
    /// </summary>
    public partial class AddProfesorToPredmet : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Profesor> Profesori { get; set; }
        private ProfesorController _ProfesorController;
        private PredmetController _PredmetController;
        public Predmet SelectedPredmet { get; set; }
        public Profesor SelectedProfesor { get; set; }
        public AddProfesorToPredmet(ProfesorController profesorController, PredmetController predmetController, Predmet selectedPredmet)
        {
            InitializeComponent();
            DataContext = this;

            _ProfesorController = profesorController;
            _PredmetController = predmetController;

            SelectedPredmet = selectedPredmet;

            Profesori = new ObservableCollection<Profesor>(_ProfesorController.GetAllProfesori());
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddProfesor_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedProfesor != null)
            {
                _PredmetController.DodajPredmetProfesoru(SelectedProfesor, SelectedPredmet);

                Close();
            }
            else
            {
                MessageBox.Show("Odaberite profesora na kog želite da dodate na predme.");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
