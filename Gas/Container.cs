using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Views;

namespace Gas
{
    public class Container<TView> : Element<TView>, IElement<TView>, IContainer<TView> where TView : ViewGroup
    {
        private readonly List<IElement> _children = new List<IElement>();

        public Container()
            : this(ViewGroup.LayoutParams.FillParent, ViewGroup.LayoutParams.FillParent)
        {
        }

        public Container(int width, int height) : base(width, height)
        {
        }

        public Container(Style.WidthHeight wh) : base(wh)
        {
        }

        public IEnumerable<IElement> Children
        {
            get { return _children; }
        }

        public IContainer<TView> Add(IElement child)
        {
            if (child != null)
            {
                _children.Add(child);
            }
            return this;
        }

        public Container<TView> AddRange(IEnumerable<IElement> children)
        {
            _children.AddRange(children.Where(c => c != null));
            return this;
        }

        public override View CreateView(Context context, ViewGroup parent)
        {
            base.CreateView(context, parent);

            foreach (var child in Children)
            {
                View.AddView(child.CreateView(context, View));
            }

            return View;
        }

        public IEnumerator<IElement> GetEnumerator()
        {
            return _children.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}