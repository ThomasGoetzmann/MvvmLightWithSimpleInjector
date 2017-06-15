using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1
{
    public interface INavigator : INavigationService
    {
        object Parameter { get; }
        
        void RegisterView(string viewKey, Window view);
    }
}
