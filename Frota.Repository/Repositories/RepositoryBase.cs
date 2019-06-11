using Frota.Domain.Interfaces.IRepositories;
using Frota.Repository.Context;
using System.Collections.Generic;
using System.Linq;

namespace Frota.Repository.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly FrotaContext _frotaContext;

        public RepositoryBase(FrotaContext frotaContext)
        {
            _frotaContext = frotaContext;
        }

        public void Adicionar(TEntity entity)
        {
            _frotaContext.Set<TEntity>().Add(entity);
            _frotaContext.SaveChanges();
        }

        public void Atualizar(TEntity entity)
        {
            _frotaContext.Set<TEntity>().Update(entity);
            _frotaContext.SaveChanges();
        }

        public TEntity ObterPorId(int id)
        {
            return _frotaContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _frotaContext.Set<TEntity>().ToList();
        }

        public void Remover(TEntity entity)
        {
            _frotaContext.Set<TEntity>().Remove(entity);
            _frotaContext.SaveChanges();
        }

        public void Dispose()
        {
            _frotaContext.Dispose();
        }
    }
}
