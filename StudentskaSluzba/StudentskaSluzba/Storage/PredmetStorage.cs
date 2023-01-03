using StudentskaSluzba.Model;
using StudentskaSluzba.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Storage
{
    internal class PredmetStorage
    {
        private const string StoragePath = "../../Data/predmeti.csv";

        private Serializer<Predmet> _serializer;


        public PredmetStorage()
        {
            _serializer = new Serializer<Predmet>();
        }

        public List<Predmet> Load()
        {
            return _serializer.FromCSV(StoragePath);
        }

        public void Save(List<Predmet> predmeti)
        {
            _serializer.ToCSV(StoragePath, predmeti);
        }
    }
}
