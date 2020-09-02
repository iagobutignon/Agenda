using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Agenda.Banco;
using Xamarin.Forms;
using System.IO;
using Agenda.iOS.Banco;

[assembly:Dependency(typeof(Caminho))]
namespace Agenda.iOS.Banco
{
    public class Caminho : ICaminho
    {
        public string ObterCaminho(string nomeArquivoBanco)
        {
            string caminhoPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string caminhoBliblioteca = Path.Combine(caminhoPasta, "..", "Library");

            string caminhoBanco = Path.Combine(caminhoBliblioteca, nomeArquivoBanco);

            return caminhoBanco;
        }
    }
}