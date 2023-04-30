using System;
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
    public partial class RequestsTableControl
    {
        public RequestsTableControl()
        {
            InitializeComponent();
        }

        private void RequestsTableControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (Data.User.Role.Name == Data.Student)
            {
                ColumnEdit.Visibility = Visibility.Collapsed;
                BtnAdd.Visibility = Visibility.Collapsed;
                BtnDelete.Visibility = Visibility.Collapsed;
            }
            else if (Data.User.Role.Name == Data.Leadership)
            {
                // ColumnEdit.Visibility = Visibility.Collapsed;
                BtnAdd.Visibility = Visibility.Collapsed;
                BtnDelete.Visibility = Visibility.Collapsed;
            }

            DgData.ItemsSource = Data.User.Role.Name == Data.Student ?
                HouseOfCultureEntities.GetContext().Requests.Where(x => x.User.Id == Data.User.Id).ToList() :
                HouseOfCultureEntities.GetContext().Requests.ToList();
        }
        
        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
            // Проверяем точно ли мы нажали на кнопку
            if(!(sender is Button btn)) return;
            // Проверяем точно ли у нашей кнопки в контексте пользователь
            if(!(btn.DataContext is Request request)) return;

            // Перемещаемся на страницу редактирования
            Navigation.Go(new RequestEditControl(request));
        }
        
        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            // Перемещаемся на страницу редактирования
            Navigation.Go(new RequestEditControl());
        }
        
        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            // Получаем выбранные элементы
            var selectedItems = DgData.SelectedItems.Cast<Request>().ToList();
            
            // Спрашиваем точно ли хотят удалить элементы и если не нажмут да, то выходим из метода
            if(ModalDialog.Show("Удаление", $"Вы действительно хотите удалить {selectedItems.Count} элементов", ModalDialogButtons.YesNo, ModalDialogType.Warning) != ModalDialogResult.Yes) return;

            // Если ответили да
            try
            {
                // Удаляем элементы из таблицы
                HouseOfCultureEntities.GetContext().Requests.RemoveRange(selectedItems);
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
            var list = HouseOfCultureEntities.GetContext().Requests.Where(data =>
                data.User.Login.ToLower().Contains(search) ||
                data.Group.Name.ToLower().Contains(search) ||
                data.TypeRequest.Name.ToLower().Contains(search)).ToList();
            DgData.ItemsSource = list;
        }
    }
}