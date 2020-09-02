using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Banco
{
    public interface ICaminho
    {
        string ObterCaminho(string nomeArquivoBanco);
    }
}
