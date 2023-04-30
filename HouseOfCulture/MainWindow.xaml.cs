using System;
using System.Windows;
using HouseOfCulture.Models;
using HouseOfCulture.Views;

namespace HouseOfCulture
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigation.ContentHost = ContentHost;
            Navigation.Go(new AuthorizationPage());
        }

        private void ContentHost_OnContentRendered(object sender, EventArgs e)
        {
            BtnBack.Visibility = Navigation.CanGoBack() ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Navigation.Back();
        }
    }
}