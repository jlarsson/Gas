using System;
using Android.Views;
using Object = Java.Lang.Object;

namespace Gas
{
    public class OnKeyListener : Object, View.IOnKeyListener
    {
        public Func<View, Keycode, KeyEvent, bool> OnKey { get; set; }

        bool View.IOnKeyListener.OnKey(View v, Keycode keyCode, KeyEvent e)
        {
            return (OnKey != null) && OnKey(v, keyCode, e);
        }
    }
}