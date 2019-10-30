using ListagemFornecedores.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListagemFornecedores.Data.Repository.Interface
{
    public interface IRepository<Entity> where Entity : IEntity
    {
        IQueryable<Entity> GetAll();
        IList<Entity> GetAllList();
        Entity GetById(int id);
        void Create(Entity entity);
        void Update(Entity entity);
        void Delete(int id);
    }
}
