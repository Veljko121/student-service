using StudentskaSluzba.Model.DAO;
using StudentskaSluzba.Model;
using StudentskaSluzba.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Controller
{
    public class OcenaController
    {
        private OcenaDAO _ocene;

        public OcenaController()
        {
            _ocene = new OcenaDAO();
        }

        public List<Ocena> GetAllOcene()
        {
            return _ocene.GetAll();
        }

        public void Create(Ocena ocena)
        {
            _ocene.Add(ocena);
        }

        public void Delete(Ocena ocena)
        {
            _ocene.Remove(ocena);
        }

        public void Subscribe(IObserver observer)
        {
            _ocene.Subscribe(observer);
        }

        public void PonistiOcenu(Ocena ocena, Student student)
        {
            _ocene.PonistiOcenu(ocena, student);
        }

        public List<Ocena> GetOceneForStudent(Student student)
        {
            return _ocene.GetOceneForStudent(student);
        }

        public void PoloziPredmet(Student student, Ocena ocena)
        {
            _ocene.PoloziPredmet(student, ocena);
        }
    }
}
