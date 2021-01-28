using Diba.Core.AppService.Contract;
using Diba.Desktop.Common;
using Diba.Desktop.Internal.DibaCore;
using Diba.Desktop.Page.Invoice;
using Diba.Desktop.Page.Receipts;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Diba.Desktop.Page.Customer
{
    /// <summary>
    /// Interaction logic for CustomerDetail.xaml
    /// </summary>
    public partial class CustomerPage
    {
        private readonly CustomerViewModel _customerViewModel;

        public CustomerPage()
        {
            InitializeComponent();
        }

        public CustomerPage(CustomerViewModel customerViewModel)
        {
            _customerViewModel = customerViewModel;

            InitializeComponent();

            Customer.LoadData(customerViewModel);
            Customer.Mode = ViewMode.View;
            CustomerFullName.Text = customerViewModel?.FirstName + " " + customerViewModel?.LastName;

            IntitiateReceiptsGridContextMenu();
        }

        private void IntitiateReceiptsGridContextMenu()
        {
            var DataGridRowContext = new ContextMenu() { FontWeight = FontWeights.Medium };

            var DetailMenuItem = new MenuItem();
            DetailMenuItem.Click += DetailMenuItem_Click;

            var DetailMenuItemContent = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
            };

            DetailMenuItemContent.Children.Add(new PackIcon()
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

            var CreateInvoiceMenuItem = new MenuItem();
            CreateInvoiceMenuItem.Click += CreateInvoiceMenuItem_Click;
            var CreateInvoiceMenuItemContent = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            };

            CreateInvoiceMenuItemContent.Children.Add(new PackIcon()
            {
                Kind = PackIconKind.Plus,
                Width = 25,
                Height = 25,
                VerticalAlignment = VerticalAlignment.Center,
                Foreground = new SolidColorBrush(Colors.Green)
            });

            CreateInvoiceMenuItemContent.Children.Add(new TextBlock()
            {
                Margin = new Thickness(10, 0, 0, 0),
                Text = "ثبت فاکتور",
                FontFamily = Application.Current.Resources["IranSans"] as FontFamily
            });

            CreateInvoiceMenuItem.Header = CreateInvoiceMenuItemContent;

            DataGridRowContext.Items.Add(CreateInvoiceMenuItem);

            DetailMenuItem.Header = DetailMenuItemContent;
            DataGridRowContext.Items.Add(DetailMenuItem);

            ReceiptsGrid.SetContextMenu(DataGridRowContext);
        }

        private void CreateInvoiceMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.ShowChild(new CreateInvoicePage());
        }

        private async void DetailMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ReceiptViewModel Model = ReceiptsGrid.DataGrid.SelectedValue as ReceiptViewModel;
            if (Model != null)
                _ = await DialogHost.Show(new ViewReceiptDialog(Model));
        }

        private async void Return_Click(object sender, RoutedEventArgs e)
        {
            var dialogResult = await DialogHost.Show(Controls.MessageBox.Build("آیا ناموساً مطمئن هستید ؟", Controls.MessageBoxType.OkCancel)) as DialogResult;

            if (dialogResult.State == DialogState.Ok)
                this.ClosePageAsChild(this, Common.PageResult.OK);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.ShowChild(new Receipts.CreateOrderPage(_customerViewModel, ViewMode.Create));
        }

        private void FormBase_Loaded(object sender, RoutedEventArgs e)
        {
            IReceiptsQuery receiptsQuery = new MockReceiptsQuery();
            ServiceResult<System.Collections.Generic.IEnumerable<ReceiptViewModel>> result = receiptsQuery.GetList(new ReceiptsQueryInputModel()
            {
                CustomerId = 1
            });
            ReceiptsGrid.ConsumeData(result.Data);

            IInvoicesQuery invoicesQuery = new MockInvoicesQuery();
            var invoices = invoicesQuery.GetByCustomerId(1);
            InvoicesGrid.ConsumeData(invoices.Data);
        }
    }
}
