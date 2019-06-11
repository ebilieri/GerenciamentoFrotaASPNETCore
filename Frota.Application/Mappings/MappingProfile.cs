using Frota.Application.ViewModels;
using Frota.Domain.Entities;

namespace Frota.Application.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Veiculo, VeiculoModel>();
        }
    }
}
