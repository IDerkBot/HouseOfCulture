using System.Windows;
using System.Windows.Controls;
using Arion.Style.Controls;
using Arion.Style.Controls.Enums;
using HouseOfCulture.Models;
using HouseOfCulture.Models.Entities;

namespace HouseOfCulture.Views.Edit
{
    public partial class TypeRequestEditControl : UserControl
    {
        private readonly TypeRequest _currentTypeRequest;
        public TypeRequestEditControl(TypeRequest selectedTypeRequest = null)
        {
            InitializeComponent();
            // Указываем либо тип заявки который мы выбрали (если мы редактируем),
            // либо создаем новую (если мы нажали добавить)
            _currentTypeRequest = selectedTypeRequest ?? new TypeRequest();
            // Добавляем тип заявки в контекст страницы что бы он привязался к нашим Биндингам
            DataContext = _currentTypeRequest;
        }

        private void BtnSave_OnClick(object sender, RoutedEventArgs e)
        {
            // Проверяем пусто ли наименование
            if (string.IsNullOrWhiteSpace(_currentTypeRequest.Name))
            {
                // Показываем уведомление
                ModalDialog.Show("Ошибка данных", "Вы не ввели наименование", ModalDialogButtons.Ok, ModalDialogType.Warning);
                // Прекращаем выполнение метода
                return;
            }

            // Проверяем на новую запись в БД
            if (_currentTypeRequest.Id == 0)
                // Добавляем новую запись
                HouseOfCultureEntities.GetContext().TypeRequests.Add(_currentTypeRequest);

            // Сохраняем данные
            HouseOfCultureEntities.GetContext().SaveChanges();
            // Возвращаемся назад
            Navigation.Back();
        }
    }
}