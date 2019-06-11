using Frota.Domain.Interfaces.IRepositories;
using Frota.Domain.Interfaces.IServices;
using System.Collections.Generic;

namespace Frota.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }        

        public TEntity ObterPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return _repository.ObterTodos();
        }

        public void Remover(TEntity entity)
        {
            _repository.Remover(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
