using System;
using System.Collections.Generic;
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

namespace StudentskaSluzba
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
        }
        private void TabPredmeti_Click(object sender, RoutedEventArgs e)
        {
            this.StatusBarTextBlock.Text = "Studentska sluzba - Predmeti";
        }
        private void TabProfesori_Click(object sender, RoutedEventArgs e)
        {
            this.StatusBarTextBlock.Text = "Studentska sluzba - Profesori";
        }
    }
}
