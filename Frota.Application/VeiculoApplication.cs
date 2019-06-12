using AutoMapper;
using Frota.Application.Extensions;
using Frota.Application.Interfaces;
using Frota.Application.ViewModels;
using Frota.Domain.Entities;
using Frota.Domain.Interfaces.IServices;
using System.Collections.Generic;

namespace Frota.Application
{
    public class VeiculoApplication : IVeiculoApplication
    {
        private readonly IVeiculoService _veiculoService;

        public VeiculoApplication(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        public void Adicionar(VeiculoModel entity)
        {
            var obj = entity.MapTo<Veiculo>();
            
            _veiculoService.Adicionar(obj);
        }

        public void Atualizar(VeiculoModel entity)
        {
            //var obj = entity.MapTo<Veiculo>();

            _veiculoService.Atualizar(entity.ID, entity.Cor);
        }

        public VeiculoModel ObterPorId(int id)
        {
            var obj = _veiculoService.ObterPorId(id);

            return obj.MapTo<VeiculoModel>();
        }

        public IEnumerable<VeiculoModel> ObterTodos()
        {
            var obj = Mapper.Map<IEnumerable<Veiculo>, IEnumerable<VeiculoModel>>(_veiculoService.ObterTodos());

            return obj;
        }

        public IEnumerable<VeiculoModel> ObterTodos(string chassi)
        {
            var obj = Mapper.Map<IEnumerable<Veiculo>, IEnumerable<VeiculoModel>>(_veiculoService.ObterTodos());

            return obj;
        }

        public void Remover(int id)
        {
            var obj = _veiculoService.ObterPorId(id);

            var item = obj.MapTo<Veiculo>();

            _veiculoService.Remover(item);
        }
    }
}
