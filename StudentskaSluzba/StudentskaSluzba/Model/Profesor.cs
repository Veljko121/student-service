using StudentskaSluzba.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Model
{
    internal class Profesor : ISerializable
    {
        public int Id { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int AdresaStanovanjaId { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public int AdresaKancelarijeId { get; set; }
        public string BrojLicne { get; set; }
        public string Zvanje { get; set; }
        public int GodineStaza { get; set; }
        public int KatedraId { get; set; }
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
            Zvanje = "";
            GodineStaza = 0;
            KatedraId = -1;

            AdresaStanovanja = new Adresa();
            AdresaKancelarije = new Adresa();
            Katedra = new Katedra();
            SpisakPredmeta = new List<Predmet>();
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

            AdresaStanovanja = new Adresa();
            AdresaKancelarije = new Adresa();
            Katedra = new Katedra();
            SpisakPredmeta = new List<Predmet>();
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
    }
}
