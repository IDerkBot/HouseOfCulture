using System.Linq;
using System.Windows;
using HouseOfCulture.Models;
using HouseOfCulture.Models.Entities;
using HouseOfCulture.Views.Tables;

namespace HouseOfCulture.Views
{
    public partial class MenuPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void BtnProfile_OnClick(object sender, RoutedEventArgs e)
        {
            if (Data.User.Students.Count == 1)
                Navigation.Go(new ProfileControl(Data.User.Students.First()));
            else if (Data.User.Leaderships.Count == 1)
                Navigation.Go(new ProfileControl(Data.User.Leaderships.First()));
            else Navigation.Go(new ProfileControl(new Student { User = Data.User }));
        }

        private void BtnUsers_OnClick(object sender, RoutedEventArgs e) => Navigation.Go(new UsersTableControl());
        private void BtnStudents_OnClick(object sender, RoutedEventArgs e) => Navigation.Go(new StudentsTableControl());

        private void BtnLeaderships_OnClick(object sender, RoutedEventArgs e) =>
            Navigation.Go(new LeadershipTableControl());

        private void BtnGroups_OnClick(object sender, RoutedEventArgs e) => Navigation.Go(new GroupsTableControl());

        private void BtnSchedule_OnClick(object sender, RoutedEventArgs e) =>
            Navigation.Go(new SchedulesTableControl());

        private void BtnEvents_OnClick(object sender, RoutedEventArgs e) => Navigation.Go(new EventsTablesControl());
        private void BtnRequests_OnClick(object sender, RoutedEventArgs e) => Navigation.Go(new RequestsTableControl());

        private void BtnTypeRequest_OnClick(object sender, RoutedEventArgs e) =>
            Navigation.Go(new TypeRequestsTableControl());

        private void MenuPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (Data.User.Role.Name == Data.UsuallyUser)
            {
                BtnProfile.Visibility = Visibility.Visible;
            }
            else if (Data.User.Role.Name == Data.Student)
            {
                BtnProfile.Visibility = Visibility.Visible;
                BtnSchedule.Visibility = Visibility.Visible;
                BtnEvents.Visibility = Visibility.Visible;
                BtnGroups.Visibility = Visibility.Visible;
                BtnRequests.Visibility = Visibility.Visible;
            }
            else if (Data.User.Role.Name == Data.Leadership)
            {
                BtnProfile.Visibility = Visibility.Visible;
                BtnSchedule.Visibility = Visibility.Visible;
                BtnEvents.Visibility = Visibility.Visible;
                BtnGroups.Visibility = Visibility.Visible;
                BtnRequests.Visibility = Visibility.Visible;
                BtnLeaderships.Visibility = Visibility.Visible;
                BtnStudents.Visibility = Visibility.Visible;
            }
            else if (Data.User.Role.Name == Data.Admin)
            {
                BtnSchedule.Visibility = Visibility.Visible;
                BtnEvents.Visibility = Visibility.Visible;
                BtnGroups.Visibility = Visibility.Visible;
                BtnRequests.Visibility = Visibility.Visible;
                BtnLeaderships.Visibility = Visibility.Visible;
                BtnStudents.Visibility = Visibility.Visible;
                BtnTypeRequest.Visibility = Visibility.Visible;
                BtnUsers.Visibility = Visibility.Visible;
            }
        }
    }
}