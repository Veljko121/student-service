﻿using StudentskaSluzba.Controller;
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
    /// Interaction logic for CreateProfesor.xaml
    /// </summary>
    public partial class CreateProfesor : Window, INotifyPropertyChanged
    {
        private ProfesorController _ProfesorController;
        private AdresaController _AdresaController;

        public Profesor Profesor { get; set; }
        public Adresa AdresaStanovanja { get; set; }
        public Adresa AdresaKancelarije { get; set; }

        public CreateProfesor(ProfesorController profesorController, AdresaController adresaController)
        {
            InitializeComponent();
            DataContext = this;
            Profesor = new Profesor();
            AdresaStanovanja = new Adresa();
            AdresaKancelarije = new Adresa();

            _ProfesorController = profesorController;
            _AdresaController = adresaController;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CreateProfesor_Click(object sender, RoutedEventArgs e)
        {
            if (Profesor.IsValid && AdresaStanovanja.IsValid && AdresaKancelarije.IsValid)
            {

                Profesor.AdresaStanovanjaId = _AdresaController.Create(AdresaStanovanja);
                Profesor.AdresaKancelarijeId = _AdresaController.Create(AdresaKancelarije);
                _ProfesorController.Create(Profesor);
                Close();
            }
            else
            {
                if (!Profesor.IsValid)
                {
                    MessageBox.Show("Profesor se ne može napraviti, jer nisu sva polja validno popunjena.");
                }
                if (!AdresaStanovanja.IsValid)
                {
                    MessageBox.Show("Adresa stanovanja se ne može napraviti, jer nisu sva polja validno popunjena.");
                }
                if(!AdresaKancelarije.IsValid)
                {
                    MessageBox.Show("Adresa kancelarije se ne može napraviti, jer nisu sva polja validno popunjena.");
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
