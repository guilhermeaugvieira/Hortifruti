using HortifrutiBE.Business.Models.ItemEstoque;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HortifrutiBE.Application.Interfaces
{
    public interface IItemEstoqueApplicationService
    {
        Task<IEnumerable<AdicionarItemEstoqueResponseModel>> AddItemEstoque(AdicionarItemEstoqueRequestModel itemEstoque, Guid idHortifruti, Guid idProduto);

        Task<IEnumerable<ObterItemEstoqueResponseModel>> ObterTodosItemEstoques(Guid idHortifruti, Guid idProduto);

        Task<ObterItemEstoqueResponseModel> ObterItemEstoquePorId(Guid idHortifruti, Guid idProduto, Guid idItemEstoque);
    }
}