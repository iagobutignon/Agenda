using System;
using System.Collections.Generic;
using System.Text;
using Agenda.Model;
using Agenda.Banco;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Agenda.ViewModel
{
    class GeralViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<Tarefa> Tarefas { get; set; }
        public List<Tarefa> TarefasHoje { get; set; }
        public List<Tarefa> TarefasPendentes { get; set; }
        public List<Tarefa> TarefasConcluidas { get; set; }
        public List<Tarefa> TarefasAtrasadas { get; set; }
        public int Total { get {return Tarefas.Count; } protected set {; } }
        public int TotalHoje { get { return TarefasHoje.Count; } protected set {; } }
        public int TotalPendentes { get { return TarefasPendentes.Count; } protected set {; } }
        public int TotalConcluidas { get { return TarefasConcluidas.Count; } protected set {; } }
        public int TotalAtrasadas { get { return TarefasAtrasadas.Count; } protected set {; } }

        public GeralViewModel()
        {
            Database database = new Database();

            Tarefas = database.Consultar();
            TarefasHoje = Tarefas.Where<Tarefa>(a => a.Data.Date == DateTime.Now.Date && a.DataFinalizacao == null).ToList();
            TarefasAtrasadas = Tarefas.Where<Tarefa>(a => a.Data < DateTime.Now && a.DataFinalizacao == null).ToList();
            TarefasPendentes = Tarefas.Where<Tarefa>(a => a.DataFinalizacao == null).ToList();
            TarefasConcluidas = Tarefas.Where<Tarefa>(a => a.DataFinalizacao != null).ToList();            
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
