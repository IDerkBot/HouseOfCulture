using System.Windows;
using HouseOfCulture.Models.Entities;

namespace HouseOfCulture.Views
{
    public partial class EventInfo : Window
    {
        public EventInfo(Event selectedEvent)
        {
            InitializeComponent();
            DataContext = selectedEvent;
        }
    }
}