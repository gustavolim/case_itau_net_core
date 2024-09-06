using AutoMapper;
using Case.Itau.Business.Util.Exception;
using Case.Itau.Business.Models.V1;
using Case.Itau.Data.Repositories.Fundos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Case.Itau.Data.Dtos;
using Case.Itau.Data.Mappings;

namespace Case.Itau.Business.Services.V1.Fundos
{
    public class FundosServices(IFundosDao fundosDao, IMapper mapper) : IFundosServices
    {
        private readonly IFundosDao _fundosDao = fundosDao;
        private readonly IMapper _mapper = mapper;

        public async Task Alterar(FundoModel fundoDto)
        {
            try
            {
                var fundoMap = _mapper.Map<FundosDtoMap>(fundoDto);

                await _fundosDao.Alterar(fundoMap);
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, $"{e.Message}");
            }
        }

        public async Task Deletar(string codigo)
        {
            try
            {
                await _fundosDao.Deletar(x=> x.Codigo == codigo);
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, $"{e.Message}");
            }
        }

        public async Task Inserir(FundoModel fundoDto)
        {
            try
            {
                var fundoMap = _mapper.Map<FundosDtoMap>(fundoDto);

                await _fundosDao.Inserir(fundoMap);
            }
            catch (Exception e)
            {
                throw new HttpException(HttpStatusCode.InternalServerError, $"{e.Message}");
            }
        }

        public async Task<FundosResult> ObterFundo(string codigo)
        {
            var fundo = await _fundosDao.ObterFundo(x => x.Codigo == codigo);
            if (fundo is not object || fundo == null)
                throw new HttpException(HttpStatusCode.NoContent, "Nao Existe Fundos");

            return _mapper.Map<FundosResult>(fundo);
        }

        public async Task<List<FundosResult>> ObterFundos()
        {
            var fundo = await _fundosDao.ObterFundos(x => x.Nome != null);
            if (fundo is not object || fundo == null)
                throw new HttpException(HttpStatusCode.NoContent, "Nao Existe Fundos");

            return _mapper.Map<List<FundosResult>>(fundo);
        }
    }
}
