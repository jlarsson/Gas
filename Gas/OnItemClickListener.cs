using System;
using Android.Views;
using Android.Widget;
using Object = Java.Lang.Object;

namespace Gas
{
    public class OnItemClickListener : Object, AdapterView.IOnItemClickListener
    {
        public Action<int, View, IListElement> OnItemClick { get; set; }

        void AdapterView.IOnItemClickListener.OnItemClick(AdapterView parent, View view, int position, long id)
        {
            if (OnItemClick != null)
            {
                var holder = parent.GetItemAtPosition(position) as ListElementAdapter.ListElementHolder;
                OnItemClick(position, view, holder == null ? null : holder.Element);
            }
        }
    }
}