using System.Collections.Generic;
using System.Linq;
using HouseOfCulture.Models.Entities;
using HouseOfCulture.ViewModels.Base;

namespace HouseOfCulture.ViewModels
{
    public class EventsTableViewModel : BaseViewModel
    {
        private List<Event> _events;

        public List<Event> Events
        {
            get => _events;
            set => SetField(ref _events, value);
        }

        public EventsTableViewModel()
        {
            Events = HouseOfCultureEntities.GetContext().Events.ToList();
        }
    }
}