using Frota.Application.ViewModels;
using System.Collections.Generic;

namespace Frota.Application.Interfaces
{
    public interface IVeiculoApplication
    {
        void Adicionar(VeiculoModel entity);

        VeiculoModel ObterPorId(int id);

        IEnumerable<VeiculoModel> ObterTodos();

        IEnumerable<VeiculoModel> ObterTodos(string chassi);

        void Atualizar(VeiculoModel entity);

        void Remover(int id);
    }
}
