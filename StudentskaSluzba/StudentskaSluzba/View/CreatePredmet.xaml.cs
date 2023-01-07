using StudentskaSluzba.Controller;
using StudentskaSluzba.Model;
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
    /// Interaction logic for CreatePredmet.xaml
    /// </summary>
    public partial class CreatePredmet : Window, INotifyPropertyChanged
    {
        private PredmetController _PredmetController;

        public Predmet Predmet { get; set; }

        public CreatePredmet(PredmetController predmetController)
        {
            InitializeComponent();
            DataContext = this;
            Predmet = new Predmet();

            _PredmetController = predmetController;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CreatePredmet_Click(object sender, RoutedEventArgs e)
        {
            if (Predmet.IsValid)
            {
                _PredmetController.Create(Predmet);
                Close();
            }
            else
            {
                MessageBox.Show("Predmet se ne može napraviti, jer nisu sva polja validno popunjena.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
