using StudentskaSluzba.Model;
using StudentskaSluzba.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Storage
{
    internal class StudentStorage
    {
        private const string StoragePath = "../../Data/studenti.csv";

        private Serializer<Student> _serializer;


        public StudentStorage()
        {
            _serializer = new Serializer<Student>();
        }

        public List<Student> Load()
        {
            return _serializer.FromCSV(StoragePath);
        }

        public void Save(List<Student> studenti)
        {
            _serializer.ToCSV(StoragePath, studenti);
        }
    }
}
