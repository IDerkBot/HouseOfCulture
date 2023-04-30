using System.Linq;
using System.Windows;
using Arion.Style.Controls;
using Arion.Style.Controls.Enums;
using HouseOfCulture.Models;
using HouseOfCulture.Models.Entities;

namespace HouseOfCulture.Views
{
    public partial class AuthorizationPage
    {
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void BtnEnter_OnClick(object sender, RoutedEventArgs e)
        {
            var login = TbLogin.Text;
            var password = PbPassword.Password;

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

            var haveUser = HouseOfCultureEntities.GetContext().Users.Any(x => x.Login == login);

            if (haveUser)
            {
                var user = HouseOfCultureEntities.GetContext().Users.First(x => x.Login == login);
                if (user.Password != password)
                {
                    ModalDialog.Show("Не верные данные", "Пароль не верный!", ModalDialogButtons.Ok, ModalDialogType.Warning);
                    return;
                }
                Data.User = user;
                Navigation.Go(new MenuPage());
            }
            else
            {
                ModalDialog.Show("Не верные данные", "Такого пользователя не существует!", ModalDialogButtons.Ok, ModalDialogType.Warning);
            }
        }

        private void BtnRegistration_OnClick(object sender, RoutedEventArgs e)
        {
            Navigation.Go(new RegistrationControl());
        }
    }
}