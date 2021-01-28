using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Diba.Desktop
{
    public class DialogPanel : HeaderedContentControl
    {
        #region static members
        public static readonly DependencyProperty FooterProperty = DependencyProperty.Register("Footer", typeof(object), typeof(DialogPanel), new PropertyMetadata(null));
        public static readonly DependencyProperty ClosedProperty = DependencyProperty.Register("CloseButton", typeof(Button), typeof(DialogPanel), new PropertyMetadata(null));
        #endregion

        #region properties
        public object Footer
        {
            get { return (object)GetValue(FooterProperty); }
            set { SetValue(FooterProperty, value); }
        }
        #endregion

        public delegate void CloseButtonDelegate(object sender, RoutedEventArgs e);
        public event CloseButtonDelegate CloseButtonClick;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            Button CloseButton = this.Template.FindName("CloseButton", this) as Button;
            if (CloseButton != null)
            {
                CloseButton.Click += (s, e) => OnCloseEvent(s, e);
            }
        }

        public Boolean Closed
        {
            get { return (Boolean)base.GetValue(ClosedProperty); }
            set { base.SetValue(ClosedProperty, value); }
        }

        protected virtual void OnCloseEvent(object sender, RoutedEventArgs e)
        {
            CloseButtonClick?.Invoke(sender, e);
        }

        static DialogPanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DialogPanel), new FrameworkPropertyMetadata(typeof(DialogPanel)));
        }

        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);

            //var CurrentParent = this.Parent;
            //while (CurrentParent != null)
            //{
            //    if (CurrentParent is DialogBase)
            //    {
            //        var DialogBase = CurrentParent as DialogBase;
            //        this.CloseButtonClick -= (S, E) =>
            //        {
            //            DialogBase.DialogComplete(this, DialogResult.Cancel);
            //        };

            //        this.CloseButtonClick += (S, E) =>
            //        {
            //            DialogBase.DialogComplete(this, DialogResult.Cancel);
            //        };
            //        break;
            //    }
            //    else
            //    {
            //        CurrentParent = (CurrentParent as FrameworkElement).Parent;
            //    }
            //}
        }

        public DialogPanel()
        {

        }
    }
}
