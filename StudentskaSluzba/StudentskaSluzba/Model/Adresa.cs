using StudentskaSluzba.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Model
{
    internal class Adresa : ISerializable
    {
        public int Id { get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public string Grad { get; set; }
        public string Drzava { get; set; }

        public Adresa()
        {
            Id = -1;
            Ulica = "";
            Broj = "";
            Grad = "";
            Drzava = "";
        }
        public Adresa(int Id, string Ulica, string Broj, string Grad, string Drzava)
        {
            this.Id = Id;
            this.Ulica = Ulica;
            this.Broj = Broj;
            this.Grad = Grad;
            this.Drzava = Drzava;
        }

        public string[] ToCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Ulica,
                Broj,
                Grad,
                Drzava
            };
            return csvValues;
        }

        public void FromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Ulica = values[1];
            Broj = values[2];
            Grad = values[3];
            Drzava = values[4];
        }
    }
}
