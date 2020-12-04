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

namespace Diba.Desktop.Controls
{
    /// <summary>
    /// Interaction logic for MessageBox.xaml
    /// </summary>
    public partial class MessageBox : UserControl
    {
        private DialogState PrimaryButtonDialogState { get; set; }
        private DialogState SecondaryButtonDialogState { get; set; }

        private MessageBox(string message, MessageBoxType type)
        {
            InitializeComponent();

            Message.Text = message;

            switch (type)
            {
                case MessageBoxType.Ok:
                    PrimaryButton.Content = "بسیار خوب";
                    PrimaryButtonDialogState = DialogState.Ok;

                    SecondaryButton.Visibility = Visibility.Collapsed;
                    break;
                case MessageBoxType.OkCancel:
                    PrimaryButton.Content = "بسیار خوب";
                    PrimaryButtonDialogState = DialogState.Ok;

                    SecondaryButton.Content = "انصراف";
                    SecondaryButton.Visibility = Visibility.Visible;
                    SecondaryButtonDialogState = DialogState.Cancel;
                    break;
                case MessageBoxType.YesNo:
                    PrimaryButton.Content = "بلی";
                    PrimaryButtonDialogState = DialogState.Yes;

                    SecondaryButton.Content = "انصراف";
                    SecondaryButtonDialogState = DialogState.No;
                    SecondaryButton.Visibility = Visibility.Visible;
                    break;
                case MessageBoxType.Accept:
                    PrimaryButton.Content = "قبول";
                    PrimaryButtonDialogState = DialogState.Accept;

                    SecondaryButton.Visibility = Visibility.Collapsed;
                    break;
                case MessageBoxType.AcceptIgnore:
                    PrimaryButton.Content = "قبول";
                    PrimaryButtonDialogState = DialogState.Accept;

                    SecondaryButton.Content = "رد";
                    SecondaryButton.Visibility = Visibility.Visible;
                    PrimaryButtonDialogState = DialogState.Ignore;
                    break;
                default:
                    break;
            }

            PrimaryButton.Click += (obj,arg) => MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand.Execute(new DialogResult()
            {
                State = PrimaryButtonDialogState
            }, null);


            SecondaryButton.Click += (obj, arg) => MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand.Execute(new DialogResult()
            {
                State = SecondaryButtonDialogState
            }, null);
        }

        public static MessageBox Build(string Message, MessageBoxType Type)
        {
            MessageBox MessageBox = new MessageBox(Message, Type);
            return MessageBox;
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)

                MaterialDesignThemes.Wpf.DialogHost.CloseDialogCommand.Execute(new DialogResult()
                {
                    State = SecondaryButtonDialogState
                }, null);
        }
    }

    public enum MessageBoxType
    {
        Ok,
        OkCancel,
        YesNo,
        Accept,
        AcceptIgnore
    }    
}
