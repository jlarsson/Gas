using System;
using Android.Content;
using Android.Views;

namespace Gas
{
    public interface IElement
    {
        View CreateView(Context context, ViewGroup parent);
    }

    public interface IElement<TView> : IElement where TView : View
    {
        int Width { get; }
        int Height { get; }
        TView View { get; }
        void AddStyle(IStyle style);
        void EnsureInit(Action<TView> init);
    }
}