using HortifrutiBE.Business.Models.Pedido;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HortifrutiBE.Application.Interfaces
{
    public interface IPedidoApplicationService
    {
        Task<AdicionarPedidoResponseModel> AddPedido(AdicionarPedidoRequestModel dadosPedido);

        Task<IEnumerable<ObterPedidoResponseModel>> ObterTodosPedidos();

        Task<ObterPedidoResponseModel> ObterPedidoPorId(Guid idPedido);
    }
}