using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract
{
    public class BaseMessage
    {
        public BaseMessage(string Text)
        {
            this.Text = Text;
        }

        public string Text { get; set; }
    }
}
