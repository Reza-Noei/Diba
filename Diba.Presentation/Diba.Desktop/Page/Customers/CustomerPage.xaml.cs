using Diba.Core.AppService.Contract;
using Diba.Desktop.Common;
using Diba.Desktop.Internal.DibaCore;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;

namespace Diba.Desktop.Page
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
            Customer.Mode = Controls.Mode.View;
            CustomerFullName.Text = customerViewModel?.FirstName + " " + customerViewModel?.LastName;

        }

        private async void Return_Click(object sender, RoutedEventArgs e)
        {
            var dialogResult = await DialogHost.Show(Controls.MessageBox.Build("آیا ناموساً مطمئن هستید ؟", Controls.MessageBoxType.OkCancel)) as DialogResult;

            if (dialogResult.State == DialogState.Ok)
                this.ClosePageAsChild(this, Common.PageResult.OK);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RedirectTo(new Receipts.SubmitNewReceiptPage(_customerViewModel, Controls.Mode.Create));
        }

        private void FormBase_Loaded(object sender, RoutedEventArgs e)
        {
            IReceiptsQuery receiptsQuery = new MockReceiptsQuery();
            ServiceResult<System.Collections.Generic.IEnumerable<ReceiptViewModel>> result = receiptsQuery.GetList(new ReceiptsQueryInputModel()
            {
                CustomerId = 1
            });
            ReceiptsGrid.ConsumeData(result.Data);
        }
    }
}
