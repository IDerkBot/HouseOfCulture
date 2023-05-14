using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Arion.Style.Controls;
using Arion.Style.Controls.Enums;
using HouseOfCulture.Models;
using HouseOfCulture.Models.Entities;
using HouseOfCulture.Views.Edit;

namespace HouseOfCulture.Views.Tables
{
    public partial class EventsTablesControl
    {
        public EventsTablesControl()
        {
            InitializeComponent();
        }

        private void EventsTablesControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (Data.User.Role.Name == Data.Student) ColumnEdit.Visibility = Visibility.Collapsed;
            else if (Data.User.Role.Name == Data.Leadership) ColumnEdit.Visibility = Visibility.Collapsed;
            DgData.ItemsSource = HouseOfCultureEntities.GetContext().Events.ToList();
        }
        
        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
            // Проверяем точно ли мы нажали на кнопку
            if(!(sender is Button btn)) return;
            // Проверяем точно ли у нашей кнопки в контексте пользователь
            if(!(btn.DataContext is Event @event)) return;

            // Перемещаемся на страницу редактирования
            Navigation.Go(new EventEditControl(@event));
        }
        
        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            // Перемещаемся на страницу редактирования
            Navigation.Go(new EventEditControl());
        }
        
        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            // Получаем выбранные элементы
            var selectedItems = DgData.SelectedItems.Cast<Event>().ToList();
            
            // Спрашиваем точно ли хотят удалить элементы и если не нажмут да, то выходим из метода
            if(ModalDialog.Show("Удаление", $"Вы действительно хотите удалить {selectedItems.Count} элементов", ModalDialogButtons.YesNo, ModalDialogType.Warning) != ModalDialogResult.Yes) return;

            // Если ответили да
            try
            {
                // Удаляем элементы из таблицы
                HouseOfCultureEntities.GetContext().Events.RemoveRange(selectedItems);
                // И сохраняем изменения
                HouseOfCultureEntities.GetContext().SaveChanges();
                // Уведомляем о том что удаление прошло
                ModalDialog.Show("Удаление", "Данные успешно удалены", ModalDialogButtons.Ok, ModalDialogType.Success);
            }
            catch (Exception)
            {
                // Если у нас возникла ошибка при удалении, то говорим об этом
                ModalDialog.Show("Удаление", "Произошла ошибка!", ModalDialogButtons.Ok, ModalDialogType.Warning);
            }
        }

        private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var search = TbSearch.Text.ToLower();
            var list = new List<Event>();
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var @event in HouseOfCultureEntities.GetContext().Events)
            {
                if(@event.Name.ToLower().Contains(search) ||
                   @event.Location.ToLower().Contains(search) ||
                   @event.Date.ToString("dd.MM.yyyy HH:mm").Contains(search)||
                   @event.Groups.Any(t => t.Name.ToLower().Contains(search)))
                   list.Add(@event);
            }
            DgData.ItemsSource = list;
        }

        private void BtnView_OnClick(object sender, RoutedEventArgs e)
        {
            var selectedEvent = ((sender as Button)?.DataContext as Event);
            new EventInfo(selectedEvent).Show();
        }
    }
}