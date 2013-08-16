using System;
using Android.Views;
using Android.Widget;
using Object = Java.Lang.Object;

namespace Gas
{
    public class OnItemSelectedListener : Object, AdapterView.IOnItemSelectedListener
    {
        public Action<int, View, IListElement> OnItemSelected { get; set; }
        public Action OnNothingSelected { get; set; }

        void AdapterView.IOnItemSelectedListener.OnItemSelected(AdapterView parent, View view, int position, long id)
        {
            if (OnItemSelected != null)
            {
                var holder = parent.GetItemAtPosition(position) as ListElementAdapter.ListElementHolder;
                OnItemSelected(position, view, holder == null ? null : holder.Element);
            }
        }

        void AdapterView.IOnItemSelectedListener.OnNothingSelected(AdapterView parent)
        {
            if (OnNothingSelected != null)
            {
                OnNothingSelected();
            }
        }
    }
}