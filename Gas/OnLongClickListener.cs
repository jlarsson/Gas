using System;
using Android.Views;
using Object = Java.Lang.Object;

namespace Gas
{
    public class OnLongClickListener : Object, View.IOnLongClickListener
    {
        public Func<View, bool> OnLongClick { get; set; }

        bool View.IOnLongClickListener.OnLongClick(View v)
        {
            return (OnLongClick != null) && OnLongClick(v);
        }
    }
}