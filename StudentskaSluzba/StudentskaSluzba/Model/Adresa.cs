using StudentskaSluzba.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Model
{
    public class Adresa : ISerializable
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

        public Adresa(Adresa adresa)
        {
            this.Id = adresa.Id;
            this.Ulica = adresa.Ulica;
            this.Broj = adresa.Broj;
            this.Grad = adresa.Grad;
            this.Drzava = adresa.Drzava;
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

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                if (columnName == "Ulica")
                {
                    if (string.IsNullOrEmpty(Ulica))
                        return "Ulica is required";
                }
                else if (columnName == "Broj")
                {
                    if (string.IsNullOrEmpty(Broj))
                        return "Broj is required";
                }
                else if (columnName == "Grad")
                {
                    if (string.IsNullOrEmpty(Grad))
                        return "Grad is required";
                }
                else if (columnName == "Drzava")
                {
                    if (string.IsNullOrEmpty(Drzava))
                        return "Drzava is required";
                }

                return null;
            }
        }

        private readonly string[] _validatedProperties = { "Ulica", "Broj", "Grad", "Drzava" };

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
    }
}
