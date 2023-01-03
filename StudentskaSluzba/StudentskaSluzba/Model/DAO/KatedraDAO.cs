using StudentskaSluzba.Observer;
using StudentskaSluzba.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Model.DAO
{
    internal class KatedraDAO : ISubject
    {
        private List<IObserver> _observers;

        private KatedraStorage _storage;
        private List<Katedra> _katedre;

        public KatedraDAO()
        {
            _storage = new KatedraStorage();
            _katedre = _storage.Load();
            _observers = new List<IObserver>();
        }

        public int NextId()
        {
            return _katedre.Max(s => s.Id) + 1;
        }

        public void Add(Katedra katedra)
        {
            katedra.Id = NextId();
            _katedre.Add(katedra);
            _storage.Save(_katedre);
            NotifyObservers();
        }

        public void Remove(Katedra katedra)
        {
            _katedre.Remove(katedra);
            _storage.Save(_katedre);
            NotifyObservers();
        }

        public List<Katedra> GetAll()
        {
            return _katedre;
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
