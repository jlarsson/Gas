using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Views;

namespace Gas
{
    public static class Element
    {
        public static IElement<TView> Create<TView>(int w, int h) where TView : View
        {
            return new Element<TView>(w, h);
        }

        public static IElement<TView> Create<TView>(Style.WidthHeight wh) where TView : View
        {
            return new Element<TView>(wh);
        }

        public static IElement<TView> Create<TView>(int w, int h, IEnumerable<IElement> children)
            where TView : ViewGroup
        {
            return new Container<TView>(w, h).AddRange(children);
        }

        public static IElement<TView> Create<TView>(int w, int h, IElement firstChild, params IElement[] children)
            where TView : ViewGroup
        {
            return Create<TView>(w, h, new[] {firstChild}.Concat(children));
        }
    }

    public class Element<TView> : IElement<TView> where TView : View
    {
        private List<Action<TView>> _ensureInitQueue = new List<Action<TView>>();
        private List<IStyle> _styles = new List<IStyle>();

        public Element() : this(ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.WrapContent)
        {
        }

        public Element(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Element(Style.WidthHeight wh) : this(wh.Width, wh.Height)
        {
        }

        public virtual View CreateView(Context context, ViewGroup parent)
        {
            if (View != null)
            {
                throw new GasException("CreateView() may only be called once");
            }

            View = ElementRegistry.CreateView(typeof (TView), context) as TView;

            var layoutParams = ElementRegistry.CreateLayoutParametersForContainer(parent ?? (View as ViewGroup), Width,
                                                                                  Height);
            foreach (var style in _styles)
            {
                style.Apply(View, layoutParams);
            }
            View.LayoutParameters = layoutParams;

            foreach (var initializer in _ensureInitQueue)
            {
                initializer(View);
            }
            _ensureInitQueue = null;
            _styles = null;

            return View;
        }

        public int Width { get; protected set; }
        public int Height { get; protected set; }
        public TView View { get; set; }

        public void AddStyle(IStyle style)
        {
            if (_styles == null)
            {
                throw new GasException("AddStyle)( must be called before CreateView() ");
            }
            if (style != null)
            {
                _styles.Add(style);
            }
        }

        public void EnsureInit(Action<TView> init)
        {
            if (_ensureInitQueue == null)
            {
                init(View);
            }
            else
            {
                _ensureInitQueue.Add(init);
            }
        }
    }
}