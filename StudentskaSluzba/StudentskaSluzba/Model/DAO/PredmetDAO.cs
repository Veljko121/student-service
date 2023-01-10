using StudentskaSluzba.Observer;
using StudentskaSluzba.Storage;
using StudentskaSluzba.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Model.DAO
{
    internal class PredmetDAO : ISubject
    {
        private List<IObserver> _observers;

        private PredmetStorage _storage;
        private List<Predmet> _predmeti;

        public PredmetDAO(List<Ocena> _ocene)
        {
            _storage = new PredmetStorage();
            _predmeti = _storage.Load();

            foreach (Predmet predmet in _predmeti)
            {
                foreach (Ocena ocena in _ocene)
                {
                    if (predmet.Id == ocena.PredmetId)
                    {
                        ocena.Predmet = predmet;
                    }
                }
            }

            _observers = new List<IObserver>();
        }

        public int NextId()
        {
            if (_predmeti.Count == 0)
            {
                return 0;
            }
            return _predmeti.Max(s => s.Id) + 1;
        }

        public void Add(Predmet predmet)
        {
            predmet.Id = NextId();
            _predmeti.Add(predmet);
            _storage.Save(_predmeti);
            NotifyObservers();
        }

        public void Remove(Predmet predmet)
        {
            _predmeti.Remove(predmet);
            _storage.Save(_predmeti);
            NotifyObservers();
        }

        public List<Predmet> GetAll()
        {
            return _predmeti;
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }

        public List<Predmet> GetPredmetiWhereNotStudent(List<Ocena> ocene)
        {
            List<Predmet> notPredmeti = new List<Predmet>();

            bool found = false;
            foreach (Predmet predmet in _predmeti)
            {
                foreach (Ocena ocena in ocene)
                {
                    if (predmet.Id == ocena.PredmetId)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    notPredmeti.Add(predmet);
                }
                found = false;
            }

            return notPredmeti;
        }

        public List<Predmet> GetPredmetiWhereNotProfesor(Profesor profesor)
        {
            List<Predmet> notPredmeti = new List<Predmet>();

            foreach (Predmet predmet in _predmeti)
            {
                if (predmet.PredmetniProfesorId != profesor.Id)
                {
                    notPredmeti.Add(predmet);
                }
            }

            return notPredmeti;
        }

        public void DodajPredmetProfesoru(Profesor profesor, Predmet predmet)
        {
            predmet.PredmetniProfesorId = profesor.Id;
            profesor.SpisakPredmeta.Add(predmet);
            _storage.Save(_predmeti);
            NotifyObservers();
        }

        public void UkloniPredmetZaProfesora(Profesor profesor, Predmet predmet)
        {
            predmet.PredmetniProfesorId = -1;
            profesor.SpisakPredmeta.Remove(predmet);
            _storage.Save(_predmeti);
            NotifyObservers();
        }
    }
}
