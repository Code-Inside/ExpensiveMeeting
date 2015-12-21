using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace ExpensiveMeeting.WinApp.ViewModels
{
    public class MainPageViewModel : Mvvm.ViewModelBase
    {
        public MainPageViewModel()
        {
            if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                Value = "Designtime value";
        }

        int _NumberOfPeople;
        public int NumberOfPeople { get { return _NumberOfPeople; } set { Set(ref _NumberOfPeople, value); } }

        double _AverageSalery;
        public double AverageSalery { get { return _AverageSalery; } set { Set(ref _AverageSalery, value); } }

        string _Value = string.Empty;
        public string Value { get { return _Value; } set { Set(ref _Value, value); } }

        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            if (state.ContainsKey(nameof(Value)))
                Value = state[nameof(Value)]?.ToString();
            state.Clear();
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
        {
            if (suspending)
                state[nameof(Value)] = Value;
            await Task.Yield();
        }

        public void GotoDetailsPage()
        {
            NavigationService.Navigate(typeof(Views.DetailPage), Value);
        }

        public void GotoPrivacy()
        {
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);
        }

        public void GotoAbout()
        {
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
        }

    }
}

