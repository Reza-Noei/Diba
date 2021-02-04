using Diba.Desktop.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Diba.Desktop.Common
{
    public delegate void RedirectToEventHandler(FormBase Page);
    public delegate void ShowChildPageEventHandler(FormBase Page);
    public delegate void CloseChildPageEventHandler(FormBase DialogPage, PageResult Result);

    public enum PageResult
    {
        OK,
        Cancel,
        Aborted,
        Yes,
        No,
        Ignore
    };

    public class FormBase : UserControl
    {
        public event RedirectToEventHandler OnRedirectTo;

        public FormBase()
        {
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
                return;
        }

        /// <summary>
        /// با فراخوانی این رویداد هر زیر صفحه میتواند فرمان هدایت به زیر صفحه ی دیگر را به مدیر صفحات ارسال کند
        /// برای اینکه بتوانیم در کلاس های فرزند این رویداد تحریک کنیم این متد را طراحی کردیم
        /// </summary>
        /// <param name="Page">صفحه ای که میخواهیم به آن منتقل شویم.</param>
        public void RedirectTo(FormBase Page)
        {
            OnRedirectTo?.Invoke(Page);
        }

        public event ShowChildPageEventHandler OnShowChild;
        /// <summary>
        /// برای نمایش یک زیر صفحه از جنس فرزند از این رویداد استفاده میشود
        /// برای اینکه بتوانیم در کلاس های فرزند این رویداد تحریک کنیم این متد را طراحی کردیم
        /// </summary>
        /// <param name="Page">صفحه فرزند</param>
        public void ShowChild(FormBase Page)
        {
            OnShowChild?.Invoke(Page);
        }

        public event CloseChildPageEventHandler OnClosePageAsChild;
        /// <summary>
        /// صفحاتی که در آنها خاصیت 
        /// IsChild = True
        /// است باید این رخداد را در محل مناسب فراخوانی کنند.
        /// برای اینکه بتوانیم در کلاس های فرزند این رویداد تحریک کنیم این متد را طراحی کردیم
        /// </summary>
        /// <param name="Page">صفحه جاری</param>
        /// <param name="Result">نتیجه صفحه</param>
        public void ClosePageAsChild(FormBase Page, PageResult Result)
        {
            OnClosePageAsChild?.Invoke(Page, Result);
        }

        /// <summary>
        /// اگر زیر صفحه از جنس فرزند باشد این مقدار در مدیر صفحات مقدار صحیح میگیرد
        /// </summary>
        public bool IsChild { get; set; }
    }
}