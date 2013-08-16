using System;
using Android.Support.V4.View;
using Object = Java.Lang.Object;

namespace Gas
{
    public class OnPageChangeListener : Object, ViewPager.IOnPageChangeListener
    {
        public Action<int> OnPageScrollStateChanged { get; set; }
        public Action<int, float, float> OnPageScrolled { get; set; }
        public Action<int> OnPageSelected { get; set; }

        void ViewPager.IOnPageChangeListener.OnPageScrollStateChanged(int p0)
        {
            if (OnPageScrollStateChanged != null)
            {
                OnPageScrollStateChanged(p0);
            }
        }

        void ViewPager.IOnPageChangeListener.OnPageScrolled(int p0, float p1, int p2)
        {
            if (OnPageScrolled != null)
            {
                OnPageScrolled(p0, p1, p2);
            }
        }

        void ViewPager.IOnPageChangeListener.OnPageSelected(int pageIndex)
        {
            if (OnPageSelected != null)
            {
                OnPageSelected(pageIndex);
            }
        }
    }
}