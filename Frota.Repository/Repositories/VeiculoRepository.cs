using Frota.Domain.Entities;
using Frota.Domain.Interfaces.IRepositories;
using Frota.Repository.Context;

namespace Frota.Repository.Repositories
{
    public class VeiculoRepository : RepositoryBase<Veiculo>, IVeiculoRepository
    {
        public VeiculoRepository(FrotaContext frotaContext) : base(frotaContext)
        {
        }
    }
}
