using Diba.Desktop.Common;
using Diba.Desktop.Internal;
using Diba.Desktop.Page.Customer;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Diba.Desktop.Page.Home
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class HomePage 
    {
        PageManager PageManager;

        List<UIElement> MenuItems = new List<UIElement>()
        {
            new ListBoxItem()
            {
                Padding = new Thickness() { Left = 32, Right = 32, Top = 5, Bottom = 5 },
                Name = "Customers",
                Content = "مشتریان"
            },
            new ListBoxItem()
            {
                Padding = new Thickness() { Left = 32, Right = 32, Top = 5, Bottom = 5 },
                Name = "Invoices",
                Content = "فاکتورها"
            },
            new ListBoxItem()
            {
                Padding = new Thickness() { Left = 32, Right = 32, Top = 5, Bottom = 5 },
                Name = "Customers",
                Content = "صندوق"
            },
            new ListBoxItem()
            {
                Padding = new Thickness() { Left = 32, Right = 32, Top = 5, Bottom = 5 },
                Name = "Settings",
                Content = "تنظیمات"
            }
        };

        public HomePage()
        {
            InitializeComponent();

            MenuItemsListBox.ItemsSource = MenuItems;

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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textbox)
            {
                if (textbox.Text == "")
                {
                    MenuItemsListBox.ItemsSource = MenuItems;
                }
                else
                {
                    MenuItemsListBox.ItemsSource = MenuItems.Where(p => p is ListBoxItem)
                                                            .Select(p => p as ListBoxItem)
                                                            .Where(p => p.Content.ToString().Contains(textbox.Text));
                }
            }
        }
    }
}
