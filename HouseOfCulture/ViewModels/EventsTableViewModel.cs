using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using HouseOfCulture.Infrastructure.Commands;
using HouseOfCulture.Models;
using HouseOfCulture.Models.Entities;
using HouseOfCulture.ViewModels.Base;
using HouseOfCulture.Views.Edit;

namespace HouseOfCulture.ViewModels
{
    public class EventsTableViewModel : BaseViewModel
    {
        public ObservableCollection<Event> Events { get; }
        public Event SelectedEvent { get; set; }

        #region AddEventCommand

        public ICommand AddEventCommand { get; }
        private static bool CanAddEventCommandExecute(object p) => true;
        private static void OnAddEventCommandExecuted(object p) => Navigation.Go(new EventEditControl());

        #endregion

        #region EditEventCommand

        public ICommand EditEventCommand { get; }
        private static bool CanEditEventCommandExecute(object p) => p is Event;

        private static void OnEditEventCommandExecuted(object p)
        {
            if(p is Event selectedEvent)
                Navigation.Go(new EventEditControl(selectedEvent));
        }

        #endregion

        #region DeleteEditCommand

        public ICommand DeleteEventCommand { get; }

        private bool CanDeleteEventCommandExecute(object p) => p is Event;

        private void OnDeleteEventCommandExecuted(object p)
        {
            if (p is Event selectedEvent)
            {
                Events.Remove(selectedEvent);
            }
        }

        #endregion

        public EventsTableViewModel()
        {
            #region Commands

            AddEventCommand = new RelayCommand(OnAddEventCommandExecuted, CanAddEventCommandExecute);
            EditEventCommand = new RelayCommand(OnEditEventCommandExecuted, CanEditEventCommandExecute);
            DeleteEventCommand = new RelayCommand(OnDeleteEventCommandExecuted, CanDeleteEventCommandExecute);

            #endregion
            
            var collection = HouseOfCultureEntities.GetContext().Events.ToList();
            Events = new ObservableCollection<Event>(collection);
        }
    }
}