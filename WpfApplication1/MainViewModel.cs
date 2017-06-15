using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System;

namespace WpfApplication1
{
    public class MainViewModel : ViewModelBase
    {
        private string text = "test";
        private INavigator navi;

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                RaisePropertyChanged(nameof(Text));
            }
        }

        public ICommand ValidateCommand { get; }
        public ICommand OpenOtherViewCommand { get; }

        public MainViewModel(INavigator navigator)
        {
            navi = navigator;
            ValidateCommand = new RelayCommand(() => Validate());
            OpenOtherViewCommand = new RelayCommand(() => OpenOtherView());
        }

        private void OpenOtherView()
        {
            navi.NavigateTo("other");
        }

        private void Validate()
        {
            Text += "Validated";
        }
    }
}
