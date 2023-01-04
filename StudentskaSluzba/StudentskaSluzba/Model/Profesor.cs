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
    public class Profesor : ISerializable, INotifyPropertyChanged, IDataErrorInfo
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
        private string _telefon;
        public string Telefon
        {
            get => _telefon;
            set
            {
                if (value != _telefon)
                {
                    _telefon = value;
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
        private int _adresaKancelarijeId;
        public int AdresaKancelarijeId
        {
            get => _adresaKancelarijeId;
            set
            {
                if (value != _adresaKancelarijeId)
                {
                    _adresaKancelarijeId = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _brojLicne;
        public string BrojLicne
        {
            get => _brojLicne;
            set
            {
                if (value != _brojLicne)
                {
                    _brojLicne = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _zvanje;
        public string Zvanje
        {
            get => _zvanje;
            set
            {
                if (value != _zvanje)
                {
                    _zvanje = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _godineStaza;
        public int GodineStaza
        {
            get => _godineStaza;
            set
            {
                if (value != _godineStaza)
                {
                    _godineStaza = value;
                    OnPropertyChanged();
                }
            }
        }
        private int _katedraId;
        public int KatedraId
        {
            get => _katedraId;
            set
            {
                if (value != _katedraId)
                {
                    _katedraId = value;
                    OnPropertyChanged();
                }
            }
        }
        public Adresa AdresaKancelarije { get; set; }
        public Adresa AdresaStanovanja { get; set; }
        public Katedra Katedra { get; set; }
        public List<Predmet> SpisakPredmeta { get; set; }

        public Profesor()
        {
            Id = -1;
            Prezime = "";
            Ime = "";
            DatumRodjenja = new DateTime();
            AdresaStanovanjaId = -1;
            Telefon = "";
            Email = "";
            AdresaKancelarijeId = -1;
            BrojLicne = "";
            Zvanje = "Redovni profesor";
            GodineStaza = 0;
            KatedraId = -1;

            //AdresaStanovanja = new Adresa();
            //AdresaKancelarije = new Adresa();
            //Katedra = new Katedra();
            //SpisakPredmeta = new List<Predmet>();
        }

        public Profesor(int Id, string Prezime, string Ime, DateTime DatumRodjenja, int AdresaStanovanjaId, string Telefon, string Email, int AdresaKancelarijeId, string BrojLicne, string Zvanje, int GodineStaza, int KatedraId)
        {
            this.Id = Id;
            this.Prezime = Prezime;
            this.Ime = Ime;
            this.DatumRodjenja = DatumRodjenja;
            this.AdresaStanovanjaId = AdresaStanovanjaId;
            this.Telefon = Telefon;
            this.Email = Email;
            this.AdresaKancelarijeId = AdresaKancelarijeId;
            this.BrojLicne = BrojLicne;
            this.Zvanje = Zvanje;
            this.GodineStaza = GodineStaza;
            this.KatedraId = KatedraId;

            //AdresaStanovanja = new Adresa();
            //AdresaKancelarije = new Adresa();
            //Katedra = new Katedra();
            //SpisakPredmeta = new List<Predmet>();
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
                Telefon,
                Email,
                AdresaKancelarijeId.ToString(),
                BrojLicne,
                Zvanje,
                GodineStaza.ToString(),
                KatedraId.ToString()
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
            Telefon = values[5];
            Email = values[6];
            AdresaKancelarijeId = int.Parse(values[7]);
            BrojLicne = values[8];
            Zvanje = values[9];
            GodineStaza = int.Parse(values[10]);
            KatedraId = int.Parse(values[11]);
        }

        private Regex _EmailRegex = new Regex("[A-Za-z0-9]+@[A-Za-z0-9]+\\.[A-Za-z0-9]+");
        private Regex _BrojTelefonaRegex = new Regex("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$");
        private Regex _BrojLicneRegex = new Regex("[0-9]{9}");

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Ime")
                {
                    if (string.IsNullOrEmpty(Ime))
                        return "First name is required";
                }
                else if (columnName == "Prezime")
                {
                    if (string.IsNullOrEmpty(Prezime))
                        return "Last name is required";
                }
                else if (columnName == "Telefon")
                {
                    if (string.IsNullOrEmpty(Telefon))
                        return "Broj telefona is required";

                    Match match = _BrojTelefonaRegex.Match(Telefon);
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
                else if (columnName == "DatumRodjenja")
                {
                    if (string.IsNullOrEmpty(DatumRodjenja.ToLongDateString()))
                        return "DatumRodjenja is required";
                }
                else if (columnName == "BrojLicne")
                {
                    if (string.IsNullOrEmpty(BrojLicne.ToString()))
                        return "BrojLicne is required";

                    Match match = _BrojLicneRegex.Match(BrojLicne);
                    if (!match.Success)
                        return "Invalid BrojLicne format.";
                }

                return null;
            }
        }

        private readonly string[] _validatedProperties = { "Ime", "Prezime", "BrojTelefona", "Email", "DatumRodjenja", "BrojLicne" };

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
