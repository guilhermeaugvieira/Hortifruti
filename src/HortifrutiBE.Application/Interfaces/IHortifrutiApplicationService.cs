using HortifrutiBE.Business.Models.Hortifruti;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HortifrutiBE.Application.Interfaces
{
    public interface IHortifrutiApplicationService
    {
        Task<AdicionarHortifrutiResponseModel> AddHortifruti(AdicionarHortifrutiRequestModel dadosHortifruti);

        Task<IEnumerable<ObterHortifrutiResponseModel>> ObterTodasHortifrutis();

        Task<ObterHortifrutiResponseModel> ObterHortifrutiPorId(Guid idHortifruti);
    }
}