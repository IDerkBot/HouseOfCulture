using System.Linq;
using System.Windows;
using Arion.Style.Controls;
using Arion.Style.Controls.Enums;
using HouseOfCulture.Models;
using HouseOfCulture.Models.Entities;

namespace HouseOfCulture.Views.Edit
{
    public partial class GroupEditControl
    {
        private readonly Group _currentGroup;
        public GroupEditControl(Group selectedGroup = null)
        {
            InitializeComponent();
            _currentGroup = selectedGroup ?? new Group();
            DataContext = _currentGroup;
        }
        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_currentGroup.Name))
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не ввели название", ModalDialogButtons.Ok, ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }

            foreach (var leadership in LvData.SelectedItems.Cast<Leadership>())
            {
                if(_currentGroup.Leaderships.Count > 0)
                    if(_currentGroup.Leaderships.Any(x => x == leadership)) continue;
                _currentGroup.Leaderships.Add(leadership);
            }
            
            // Проверяем, новый это пользователь или нет
            if (_currentGroup.Id == 0)
                // Если новый, то добавляем его
                HouseOfCultureEntities.GetContext().Groups.Add(_currentGroup);
            
            // Сохраняем изменения
            HouseOfCultureEntities.GetContext().SaveChanges();
            // Возвращаемся на прошлую страницу
            Navigation.Back();
        }

        private void GroupEditControl_OnLoaded(object sender, RoutedEventArgs e)
        {
            LvData.ItemsSource = HouseOfCultureEntities.GetContext().Leaderships.ToList();
        }
    }
}