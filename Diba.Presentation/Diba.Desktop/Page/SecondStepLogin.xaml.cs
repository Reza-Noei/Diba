using Diba.Core.AppService.Contract;
using Diba.Desktop.Internal.DibaCore;
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
using Diba.Core.AppService.Contract.ViewModels;
using RestSharp;
using Diba.Desktop.Common;
using Diba.Desktop.Page.Home;

namespace Diba.Desktop.Page
{
    /// <summary>
    /// Interaction logic for SecondStepLogin.xaml
    /// </summary>
    public partial class SecondStepLogin
    {
        IAuthenticationCommand AuthenticationCommand;
        IOrganizationMembershipManagementQuery OrganizationMembershipManagementQuery;
        List<OrganizationMembershipViewModel> Memberships;

        private static Dictionary<string, string> RoleDictionary = new Dictionary<string, string>()
        {
            { "Secretary", "منشی" },
            { "Admin", "مدیر" },
            { "SuperAdmin", "مدیر ارشد" },
        };

        private static Dictionary<string, string> RoleReverseDictionary = new Dictionary<string, string>()
        {
            { "منشی" , "Secretary"},
            { "مدیر" , "Admin"},
            { "مدیر ارشد", "SuperAdmin"},
        };

        public SecondStepLogin()
        {
            InitializeComponent();

            this.AuthenticationCommand = new MockAuthenticationCommand();
            this.OrganizationMembershipManagementQuery = new MockOrganizationMembershipManagementQuery();
        }

        private void FormBase_Loaded(object sender, RoutedEventArgs e)
        {
            var result = OrganizationMembershipManagementQuery.GetUserMemberships();
            if (result.StatusCode != StatusCode.Ok)
            {
                DisplayErrorMessage(result.Message.Text);
            }
            else
            {
                Memberships = result.Data.ToList();
                for (int i = 0; i < Memberships.Count(); i++)
                {
                    Organization.Items.Add(new ComboBoxItem()
                    {
                        Content = Memberships[i].OrganizationTitle
                    });
                }

                Organization.SelectionChanged += Organization_SelectionChanged;
                Organization.SelectedIndex = 0;
            }

        }

        private void Organization_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Role.Items.Clear();

            var Roles = Memberships.Where(P => P.OrganizationTitle == (Organization.SelectedItem as ComboBoxItem).Content.ToString()).Select(P => RoleDictionary[P.RoleTitle]).ToList();

            for (int i = 0; i < Roles.Count; i++)
            {
                Role.Items.Add(new ComboBoxItem() { Content = Roles[i].ToString() });
            }

            Role.SelectedIndex = 0;
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
            if (Organization.SelectedItem == null || Role.SelectedItem == null)
            {
                DisplayErrorMessage("سازمان یا نقش انتخاب نشده است.");
                return;
            }

            try
            {
                HideErrorMessage();

                var Model = new Core.AppService.Contract.BindingModels.MembershipAuthenticationBindingModel()
                {
                    OrganizationId = Memberships.Where(P => P.OrganizationTitle == (Organization.SelectedItem as ComboBoxItem).Content.ToString()).Select(P => P.OrganizationId).First(),
                    Role = RoleReverseDictionary[(Role.SelectedItem as ComboBoxItem).Content.ToString()]
                };
                var Result = AuthenticationCommand.SecondStepLogin(Model);

                if (Result.StatusCode != StatusCode.Ok)
                    DisplayErrorMessage(Result.Message.Text);
                else
                {
                    SessionManagement.AccessToken = Result.Data;
                    RedirectTo(new HomePage());
                }
            }
            catch (Exception Ex)
            {
                DisplayErrorMessage(Ex.Message);
            }
        }
    }
}
