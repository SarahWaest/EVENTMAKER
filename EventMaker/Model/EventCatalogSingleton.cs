using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Persistency;
using EventMaker.Viewmodel;

namespace EventMaker.Model
{
    class EventCatalogSingleton
    {
        private ObservableCollection<Event> _eventcatalog;
        //private Dictionary<int, string> _eventcollection;
        private static EventCatalogSingleton _instance;

        public static EventCatalogSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EventCatalogSingleton();
                    return _instance;
                }

                return _instance;
            }
        }

       public EventCatalogSingleton()
        {
            _eventcatalog = new ObservableCollection<Event>();
            //_eventcollection = new Dictionary<int, string>();

            AddEvent(12,"Kunst","Meget sjovt", "Roskilde", datetime:new DateTime(2019,08,30));
            //AddEvent(13, "Musik", "Meget sjovt", "Roskilde", datetime: new DateTime(2019, 08, 30));
            //AddEvent(14, "IT", "Meget sjovt", "Roskilde", datetime: new DateTime(2019, 08, 30));
            //AddEvent(15, "Rollespil", "Meget sjovt", "Roskilde", datetime: new DateTime(2019, 08, 30));
        }

        public void AddEvent(int id, string name, string description, string place, DateTime datetime)
        {
            if (name != null && id != null)
            {
                Event newEvent = new Event(id, name, description, place, datetime);

                _eventcatalog.Add(newEvent);
                PersistencyService.SaveEventsAsJsonAsync(Events);
            }
            else
            {
                throw new ArgumentException("Missing ID or Name");
            }
        }

        public ObservableCollection<Event> Events
        {
            get { return _eventcatalog; }

        }

        public async void LoadEventAsync()
        {
            await PersistencyService.LoadEventsFromJsonAsync();
        }

        public void Remove (Event eet)
        {
            if (eet != null)
            {
                Events.Remove(eet);
                PersistencyService.SaveEventsAsJsonAsync(Events);
                LoadEventAsync();
            }
        }
    }
}
