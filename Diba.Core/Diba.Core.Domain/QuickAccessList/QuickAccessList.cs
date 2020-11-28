using System.Collections.Generic;

namespace Diba.Core.Domain
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

    public class QuickAccessList
    {
        public long Id { get; set; }

        public QuickAccessListType Type { get; set; }

        public virtual ICollection<QName> Items { get; set; }

        public QuickAccessList()
        {
            Items = new HashSet<QName>();
        }
    }

    public class QName
    {
        public long Id { get; set; }

        public string Title { get; set; }
    }
}
