using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Model;

namespace EventMaker.Viewmodel
{
    class EventViewModel
    {
        private EventCatalogSingleton _eventCatalogSingleton;
        private int _id;
        private string _name;
        private string _description;
        private string _place;
        private DateTimeOffset _dateTime;
        private TimeSpan _time;

        public EventViewModel()
        {
            _eventCatalogSingleton = EventCatalogSingleton.Instance;

            DateTime dt = System.DateTime.Now;
            Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day,dt.Hour,dt.Minute,0 ,0, new TimeSpan());
            Time = new TimeSpan(dt.Hour, dt.Minute, dt.Second);
        }

        public ObservableCollection<Event> EventCatalog
        {
            get { return _eventCatalogSingleton.Events; }
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
            set { _dateTime = value;}
            get { return _dateTime; }
        }

        public TimeSpan Time
        {
            set { _time = value; }
            get { return _time; }
        }

    }
}
