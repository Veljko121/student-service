using StudentskaSluzba.Serializer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentskaSluzba.Model
{
    public enum Status { B, S };
    public class Student : ISerializable
    {
        public int Id { get; set; }
        private string _prezime;
        public string Prezime
        {
            get => _prezime;
            set
            {
                if (value != _prezime)
                {
                    _prezime = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _ime;
        public string Ime
        {
            get => _ime;
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged();
                }
            }
        }
        private DateTime _datumRodjenja;
        public DateTime DatumRodjenja
        {
            get => _datumRodjenja;
            set
            {
                if (value != _datumRodjenja)
                {
                    _datumRodjenja = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _adresaStanovanjaId;
        public int AdresaStanovanjaId
        {
            get => _adresaStanovanjaId;
            set
            {
                if (value != _adresaStanovanjaId)
                {
                    _adresaStanovanjaId = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _kontaktTelefon;
        public string KontaktTelefon
        {
            get => _kontaktTelefon;
            set
            {
                if (value != _kontaktTelefon)
                {
                    _kontaktTelefon = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _brojIndeksa;
        public string BrojIndeksa
        {
            get => _brojIndeksa;
            set
            {
                if (value != _brojIndeksa)
                {
                    _brojIndeksa = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _godinaUpisa;
        public int GodinaUpisa
        {
            get => _godinaUpisa;
            set
            {
                if (value != _godinaUpisa)
                {
                    _godinaUpisa = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _trenutnaGodinaStudija;
        public int TrenutnaGodinaStudija
        {
            get => _trenutnaGodinaStudija;
            set
            {
                if (value != _trenutnaGodinaStudija)
                {
                    _trenutnaGodinaStudija = value;
                    OnPropertyChanged();
                }
            }
        }
        private Status _status;
        public Status Status
        {
            get => _status;
            set
            {
                if (value != _status)
                {
                    _status = value;
                    OnPropertyChanged();
                }
            }
        }
        private double _prosecnaOcena;
        public double ProsecnaOcena
        {
            get => _prosecnaOcena;
            set
            {
                if (value != _prosecnaOcena)
                {
                    _prosecnaOcena = value;
                    OnPropertyChanged();
                }
            }
        }
        public Adresa AdresaStanovanja { get; set; }
        public List<Ocena> PolozeniIspiti { get; set; }
        public List<Predmet> NepolozeniIspiti { get; set; }

        public Student()
        {
            Id = -1;
            Prezime = "";
            Ime = "";
            DatumRodjenja = new DateTime();
            AdresaStanovanjaId = -1;
            KontaktTelefon = "";
            Email = "";
            BrojIndeksa = "";
            GodinaUpisa = 0;
            TrenutnaGodinaStudija = 0;
            Status = Status.S;
            ProsecnaOcena = 0.0;

            //AdresaStanovanja = new Adresa();
            //PolozeniIspiti = new List<Ocena>();
            //NepolozeniIspiti = new List<Predmet>();
        }

        public Student(int Id, string Prezime, string Ime, DateTime DatumRodjenja, int AdresaStanovanjaId, string KontaktTelefon, string Email, string BrojIndeksa, int GodinaUpisa, int TrenutnaGodinaStudija, Status Status, int ProsecnaOcena)
        {
            this.Id = Id;
            this.Prezime = Prezime;
            this.Ime = Ime;
            this.DatumRodjenja = DatumRodjenja;
            this.AdresaStanovanjaId = AdresaStanovanjaId;
            this.KontaktTelefon = KontaktTelefon;
            this.Email = Email;
            this.BrojIndeksa = BrojIndeksa;
            this.GodinaUpisa = GodinaUpisa;
            this.TrenutnaGodinaStudija = TrenutnaGodinaStudija;
            this.Status = Status;
            this.ProsecnaOcena = ProsecnaOcena;

            //AdresaStanovanja = new Adresa();
            //PolozeniIspiti = new List<Ocena>();
            //NepolozeniIspiti = new List<Predmet>();
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Prezime,
                Ime,
                DatumRodjenja.ToString(),
                AdresaStanovanjaId.ToString(),
                KontaktTelefon,
                Email,
                BrojIndeksa,
                GodinaUpisa.ToString(),
                TrenutnaGodinaStudija.ToString(),
                Convert.ToInt32(Status).ToString(),
                ProsecnaOcena.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Prezime = values[1];
            Ime = values[2];
            DatumRodjenja = DateTime.Parse(values[3]);
            AdresaStanovanjaId = int.Parse(values[4]);
            KontaktTelefon = values[5];
            Email = values[6];
            BrojIndeksa = values[7];
            GodinaUpisa = int.Parse(values[8]);
            TrenutnaGodinaStudija = int.Parse(values[9]);
            Status = (Status)int.Parse(values[10]);
            ProsecnaOcena = double.Parse(values[11]);
        }

        private Regex _IndexRegex = new Regex("[A-Z]{2} [0-9]{1,3}/[0-9]{4}");
        private Regex _EmailRegex = new Regex("[A-Za-z0-9]+@[A-Za-z0-9]+.[A-Za-z0-9]+");
        private Regex _BrojTelefonaRegex = new Regex("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$");

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Indeks")
                {
                    if (string.IsNullOrEmpty(BrojIndeksa))
                        return "Index is required";

                    Match match = _IndexRegex.Match(BrojIndeksa);
                    if (!match.Success)
                        return "Index should be in format: XY 123/YYYY";
                }
                else if (columnName == "Ime")
                {
                    if (string.IsNullOrEmpty(Ime))
                        return "First name is required";
                }
                else if (columnName == "Prezime")
                {
                    if (string.IsNullOrEmpty(Prezime))
                        return "Last name is required";
                }
                else if (columnName == "BrojTelefona")
                {
                    if (string.IsNullOrEmpty(KontaktTelefon))
                        return "Broj telefona is required";

                    Match match = _BrojTelefonaRegex.Match(KontaktTelefon);
                    if (!match.Success)
                        return "Invalid phone number format.";
                }
                else if (columnName == "Email")
                {
                    if (string.IsNullOrEmpty(Email))
                        return "Email is required";

                    Match match = _EmailRegex.Match(Email);
                    if (!match.Success)
                        return "Invalid email address format.";
                }

                return null;
            }
        }

        private readonly string[] _validatedProperties = { "BrojIndeksa", "Ime", "Prezime", "BrojTelefona", "Email" };

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
