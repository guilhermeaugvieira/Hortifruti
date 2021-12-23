using System.Collections.Generic;
using System.Linq;
using HortifrutiBE.Business.Interfaces;

namespace HortifrutiBE.Business.Notificacoes
{
    public class Notificador : INotificador
    {
        private List<string> _notificacoes;

        public Notificador()
        {
            _notificacoes = new List<string>();
        }

        public void AdicionarNotificacao(string notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<string> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}
