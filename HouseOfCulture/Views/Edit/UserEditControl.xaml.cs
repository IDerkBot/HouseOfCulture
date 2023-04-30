using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Arion.Style.Controls;
using Arion.Style.Controls.Enums;
using HouseOfCulture.Models;
using HouseOfCulture.Models.Entities;

namespace HouseOfCulture.Views.Edit
{
    public partial class UserEditControl
    {
        private readonly User _currentUser;
        public UserEditControl(User selectedUser = null)
        {
            InitializeComponent();
            // Указываем либо пользователя которого мы выбрали (если мы редактируем),
            // либо создаем нового (если мы нажали добавить)
            _currentUser = selectedUser ?? new User();
            // Добавляем пользователя в контекст страницы что бы он привязался к нашим Биндингам
            DataContext = _currentUser;
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            // Проверяем на пустоту логин
            if (string.IsNullOrWhiteSpace(_currentUser.Login))
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не ввели логин", ModalDialogButtons.Ok, ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }
            // Проверяем на пустоту пароль
            if (string.IsNullOrWhiteSpace(_currentUser.Password))
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не ввели пароль", ModalDialogButtons.Ok, ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }
            // Проверяем выбор роли
            if (_currentUser.Role == null)
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не выбрали роль", ModalDialogButtons.Ok, ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }
            
            // Проверяем, новый это пользователь или нет
            if (_currentUser.Id == 0)
                // Если новый, то добавляем его
                HouseOfCultureEntities.GetContext().Users.Add(_currentUser);
            // Сохраняем изменения
            HouseOfCultureEntities.GetContext().SaveChanges();
            // Возвращаемся на прошлую страницу
            Navigation.Back();
        }

        private void UserEditControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            // Загружаем роли в выпадающий список
            CbRoles.ItemsSource = HouseOfCultureEntities.GetContext().Roles.ToList();
        }
    }
}