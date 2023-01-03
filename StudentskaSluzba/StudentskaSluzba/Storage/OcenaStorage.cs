using StudentskaSluzba.Model;
using StudentskaSluzba.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Storage
{
    internal class OcenaStorage
    {
        private const string StoragePath = "../../Data/ocene.csv";

        private Serializer<Ocena> _serializer;


        public OcenaStorage()
        {
            _serializer = new Serializer<Ocena>();
        }

        public List<Ocena> Load()
        {
            return _serializer.FromCSV(StoragePath);
        }

        public void Save(List<Ocena> ocene)
        {
            _serializer.ToCSV(StoragePath, ocene);
        }
    }
}
