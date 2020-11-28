using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract.ViewModels
{
    public class UserViewModel: BaseViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
