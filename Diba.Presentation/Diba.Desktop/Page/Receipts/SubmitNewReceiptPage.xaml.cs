using Diba.Core.AppService.Contract;
using Diba.Desktop.Controls;
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
    /// <summary>
    /// Interaction logic for SubmitNewReceipt.xaml
    /// </summary>
    public partial class SubmitNewReceiptPage 
    {
        public SubmitNewReceiptPage()
        {
            InitializeComponent();
        }

        public SubmitNewReceiptPage(CustomerViewModel customerViewModel, Mode mode)
        {
            InitializeComponent();
            Receipt.Initiate(customerViewModel, mode);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialogResult = await DialogHost.Show(new SubmitNewReceiptItem());
        }

        private void Receipt_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
