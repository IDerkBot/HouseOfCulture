using System.Linq;
using System.Windows;
using Arion.Style.Controls;
using Arion.Style.Controls.Enums;
using HouseOfCulture.Models;
using HouseOfCulture.Models.Entities;

namespace HouseOfCulture.Views
{
    // TODO Для фото сделать загрузку по выбору из папки
    public partial class RegistrationControl
    {
        public RegistrationControl()
        {
            InitializeComponent();
        }

        private void BtnRegistration_OnClick(object sender, RoutedEventArgs e)
        {
            var login = TbLogin.Text;
            var password = PbPassword.Password;
            var confirmPassword = PbConfirmPassword.Password;

            if (string.IsNullOrWhiteSpace(login))
            {
                ModalDialog.Show("Не верные данные", "Вы не ввели логин!", ModalDialogButtons.Ok, ModalDialogType.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                ModalDialog.Show("Не верные данные", "Вы не ввели пароль!", ModalDialogButtons.Ok, ModalDialogType.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                ModalDialog.Show("Не верные данные", "Вы не ввели пароль повторно!", ModalDialogButtons.Ok, ModalDialogType.Warning);
                return;
            }

            var canCreate = !HouseOfCultureEntities.GetContext().Users.Any(x => x.Login == login);

            if (canCreate)
            {
                if (password != confirmPassword)
                {
                    ModalDialog.Show("Не верные данные", "Пароли не совпадают!", ModalDialogButtons.Ok, ModalDialogType.Warning);
                    return;
                }

                var user = new User { Login = login, Password = password, IdRole = 1 };
                HouseOfCultureEntities.GetContext().Users.Add(user);
                HouseOfCultureEntities.GetContext().SaveChanges();
                ModalDialog.Show("Успешно", "Вы успешно зарегистрировались!", ModalDialogButtons.Ok, ModalDialogType.Success);
                Navigation.Back();
            }
            else
            {
                ModalDialog.Show("Ошибка данных", "Такой пользователь уже существует!", ModalDialogButtons.Ok, ModalDialogType.Danger);
            }
        }
    }
}