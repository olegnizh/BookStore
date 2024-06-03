using System;
using BookStore.Models;

namespace BookStore.Repositories
{
	public interface IBaseRepository<T>
	{
        public void Add(T model);
        public List<T> GetAll();
        public void Update(T model);
        public T FindById(int id);
        public List<T> FindByName(string name);
        public void Delete(T model);
    }
}

