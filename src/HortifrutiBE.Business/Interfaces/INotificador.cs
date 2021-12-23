using System.Collections.Generic;
using HortifrutiBE.Business.Notificacoes;

namespace HortifrutiBE.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<string> ObterNotificacoes();
        void AdicionarNotificacao(string notificacao);
    }
}
