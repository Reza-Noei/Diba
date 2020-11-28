using Diba.Core.AppService.Contract;
using Diba.Desktop.Common;
using Diba.Desktop.Internal.DibaCore;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diba.Desktop.Page
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class FirstStepLogin
    {
        IAuthenticationCommand AuthenticationCommand;

        public FirstStepLogin()
        {
            InitializeComponent();

            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;

            AuthenticationCommand = new MockAuthenticationCommand();
        }

        public FirstStepLogin(FormBase RedirectPage)
        {
            //RedirectTo(new Main());
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Username.Focus();
        }

        private void DisplayErrorMessage(string Message)
        {
            ErrorMessage.Visibility = Visibility.Visible;
            ErrorMessage.Text = Message;
        }

        private void HideErrorMessage()
        {
            ErrorMessage.Visibility = Visibility.Collapsed;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Username.Text.Trim()) || string.IsNullOrEmpty(Password.Password))
            {
                DisplayErrorMessage("نام کاربری یا رمز عبور وارد نشده است.");
                return;
            }

            try
            {
                HideErrorMessage();

                var Result = AuthenticationCommand.FirstStepLogin(new Core.AppService.Contract.BindingModels.UserAuthenticationBindingModel()
                {
                    Username = Username.Text,
                    Password = Password.Password
                });

                if (Result.StatusCode != StatusCode.Ok)
                    DisplayErrorMessage(Result.Message.Text);
                else
                {
                    SessionManagement.AccessToken = Result.Data;
                    
                    RedirectTo(new SecondStepLogin());
                }
            }
            catch (Exception Ex)
            {
                DisplayErrorMessage(Ex.Message);
            }
        }
    }
}
