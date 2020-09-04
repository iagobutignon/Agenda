using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using SQLite;

namespace Agenda.Model
{
    [Table("Tarefas")]
    public class Tarefa
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public byte Prioridade { get; set; }
        public string Imagem { get { return "p" + Prioridade.ToString() + ".jpg"; } protected set { ; } }
        public string Hora { get { return Data.TimeOfDay.ToString(); } protected set {; } } 
        public Tarefa()
        {
            Id = Guid.NewGuid();
            DataAbertura = DateTime.Now;
        }
    }
}
