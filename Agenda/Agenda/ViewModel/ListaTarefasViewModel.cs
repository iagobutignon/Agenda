using Agenda.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.ViewModel
{
    class ListaTarefasViewModel
    {
        public List<Tarefa> Lista { get; set; }
        public string Titulo { get; set; }
        public ListaTarefasViewModel(List<Tarefa> tarefas, string titulo)
        {
            Lista = tarefas;
            Titulo = titulo;
        }
    }
}
