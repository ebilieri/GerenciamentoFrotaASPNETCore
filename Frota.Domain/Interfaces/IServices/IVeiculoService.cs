using Frota.Domain.Entities;
using System.Collections.Generic;

namespace Frota.Domain.Interfaces.IServices
{
    public interface IVeiculoService : IServiceBase<Veiculo>
    {
        void Adicionar(Veiculo entity);

        void Atualizar(int id, string cor);

        IEnumerable<Veiculo> ObterTodos(string chassi);
    }
}
