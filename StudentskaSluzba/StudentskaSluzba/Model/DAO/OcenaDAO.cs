using StudentskaSluzba.Observer;
using StudentskaSluzba.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentskaSluzba.Model.DAO
{
    internal class OcenaDAO : ISubject
    {
        private List<IObserver> _observers;

        private OcenaStorage _storage;
        private List<Ocena> _ocene;

        public OcenaDAO()
        {
            _storage = new OcenaStorage();
            _ocene = _storage.Load();
            _observers = new List<IObserver>();
        }

        public int NextId()
        {
            return _ocene.Max(s => s.Id) + 1;
        }

        public void Add(Ocena ocena)
        {
            ocena.Id = NextId();
            _ocene.Add(ocena);
            _storage.Save(_ocene);
            NotifyObservers();
        }

        public void Remove(Ocena ocena)
        {
            _ocene.Remove(ocena);
            _storage.Save(_ocene);
            NotifyObservers();
        }

        public List<Ocena> GetAll()
        {
            return _ocene;
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

        public void PonistiOcenu(Ocena ocena, Student student)
        {
            ocena.VrednostOcene = 5;
            student.PolozeniIspiti.Remove(ocena);
            student.NepolozeniIspiti.Add(ocena);
            _storage.Save(_ocene);
            NotifyObservers();
        }

        public List<Ocena> GetOceneForStudent(Student student)
        {
            List<Ocena> ocene = new List<Ocena>();

            foreach (Ocena ocena in _ocene)
            {
                if (ocena.StudentId == student.Id)
                {
                    ocene.Add(ocena);
                }
            }

            return ocene;
        }
    }
}
