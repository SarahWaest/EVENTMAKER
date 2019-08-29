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
    class EventHandler
    {
        private EventViewModel _EventViewModel;

        public EventHandler(EventViewModel eventvm)
        {
            _EventViewModel = eventvm;
        }

        public void CreateEvent()
        {
            _EventViewModel.EventCatalog.Add(new Event(_EventViewModel.ID,_EventViewModel.Name,_EventViewModel.Description, _EventViewModel.Place, DateTimeConverter.DateTimeOffsetAndTimeSetToDateTime(_EventViewModel.Date,_EventViewModel.Time)));
        }

    }
}
