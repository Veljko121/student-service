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
    internal class StudentDAO : ISubject
    {
        private List<IObserver> _observers;

        private StudentStorage _storage;
        private List<Student> _studenti;

        public StudentDAO(List<Ocena> _ocene)
        {
            _storage = new StudentStorage();
            _studenti = _storage.Load();

            foreach (Student student in _studenti)
            {
                foreach (Ocena ocena in _ocene)
                {
                    if (student.Id == ocena.StudentId)
                    {
                        if (ocena.VrednostOcene >= 6 && ocena.VrednostOcene <= 10)
                        {
                            student.PolozeniIspiti.Add(ocena);
                        }
                        else
                        {
                            student.NepolozeniIspiti.Add(ocena);
                        }
                    }
                }
                student.ProsecnaOcena = 0;
                foreach (Ocena ocena in student.PolozeniIspiti)
                {
                    student.ProsecnaOcena += ocena.VrednostOcene;
                }
                student.ProsecnaOcena /= student.PolozeniIspiti.Count();
            }
            _observers = new List<IObserver>();
        }

        public int NextId()
        {
            if (_studenti.Count == 0)
            {
                return 0;
            }
            return _studenti.Max(s => s.Id) + 1;
        }

        public void Add(Student student)
        {
            student.Id = NextId();
            _studenti.Add(student);
            _storage.Save(_studenti);
            NotifyObservers();
        }

        public void Remove(Student student)
        {
            _studenti.Remove(student);
            _storage.Save(_studenti);
            NotifyObservers();
        }

        public List<Student> GetAll()
        {
            return _studenti;
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
