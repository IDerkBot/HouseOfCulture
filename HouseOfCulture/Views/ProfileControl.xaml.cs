using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Arion.Style.Controls;
using Arion.Style.Controls.Enums;
using HouseOfCulture.Models;
using HouseOfCulture.Models.Entities;

namespace HouseOfCulture.Views
{
    public partial class ProfileControl : UserControl
    {
        private readonly Student _currentStudent;
        private readonly Leadership _currentLeadership;
        public ProfileControl(Student student)
        {
            InitializeComponent();
            _currentStudent = student;
            DataContext = _currentStudent;
        }
        public ProfileControl(Leadership leadership)
        {
            InitializeComponent();
            _currentLeadership = leadership;
            DataContext = _currentLeadership;
        }
        
        private void File_OnDrop(object sender, DragEventArgs e)
        {
            var filePath = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (filePath == null) return;
            var source = ImageManager.CroppedToBitmapImage(filePath[0]);
            var bytes = ImageManager.CroppedToBytes(source);
            if (_currentStudent != null)
            {
                _currentStudent.Photo = bytes;
                DataContext = null;
                DataContext = _currentStudent;
            }
            else if (_currentLeadership != null)
            {
                _currentLeadership.Photo = bytes;
                DataContext = null;
                DataContext = _currentLeadership;
            }
        }
        
        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            if ((_currentStudent != null && string.IsNullOrWhiteSpace(_currentStudent.Surname)) || 
                (_currentLeadership != null && string.IsNullOrWhiteSpace(_currentLeadership.Surname)))
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не ввели фамилию", ModalDialogButtons.Ok,
                    ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }

            if ((_currentStudent != null && string.IsNullOrWhiteSpace(_currentStudent.Firstname)) || 
                (_currentLeadership != null && string.IsNullOrWhiteSpace(_currentLeadership.Firstname)))
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не ввели имя", ModalDialogButtons.Ok, ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }

            if ((_currentStudent != null && string.IsNullOrWhiteSpace(_currentStudent.Patronymic)) || 
                (_currentLeadership != null && string.IsNullOrWhiteSpace(_currentLeadership.Patronymic)))
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не ввели отчество", ModalDialogButtons.Ok,
                    ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }

            if (_currentStudent != null && _currentStudent.Id == 0)
            {
                HouseOfCultureEntities.GetContext().Students.Add(_currentStudent);
                _currentStudent.User.Role = HouseOfCultureEntities.GetContext().Roles.First(x => x.Name == "Студент");
            }

            if (_currentLeadership != null && _currentLeadership.Id == 0)
            {
                HouseOfCultureEntities.GetContext().Leaderships.Add(_currentLeadership);
                _currentLeadership.User.Role = HouseOfCultureEntities.GetContext().Roles.First(x => x.Name == "Руководитель");
            }

            HouseOfCultureEntities.GetContext().SaveChanges();
        }
    }
}