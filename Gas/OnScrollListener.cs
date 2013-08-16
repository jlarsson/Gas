using System;
using Android.Widget;
using Object = Java.Lang.Object;

namespace Gas
{
    public class OnScrollListener : Object, AbsListView.IOnScrollListener
    {
        public Action<AbsListView, ScrollState> OnScrollStateChanged { get; set; }
        public Action<AbsListView, int, int, int> OnScroll { get; set; }

        void AbsListView.IOnScrollListener.OnScroll(AbsListView view, int firstVisibleItem, int visibleItemCount,
                                                    int totalItemCount)
        {
            if (OnScroll != null)
            {
                OnScroll(view, firstVisibleItem, visibleItemCount, totalItemCount);
            }
        }

        void AbsListView.IOnScrollListener.OnScrollStateChanged(AbsListView view, ScrollState scrollState)
        {
            if (OnScrollStateChanged != null)
            {
                OnScrollStateChanged(view, scrollState);
            }
        }
    }
}