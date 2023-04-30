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
    public partial class GroupsTableControl
    {
        public GroupsTableControl()
        {
            InitializeComponent();
        }

        private void GroupsTableControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (Data.User.Role.Name == Data.Student)
            {
                ColumnEdit.Visibility = Visibility.Collapsed;
                BtnAdd.Visibility = Visibility.Collapsed;
                BtnDelete.Visibility = Visibility.Collapsed;
            }
            else if (Data.User.Role.Name == Data.Leadership)
            {
                ColumnEdit.Visibility = Visibility.Collapsed;
                ColumnRequest.Visibility = Visibility.Collapsed;
                BtnAdd.Visibility = Visibility.Collapsed;
                BtnDelete.Visibility = Visibility.Collapsed;
            }
            else if (Data.User.Role.Name == Data.Admin) ColumnRequest.Visibility = Visibility.Collapsed;
            
            DgData.ItemsSource = HouseOfCultureEntities.GetContext().Groups.ToList();
        }

        private void BtnEdit_OnClick(object sender, RoutedEventArgs e)
        {
            // Проверяем точно ли мы нажали на кнопку
            if (!(sender is Button btn)) return;
            // Проверяем точно ли у нашей кнопки в контексте пользователь
            if (!(btn.DataContext is Group group)) return;

            // Перемещаемся на страницу редактирования
            Navigation.Go(new GroupEditControl(group));
        }

        private void BtnAdd_OnClick(object sender, RoutedEventArgs e)
        {
            // Перемещаемся на страницу редактирования
            Navigation.Go(new GroupEditControl());
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            // Получаем выбранные элементы
            var selectedItems = DgData.SelectedItems.Cast<Group>().ToList();

            // Спрашиваем точно ли хотят удалить элементы и если не нажмут да, то выходим из метода
            if (ModalDialog.Show("Удаление", $"Вы действительно хотите удалить {selectedItems.Count} элементов",
                    ModalDialogButtons.YesNo, ModalDialogType.Warning) != ModalDialogResult.Yes) return;

            // Если ответили да
            try
            {
                // Удаляем элементы из таблицы
                HouseOfCultureEntities.GetContext().Groups.RemoveRange(selectedItems);
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

        private void BtnRequest_OnClick(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button btn)) return;
            if (!(btn.DataContext is Group group)) return;
            // Проверяем является наш пользователь студентом
            if (Data.User.Students != null)
            {
                // Проверяем есть ли у нашего пользователя другие заявки
                if (HouseOfCultureEntities.GetContext().Requests
                    .Any(x => x.IdUser == Data.User.Id && x.Group.Id == group.Id))
                {
                    ModalDialog.Show("Запись в группу", "Вы уже отправляли заявку на запись в эту группу",
                        ModalDialogButtons.Ok, ModalDialogType.Warning);
                    return;
                }
                // Создаем новую заявку
                var request = new Request() { User = Data.User, Group = group, IdType = 1 };
                // Добавляем новую заявку
                HouseOfCultureEntities.GetContext().Requests.Add(request);
                // Сохраняем
                HouseOfCultureEntities.GetContext().SaveChanges();

                ModalDialog.Show("Запись в группу", "Заявка на вступлению группу отправлена и ожидает рассмотрения",
                    ModalDialogButtons.Ok, ModalDialogType.Success);
            }
        }
        
        private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var search = TbSearch.Text.ToLower();
            var list = HouseOfCultureEntities.GetContext().Groups.Where(data =>
                data.Name.ToLower().Contains(search) ||
                data.Leaderships.Any(x => 
                    x.Firstname.ToLower().Contains(search) ||
                    x.Surname.ToLower().Contains(search) ||
                    x.Patronymic.ToLower().Contains(search))).ToList();
            DgData.ItemsSource = list;
        }
    }
}