using Diba.Core.AppService.Contract;
using Diba.Desktop.Common;
using Diba.Desktop.Controls;
using Diba.Desktop.Internal.DibaCore;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Diba.Desktop.Page.Receipts
{
    /// <summary>
    /// Interaction logic for ReceiptControl.xaml
    /// </summary>
    public partial class ReceiptControl : UserControl
    {
        private Mode _mode;
        public Mode Mode
        {
            get => _mode;
            set
            {
                switch (value)
                {
                    case Mode.View:
                        DisableForm();
                        break;
                    case Mode.Edit:
                        EnableForm();
                        break;
                    case Mode.Create:
                        EnableForm();
                        break;
                    default:
                        break;
                }
                _mode = value;
            }
        }

        public ReceiptControl()
        {
            InitializeComponent();
        }

        public ReceiptControl(CustomerViewModel customer, Mode mode)
        {
            InitializeComponent();

            Mode = mode;
            Customer.Mode = Mode.View;
            Customer.LoadData(customer);
        }

        public void Initiate(CustomerViewModel customer, Mode mode)
        {
            Mode = mode;
            Customer.Mode = Mode.View;
            Customer.LoadData(customer);
        }

        public ReceiptControl(CustomerViewModel customer, IEnumerable<ReceiptItemViewModel> items, Mode mode)
        {
            InitializeComponent();

            Mode = mode;
            Customer.Mode = Mode.View;
            Customer.LoadData(customer);
            ReceiptItemsGrid.ConsumeData(items);
        }

        private void DisableForm()
        {
            NewItem.Visibility = Visibility.Collapsed;
            Submit.Visibility = Visibility.Collapsed;
        }

        private void EnableForm()
        {
            NewItem.Visibility = Visibility.Visible;
            Submit.Visibility = Visibility.Visible;
        }

        private async void Submit_Click(object sender, RoutedEventArgs e)
        {
            IReceiptsCommand receiptsCommand = new MockReceiptsCommand();
            _ = receiptsCommand.Create(new ReceiptInputModel()
            {
                CustomerId = Customer.Id,
                Items = ReceiptItemsGrid.DataGrid.Items.OfType<ReceiptItemViewModel>().Select(P => new ReceiptItemInputModel()
                {
                    Descrption = P.Description
                })
            });
        }

        private async void NewItem_Click(object sender, RoutedEventArgs e)
        {
            SubmitNewReceiptItem content = new SubmitNewReceiptItem();
            var dialogResult = await DialogHost.Show(content) as DialogResult;

            if (dialogResult.State == DialogState.Ok)
            {
                if (ReceiptItemsGrid.DataGrid.Items.Count == 0)
                {
                    ReceiptItemsGrid.ConsumeData(new List<ReceiptItemViewModel>()
                    {
                        new ReceiptItemViewModel()
                        {
                            Description = content.Description.Text
                        }
                    });
                }
                else
                {
                    List<ReceiptItemViewModel> Items = ReceiptItemsGrid.DataGrid.Items.OfType<ReceiptItemViewModel>().ToList();
                    Items.Add(new ReceiptItemViewModel()
                    {
                        Description = content.Description.Text
                    });

                    ReceiptItemsGrid.DataGrid.ItemsSource = Items;
                }
            }
        }
    }
}
