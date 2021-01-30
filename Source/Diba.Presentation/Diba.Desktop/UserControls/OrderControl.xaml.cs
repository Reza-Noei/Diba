using Diba.Core.AppService.Contract;
using Diba.Desktop.Common;
using Diba.Desktop.Controls;
using Diba.Desktop.Internal.DibaCore;
using Diba.Desktop.Page.Receipts;
using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Diba.Desktop.Controls
{
    public partial class OrderControl : UserControl
    {
        private ViewMode _mode;
        public ViewMode Mode
        {
            get => _mode;
            set
            {
                switch (value)
                {
                    case ViewMode.View:
                        DisableForm();
                        break;
                    case ViewMode.Edit:
                        EnableForm();
                        break;
                    case ViewMode.Create:
                        EnableForm();
                        break;
                    default:
                        break;
                }
                _mode = value;
            }
        }

        private ReceiptViewModel ReceiptViewModel;

        private long CustomerId { get; set; }

        public OrderControl()
        {
            InitializeComponent();
        }

        public OrderControl(ReceiptViewModel receipt, ViewMode mode)
        {
            InitializeComponent();

            Mode = mode;
            ReceiptViewModel = receipt;
        }

        public void InitiateForView(ReceiptViewModel receiptViewModel)
        {
            ReceiptViewModel = receiptViewModel;

            ReceiptionDate.Text = receiptViewModel.ReceptionDate.ToString();
            SecretaryFullName.Text = receiptViewModel.SecretaryFullName;

            DeliveryDueDate.Text = receiptViewModel.DeliveringDueDate.ToString();
            Delivery.Items.Add(new ComboBoxItem()
            {
                Content = receiptViewModel.DeliveryFullName
            });
            Delivery.SelectedIndex = 0;

            CollectingDueDate.Text = receiptViewModel.CollectingDueDate.ToString();
            Collector.Text = receiptViewModel.CollectorFullName;
            Collector.Items.Add(new ComboBoxItem()
            {
                Content = receiptViewModel.CollectorFullName
            });
            Collector.SelectedIndex = 0;

            EstimatedPrice.Text = receiptViewModel.EstimatedPrice.ToString();

            Status.Text = receiptViewModel.State.ToString("g");

            ReceiptItemsGrid.ConsumeData(receiptViewModel.Items);

            Mode = ViewMode.View;
        }

        public void InitiateForCreate(string CustomerAddress, IEnumerable<string> Collectors, IEnumerable<string> Deliveries)
        {
            CollectingAddress.Text = CustomerAddress;
            DeliveryAddress.Text = CustomerAddress;

            Collector.ItemsSource = Collectors.Select(P => new ComboBoxItem()
            {
                Content = P
            });

            Delivery.ItemsSource = Deliveries.Select(P => new ComboBoxItem()
            {
                Content = P
            });

            Mode = ViewMode.Create;
        }

        /// <summary>
        /// Instanciate in CreateMode
        /// </summary>
        /// <param name="CustomerId"></param>
        public OrderControl(long customerId)
        {
            InitializeComponent();

            Mode = ViewMode.Create;
            CustomerId = customerId;
        }
           
        private void DisableForm()
        {
            NewItem.Visibility = Visibility.Collapsed;
            
            SecretaryFullName.Visibility = Visibility.Visible;
            SecretaryFullName.IsReadOnly = true;
            
            ReceiptionDate.Visibility = Visibility.Visible;
            ReceiptionDate.IsReadOnly = true;

            CollectingDueDate.Visibility = Visibility.Visible;
            CollectingDueDate.IsReadOnly = true;

            Collector.Visibility = Visibility.Visible;
            Collector.IsReadOnly = true;

            DeliveryDueDate.Visibility = Visibility.Visible;
            DeliveryDueDate.IsReadOnly = true;

            Delivery.Visibility = Visibility.Visible;
            Delivery.IsReadOnly = true;

            CollectingAddress.Visibility = Visibility.Visible;
            CollectingAddress.IsReadOnly = true;

            DeliveryAddress.Visibility = Visibility.Visible;
            DeliveryAddress.IsReadOnly = true;

            Status.Visibility = Visibility.Visible;
            Status.IsReadOnly = true;
            
            EstimatedPrice.Visibility = Visibility.Visible;
            EstimatedPrice.IsReadOnly = true;
        }

        private void EnableForm()
        {
            NewItem.Visibility = Visibility.Visible;

            SecretaryFullName.Visibility = Visibility.Collapsed;
            ReceiptionDate.Visibility = Visibility.Collapsed;
            Status.Visibility = Visibility.Collapsed;

            CollectingDueDate.Visibility = Visibility.Visible;
            CollectingDueDate.IsReadOnly = false;

            DeliveryDueDate.Visibility = Visibility.Visible;
            DeliveryDueDate.IsReadOnly = false;

            Collector.Visibility = Visibility.Visible;
            Collector.IsReadOnly = false;

            Delivery.Visibility = Visibility.Visible;
            Delivery.IsReadOnly = false;

            CollectingAddress.Visibility = Visibility.Visible;
            CollectingAddress.IsReadOnly = false;

            DeliveryAddress.Visibility = Visibility.Visible;
            DeliveryAddress.IsReadOnly = false;

            EstimatedPrice.Visibility = Visibility.Visible;
            EstimatedPrice.IsReadOnly = false;
        }

        private async void NewItem_Click(object sender, RoutedEventArgs e)
        {
            CreateOrderItemDialog content = new CreateOrderItemDialog();
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
