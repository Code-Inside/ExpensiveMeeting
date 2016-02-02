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
            this.NumberOfPeople = 4;
            this.AverageSalery = 100000;
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

        bool _IsMeetingRunning;
        public bool IsMeetingRunning { get { return _IsMeetingRunning; } set { Set(ref _IsMeetingRunning, value); } }

        bool _IsMeetingStarted;
        public bool IsMeetingStarted { get { return _IsMeetingStarted; } set { Set(ref _IsMeetingStarted, value); } }

        bool _HasValidationErrors;
        public bool HasValidationErrors { get { return _HasValidationErrors; } set { Set(ref _HasValidationErrors, value); } }


        TimeSpan _ElapsedTime;
        public TimeSpan ElapsedTime { get { return _ElapsedTime; } set { Set(ref _ElapsedTime, value); } }

        public override Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> state)
        {
            state.Clear();
            return Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> state, bool suspending)
        {
            await Task.Yield();
        }

       

        private void Reset()
        {
            IsMeetingRunning = false;
            IsMeetingStarted = false;
            MoneyBurndownPerHour = 0;
            MoneyBurndownPerMinute = 0;
            MoneyBurndownPerFithteenMinutes = 0;
            MoneyBurndownCounter = 0;
            ElapsedTime = new TimeSpan();
        }

        private async void CalculateCosts()
        {
            var costsPerHourForOne = AverageSalery / 2000; // OECD max work hours 

            MoneyBurndownPerHour = costsPerHourForOne * NumberOfPeople;
            MoneyBurndownPerMinute = MoneyBurndownPerHour / 60;
            MoneyBurndownPerFithteenMinutes = MoneyBurndownPerMinute * 15;

            var costsPerSecondsForAll = MoneyBurndownPerMinute / 60;

            while (this.IsMeetingRunning)
            {
                this.ElapsedTime = this.ElapsedTime.Add(TimeSpan.FromSeconds(1));

                MoneyBurndownCounter = this.ElapsedTime.TotalSeconds * costsPerSecondsForAll;   

                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        public void StartMeeting()
        {
            this.IsMeetingStarted = true;
            this.IsMeetingRunning = true;
            CalculateCosts();
        }

        public void PauseMeeting()
        {
            this.IsMeetingRunning = false;
        }

        public void RestartMeeting()
        {
            
            Reset();
        }
    }
}

