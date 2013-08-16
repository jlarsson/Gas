using System;
using Android.Widget;
using Object = Java.Lang.Object;

namespace Gas
{
    public class OnCheckedChangeListenerForRadioGroup : Object, RadioGroup.IOnCheckedChangeListener
    {
        public Action<RadioGroup, int> OnCheckedChanged { get; set; }

        void RadioGroup.IOnCheckedChangeListener.OnCheckedChanged(RadioGroup @group, int checkedId)
        {
            if (OnCheckedChanged != null)
            {
                OnCheckedChanged(@group, checkedId);
            }
        }
    }
}