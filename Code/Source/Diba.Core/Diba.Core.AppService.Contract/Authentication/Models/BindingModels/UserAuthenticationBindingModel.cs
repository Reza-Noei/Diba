using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract.BindingModels
{
    public class UserAuthenticationBindingModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
