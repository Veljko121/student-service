using StudentskaSluzba.Observer;
using StudentskaSluzba.Storage;
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

        public PredmetDAO()
        {
            _storage = new PredmetStorage();
            _predmeti = _storage.Load();
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
    }
}
