using Agenda.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.ViewModel
{
    class ListaGeralViewModel
    {
        public List<Tarefa> Lista { get; set; }
        public string Titulo { get; set; }
        public ListaGeralViewModel(List<Tarefa> tarefas, string titulo)
        {
            Lista = tarefas;
            Titulo = titulo;
        }
    }
}
