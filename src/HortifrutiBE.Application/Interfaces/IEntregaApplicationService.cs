using HortifrutiBE.Business.Models.Entrega;
using HortifrutiBE.Business.Models.Pedido;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HortifrutiBE.Application.Interfaces
{
    public interface IEntregaApplicationService
    {
        Task<AdicionarEntregaResponseModel> AddEntrega(AdicionarEntregaRequestModel dadosEntrega);

        Task<ObterEntregaResponseModel> ObterEntregaPorId(Guid idEntrega);

        Task<IEnumerable<ObterEntregaResponseModel>> ObterTodasEntregas();
    }
}