using Diba.Core.AppService.Contract;
using Diba.Desktop.Common;
using Diba.Desktop.Controls;
using Diba.Desktop.Internal.DibaCore;
using MaterialDesignThemes.Wpf;
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

namespace Diba.Desktop.Page.Receipts
{
    public partial class CreateOrderPage 
    {
        private readonly CustomerViewModel customerViewModel;

        public CreateOrderPage()
        {
            InitializeComponent();
        }

        public CreateOrderPage(CustomerViewModel customerViewModel, ViewMode mode)
        {
            InitializeComponent();
            this.customerViewModel = customerViewModel;
            Receipt.InitiateForCreate(customerViewModel.Address,
                new List<string>()
                {
                    "رضا قربانی",
                    "حسین مهرابی",
                    "شایان اکبری",
                    "علی احمدی"
                },
                new List<string>()
                {
                    "رضا قربانی",
                    "حسین مهرابی",
                    "شایان اکبری",
                    "علی احمدی",
                    "محمد غیاثی خودمون"
                });

            Customer.LoadData(customerViewModel);
            Customer.Mode = ViewMode.View;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialogResult = await DialogHost.Show(new CreateOrderItemDialog());
        }

        private void Receipt_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Customer_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            List<ReceiptItemViewModel> Items =
                Receipt.ReceiptItemsGrid.DataGrid.Items.OfType<ReceiptItemViewModel>().ToList();

            if (Items.Count > 0)
            {
                IReceiptsCommand receiptsCommand = new MockReceiptsCommand();
                _ = receiptsCommand.Create(new ReceiptInputModel()
                {
                    CustomerId = customerViewModel.Id,
                    Items = Items.Select(P => new ReceiptItemInputModel()
                    {
                        Descrption = P.Description
                    })
                });

                Submit.Visibility = Visibility.Collapsed;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private async void Return_Click(object sender, RoutedEventArgs e)
        {
            var dialogResult = await DialogHost.Show(Controls.MessageBox.Build("آیا ناموساً مطمئن هستید ؟", Controls.MessageBoxType.OkCancel)) as DialogResult;

            if (dialogResult.State == DialogState.Ok)
                this.ClosePageAsChild(this, Common.PageResult.OK);
        }
    }
}
