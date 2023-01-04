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
    public class PredmetController
    {
        private PredmetDAO _predmeti;

        public PredmetController()
        {
            _predmeti = new PredmetDAO();
        }

        public List<Predmet> GetAllPredmeti()
        {
            return _predmeti.GetAll();
        }

        public void Create(Predmet predmet)
        {
            _predmeti.Add(predmet);
        }

        public void Delete(Predmet predmet)
        {
            _predmeti.Remove(predmet);
        }

        public void Subscribe(IObserver observer)
        {
            _predmeti.Subscribe(observer);
        }
    }
}
