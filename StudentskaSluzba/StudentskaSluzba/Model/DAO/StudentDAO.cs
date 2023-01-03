﻿using StudentskaSluzba.Observer;
using StudentskaSluzba.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentskaSluzba.Model.DAO
{
    internal class StudentDAO : ISubject
    {
        private List<IObserver> _observers;

        private StudentStorage _storage;
        private List<Student> _studenti;

        public StudentDAO()
        {
            _storage = new StudentStorage();
            _studenti = _storage.Load();
            _observers = new List<IObserver>();
        }

        public int NextId()
        {
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
