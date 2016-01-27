using System;
using Windows.UI.Xaml;

namespace ExpensiveMeeting.WinApp.ViewModels
{
    public class SettingsPageViewModel : ExpensiveMeeting.WinApp.Mvvm.ViewModelBase
    {
        public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();
    }

    public class AboutPartViewModel : Mvvm.ViewModelBase
    {
        public Uri Logo => Windows.ApplicationModel.Package.Current.Logo;

        public string DisplayName => Windows.ApplicationModel.Package.Current.DisplayName;

        public string Publisher => Windows.ApplicationModel.Package.Current.PublisherDisplayName;

        public string Version
        {
            get
            {
                var ver = Windows.ApplicationModel.Package.Current.Id.Version;
                return ver.Major.ToString() + "." + ver.Minor.ToString() + "." + ver.Build.ToString() + "." + ver.Revision.ToString();
            }
        }
    }
}

