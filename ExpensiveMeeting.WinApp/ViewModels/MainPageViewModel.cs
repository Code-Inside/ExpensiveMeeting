using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

namespace ExpensiveMeeting.WinApp.ViewModels
{
    public class MainPageViewModel : Mvvm.ViewModelBase
    {
        public MainPageViewModel()
        {
            this.ElapsedTime = new TimeSpan();
        }

        int _NumberOfPeople;
        public int NumberOfPeople { get { return _NumberOfPeople; } set { Set(ref _NumberOfPeople, value); } }

        double _AverageSalery;
        public double AverageSalery { get { return _AverageSalery; } set { Set(ref _AverageSalery, value); } }

        double _MoneyBurndownCounter;
        public double MoneyBurndownCounter { get { return _MoneyBurndownCounter; } set { Set(ref _MoneyBurndownCounter, value); } }

        double _MoneyBurndownPerMinute;
        public double MoneyBurndownPerMinute { get { return _MoneyBurndownPerMinute; } set { Set(ref _MoneyBurndownPerMinute, value); } }

        double _MoneyBurndownPerFithteenMinutes;
        public double MoneyBurndownPerFithteenMinutes { get { return _MoneyBurndownPerFithteenMinutes; } set { Set(ref _MoneyBurndownPerFithteenMinutes, value); } }

        double _MoneyBurndownPerHour;
        public double MoneyBurndownPerHour { get { return _MoneyBurndownPerHour; } set { Set(ref _MoneyBurndownPerHour, value); } }

        TimeSpan _ElapsedTime;
        public TimeSpan ElapsedTime { get { return _ElapsedTime; } set { Set(ref _ElapsedTime, value); } }

        public override void OnNavigatedTo(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            state.Clear();
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
        {
            await Task.Yield();
        }

        public void GotoDetailsPage()
        {
            NavigationService.Navigate(typeof(Views.DetailPage));
        }

        private bool isTimerRunning;
        private async void StartTimer(TimeSpan MyInterval, TimeSpan TotalTime)
        {
            isTimerRunning = true;
            int i = 0;
            double TotalSeconds = TotalTime.TotalSeconds;
            double MyIntervalSeconds = MyInterval.TotalSeconds;
            while (this.isTimerRunning)
            {
                this.ElapsedTime = this.ElapsedTime.Add(TimeSpan.FromSeconds(1));

                await Task.Delay(MyInterval);
                i = i++;
                if (TotalSeconds <= i * MyIntervalSeconds)
                {
                    isTimerRunning = false;
                }
            }
        }
        

        public void StartMeeting()
        {
            StartTimer(TimeSpan.FromSeconds(1), TimeSpan.FromDays(1));
        }

        public void StopMeeting()
        {
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

