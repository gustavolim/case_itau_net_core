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

namespace Case.Itau.Business.Services.V1.Fundos
{
    public class FundosServices(IFundosDao fundosDao, IMapper mapper) : IFundosServices
    {
        private readonly IFundosDao _fundosDao = fundosDao;
        private readonly IMapper _mapper = mapper;

        public Task Alterar(FundoModel fundoDto)
        {
            throw new NotImplementedException();
        }

        public Task Deletar(FundoModel fundoDto)
        {
            throw new NotImplementedException();
        }

        public Task Inserir(FundoModel fundoDto)
        {
            throw new NotImplementedException();
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
