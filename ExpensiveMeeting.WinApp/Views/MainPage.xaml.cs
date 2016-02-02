using System;
using ExpensiveMeeting.WinApp.ViewModels;
using Windows.UI.Xaml.Controls;

namespace ExpensiveMeeting.WinApp.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled;
        }

        // strongly-typed view models enable x:bind
        public MainPageViewModel ViewModel => this.DataContext as MainPageViewModel;

        private void NumberOfPeopleTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateInputs();
        }

        private void ValidateInputs()
        {
            bool averageSaleryIsInvalid = false;
            bool numberOfPeopleIsInvalid = false;

            double salery;
            if (!double.TryParse(AverageSalery.Text, out salery))
            {
                averageSaleryIsInvalid = true;
            }

            int numberOfPeople;
            if (!int.TryParse(NumberOfPeople.Text, out numberOfPeople))
            {
                numberOfPeopleIsInvalid = true;
            }

            if (numberOfPeopleIsInvalid || averageSaleryIsInvalid)
            {
                ViewModel.HasValidationErrors = true;
            }
            else
            {
                ViewModel.HasValidationErrors = false;
            }
        }

        private void SaleryTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateInputs();
        }
    }
}
