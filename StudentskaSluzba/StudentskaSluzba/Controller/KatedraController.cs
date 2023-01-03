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
    internal class KatedraController
    {
        private KatedraDAO _katedre;

        public KatedraController()
        {
            _katedre = new KatedraDAO();
        }

        public List<Katedra> GetAllKatedre()
        {
            return _katedre.GetAll();
        }

        public void Create(Katedra katedra)
        {
            _katedre.Add(katedra);
        }

        public void Delete(Katedra katedra)
        {
            _katedre.Remove(katedra);
        }

        public void Subscribe(IObserver observer)
        {
            _katedre.Subscribe(observer);
        }
    }
}
