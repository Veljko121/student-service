using StudentskaSluzba.Observer;
using StudentskaSluzba.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Model.DAO
{
    internal class AdresaDAO : ISubject
    {
        private List<IObserver> _observers;

        private AdresaStorage _storage;
        private List<Adresa> _adrese;

        public AdresaDAO()
        {
            _storage = new AdresaStorage();
            _adrese = _storage.Load();
            _observers = new List<IObserver>();
        }

        public int NextId()
        {
            return _adrese.Max(s => s.Id) + 1;
        }

        public void Add(Adresa adresa)
        {
            adresa.Id = NextId();
            _adrese.Add(adresa);
            _storage.Save(_adrese);
            NotifyObservers();
        }

        public void Remove(Adresa adresa)
        {
            _adrese.Remove(adresa);
            _storage.Save(_adrese);
            NotifyObservers();
        }

        public List<Adresa> GetAll()
        {
            return _adrese;
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
