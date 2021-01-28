using Diba.Core.AppService.Contract;
using Diba.Desktop.Common;
using System.Windows;

namespace Diba.Desktop.Controls
{
    /// <summary>
    /// Interaction logic for InvoiceControl.xaml
    /// </summary>
    public partial class InvoiceControl
    {
        public long Id { get; set; }
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

        public InvoiceControl()
        {
            InitializeComponent();

            Mode = ViewMode.Create;
        }

        public InvoiceControl(InvoiceViewModel invoice, ViewMode mode)
        {
            InitializeComponent();

            Mode = mode;

            LoadData(invoice);

            switch (mode)
            {
                case ViewMode.View:
                    DisableForm();
                    break;
                case ViewMode.Edit:
                    break;
                case ViewMode.Create:
                    break;
                default:
                    break;
            }
        }

        private void DisableForm()
        {
            //CustomerCode.IsReadOnly = true;
            //CustomerFirstName.IsReadOnly = true;
            //CustomerLastName.IsReadOnly = true;
            //CustomerAddress.IsReadOnly = true;
            //CustomerDistrict.IsReadOnly = true;
            //CustomerEconomicCode.IsReadOnly = true;
            //CustomerPostalCode.IsReadOnly = true;
            //CustomerPhoneNumber.IsReadOnly = true;
            //CustomerRegistrationNumber.IsReadOnly = true;
            //CustomerNationalIdentifier.IsReadOnly = true;
        }

        private void EnableForm()
        {
            //CustomerCode.IsReadOnly = false;
            //CustomerFirstName.IsReadOnly = false;
            //CustomerLastName.IsReadOnly = false;
            //CustomerAddress.IsReadOnly = false;
            //CustomerDistrict.IsReadOnly = false;
            //CustomerEconomicCode.IsReadOnly = false;
            //CustomerPostalCode.IsReadOnly = false;
            //CustomerPhoneNumber.IsReadOnly = false;
            //CustomerRegistrationNumber.IsReadOnly = false;
            //CustomerNationalIdentifier.IsReadOnly = false;
        }

        public void LoadData(InvoiceViewModel invoice)
        {
            //CustomerFirstName.Text = invoice?.FirstName;
            //CustomerLastName.Text = invoice?.LastName;
            //CustomerAddress.Text = invoice?.Address;
            //CustomerCode.Text = invoice?.Code;
            //CustomerDistrict.Text = invoice?.District;
            //CustomerEconomicCode.Text = invoice?.EconomicCode;
            //CustomerPostalCode.Text = invoice?.PostalCode;
            //CustomerPhoneNumber.Text = invoice?.PhoneNumber;
            //CustomerRegistrationNumber.Text = invoice?.RegistrationNumber;
            //CustomerNationalIdentifier.Text = invoice?.NationalIdentifier;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
