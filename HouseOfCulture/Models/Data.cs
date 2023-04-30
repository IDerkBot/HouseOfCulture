using HouseOfCulture.Models.Entities;

namespace HouseOfCulture.Models
{
    public static class Data
    {
        public static User User { get; set; }

        public static string UsuallyUser { get; set; } = "Пользователь";
        public static string Student { get; set; } = "Студент";
        public static string Leadership { get; set; } = "Руководитель";
        public static string Admin { get; set; } = "Администратор";
    }
}