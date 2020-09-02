using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Agenda.Banco;
using System.IO;
using Agenda.UWP.Banco;

using Windows.Storage;

[assembly: Dependency(typeof(Caminho))]
namespace Agenda.UWP.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string nomeArquivoBanco)
        {
            string caminhoPasta = ApplicationData.Current.LocalFolder.Path;

            string caminhoBanco = Path.Combine(caminhoPasta, nomeArquivoBanco);

            return caminhoBanco;
        }
    }
}
