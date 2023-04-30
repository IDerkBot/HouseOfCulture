using System.Windows.Controls;

namespace HouseOfCulture.Models
{
    public static class Navigation
    {
        public static Frame ContentHost;
        public static bool Go(object obj)
        {
            return ContentHost.Navigate(obj);
        }

        public static void Back()
        {
            if(CanGoBack())
                ContentHost.GoBack();
        }

        public static bool CanGoBack()
        {
            return ContentHost.CanGoBack;
        }
    }
}