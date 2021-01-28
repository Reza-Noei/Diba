using Diba.Core.AppService.Contract;
using Diba.Desktop.Page;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for Table.xaml
    /// </summary>
    public partial class Table
    {
        public int CurrentPage { get; set; }
        public int LastPage { get; set; }
        Type ElementsType;
        public Table()
        {
            InitializeComponent();

            DataGrid.AutoGenerateColumns = false;
            DataGrid.IsReadOnly = true;
            DataGrid.PreviewMouseWheel += DataGrid_PreviewMouseWheel;
        }

        // TODO: This Code will Ignores Scrolls on the current DataGrid. 
        // First Problem of this Code is that it's not calibrated.
        // If you scroll over an DataGrid using this code it will jumps over whole DataGrid by a few scrolling.
        // Second problem is optimization. This code is not optimal. 
        // we should find all scrollviewer parrent on initialization time not on event triggering.
        private void DataGrid_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (sender is FrameworkElement Element)
            {
                FrameworkElement Pointer = Element;
                while (Pointer.Parent != null)
                {
                    if (Pointer.Parent is FrameworkElement ParentElement)
                    {
                        if (ParentElement is ScrollViewer Scroll)
                        {
                            Scroll.ScrollToVerticalOffset(Scroll.VerticalOffset - e.Delta);
                        }

                        Pointer = ParentElement;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public void SetContextMenu(ContextMenu ContextMenu)
        {
            var DataGridRowStyle = new Style(typeof(DataGridRow));
            DataGridRowStyle.Setters.Add(new Setter(DataGridRow.ContextMenuProperty, ContextMenu));
            DataGrid.ItemContainerStyle = DataGridRowStyle;
        }

        public void ConsumeData<T>(IEnumerable<T> Data)
        {
            ElementsType = typeof(T);
            DataGrid.ItemsSource = Data;
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var Property = ElementsType.GetProperties().Where(P => P.Name == e.Column.Header.ToString()).FirstOrDefault();            
            if (Property != null)
            {
                object[] Attributes = Property.GetCustomAttributes(true);
                foreach (object Attribute in Attributes)
                {
                    DisplayHeaderAttribute HeaderAttribute = Attribute as DisplayHeaderAttribute;
                    if (HeaderAttribute != null)
                    {
                        e.Column.Header = HeaderAttribute.Text;
                        if (HeaderAttribute.View == View.Form || HeaderAttribute.View == View.None)
                            e.Column.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }
    }
}
