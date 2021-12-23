using HortifrutiBE.Business.Models.Produto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HortifrutiBE.Application.Interfaces
{
    public interface IProdutoApplicationService
    {
        Task<AdicionarProdutoResponseModel> AddProduto(AdicionarProdutoRequestModel dadosProduto, Guid idHortifruti);

        Task<IEnumerable<ObterProdutoResponseModel>> ObterTodosProdutos(Guid idHortifruti);

        Task<ObterProdutoResponseModel> ObterProdutoPorId(Guid idHortifruti, Guid idProduto);
    }
}