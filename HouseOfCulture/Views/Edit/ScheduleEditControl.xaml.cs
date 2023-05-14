using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                ModalDialog.Show("Ошибка данных", "Вы не выбрали группу", ModalDialogButtons.Ok,
                    ModalDialogType.Warning);
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
            UpdateTimes();

            if (_currentSchedule.Id != 0)
            {
                CbRoles.SelectedIndex = _listTime.FindIndex(x => x.Contains(_currentSchedule.Date.Hour.ToString()));
            }
        }

        private void Dp_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTimes();
        }

        private void UpdateTimes()
        {
            AddTimes();
            DeleteAllUsingTimes();
            CbRoles.ItemsSource = _listTime;
        }

        private void DeleteAllUsingTimes()
        {
            var selectedDate = Dp.SelectedDate ?? DateTime.Now;
            var list = HouseOfCultureEntities.GetContext().Schedules.Where(x =>
                x.Date.Day == selectedDate.Day && x.Date.Month == selectedDate.Month &&
                x.Date.Year == selectedDate.Year).ToList();

            if (list.Count <= 0) return;
            // Удалить все используемые временные метки
            foreach (var schedule in list)
            {
                if(schedule.Id == _currentSchedule.Id) continue;
                _listTime.Remove($"{schedule.Date.Hour.ToString().PadLeft(2, '0')}:00");
            }
        }

        private void AddTimes()
        {
            _listTime = new List<string>();
            for (var i = 8; i < 22; i += 2) _listTime.Add($"{i}".PadLeft(2, '0') + ":00");
        }

        private void CbGroups_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // var selectedGroup = CbGroups.SelectedItem as Group;
            // var leadership = selectedGroup.Leaderships.ToList();
            // var listSchedules = HouseOfCultureEntities.GetContext().Schedules.ToList();
            // if (listSchedules.Any(x =>
            //         x.Date == _currentSchedule.Date || x.Group.Leaderships.Any(y => leadership.Contains(y))))
            // {
            //     Debug.WriteLine(string.Join("\n", listSchedules.Where(x =>
            //             x.Date == _currentSchedule.Date || x.Group.Leaderships.Any(y => leadership.Contains(y)))
            //         .Select(x => x.Date)));
            // }
        }
    }
}