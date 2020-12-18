using Diba.Core.AppService.Contract;
using Diba.Desktop.Internal.DibaCore;
using Diba.Desktop.Page.Customers;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Diba.Desktop.Page.Customer
{
    /// <summary>
    /// Interaction logic for SearchCustomerPage.xaml
    /// </summary>
    public partial class SearchCustomerPage
    {
        public SearchCustomerPage()
        {
            InitializeComponent();

            var DataGridRowContext = new ContextMenu() { FontWeight = FontWeights.Medium };

            var DetailMenuItem = new MenuItem();
            DetailMenuItem.Click += DetailMenuItem_Click;

            var DetailMenuItemContent = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
            };

            DetailMenuItemContent.Children.Add(new MaterialDesignThemes.Wpf.PackIcon()
            {
                Kind = PackIconKind.Magnify,
                VerticalAlignment = VerticalAlignment.Center,
                Width = 25,
                Height = 25,
                Foreground = new SolidColorBrush(Colors.DarkBlue)
            });

            DetailMenuItemContent.Children.Add(new TextBlock()
            {
                Margin = new Thickness(10, 0, 0, 0),
                Text = "نمایش جزئیات",
                FontFamily = Application.Current.Resources["IranSans"] as FontFamily
            });

            var NewOrderMenuItem = new MenuItem();

            var NewOrderMenuItemContent = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };

            NewOrderMenuItemContent.Children.Add(new MaterialDesignThemes.Wpf.PackIcon()
            {
                Kind = PackIconKind.Plus,
                Width = 25,
                Height = 25,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = new SolidColorBrush(Colors.Green)
            });

            NewOrderMenuItemContent.Children.Add(new TextBlock()
            {
                Margin = new Thickness(10, 0, 0, 0),
                Text = "سفارش جدید",
                FontFamily = Application.Current.Resources["IranSans"] as FontFamily
            });

            NewOrderMenuItem.Header = NewOrderMenuItemContent;

            DataGridRowContext.Items.Add(NewOrderMenuItem);

            DetailMenuItem.Header = DetailMenuItemContent;
            DataGridRowContext.Items.Add(DetailMenuItem);

            DataGrid.SetContextMenu(DataGridRowContext);
        }

        private async void DetailMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var Model = DataGrid.DataGrid.SelectedValue as CustomerViewModel;
            this.ShowChild(new CustomerPage(Model));
        }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialogResult = await DialogHost.Show(new CreateNewCustomer());
        }

        private void FormBase_MouseUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void SearchCustomers_Click(object sender, RoutedEventArgs e)
        {
            ICustomerManagementQuery customerManagementQuery = new MockCustomerManagementQuery();
            var Result = customerManagementQuery.Search(new CustomerSearchInputModel()
            {
                Query = ""
            });

            DataGrid.ConsumeData(Result.Data);
        }

        private void FormBase_Loaded(object sender, RoutedEventArgs e)
        {
            ICustomerManagementQuery customerManagementQuery = new MockCustomerManagementQuery();
            var Result = customerManagementQuery.Search(new CustomerSearchInputModel()
            {
                Query = ""
            });

            DataGrid.ConsumeData(Result.Data);
        }
    }
}
