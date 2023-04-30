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
    public partial class UsersTableControl
    {
        public UsersTableControl()
        {
            InitializeComponent();
        }

        private void UsersTableControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            DgData.ItemsSource = HouseOfCultureEntities.GetContext().Users.ToList();
        }

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
            // Проверяем точно ли мы нажали на кнопку
            if(!(sender is Button btn)) return;
            // Проверяем точно ли у нашей кнопки в контексте пользователь
            if(!(btn.DataContext is User user)) return;

            // Перемещаемся на страницу редактирования
            Navigation.Go(new UserEditControl(user));
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            // Перемещаемся на страницу редактирования
            Navigation.Go(new UserEditControl());
        }
        
        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            // Получаем выбранные элементы
            var selectedItems = DgData.SelectedItems.Cast<User>().ToList();
            
            // Спрашиваем точно ли хотят удалить элементы и если не нажмут да, то выходим из метода
            if(ModalDialog.Show("Удаление", $"Вы действительно хотите удалить {selectedItems.Count} элементов", ModalDialogButtons.YesNo, ModalDialogType.Warning) != ModalDialogResult.Yes) return;

            // Если ответили да
            try
            {
                // Удаляем элементы из таблицы
                HouseOfCultureEntities.GetContext().Users.RemoveRange(selectedItems);
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
            var list = HouseOfCultureEntities.GetContext().Users.Where(data =>
                data.Login.ToLower().Contains(search) ||
                data.Role.Name.ToLower().Contains(search)).ToList();
            DgData.ItemsSource = list;
        }
    }
}