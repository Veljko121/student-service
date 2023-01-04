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
    /// Interaction logic for CreateAdresa.xaml
    /// </summary>
    public partial class CreateAdresa : Window, INotifyPropertyChanged
    {
        private AdresaController _AdresaController;

        public Adresa Adresa { get; set; }

        public CreateAdresa(AdresaController AdresaController)
        {
            InitializeComponent();
            DataContext = this;
            Adresa = new Adresa();

            _AdresaController = AdresaController;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

       /*private void CreateStudent_Click(object sender, RoutedEventArgs e)
        {
            if (Adresa.IsValid)
            {
                _AdresaController.Create(Adresa);
                Close();
            }
            else
            {
                MessageBox.Show("Adresa se ne može napraviti, jer nisu sva polja validno popunjena.");
            }
        }*/

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
