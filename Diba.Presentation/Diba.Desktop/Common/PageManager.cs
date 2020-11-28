using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Diba.Desktop.Common
{
    /// <summary>
    /// این کلاس وظیفه مدیریت صفحه را دارد. صفحاتی که حاوی زیر صفحه هستند میتوانند از این کلاس برای مدیریت زیر صفحات خود استفاده کنند.
    /// صفحات والد میتوانند به نمایش و نظم زیر صفحات اعمال نفوذ کنند.
    /// زیر صفحات میتوانند صفحاتی را که نقش فرزندی برای آن ها دارد را از طریق رویداد مربوطه به مدیر صفحه اعلان کنند تا صفحه مورد نظر به پشته ی صفحات آن زیر صفحه اضافه شود.
    /// برای زیر صفحه لفظ پشته وجود دارد. به این معنا که زیر صفحه میتواند تا چندین نسل فرزند ایجاد کند. مدیر صفحه از جانب صفحه ی اصلی برای زیر صفحه یک پشته در نظر میگیرد
    /// علاوه بر این خود زیر صفحه نیز قادر است، جانشین خود را معرفی کند. این کار از طریق رخداد تغییر مسیر (ری دایرکت) امکانپذیر است
    /// تغییر مسیر در زیر صفحه پشته ی مربوط به نسل آن زیر صفحه را پاکسازی میکند
    /// ** برای مطالعه جزئیات عملکرد. مستندات رویه ها و واسط آی پیج را مطالعه نمائید
    /// </summary>
    internal class PageManager
    {
        #region Private Members ... 
        /// <summary>
        /// محل قرارگیری زیر صفحه
        /// </summary>
        private Grid MainGrid { get; set; }

        /// <summary>
        /// پشته ی فرزندان یک زیر صفحه
        /// </summary>
        private Stack<FormBase> PageStack { get; set; }
        #endregion

        public PageManager(Grid MainGrid)
        {
            this.MainGrid = MainGrid;
            PageStack = new Stack<FormBase>();
        }


        /// <summary>
        /// این رویه مسئول پر کردن جایگاه نمایش زیر صفحه با صفحه معرفی شده است.
        /// </summary>
        /// <param name="Page">زیر صفحه یا فرزند جانشین</param>
        /// <param name="ClearStack">اگر بخواهیم زیر صفحه جایگزین کنیم پشته ی نسل قبلی باید پاک شود. اگر بخواهیم فرزند اضافه کنیم نباید پشته نسل جاری را پاک کنیم.</param>
        private void ShowPage(FormBase Page, bool ClearStack)
        {
            if (ClearStack)
            {
                PageStack.Clear();
            }

            // برای جلوگیری از کلیک های متعدد ابتدا فرم را غیر فعال میکنیم
            MainGrid.IsEnabled = false;

            Page.OnRedirectTo -= Page_RedirectTo;
            Page.OnRedirectTo += Page_RedirectTo;
            Page.OnShowChild -= Page_ShowChildPage;
            Page.OnShowChild += Page_ShowChildPage;
            Page.OnClosePageAsChild -= Page_CloseChildPage;
            Page.OnClosePageAsChild += Page_CloseChildPage;

            PageStack.Push(Page);

            // TODO: باید تمام کنترل های گرید اصلی بجز دیالوگ جدید ما غیر فعال و پس از خروج از دیالوگ فعال شوند

            var fade = new DoubleAnimation()
            {
                From = 1,
                To = 0,
                Duration = TimeSpan.FromMilliseconds(300),
            };

            Storyboard.SetTarget(fade, MainGrid);
            Storyboard.SetTargetProperty(fade, new PropertyPath(UIElement.OpacityProperty));

            var sb = new Storyboard();
            sb.Children.Add(fade);
            sb.Completed += (sender, e) =>
            {
                MainGrid.Children.Clear();
                MainGrid.Children.Add(Page);

                // پس از اتمام عملیات فرم را فعال میکنیم.
                MainGrid.IsEnabled = true;

                var Fade2 = new DoubleAnimation()
                {
                    From = 0,
                    To = 1,
                    Duration = TimeSpan.FromMilliseconds(300),
                };

                Storyboard.SetTarget(Fade2, MainGrid);
                Storyboard.SetTargetProperty(Fade2, new PropertyPath(UIElement.OpacityProperty));

                var Sb2 = new Storyboard();
                Sb2.Children.Add(Fade2);
                Sb2.Begin();
            };
            sb.Begin();

        }


        /// <summary>
        /// هرگاه یک زیر صفحه از جنس فرزند بسته شود باید از پشته حذف شود و زیر صفحه پیشین جایگزین شود.
        /// </summary>
        /// <param name="DialogPage">فرزند بسته شده</param>
        /// <param name="Result">نتیجه اجرای فرزند</param>
        private void Page_CloseChildPage(FormBase DialogPage, PageResult Result)
        {
            if (PageStack != null)
            {
                if (PageStack.Count > 0)
                {
                    var Page = PageStack.Pop();
                    ShowPage(PageStack.Peek(), false);
                }
            }
        }


        /// <summary>
        /// برای نمایش فرزند؛ زیر صفحات این رویداد را فراخوانی میکنند.
        /// </summary>
        /// <param name="Page">فرزند نسل بعدی</param>
        private void Page_ShowChildPage(FormBase Page)
        {
            Page.IsChild = true;
            ShowPage(Page, false);
        }


        /// <summary>
        /// هر گاه یک زیر صفحه بخواهد به کار خود خاتمه دهد و با زیر صفحه ی دیگری جایگزین شود این رویداد را فراخوانی میکند
        /// </summary>
        /// <param name="Page">زیر صفحه مقصد</param>
        private void Page_RedirectTo(FormBase Page)
        {
            ShowPage(Page, true);
        }


        /// <summary>
        /// هرگاه صفحه اصلی بخواهد در نظم نمایش صفحات دست ببرد از این متد استفاده میکند.
        /// </summary>
        /// <param name="TargetPage">زیر صفحه مقصد</param>
        public void RedirectPage(FormBase TargetPage)
        {
            ShowPage(TargetPage, true);
        }
    }
}
