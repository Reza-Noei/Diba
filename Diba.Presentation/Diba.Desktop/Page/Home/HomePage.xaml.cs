using Diba.Desktop.Common;
using Diba.Desktop.Internal;
using Diba.Desktop.Page.Customer;
using System.Windows;

namespace Diba.Desktop.Page.Home
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class HomePage 
    {
        PageManager PageManager;

        public HomePage()
        {
            InitializeComponent();

            IJWTParser jwtParser = new MockJWTParser();
            var tokenPayload = jwtParser.Parse(SessionManagement.AccessToken);

            Header_UserTitle.Text = tokenPayload.UserName + "\\" + tokenPayload.OrganizationTitle;

            Header_UserProfilePopUp.Exit.Click += (p, e) =>
            {
                this.RedirectTo(new FirstStepLogin());
            };
        }

        private void FormBase_Loaded(object sender, RoutedEventArgs e)
        {
            PageManager = new PageManager(this.PageHost);
            PageManager.RedirectPage(new SearchCustomerPage());
        }
    }
}
