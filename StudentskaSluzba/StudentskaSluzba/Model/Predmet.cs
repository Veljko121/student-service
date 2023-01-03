using StudentskaSluzba.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Model
{
    public enum Semestar { L, Z };
    public class Predmet : ISerializable
    {
        public int Id { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public Semestar Semestar { get; set; }
        public int GodinaStudija { get; set; }
        public int PredmetniProfesorId { get; set; }
        public int BrojESPB { get; set; }
        public Profesor PredmetniProfesor { get; set; }
        public List<Student> Polozili { get; set; }
        public List<Student> NisuPolozili { get; set; }

        public Predmet()
        {
            Id = -1;
            Sifra = "";
            Naziv = "";
            Semestar = Semestar.Z;
            GodinaStudija = 0;
            PredmetniProfesorId = -1;
            BrojESPB = 0;

            PredmetniProfesor = new Profesor();
            Polozili = new List<Student>();
            NisuPolozili = new List<Student>();
        }

        public Predmet(int Id, string Sifra, string Naziv, Semestar Semestar, int GodinaStudija, int PredmetniProfesorId, int BrojESPB)
        {
            this.Id = Id;
            this.Sifra = Sifra;
            this.Naziv = Naziv;
            this.Semestar = Semestar;
            this.GodinaStudija = GodinaStudija;
            this.PredmetniProfesorId = PredmetniProfesorId;
            this.BrojESPB = BrojESPB;

            PredmetniProfesor = new Profesor();
            Polozili = new List<Student>();
            NisuPolozili = new List<Student>();
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Sifra,
                Naziv,
                Convert.ToInt32(Semestar).ToString(),
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
            Semestar = (Semestar)int.Parse(values[3]);
            GodinaStudija = int.Parse(values[4]);
            PredmetniProfesorId = int.Parse(values[5]);
            BrojESPB = int.Parse(values[6]);
        }
    }
}
