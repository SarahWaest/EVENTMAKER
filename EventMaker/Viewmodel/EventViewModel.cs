using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EventMaker.Common;
using EventMaker.Handler;
using EventMaker.Model;
using EventHandler = System.EventHandler;

namespace EventMaker.Viewmodel
{
    public class EventViewModel
    {
        private ObservableCollection<Event> _eventCatalogSingleton;
        private int _id;
        private string _name;
        private string _description;
        private string _place;
        private DateTimeOffset _dateTime;
        private TimeSpan _time;
        private Handler.EventHandler _eventHandler;
        private static Event _selectedEvent;
        private ICommand _createEventCommand;
        private ICommand _selectedEventCommand;
        private ICommand _deleteEventCommand;

        public EventViewModel()
        {
            _eventCatalogSingleton = EventCatalogSingleton.Instance.Events;
            _eventHandler = new Handler.EventHandler(this);

            DateTime dt = System.DateTime.Now;
            Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, 0, new TimeSpan());
            Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            EventCreateCommand = new RelayCommand(_eventHandler.CreateEvent);
        }

        public ObservableCollection<Event> EventCatalog
        {
            get { return _eventCatalogSingleton; }
        }

        public static Event SelectedEvent
        {
            set { _selectedEvent = value; }
            get { return _selectedEvent; }
        }

        public int ID
        {
            get { return _id; }
        }

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }

        public string Place
        {
            set { _place = value; }
            get { return _place; }
        }

        public DateTimeOffset Date
        {
            set { _dateTime = value; }
            get { return _dateTime; }
        }

        public TimeSpan Time
        {
            set { _time = value; }
            get { return _time; }
        }

        public Handler.EventHandler EventH
        {
            set { _eventHandler = value; }
            get { return _eventHandler; }
        }

        public ICommand EventCreateCommand { set; get; }

        public ICommand SelectedEventCommand
        {
            get
            {
                return _selectedEventCommand ?? (_selectedEventCommand =
                           new RelayArgCommand<Event>(ev => _eventHandler.SetSelectedEvent(ev)));
            }
            set { _selectedEventCommand = value; }
        }

        public ICommand DeleteEventCommand
        {
            set { _deleteEventCommand = value; }
            get {return _deleteEventCommand ?? (_deleteEventCommand = new RelayCommand(_eventHandler.DeleteEvent)); }

        }

    }
}
