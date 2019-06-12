using Frota.Domain.Entities;
using Frota.Domain.Interfaces.IRepositories;
using Frota.Domain.Interfaces.IServices;
using System.Collections.Generic;

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
            var veiculo = ObterPorChassi(entity.Chassi);
            if (veiculo != null)
            {
                entity.AdicionarMensagem("Veículo já cadastrado com esse Chassi");

            }
            else
            {
                switch (entity.Tipo)
                {
                    case 2:
                        {
                            entity.NumeroPassageiro = 42;
                            break;
                        }
                    default:
                        entity.NumeroPassageiro = 2;
                        break;
                }

                _veiculoRepository.Adicionar(entity);
            }
        }

        public void Atualizar(int id, string cor)
        {
            var veiculo = _veiculoRepository.ObterPorId(id);
            veiculo.Cor = cor;

            _veiculoRepository.Atualizar(veiculo);
        }

        public Veiculo ObterPorChassi(string chassi)
        {
            return _veiculoRepository.ObterPorChassi(chassi);
        }

        public IEnumerable<Veiculo> ObterTodos(string chassi)
        {
            return _veiculoRepository.ObterTodos(chassi);
        }
    }
}
