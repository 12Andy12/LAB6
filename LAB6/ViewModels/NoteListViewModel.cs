using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using LAB6.Models;
using ReactiveUI;
using System.Reactive;

namespace LAB6.ViewModels
{
    public class NoteListViewModel : ViewModelBase
    {
        DateTimeOffset? currentDate;

        public NoteListViewModel() // DateTimeOffset?
        {
            CurrentDate = DateTime.Today;
            NoteList = new ObservableCollection<StateData>(notes[currentDate]);
        }

        public DateTimeOffset? CurrentDate
        {
            set
            {
                this.RaiseAndSetIfChanged(ref currentDate, value);
                notes.TryAdd(CurrentDate, new List<StateData> { });
                NoteList = new ObservableCollection<StateData>(notes[currentDate]);
            }
            get => currentDate;
        }

        ObservableCollection<StateData> noteList;

        Dictionary<DateTimeOffset?, List<StateData>> notes = new Dictionary<DateTimeOffset?, List<StateData>>() { { DateTime.Today, new List<StateData>() } };

        public ObservableCollection<StateData> NoteList
        {
            get => noteList;
            set
            {
                this.RaiseAndSetIfChanged(ref noteList, value);
            }
        }

        public Dictionary<DateTimeOffset?, List<StateData>> Notes
        {
            get => notes;
        }
    }
}
