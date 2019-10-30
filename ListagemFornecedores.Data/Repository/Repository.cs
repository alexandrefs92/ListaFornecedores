using ListagemFornecedores.Data.Context;
using ListagemFornecedores.Data.Repository.Interface;
using ListagemFornecedores.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListagemFornecedores.Data.Repository
{
    public class Repository<Entity> : IRepository<Entity> where Entity : class, IEntity
    {
        private readonly ListagemFornecedoresContext _context;

        public Repository(ListagemFornecedoresContext listagemFornecedoresContext)
        {
            _context = listagemFornecedoresContext;
        }

        public void Create(Entity entity)
        {
            _context.Set<Entity>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _context.Set<Entity>().FirstOrDefault<Entity>(e => e.Id == id);

            if (entity != null)
                _context.Set<Entity>().Remove(entity);

            _context.SaveChanges();
        }

        public IQueryable<Entity> GetAll()
        {
            return _context.Set<Entity>().AsQueryable();
        }

        public IList<Entity> GetAllList()
        {
            var a = _context.Set<Entity>().ToList();
            return a;
        }

        public Entity GetById(int id)
        {
            return _context.Set<Entity>().FirstOrDefault<Entity>(e => e.Id == id);
        }

        public void Update(Entity entity)
        {
            _context.Set<Entity>().Update(entity);
            _context.SaveChanges();
        }
    }
}
