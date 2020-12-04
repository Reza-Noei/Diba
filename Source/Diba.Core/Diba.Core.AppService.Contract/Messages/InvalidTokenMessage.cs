using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract
{
    public class InvalidTokenMessage : BaseMessage
    {
        public InvalidTokenMessage() : base("توکن استفاده شده نامعتبر است.")
        {
        }
    }

    public class UserNotFoundMessage : BaseMessage
    {
        public UserNotFoundMessage() : base("کاربر در سامانه پیدا نشد.")
        {
        }
    }

    public class InvalidOrganizationIdMessage : BaseMessage
    {
        public InvalidOrganizationIdMessage() : base("شناسه سازمان نامعتبر است.")
        {
        }
    }

    public class InvalidRoleMessage : BaseMessage
    {
        public InvalidRoleMessage() : base("نقش انتخاب شده نامعتبر است.")
        {
        }
    }

    public class MembershipNotFoundMessage : BaseMessage
    {
        public MembershipNotFoundMessage() : base("عضویت انتخاب شده برای کاربر مورد نظر در سازمان وجود ندارد.")
        {
        }
    }
}
