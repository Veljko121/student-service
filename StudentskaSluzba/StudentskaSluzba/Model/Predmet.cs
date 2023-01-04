using StudentskaSluzba.Serializer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentskaSluzba.Model
{
    public enum Semestar { L, Z };
    public class Predmet : ISerializable, INotifyPropertyChanged, IDataErrorInfo
    {
        public int Id { get; set; }
        private string _sifra;
        public string Sifra
        {
            get => _sifra;
            set
            {
                if (value != _sifra)
                {
                    _sifra = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _naziv;
        public string Naziv
        {
            get => _naziv;
            set
            {
                if (value != _naziv)
                {
                    _naziv = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _semestar;
        public string Semestar
        {
            get => _semestar;
            set
            {
                if (value != _semestar)
                {
                    _semestar = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _godinaStudija;
        public string GodinaStudija
        {
            get => _godinaStudija;
            set
            {
                if (value != _godinaStudija)
                {
                    _godinaStudija = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _predmetniProfesorId;
        public int PredmetniProfesorId
        {
            get => _predmetniProfesorId;
            set
            {
                if (value != _predmetniProfesorId)
                {
                    _predmetniProfesorId = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _brojESPB;
        public int BrojESPB
        {
            get => _brojESPB;
            set
            {
                if (value != _brojESPB)
                {
                    _brojESPB = value;
                    OnPropertyChanged();
                }
            }
        }
        public Profesor PredmetniProfesor { get; set; }
        public List<Student> Polozili { get; set; }
        public List<Student> NisuPolozili { get; set; }

        public Predmet()
        {
            Id = -1;
            Sifra = "";
            Naziv = "";
            Semestar = "Zimski";
            GodinaStudija = "I (prva)";
            PredmetniProfesorId = -1;
            BrojESPB = 0;

            //PredmetniProfesor = new Profesor();
            //Polozili = new List<Student>();
            //NisuPolozili = new List<Student>();
        }

        public Predmet(int Id, string Sifra, string Naziv, string Semestar, string GodinaStudija, int PredmetniProfesorId, int BrojESPB)
        {
            this.Id = Id;
            this.Sifra = Sifra;
            this.Naziv = Naziv;
            this.Semestar = Semestar;
            this.GodinaStudija = GodinaStudija;
            this.PredmetniProfesorId = PredmetniProfesorId;
            this.BrojESPB = BrojESPB;

            //PredmetniProfesor = new Profesor();
            //Polozili = new List<Student>();
            //NisuPolozili = new List<Student>();
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Sifra,
                Naziv,
                Semestar,
                GodinaStudija.ToString(),
                PredmetniProfesorId.ToString(),
                BrojESPB.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Sifra = values[1];
            Naziv = values[2];
            Semestar = values[3];
            GodinaStudija = values[4];
            PredmetniProfesorId = int.Parse(values[5]);
            BrojESPB = int.Parse(values[6]);
        }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Sifra")
                {
                    if (string.IsNullOrEmpty(Sifra))
                        return "Sifra is required";
                }
                else if (columnName == "Naziv")
                {
                    if (string.IsNullOrEmpty(Naziv))
                        return "Naziv is required";
                }
                else if (columnName == "GodinaStudija")
                {
                    if (string.IsNullOrEmpty(GodinaStudija.ToString()))
                        return "GodinaStudija is required";
                }
                else if (columnName == "BrojESPB")
                {
                    if (string.IsNullOrEmpty(BrojESPB.ToString()))
                        return "BrojESPB is required";
                }

                return null;
            }
        }

        private readonly string[] _validatedProperties = { "Sifra", "Naziv", "GodinaStudija", "BrojESPB" };

        public bool IsValid
        {
            get
            {
                foreach (var property in _validatedProperties)
                {
                    if (this[property] != null)
                        return false;
                }

                return true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
