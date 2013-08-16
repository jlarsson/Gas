using System.Collections.Generic;
using Android.Views;

namespace Gas
{
    public interface IContainer : IElement
    {
    }

    public interface IContainer<TView> : IElement<TView>, IContainer, IEnumerable<IElement> where TView : ViewGroup
    {
        IEnumerable<IElement> Children { get; }
        IContainer<TView> Add(IElement child);
    }
}