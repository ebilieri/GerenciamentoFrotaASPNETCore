using Frota.Domain.Entities;
using Frota.Domain.Interfaces.IRepositories;
using Frota.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Frota.Domain.Services
{
    public class VeiculoService : ServiceBase<Veiculo>, IVeiculoService
    {
        private readonly IVeiculoRepository _veiculoRepository;


        public VeiculoService(IVeiculoRepository veiculoRepository) : base(veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public void Adicionar(Veiculo entity)
        {
            if (entity == null)
            {
                entity.AdicionarMensagem("");
            }


            _veiculoRepository.Adicionar(entity);
        }

        public void Atualizar(int id, string cor)
        {
            var veiculo = _veiculoRepository.ObterPorId(id);
            veiculo.Cor = cor;

            _veiculoRepository.Atualizar(veiculo);
        }

        public IEnumerable<Veiculo> ObterTodos(string chassi)
        {
            return _veiculoRepository.ObterTodos(chassi);
        }
    }
}
