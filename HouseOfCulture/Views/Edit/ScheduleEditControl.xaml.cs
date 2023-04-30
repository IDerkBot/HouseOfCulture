using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Arion.Style.Controls;
using Arion.Style.Controls.Enums;
using HouseOfCulture.Models;
using HouseOfCulture.Models.Entities;

namespace HouseOfCulture.Views.Edit
{
    public partial class ScheduleEditControl
    {
        private readonly Schedule _currentSchedule;
        public ScheduleEditControl(Schedule selectedSchedule = null)
        {
            InitializeComponent();
            _currentSchedule = selectedSchedule ?? new Schedule();
            if (_currentSchedule.Date < new DateTime(1900, 1, 1)) _currentSchedule.Date = DateTime.Now;
            DataContext = _currentSchedule;
        }
        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            // Проверяем выбор роли
            if (_currentSchedule.Group == null)
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не выбрали группу", ModalDialogButtons.Ok, ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }
            
            // Проверяем, новый это пользователь или нет
            if (_currentSchedule.Id == 0)
                // Если новый, то добавляем его
                HouseOfCultureEntities.GetContext().Schedules.Add(_currentSchedule);
            // Сохраняем изменения
            HouseOfCultureEntities.GetContext().SaveChanges();
            // Возвращаемся на прошлую страницу
            Navigation.Back();
        }

        private List<string> _listTime;

        private void ScheduleEditControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            CbGroups.ItemsSource = HouseOfCultureEntities.GetContext().Groups.ToList();
            _listTime = new List<string>();
            for (var i = 8; i < 22; i+=2)
            {
                _listTime.Add($"{i}".PadLeft(2, '0') + ":00");
            }

            CbRoles.ItemsSource = _listTime;

            if (_currentSchedule.Id != 0)
            {
                CbRoles.SelectedIndex = _listTime.FindIndex(x => x.Contains(_currentSchedule.Date.Hour.ToString()));
            }
        }
    }
}