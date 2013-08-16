using System;
using Android.Views;
using Object = Java.Lang.Object;

namespace Gas
{
    public class OnCreateContextMenuListener : Object, View.IOnCreateContextMenuListener
    {
        public Action<IContextMenu, View, IContextMenuContextMenuInfo> OnCreateContextMenu { get; set; }

        void View.IOnCreateContextMenuListener.OnCreateContextMenu(IContextMenu menu, View v,
                                                                   IContextMenuContextMenuInfo menuInfo)
        {
            if (OnCreateContextMenu != null)
            {
                OnCreateContextMenu(menu, v, menuInfo);
            }
        }
    }
}