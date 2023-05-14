using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Arion.Style.Controls;
using Arion.Style.Controls.Enums;
using HouseOfCulture.Models;
using HouseOfCulture.Models.Entities;

namespace HouseOfCulture.Views.Edit
{
    public partial class EventEditControl
    {
        private readonly Event _currentEvent;
        public EventEditControl(Event selectedEvent = null)
        {
            InitializeComponent();
            _currentEvent = selectedEvent ?? new Event();
            if(_currentEvent.Date < new DateTime(1900, 1, 1)) _currentEvent.Date = DateTime.Now;
            DataContext = _currentEvent;
        }
        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_currentEvent.Name))
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не ввели наименование", ModalDialogButtons.Ok, ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }
    
            if (string.IsNullOrWhiteSpace(_currentEvent.Location))
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не ввели местоположение", ModalDialogButtons.Ok, ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }
            
            foreach (var group in LvData.SelectedItems.Cast<Group>())
            {
                if(_currentEvent.Groups.Count > 0)
                    if(_currentEvent.Groups.Any(x => x == group)) continue;
                _currentEvent.Groups.Add(group);
            }

            if (_currentEvent.Id == 0)
                HouseOfCultureEntities.GetContext().Events.Add(_currentEvent);

            HouseOfCultureEntities.GetContext().SaveChanges();
            Navigation.Back();
        }

        private void EventEditControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            LvData.ItemsSource = HouseOfCultureEntities.GetContext().Groups.ToList();
        }
    }
}