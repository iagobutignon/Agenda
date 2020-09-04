using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Agenda.Model;
using Xamarin.Forms;

namespace Agenda.Banco
{
    public class Database
    {
        private SQLiteConnection _conexao;
        public Database()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminho = dep.ObterCaminho("database.sqlite");
            
            _conexao = new SQLiteConnection(caminho);
            _conexao.CreateTable<Tarefa>();
        }
        public void Cadastrar(Tarefa tarefa)
        {
            _conexao.Insert(tarefa);
        }
        public void Atualizar(Tarefa tarefa)
        {
            _conexao.Update(tarefa);
        }
        public void Excluir(Tarefa tarefa)
        {
            _conexao.Delete(tarefa);
        }
        public Tarefa ObterPorId(Guid id)
        {
            return _conexao.Table<Tarefa>().Where(a => a.Id == id).FirstOrDefault();
        }
        public List<Tarefa> Pesquisar(string palavra)
        {
            return _conexao.Table<Tarefa>().Where(a => a.Nome.Contains(palavra)).ToList();
        }
        public List<Tarefa> Consultar()
        {
            return _conexao.Table<Tarefa>().ToList();
        }
    }
}
