using StudentskaSluzba.Serializer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Model
{
    public class Katedra : ISerializable
    {
        public int Id { get; set; }
        public string SifraKatedre { get; set; }
        public string Naziv { get; set; }
        public int SefKatedreId { get; set; }
        public Profesor SefKatedre { get; set; }
        public List<Profesor> Profesori { get; set; }

        public Katedra()
        {
            Id = -1;
            SifraKatedre = "";
            Naziv = "";
            SefKatedreId = -1;

            //SefKatedre = new Profesor();
            //Profesori = new List<Profesor>();
        }
        public Katedra(int Id, string SifraKatedre, string Naziv, int SefKatedreId)
        {
            this.Id = Id;
            this.SifraKatedre = SifraKatedre;
            this.Naziv = Naziv;
            this.SefKatedreId = SefKatedreId;

            //SefKatedre = new Profesor();
            //Profesori = new List<Profesor>();
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                SifraKatedre,
                Naziv,
                SefKatedreId.ToString()
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            SifraKatedre = values[1];
            Naziv = values[2];
            SefKatedreId = int.Parse(values[3]);
        }
    }
}
