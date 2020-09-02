using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Plugin.Calendar.Models;
using Agenda.Model;
using Agenda.Banco;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections;

namespace Agenda.ViewModel
{
    class CalendarioViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
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
        public EventCollection Events { get; set; }
        private void CarregarEventos()
        {
            Database database = new Database();

            List<Tarefa> Lista = database.Consultar();
            Events = new EventCollection();
            Lista.OrderBy(a => a.Data);

            DateTime dataAnterior = DateTime.MinValue;

            foreach (Tarefa tarefa in Lista)
            {
                if (dataAnterior.Date == tarefa.Data.Date)
                {
                    continue;
                }
                else
                {
                    ICollection Colecao = Lista.Where<Tarefa>(a => a.Data.Date.Equals(tarefa.Data.Date)).ToList();
                    Events.Add(tarefa.Data.Date, Colecao);

                    dataAnterior = tarefa.Data;
                }
            }
        }
        public CalendarioViewModel()
        {
            CarregarEventos();
        }
    }
}
