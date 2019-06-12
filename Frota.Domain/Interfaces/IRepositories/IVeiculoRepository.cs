using Frota.Domain.Entities;
using System.Collections.Generic;

namespace Frota.Domain.Interfaces.IRepositories
{
    public interface IVeiculoRepository : IRepositoryBase<Veiculo>
    {
        IEnumerable<Veiculo> ObterTodos(string chassi);
    }
}
