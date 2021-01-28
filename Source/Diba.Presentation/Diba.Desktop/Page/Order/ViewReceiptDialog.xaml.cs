using Diba.Core.AppService.Contract;
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
    /// Interaction logic for ViewReceipt.xaml
    /// </summary>
    public partial class ViewReceiptDialog : UserControl
    {
        public ViewReceiptDialog()
        {
            InitializeComponent();
        }

        public ViewReceiptDialog(ReceiptViewModel receiptViewModel)
        {
            InitializeComponent();

            Receipt.InitiateForView(receiptViewModel);
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand.Execute(this, null);
        }
    }
}
