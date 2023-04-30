using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Arion.Style.Controls;
using Arion.Style.Controls.Enums;
using HouseOfCulture.Models;
using HouseOfCulture.Models.Entities;

namespace HouseOfCulture.Views.Edit
{
    public partial class LeadershipEditControl : UserControl
    {
        private readonly Leadership _currentLeadership;
        public LeadershipEditControl(Leadership selectedLeadership = null)
        {
            InitializeComponent();
            _currentLeadership = selectedLeadership ?? new Leadership();
            if (_currentLeadership.DateBirth < new DateTime(1900, 1, 1)) _currentLeadership.DateBirth = DateTime.Now;
            DataContext = _currentLeadership;
        }
        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_currentLeadership.Surname))
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не ввели фамилию", ModalDialogButtons.Ok,
                    ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }

            if (string.IsNullOrWhiteSpace(_currentLeadership.Firstname))
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не ввели имя", ModalDialogButtons.Ok, ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }

            if (string.IsNullOrWhiteSpace(_currentLeadership.Patronymic))
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не ввели отчество", ModalDialogButtons.Ok,
                    ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }

            if (_currentLeadership.Id == 0)
                HouseOfCultureEntities.GetContext().Leaderships.Add(_currentLeadership);

            HouseOfCultureEntities.GetContext().SaveChanges();
            Navigation.Back();
        }
        
        private void File_OnDrop(object sender, DragEventArgs e)
        {
            var filePath = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (filePath == null) return;
            var source = ImageManager.CroppedToBitmapImage(filePath[0]);
            _currentLeadership.Photo = ImageManager.CroppedToBytes(source);
            DataContext = null;
            DataContext = _currentLeadership;
        }

        private void LeadershipEditControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            var list = HouseOfCultureEntities.GetContext().Users
                .Where(x => x.Students.Count == 0 && x.Leaderships.Count == 0).ToList();
            if (_currentLeadership.User != null) list.Add(_currentLeadership.User);

            CbRoles.ItemsSource = list;
        }
    }
}