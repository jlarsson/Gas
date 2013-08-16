using System;
using Android.Views;
using Android.Widget;
using Object = Java.Lang.Object;

namespace Gas
{
    public class OnItemLongClickListener : Object, AdapterView.IOnItemLongClickListener
    {
        public Func<int, View, IListElement, bool> OnItemLongClick { get; set; }

        bool AdapterView.IOnItemLongClickListener.OnItemLongClick(AdapterView parent, View view, int position, long id)
        {
            if (OnItemLongClick != null)
            {
                var holder = parent.GetItemAtPosition(position) as ListElementAdapter.ListElementHolder;
                return OnItemLongClick(position, view, holder == null ? null : holder.Element);
            }
            return false;
        }
    }
}