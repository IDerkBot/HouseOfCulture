using System.Linq;
using System.Windows;
using Arion.Style.Controls;
using Arion.Style.Controls.Enums;
using HouseOfCulture.Models;
using HouseOfCulture.Models.Entities;

namespace HouseOfCulture.Views.Edit
{
    public partial class RequestEditControl
    {
        private readonly Request _currentRequest;
        public RequestEditControl(Request selectedRequest = null)
        {
            InitializeComponent();
            _currentRequest = selectedRequest ?? new Request();
            DataContext = _currentRequest;
        }
        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            // Проверяем на пустоту логин
            if (_currentRequest.User == null)
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не ввели логин", ModalDialogButtons.Ok, ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }
            // Проверяем на пустоту пароль
            if (_currentRequest.Group == null)
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не ввели пароль", ModalDialogButtons.Ok, ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }
            // Проверяем выбор роли
            if (_currentRequest.TypeRequest == null)
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не выбрали роль", ModalDialogButtons.Ok, ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }
            
            // Проверяем, новый это пользователь или нет
            if (_currentRequest.Id == 0)
                // Если новый, то добавляем его
                HouseOfCultureEntities.GetContext().Requests.Add(_currentRequest);

            if (_currentRequest.TypeRequest.Name == "Одобрена")
            {
                if(_currentRequest.User.Students.Count == 1)
                    _currentRequest.Group.Students.Add(_currentRequest.User.Students.First());
            }
            // Сохраняем изменения
            HouseOfCultureEntities.GetContext().SaveChanges();
            // Возвращаемся на прошлую страницу
            Navigation.Back();
        }

        private void RequestEditControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            CbUsers.ItemsSource = HouseOfCultureEntities.GetContext().Users.Where(x => x.Leaderships.Count == 0).ToList();
            CbGroups.ItemsSource = HouseOfCultureEntities.GetContext().Groups.ToList();
            CbTypeRequests.ItemsSource = HouseOfCultureEntities.GetContext().TypeRequests.ToList();
        }
    }
}