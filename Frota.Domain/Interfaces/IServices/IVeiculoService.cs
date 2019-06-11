using Frota.Domain.Entities;

namespace Frota.Domain.Interfaces.IServices
{
    public interface IVeiculoService : IServiceBase<Veiculo>
    {
        void Adicionar(Veiculo entity);

        void Atualizar(Veiculo entity);
    }
}
