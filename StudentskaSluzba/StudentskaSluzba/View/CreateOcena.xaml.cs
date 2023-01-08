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
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudentskaSluzba.View
{
    /// <summary>
    /// Interaction logic for CreateOcena.xaml
    /// </summary>
    public partial class CreateOcena : Window, INotifyPropertyChanged
    {
        private StudentController _StudentController;
        private OcenaController _OcenaController;
        public Student _Student { get; set; }
        public Ocena _Ocena { get; set; }
        public Ocena OcenaOriginal { get; set; }

        public CreateOcena(StudentController studentController, OcenaController ocenaController, Student SelectedStudent, Ocena SelectedNepolozeni)
        {
            InitializeComponent();

            _StudentController = studentController;
            _OcenaController = ocenaController;

            OcenaOriginal = SelectedNepolozeni;

            _Student = SelectedStudent;
            _Ocena = new Ocena(SelectedNepolozeni);
            _Ocena.DatumPolaganja = DateTime.Now.Date;
            _Ocena.VrednostOcene = 6;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CreateOcena_Click(object sender, RoutedEventArgs e)
        {
            if (_Ocena.IsValid )
            {
                OcenaOriginal.VrednostOcene = _Ocena.VrednostOcene;
                OcenaOriginal.DatumPolaganja = _Ocena.DatumPolaganja;

                Close();
            }
            else
            {
                MessageBox.Show("Ocena se ne može izmeniti, jer nisu sva polja validno popunjena.");
            }
        }
    }
}
