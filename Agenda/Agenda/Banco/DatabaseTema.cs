using System;
using System.Collections.Generic;
using System.Text;
using Agenda.Model;
using SQLite;
using Xamarin.Forms;

namespace Agenda.Banco
{
    class DatabaseTema
    {
        private SQLiteConnection _conexao;        
        public DatabaseTema()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");

            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Tema>();
        }
        public void Salvar(Tema tema)
        {
            _conexao.Insert(tema);
        }
        public void Deletar(Tema tema)
        {
            _conexao.Delete(tema);
        }
        public List<Tema> Carregar()
        {
            return _conexao.Table<Tema>().ToList();
        }

    }
}
