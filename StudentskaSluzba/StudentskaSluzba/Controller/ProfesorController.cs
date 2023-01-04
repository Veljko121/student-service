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
    public class ProfesorController
    {
        private ProfesorDAO _profesori;

        public ProfesorController()
        {
            _profesori = new ProfesorDAO();
        }

        public List<Profesor> GetAllProfesori()
        {
            return _profesori.GetAll();
        }

        public void Create(Profesor profesor)
        {
            _profesori.Add(profesor);
        }

        public void Delete(Profesor profesor)
        {
            _profesori.Remove(profesor);
        }

        public void Subscribe(IObserver observer)
        {
            _profesori.Subscribe(observer);
        }
    }
}
