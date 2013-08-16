using System;
using System.Collections.Generic;
using System.Linq;

namespace Gas.Data
{
    public class ListDataBinding<TData> : IListDataBinding<TData>
    {
        private readonly Func<IListElement, TData> _getData;
        private readonly Func<TData, IListElement> _createElement;

        public ListDataBinding(IListElementAdapter adapter, Func<IListElement, TData> getData,
                               Func<TData, IListElement> createElement)
        {
            Adapter = adapter;
            _getData = getData;
            _createElement = createElement;
        }

        public IListElementAdapter Adapter { get; private set; }

        public IList<TData> Data
        {
            get { return Adapter.Elements.Select(_getData).ToList(); }
            set { Adapter.Elements = (value ?? new List<TData>(0)).Select(_createElement).ToList(); }
        }
    }
}