using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract
{
    public class DisplayHeaderAttribute : Attribute
    {
        public string Text { get; set; }
        public View View { get; set; }
        public DisplayHeaderAttribute(string text, View view)
        {
            Text = text;
            View = view;
        }
    }
}
