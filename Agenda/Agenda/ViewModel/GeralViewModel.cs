using System;
using System.Collections.Generic;
using System.Text;
using Agenda.Model;
using Agenda.Banco;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Agenda.View;

namespace Agenda.ViewModel
{
    class GeralViewModel
    {
        private ContentPage Page { get; set; }
        public List<Tarefa> Tarefas { get; set; }
        public List<Tarefa> TarefasHoje { get; set; }
        public List<Tarefa> TarefasPendentes { get; set; }
        public List<Tarefa> TarefasConcluidas { get; set; }
        public List<Tarefa> TarefasAtrasadas { get; set; }
        public int Total { get { return Tarefas.Count; } protected set {; } }
        public int TotalHoje { get { return TarefasHoje.Count; } protected set {; } }
        public int TotalPendentes { get { return TarefasPendentes.Count; } protected set {; } }
        public int TotalConcluidas { get { return TarefasConcluidas.Count; } protected set {; } }
        public int TotalAtrasadas { get { return TarefasAtrasadas.Count; } protected set {; } }
        public Command TotalHojeCommand { get; set; }
        public Command TotalPendentesCommand { get; set; }
        public Command TotalConcluidasCommand { get; set; }
        public Command TotalAtrasadasCommand { get; set; }
        public GeralViewModel(ContentPage page)
        {
            Page = page;

            Database database = new Database();

            Tarefas = database.Consultar();
            TarefasHoje = Tarefas.Where<Tarefa>(a => a.Data.Date == DateTime.Now.Date && a.DataFinalizacao == null).ToList();
            TarefasAtrasadas = Tarefas.Where<Tarefa>(a => a.Data < DateTime.Now && a.DataFinalizacao == null).ToList();
            TarefasPendentes = Tarefas.Where<Tarefa>(a => a.DataFinalizacao == null).ToList();
            TarefasConcluidas = Tarefas.Where<Tarefa>(a => a.DataFinalizacao != null).ToList();

            TotalHojeCommand = new Command(CommandTotalHoje);
            TotalPendentesCommand = new Command(CommandTotalPendentes);
            TotalConcluidasCommand = new Command(CommandTotalConcluidas);
            TotalAtrasadasCommand = new Command(CommandTotalAtrasadas);
        }
        private void CommandTotalHoje()
        {
            Page.Navigation.PushAsync(new ListaTarefas(TarefasHoje, "Tarefas Hoje"));
        }
        private void CommandTotalPendentes()
        {
            Page.Navigation.PushAsync(new ListaTarefas(TarefasPendentes, "Tarefas Pendentes"));
        }
        private void CommandTotalConcluidas()
        {
            Page.Navigation.PushAsync(new ListaTarefas(TarefasConcluidas, "Tarefas Concluídas"));
        }
        private void CommandTotalAtrasadas()
        {
            Page.Navigation.PushAsync(new ListaTarefas(TarefasAtrasadas, "Tarefas Atrasadas"));
        }
    }
}
