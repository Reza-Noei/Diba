using Diba.Core.AppService;
using Diba.Core.AppService.Contract;
using Diba.Desktop.Common;
using Diba.Desktop.Internal.DibaCore;
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

namespace Diba.Desktop.Page.Customer
{
    /// <summary>
    /// Interaction logic for CreateCustomerStart.xaml
    /// </summary>
    public partial class CreateCustomerDialog : UserControl
    {
        public CreateCustomerInputModel CreateCustomerInputModel { get; set; }
        public CreateCustomerDialog()
        {
            InitializeComponent();
        }

        private void CreateCustomerStart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand.Execute(new DialogResult()
                {
                    State = DialogState.No
                }, null);
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            CreateCustomerInputModel = new CreateCustomerInputModel()
            {
                FirstName = Customer.CustomerFirstName.Text,
                LastName = Customer.CustomerLastName.Text,
                Code = Customer.CustomerCode.Text,
                EconomicCode = Customer.CustomerEconomicCode.Text,
                NationalIdentifier = Customer.CustomerNationalIdentifier.Text,
                PostalCode = Customer.CustomerPostalCode.Text,
                RegistrationNumber = Customer.CustomerRegistrationNumber.Text,
                ContactInfo = new ContactInfoInputModel()
                {
                    Address = Customer.CustomerAddress.Text,
                    PhoneNumber = Customer.CustomerPhoneNumber.Text
                },
                District = Customer.CustomerDistrict.Text
            };

            MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand.Execute(new DialogResult()
            {
                State = DialogState.Yes
            }, null);
        }
    }    
}