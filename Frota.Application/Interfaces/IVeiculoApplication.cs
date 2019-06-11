using Frota.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frota.Application.Interfaces
{
   public interface IVeiculoApplication
    {
        void Adicionar(VeiculoModel entity);

        VeiculoModel ObterPorId(int id);

        IEnumerable<VeiculoModel> ObterTodos();

        void Atualizar(VeiculoModel entity);

        void Remover(int id);
    }
}
