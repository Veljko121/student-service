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
    /// Interaction logic for AddPredmetToProfesor.xaml
    /// </summary>
    public partial class AddPredmetToProfesor : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Predmet> Predmeti { get; set; }

        private PredmetController _PredmetController;
        public Predmet SelectedPredmet { get; set; }
        private Profesor _Profesor;

        public AddPredmetToProfesor(PredmetController predmetController, Profesor SelectedProfesor)
        {
            InitializeComponent();
            DataContext = this;

            this._Profesor = SelectedProfesor;

            this._PredmetController = predmetController;

            Predmeti = new ObservableCollection<Predmet>(_PredmetController.GetPredmetiWhereNotProfesor(_Profesor));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddPredmet_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPredmet != null)
            {
                _PredmetController.DodajPredmetProfesoru(_Profesor, SelectedPredmet);

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
