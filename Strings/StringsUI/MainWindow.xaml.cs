using Strings.BL;
using Strings.Common;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace StringsUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ListRepository<User> _users = new();
        User _currentUser = new();

        public MainWindow()
        {
            InitializeComponent();
            UsersList.ItemsSource = _users.GetAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //decimal addingSum = Convert.ToDecimal(AmountToAdd.Text, CultureInfo.CreateSpecificCulture(_currentUser.Culture));
            decimal addingSum;
            decimal.TryParse(AmountToAdd.Text, NumberStyles.Number, CultureInfo.CreateSpecificCulture(_currentUser.Culture), out addingSum);
            _currentUser.Sum += addingSum;
            CurrentAmount.Content = $"{_currentUser.Sum.ToLocalizedString(_currentUser.Culture)}$";
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _currentUser = e.AddedItems[0] as User;
            if (_currentUser == null) userInfo.Text = "Smth went wrong";
            else
            {
                userInfo.Text = "Birthday: " + _currentUser.Birthday.UnixToUsualConvert(_currentUser.Culture) + "\n" +
                                "Registration Date: " + _currentUser.RegistrationDate.UnixToUsualConvert(_currentUser.Culture) + "\n" + 
                                "Culture: " + _currentUser.Culture;
                CurrentAmount.Content = $"{_currentUser.Sum.ToLocalizedString(_currentUser.Culture)}$";

                AmountToAdd.Visibility = Visibility.Visible; 
                CurrentAmount.Visibility = Visibility.Visible; 
                SaveButton.Visibility = Visibility.Visible;
                AddMoney.Visibility = Visibility.Visible;
            }

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _users.Save();
        }


        private void AmountToAdd_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex allowedChars = new Regex(@"^[-,0-9]+$");
            decimal checker = 0.1m;
            if (checker.ToLocalizedString(_currentUser.Culture) == "0.1")
            {
                allowedChars = new Regex(@"^[-.0-9]+$");
            }

            var match = allowedChars.Match(e.Text);

            if (!match.Success)
            {
                e.Handled = true;
            }
        }
    }
}
