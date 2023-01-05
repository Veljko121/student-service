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
    public class AdresaController
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

        public int Create(Adresa adresa)
        {
            _adrese.Add(adresa);
            return adresa.Id;
        }

        public void Delete(Adresa adresa)
        {
            _adrese.Remove(adresa);
        }

        public void Subscribe(IObserver observer)
        {
            _adrese.Subscribe(observer);
        }

        public Adresa FindByID(int id)
        {
            return _adrese.Find(id);
        }
    }
}
