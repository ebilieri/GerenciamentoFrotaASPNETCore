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

        public void Atualizar(Veiculo entity)
        {
            _veiculoRepository.Atualizar(entity);
        }
    }
}
