using Agenda.Banco;
using Agenda.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Agenda.ViewModel
{
    class AppViewModel
    {
        public string FundoTitulo { get; set; }        
        public string TextoTitulo { get; set; }
        public string FundoApp { get; set; }
        public string TextoApp { get; set; }

        public AppViewModel()
        {   
            FundoTitulo = "#073b52";
            TextoTitulo = "#ffffff";
            FundoApp = "#ffffff";
            TextoApp = "#000000";
        }
    }
}
