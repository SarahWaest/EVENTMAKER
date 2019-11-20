using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMaker.Converter;
using EventMaker.Model;
using EventMaker.Viewmodel;

namespace EventMaker.Handler
{
    public class EventHandler
    {
        private EventViewModel _EventViewModel;
        private List<Event> _allEvents;

        public EventHandler(EventViewModel eventvm)
        {
            _EventViewModel = eventvm;
            this._EventViewModel = eventvm;
        }

        public void CreateEvent()
        {
            _EventViewModel.EventCatalog.Add(new Event(_EventViewModel.ID,_EventViewModel.Name,_EventViewModel.Description, _EventViewModel.Place, DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(_EventViewModel.Date,_EventViewModel.Time)));
        }

        public void DeleteEvent()
        {
                 _EventViewModel.EventCatalog.Remove(EventViewModel.SelectedEvent);

        }

        public void SetSelectedEvent(object id)
        {
            int Id = Convert.ToInt16(id);

            foreach (Event ev in _allEvents)
            {
                if (ev.ID == Id)
                {
                    EventViewModel.SelectedEvent = ev;
                }
            }
        }

    }
}
