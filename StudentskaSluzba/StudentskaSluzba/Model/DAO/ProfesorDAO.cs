using StudentskaSluzba.Observer;
using StudentskaSluzba.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Model.DAO
{
    internal class ProfesorDAO : ISubject
    {
        private List<IObserver> _observers;

        private ProfesorStorage _storage;
        private List<Profesor> _profesori;

        public ProfesorDAO(List<Predmet> predmeti)
        {
            _storage = new ProfesorStorage();
            _profesori = _storage.Load();

            foreach (Profesor profesor in _profesori)
            {
                foreach (Predmet predmet in predmeti)
                {
                    if (profesor.Id == predmet.PredmetniProfesorId)
                    {
                        profesor.SpisakPredmeta.Add(predmet);
                    }
                }
            }

            _observers = new List<IObserver>();
        }

        public int NextId()
        {
            if (_profesori.Count == 0)
            {
                return 0;
            }
            return _profesori.Max(s => s.Id) + 1;
        }

        public void Add(Profesor profesor)
        {
            profesor.Id = NextId();
            _profesori.Add(profesor);
            _storage.Save(_profesori);
            NotifyObservers();
        }

        public void Remove(Profesor profesor)
        {
            _profesori.Remove(profesor);
            _storage.Save(_profesori);
            NotifyObservers();
        }

        public List<Profesor> GetAll()
        {
            return _profesori;
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
    }
}
