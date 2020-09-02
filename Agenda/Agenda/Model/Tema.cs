using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Model
{
    public class Tema
    {
        [PrimaryKey]
        public Guid Id { get; protected set; }
        public string Nome { get; set; }
        public string FundoTitulo { get; set; }
        public string TextoTitulo { get; set; }
        public string FundoApp { get; set; }
        public string TextoApp { get; set; }
        public Tema()
        {
            Id = new Guid();            
        }
    }
}
