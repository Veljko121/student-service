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
    internal class OcenaController
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
    }
}
