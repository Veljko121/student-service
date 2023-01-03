using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Model
{
    internal class Ocena
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int PredmetId { get; set; }
        public int VrednostOcene { get; set; }
        public DateTime DatumPolaganja { get; set; }
        public Student Student { get; set; }
        public Predmet Predmet { get; set; }

        public Ocena()
        {
            Id = -1;
            StudentId = -1;
            PredmetId = -1;
            VrednostOcene = -1;
            DatumPolaganja = new DateTime();

            Student = new Student();
            Predmet = new Predmet();
        }

        public Ocena(int Id, int StudentId, int PredmetId, int VrednostOcene, DateTime DatumPolaganja)
        {
            this.Id = Id;
            this.StudentId = StudentId;
            this.PredmetId = PredmetId;
            this.VrednostOcene = VrednostOcene;
            this.DatumPolaganja = DatumPolaganja;

            Student = new Student();
            Predmet = new Predmet();
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                StudentId.ToString(),
                PredmetId.ToString(),
                VrednostOcene.ToString(),
                DatumPolaganja.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            StudentId = int.Parse(values[1]);
            PredmetId = int.Parse(values[2]);
            VrednostOcene = int.Parse(values[3]);
            DatumPolaganja = DateTime.Parse(values[4]);
        }
    }
}
