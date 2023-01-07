using StudentskaSluzba.Model;
using StudentskaSluzba.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Storage
{
    internal class KatedraStorage
    {
        private const string StoragePath = "../../Data/katedre.csv";

        private Serializer<Katedra> _serializer;


        public KatedraStorage()
        {
            _serializer = new Serializer<Katedra>();
        }

        public List<Katedra> Load()
        {
            return _serializer.FromCSV(StoragePath);
        }

        public void Save(List<Katedra> katedre)
        {
            _serializer.ToCSV(StoragePath, katedre);
        }
    }
}
