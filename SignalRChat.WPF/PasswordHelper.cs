using System.Reflection;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace SignalRChat.WPF
{
    public class PasswordHelper
    {
        public static DependencyProperty BindablePasswordEnabledProperty =
            DependencyProperty.RegisterAttached(
                "BindablePasswordEnabled",
                typeof(bool),
                typeof(PasswordHelper),
                new PropertyMetadata(BindablePasswordEnabledChanged));

        private static void BindablePasswordEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = d as PasswordBox;
            passwordBox.PasswordChanged += (s, ee) =>
            {
                var password = passwordBox.Password;

                BindingExpression bindingExpression = BindingOperations.GetBindingExpression(passwordBox, BindablePasswordProperty);
                if (bindingExpression != null)
                {
                    PropertyInfo property = bindingExpression.DataItem.GetType().GetProperty(bindingExpression.ParentBinding.Path.Path);
                    if (property != null)
                        property.SetValue(bindingExpression.DataItem, password, null);
                }                
            };
        }

        public static bool GetBindablePasswordEnabled(PasswordBox passwordBox)
        {
            return (bool)passwordBox.GetValue(BindablePasswordEnabledProperty);
        }

        public static void SetBindablePasswordEnabled(PasswordBox passwordBox, bool enabled)
        {
            passwordBox.SetValue(BindablePasswordEnabledProperty, enabled);
        }


        public static DependencyProperty BindablePasswordProperty =
            DependencyProperty.RegisterAttached(
                "BindablePassword",
                typeof(string),
                typeof(PasswordHelper));


        public static string GetBindablePassword(PasswordBox passwordBox)
        {
            return passwordBox.Password;
        }

        public static void SetBindablePassword(PasswordBox passwordBox, string password)
        {
            passwordBox.Password = password;
        }
    }
}
