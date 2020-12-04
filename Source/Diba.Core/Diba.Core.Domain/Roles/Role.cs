using Diba.Core.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.Domain
{
    public enum RoleEnum
    {
        SuperAdmin,
        Admin,
        Secretary,
        Collector,
        Delivery,
        Customer
    }

    public class BaseRole
    {
        public long Id { get; set; }
        public string Title { get; }

        public long UserId { get; set; }
        public virtual User User { get; set; }
                
        public BaseRole(RoleEnum Role): this()
        {
            Title = Role.ToString("g");
        }

        public BaseRole()
        {

        }
    }
}
