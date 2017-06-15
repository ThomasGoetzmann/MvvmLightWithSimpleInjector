using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication1
{
    public class OtherViewModel
    {
        private INavigator navi;

        public ICommand BackCommand { get; }

        public OtherViewModel(INavigator navigator)
        {
            navi = navigator;
            BackCommand = new RelayCommand(() => NavigateBack());
        }

        private void NavigateBack()
        {
            navi.GoBack();
        }
    }
}
