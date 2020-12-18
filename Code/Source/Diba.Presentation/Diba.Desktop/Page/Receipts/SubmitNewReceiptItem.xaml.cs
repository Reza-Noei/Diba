using Diba.Desktop.Common;
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
    /// Interaction logic for SubmitNewReceiptItem.xaml
    /// </summary>
    public partial class SubmitNewReceiptItem : UserControl
    {
        public SubmitNewReceiptItem()
        {
            InitializeComponent();
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            //TODO: این بحث فرم های دیالوگی بهتره که خروجی با یک شی وضعیت دیالوگ داشته باشیم.
            // بنابراین این بخش رو اصلاح کنید بعلاوه موارد مشابه
            if (e.Key == Key.Escape)
                MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand.Execute(new DialogResult()
                {
                    State = DialogState.Cancel
                }, null);
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand.Execute(new DialogResult()
            {
                State = DialogState.Ok
            }, null);
        }
    }
}
