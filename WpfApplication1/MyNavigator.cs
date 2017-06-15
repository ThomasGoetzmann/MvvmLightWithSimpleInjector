using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WpfApplication1
{
    public class MyNavigator : INavigator
    {
        private Stack<string> history;
        private KeyValuePair<string,Window> currentElement;

        public object Parameter { get; private set; }

        public string CurrentPageKey
        {
            get
            {
                return currentElement.Key;
            }
        }

        public void NavigateTo(string viewKey)
        {
            var currentWindow = currentElement.Value;
            var currentKey = currentElement.Key;
            if(!string.IsNullOrEmpty(currentKey))
                history.Push(currentKey);

            currentElement = views.FirstOrDefault(x =>x.Key == viewKey);
            

            if (currentElement.Value == null)
                throw new Exception($"View '{viewKey}' has never been registered. Please use Navigator.Register(key, Window)");

            currentWindow?.Hide();
            currentElement.Value.Show();
        }

        public void NavigateTo(string viewKey, object parameter)
        {
            Parameter = parameter;
            NavigateTo(viewKey);
        }

        public void RegisterView(string viewKey, Window view)
        {
            views.Add(viewKey, view);
        }

        public void GoBack()
        {
            var previous = history.Pop();
            if (!string.IsNullOrEmpty(previous))
                NavigateTo(previous);
        }

        public MyNavigator()
        {
            views = new Dictionary<string, Window>();
            history = new Stack<string>();
        }

        private Dictionary<string, Window> views;
    }
}
