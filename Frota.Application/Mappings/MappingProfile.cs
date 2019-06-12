using Frota.Application.Enumerators;
using Frota.Application.ViewModels;
using Frota.Domain.Entities;
using System;

namespace Frota.Application.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Veiculo, VeiculoModel>()
                .ForMember(dest => dest.Tipo,
                opt => opt.MapFrom(source => Enum.GetName(typeof(TipoVeiculo), source.Tipo)));
        }
    }
}
