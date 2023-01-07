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
    public class Ocena : ISerializable, INotifyPropertyChanged, IDataErrorInfo
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int PredmetId { get; set; }
        public int VrednostOcene { get; set; }
        public DateTime DatumPolaganja { get; set; }
        private Student _student;
        public Student Student
        {
            get => _student;
            set
            {
                if (value != _student)
                {
                    _student = value;
                    OnPropertyChanged();
                }
            }
        }
        private Predmet _predmet;
        public Predmet Predmet
        {
            get => _predmet;
            set
            {
                if (value != _predmet)
                {
                    _predmet = value;
                    OnPropertyChanged();
                }
            }
        }

        public Ocena()
        {
            Id = -1;
            StudentId = -1;
            PredmetId = -1;
            VrednostOcene = 5;
            DatumPolaganja = new DateTime();

            //Student = new Student();
            //Predmet = new Predmet();
        }

        public Ocena(int Id, int StudentId, int PredmetId, int VrednostOcene, DateTime DatumPolaganja)
        {
            this.Id = Id;
            this.StudentId = StudentId;
            this.PredmetId = PredmetId;
            this.VrednostOcene = VrednostOcene;
            this.DatumPolaganja = DatumPolaganja;

            //Student = new Student();
            //Predmet = new Predmet();
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

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                return null;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
