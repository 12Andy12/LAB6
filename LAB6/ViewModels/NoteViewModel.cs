using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using LAB6.Models;

namespace LAB6.ViewModels
{
    public class NoteViewModel : ViewModelBase
    {
        string header;
        string text;
        public NoteViewModel(StateData note)
        {
            var recordPossible = this.WhenAnyValue(
                    record => record.Header,
                    record => !string.IsNullOrWhiteSpace(record)
                );

            Header = note.header;
            Text= note.text;
            AddCommand = ReactiveCommand.Create(() => new StateData(Header, Text), recordPossible);
            CancelCommand = ReactiveCommand.Create(() => new StateData("", ""));
        }

        public ReactiveCommand<Unit, StateData> AddCommand { get; }
        public ReactiveCommand<Unit, StateData> CancelCommand { get; }
        public string Header
        {
            set => this.RaiseAndSetIfChanged(ref header, value);
            get => header;
        }

        public string Text
        {
            set => this.RaiseAndSetIfChanged(ref text, value);
            get => text;
        }
    }
}
