using Diba.Desktop.Common;
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

namespace Diba.Desktop.Page.Invoice
{
    /// <summary>
    /// Interaction logic for InvoicePage.xaml
    /// </summary>
    public partial class CreateInvoicePage
    {
        public CreateInvoicePage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialogResult = await DialogHost.Show(Controls.MessageBox.Build("آیا ناموساً مطمئن هستید ؟", Controls.MessageBoxType.OkCancel)) as DialogResult;

            if (dialogResult.State == DialogState.Ok)
                this.ClosePageAsChild(this, Common.PageResult.OK);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
