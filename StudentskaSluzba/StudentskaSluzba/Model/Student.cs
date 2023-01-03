using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Model
{
    public enum Status { B, S };
    internal class Student
    {
        public int Id { get; set; }
        public string Prezime { get; set; }
        public string Ime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int AdresaStanovanjaId { get; set; }
        public string KontaktTelefon { get; set; }
        public string Email { get; set; }
        public string BrojIndeksa { get; set; }
        public int GodinaUpisa { get; set; }
        public int TrenutnaGodinaStudija { get; set; }
        public Status Status { get; set; }
        public double ProsecnaOcena { get; set; }
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

            AdresaStanovanja = new Adresa();
            PolozeniIspiti = new List<Ocena>();
            NepolozeniIspiti = new List<Predmet>();
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

            AdresaStanovanja = new Adresa();
            PolozeniIspiti = new List<Ocena>();
            NepolozeniIspiti = new List<Predmet>();
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
    }
}
