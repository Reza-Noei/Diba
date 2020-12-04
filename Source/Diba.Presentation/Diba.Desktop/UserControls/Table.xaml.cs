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

            DataGrid.AutoGenerateColumns = true;
            DataGrid.AutoGeneratingColumn += DataGrid_AutoGeneratingColumn;
            DataGrid.IsReadOnly = true;
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
                        if (HeaderAttribute.View == View.Form)
                            e.Column.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }
    }
}
