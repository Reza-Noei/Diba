using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diba.Desktop.Common
{
    public class DialogResult
    {
        public DialogState State { get; set; }
    }

    public enum DialogState
    {
        Ok,
        Cancel,
        Yes, 
        No ,
        Accept,
        Ignore ,
    }
}
