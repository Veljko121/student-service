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
    internal class AdresaController
    {
        private AdresaDAO _adrese;

        public AdresaController()
        {
            _adrese = new AdresaDAO();
        }

        public List<Adresa> GetAllAdrese()
        {
            return _adrese.GetAll();
        }

        public void Create(Adresa adresa)
        {
            _adrese.Add(adresa);
        }

        public void Delete(Adresa adresa)
        {
            _adrese.Remove(adresa);
        }

        public void Subscribe(IObserver observer)
        {
            _adrese.Subscribe(observer);
        }
    }
}
