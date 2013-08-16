using System;
using Android.Text;
using Java.Lang;
using Object = Java.Lang.Object;

namespace Gas
{
    public class TextWatcher : Object, ITextWatcher
    {
        public Action<ICharSequence, int, int, int> BeforeTextChanged { get; set; }
        public Action<TextChangedEventArgs> OnTextChanged { get; set; }
        public Action<IEditable> AfterTextChanged { get; set; }

        void ITextWatcher.AfterTextChanged(IEditable s)
        {
            if (AfterTextChanged != null)
            {
                AfterTextChanged(s);
            }
        }

        void ITextWatcher.BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
            if (BeforeTextChanged != null)
            {
                BeforeTextChanged(s, start, count, after);
            }
        }

        void ITextWatcher.OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            if (OnTextChanged != null)
            {
                OnTextChanged(new TextChangedEventArgs(s, start, before, count));
            }
        }
    }
}