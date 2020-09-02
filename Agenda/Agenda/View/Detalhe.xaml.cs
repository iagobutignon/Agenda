using Agenda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Agenda.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detalhe : ContentPage
    {
        public Detalhe(Tarefa tarefa)
        {
            InitializeComponent();

            Nome.Text = tarefa.Nome;
            Data.Text = tarefa.Data.ToString();
            Descricao.Text = tarefa.Descricao;
            Imagem.Source = tarefa.Imagem;
            DataAbertura.Text = tarefa.DataAbertura.ToString();
            
            if (tarefa.DataFinalizacao != null)
            {
                DataFinalizacao.Text = tarefa.DataFinalizacao.ToString();
            }
            else
            {
                stackDataFinalizacao.IsVisible = false;
            }
                
        }
    }
}