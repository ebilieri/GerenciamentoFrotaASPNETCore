using System.Collections.Generic;
using System.Linq;
using Frota.Domain.Entities;
using Frota.Domain.Interfaces.IRepositories;
using Frota.Repository.Context;

namespace Frota.Repository.Repositories
{
    public class VeiculoRepository : RepositoryBase<Veiculo>, IVeiculoRepository
    {
        protected new readonly FrotaContext _frotaContext;

        public VeiculoRepository(FrotaContext frotaContext) : base(frotaContext)
        {
            _frotaContext = frotaContext;
        }

        public IEnumerable<Veiculo> ObterTodos(string chassi)
        {
            return _frotaContext.Set<Veiculo>().Where(p => p.Chassi.ToUpper().Contains(chassi.ToUpper())).ToList();
        }
    }
}
