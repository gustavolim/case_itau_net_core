using AutoMapper;
using Case.Itau.Business.Models.V1;
using Case.Itau.Data.Dtos;
using Case.Itau.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case.Itau.Business.AutoMapper.V1
{
    public class FundosMappingProfile : Profile
    {
        public FundosMappingProfile()
        {
            CreateMap<FundosDtoMap, FundosResult>()
                .ForMember(x => x.Nome, o => o.MapFrom(src => src.Nome))
                .ForMember(x => x.CNPJ, o => o.MapFrom(src => src.CNPJ))
                .ForMember(x => x.Patrimonio, o => o.MapFrom(src => src.Patrimonio))
                .ForMember(x => x.TipoFundo, o => o.MapFrom(src => src.TipoFundo));

            CreateMap<FundosDtoMap, FundoModel>()
                .ForMember(x => x.Codigo, o => o.MapFrom(src => src.Codigo))
                .ForMember(x => x.Nome, o => o.MapFrom(src => src.Nome))
                .ForMember(x => x.CNPJ, o => o.MapFrom(src => src.CNPJ))
                .ForMember(x => x.CodigoTipo, o => o.MapFrom(src => src.CodigoTipo))
                .ForMember(x => x.Patrimonio, o => o.MapFrom(src => src.Patrimonio))
                .ForMember(x => x.TipoFundo, o => o.MapFrom(src => src.TipoFundo));

            CreateMap<TipoFundosDtoMap, TipoFundoResult>();
        }
    }
}
