using Strings.BL;
using Strings.Common;
using System.Windows;
using System.Windows.Controls;

namespace StringsUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var userRepository = new ListRepository<User>();
            UsersList.ItemsSource = userRepository.GetAll();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var user = e.AddedItems[0] as User;
            if (user == null) userInfo.Text = "Smth went wrong";
            else
            {
                userInfo.Text = user.Birthday.UnixToDateTimeConvert(user.Culture) + "\n" +
                                user.RegistrationDate.UnixToDateTimeConvert(user.Culture) + "\n" +
                                user.Sum.ShowSumInCulture(user.Culture);
            }

        }
    }
}
