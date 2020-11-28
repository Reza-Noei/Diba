using System;
using System.Collections.Generic;
using System.Text;

namespace Diba.Core.AppService.Contract
{
    public enum QuickAccessListType
    {
        CustomerGroup = 1, // گروه مشتری
        ServiceType = 2, // نوع کالا یا خدمت
        District = 2,  // محله
        NamePrefix = 3, // نام پیشفرض
        Color = 4, // رنگ
        WashingType = 5, // نوع شستشو
        Deformations = 6,  // عیوب    
        Metric = 7
    }
}
