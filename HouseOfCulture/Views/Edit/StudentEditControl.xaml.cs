using System;
using System.Linq;
using System.Windows;
using Arion.Style.Controls;
using Arion.Style.Controls.Enums;
using HouseOfCulture.Models;
using HouseOfCulture.Models.Entities;

namespace HouseOfCulture.Views.Edit
{
    public partial class StudentEditControl
    {
        private readonly Student _currentStudent;

        public StudentEditControl(Student selectedStudent = null)
        {
            InitializeComponent();
            _currentStudent = selectedStudent ?? new Student();
            if (_currentStudent.DateBirth < new DateTime(1900, 1, 1)) _currentStudent.DateBirth = DateTime.Now;
            DataContext = _currentStudent;
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_currentStudent.Surname))
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не ввели фамилию", ModalDialogButtons.Ok,
                    ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }

            if (string.IsNullOrWhiteSpace(_currentStudent.Firstname))
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не ввели имя", ModalDialogButtons.Ok, ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }

            if (string.IsNullOrWhiteSpace(_currentStudent.Patronymic))
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не ввели отчество", ModalDialogButtons.Ok,
                    ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }

            if (_currentStudent.Id == 0)
                HouseOfCultureEntities.GetContext().Students.Add(_currentStudent);

            HouseOfCultureEntities.GetContext().SaveChanges();
            Navigation.Back();
        }

        private void File_OnDrop(object sender, DragEventArgs e)
        {
            var filePath = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (filePath == null) return;
            var source = ImageManager.CroppedToBitmapImage(filePath[0]);
            _currentStudent.Photo = ImageManager.CroppedToBytes(source);
            DataContext = null;
            DataContext = _currentStudent;
        }

        private void StudentEditControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            var list = HouseOfCultureEntities.GetContext().Users
                .Where(x => x.Students.Count == 0 && x.Leaderships.Count == 0).ToList();
            if (_currentStudent.User != null) list.Add(_currentStudent.User);

            CbRoles.ItemsSource = list;
        }
    }
}