using System.Collections.Generic;

namespace Gas.Data
{
    public interface IListDataBinding<T>
    {
        IListElementAdapter Adapter { get; }
        IList<T> Data { get; set; }
    }
}