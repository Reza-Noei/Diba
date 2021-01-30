using Diba.Core.AppService.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract
{
    public class IncorrectUsernameOrPasswordMessage : BaseMessage
    {
        public IncorrectUsernameOrPasswordMessage(): base("نام کاربری یا رمز عبور اشتباه است.") 
        {
            
        }
    }
}
