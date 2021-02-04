using Diba.Core.AppService.Contract;
using Diba.Desktop.Common;
using System.Windows.Controls;

namespace Diba.Desktop.Controls
{
    /// <summary>
    /// Interaction logic for CustomerControl.xaml
    /// </summary>
    public partial class CustomerControl : UserControl
    {        
        public long Id { get; set; }
        private ViewMode _mode;
        public ViewMode Mode { get => _mode;
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

        public CustomerControl()
        {
            InitializeComponent();

            Mode = ViewMode.Create;
        }

        public CustomerControl(CustomerViewModel customer, ViewMode mode)
        {
            InitializeComponent();

            Mode = mode;

            LoadData(customer);

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
            CustomerCode.IsReadOnly = true;
            CustomerFirstName.IsReadOnly = true;
            CustomerLastName.IsReadOnly = true;
            CustomerAddress.IsReadOnly = true;
            CustomerDistrict.IsReadOnly = true;
            CustomerEconomicCode.IsReadOnly = true;
            CustomerPostalCode.IsReadOnly = true;
            CustomerPhoneNumber.IsReadOnly = true;
            CustomerRegistrationNumber.IsReadOnly = true;
            CustomerNationalIdentifier.IsReadOnly = true;
        }

        private void EnableForm()
        {
            CustomerCode.IsReadOnly = false;
            CustomerFirstName.IsReadOnly = false;
            CustomerLastName.IsReadOnly = false;
            CustomerAddress.IsReadOnly = false;
            CustomerDistrict.IsReadOnly = false;
            CustomerEconomicCode.IsReadOnly = false;
            CustomerPostalCode.IsReadOnly = false;
            CustomerPhoneNumber.IsReadOnly = false;
            CustomerRegistrationNumber.IsReadOnly = false;
            CustomerNationalIdentifier.IsReadOnly = false;
        }

        public void LoadData(CustomerViewModel customer)
        {
            CustomerFirstName.Text = customer?.FirstName;
            CustomerLastName.Text = customer?.LastName;
            CustomerAddress.Text = customer?.Address;
            CustomerCode.Text = customer?.Code;
            CustomerDistrict.Text = customer?.District;
            CustomerEconomicCode.Text = customer?.EconomicCode;
            CustomerPostalCode.Text = customer?.PostalCode;
            CustomerPhoneNumber.Text = customer?.PhoneNumber;
            CustomerRegistrationNumber.Text = customer?.RegistrationNumber;
            CustomerNationalIdentifier.Text = customer?.NationalIdentifier;
        }
    }
}
