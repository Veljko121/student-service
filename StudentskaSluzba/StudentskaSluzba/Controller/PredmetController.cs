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

        public PredmetController(OcenaController ocenaController)
        {
            _predmeti = new PredmetDAO(ocenaController.GetAllOcene());
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

        public List<Predmet> GetPredmetiWhereNotStudent(List<Ocena> ocene)
        {
            return _predmeti.GetPredmetiWhereNotStudent(ocene);
        }

        public List<Predmet> GetPredmetiWhereNotProfesor(Profesor profesor)
        {
            return _predmeti.GetPredmetiWhereNotProfesor(profesor);
        }

        public void DodajPredmetProfesoru(Profesor profesor, Predmet predmet)
        {
            _predmeti.DodajPredmetProfesoru(profesor, predmet);
        }

        public void UkloniPredmetZaProfesora(Profesor profesor, Predmet predmet)
        {
            _predmeti.UkloniPredmetZaProfesora(profesor, predmet);
        }
    }
}
