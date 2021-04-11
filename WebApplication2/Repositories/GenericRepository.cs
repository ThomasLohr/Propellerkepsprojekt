using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Data;

namespace WebApplication2.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext _context = null;
        private DbSet<T> table = null;
        public GenericRepository()
        {
            this._context = new ApplicationDbContext();
            table = _context.Set<T>();
        }
        public GenericRepository(ApplicationDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();

        }

        public IQueryable<T> GetAllRaw()
        {
            return table;
        }
        public T GetById(int id)
        {
            return table.Find(id);
        }

        public T GetById(string id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
            Save();
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(int id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
