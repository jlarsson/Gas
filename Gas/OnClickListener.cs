using System;
using Android.Views;
using Object = Java.Lang.Object;

namespace Gas
{
    public class OnClickListener : Object, View.IOnClickListener
    {
        public Action<View> OnClick { get; set; }

        void View.IOnClickListener.OnClick(View v)
        {
            if (OnClick != null)
            {
                OnClick(v);
            }
        }
    }
}