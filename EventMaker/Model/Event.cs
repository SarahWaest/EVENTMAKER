using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Documents;

namespace EventMaker.Model
{
    public class Event
    {
        private int _id;
        private string _name;
        private string _description;
        private string _place;
        private DateTime _datetime;

        public Event(int id, string name, string description, string place, DateTime datetime)
        {
            _place = place;
            _name = name;
            _id = id;
            _description = description;
            _datetime = datetime;
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

        public DateTime Datetime
        {
            set { _datetime = value; }
            get { return _datetime; }
        }

        public string ToString()
        {
            return ID + "" + Name;
        }
}
}
