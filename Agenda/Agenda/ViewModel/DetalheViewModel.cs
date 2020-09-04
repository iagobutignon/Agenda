using Agenda.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.ViewModel
{
    class DetalheViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public byte Prioridade { get; set; }
        public string Imagem { get; set; }
        public string Hora { get; set; }
        public bool Finalizado { get { return DataFinalizacao != null ; } }

        public DetalheViewModel(Tarefa tarefa)
        {
            Id = tarefa.Id;
            Nome = tarefa.Nome;
            Descricao = tarefa.Descricao;
            Data = tarefa.Data;
            DataAbertura = tarefa.DataAbertura;
            DataFinalizacao = tarefa.DataFinalizacao;
            Prioridade = tarefa.Prioridade;
            Imagem = tarefa.Imagem;
        }
    }
}
