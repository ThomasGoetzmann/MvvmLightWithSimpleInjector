using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WpfApplication1
{
    public static class Program 
    {
        public static void Main()
        {
            var container = BootStrap();
            RegisterViews(container);

            RunApplication(container);
        }

        private static void RegisterViews(Container container)
        {
            var navigator = container.GetInstance<INavigator>();
            navigator.RegisterView("main", container.GetInstance<MainWindow>());
            navigator.RegisterView("other", container.GetInstance<OtherView>());
        }

        private static void RunApplication(Container container)
        {
            try
            {
                var navigator = container.GetInstance<INavigator>();
                navigator.NavigateTo("main");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unhandled error with message:\n" + ex.Message);
            }
        }

        private static Container BootStrap()
        {
            var container = new Container();

            container.RegisterSingleton<INavigator, MyNavigator>();

            container.Register<MainWindow>();
            container.Register<OtherView>();

            container.Register<MainViewModel>();
            container.Register<OtherViewModel>();

            container.Verify();

            return container;
        }
    }
}
