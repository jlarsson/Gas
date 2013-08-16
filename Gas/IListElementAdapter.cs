using System.Collections.Generic;
using Android.Widget;

namespace Gas
{
    public interface IListElementAdapter : IListAdapter, ISpinnerAdapter
    {
        IList<IListElement> Elements { get; set; }
        void Invalidate();
    }
}