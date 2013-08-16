using System.Collections.Generic;
using System.Linq;
using Android.Database;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace Gas
{
    public class ListElementAdapter : Object, IListAdapter, ISpinnerAdapter, IListElementAdapter
    {
        private IList<IListElement> _elements;
        private readonly ListElementAdapterViewTypes _viewTypes = new ListElementAdapterViewTypes();

        private readonly List<DataSetObserver> _observers = new List<DataSetObserver>();

        public class ListElementHolder : Object
        {
            public IListElement Element { get; set; }
        }

        public IList<IListElement> Elements
        {
            get { return GetElements(); }
            set { SetElements(value); }
        }

        public void Invalidate()
        {
            foreach (var dataSetObserver in _observers)
            {
                dataSetObserver.OnInvalidated();
            }
        }

        private void SetElements(IList<IListElement> value)
        {
            _elements = value ?? new List<IListElement>();
            _viewTypes.Upgrade(_elements.Select(element => element.TypeTag).Distinct());

            foreach (var dataSetObserver in _observers)
            {
                //dataSetObserver.OnInvalidated();
                dataSetObserver.OnChanged();
            }
        }

        private IList<IListElement> GetElements()
        {
            return _elements;
        }

        public ListElementAdapter(int reservedViewTypes = 1) : this(reservedViewTypes, new List<IListElement>())
        {
        }

        public ListElementAdapter(IEnumerable<IListElement> elements) : this(1, elements.ToList())
        {
        }

        public ListElementAdapter(IList<IListElement> elements) : this(1, elements)
        {
        }

        public ListElementAdapter(int reservedViewTypes, IList<IListElement> elements)
        {
            _viewTypes = new ListElementAdapterViewTypes(reservedViewTypes);
            SetElements(elements);
        }

        public Object GetItem(int position)
        {
            return new ListElementHolder {Element = _elements[position]};
        }

        public long GetItemId(int position)
        {
            return position;
        }

        public int GetItemViewType(int position)
        {
            return _viewTypes.GetViewType(_elements[position].TypeTag);
        }

        public View GetView(int position, View convertView, ViewGroup parent)
        {
            var element = _elements[position];
            var view = ((convertView == null) || !element.IsReusable)
                           ? element.CreateView(parent.Context, parent)
                           : convertView;
            element.UpdateView(view);
            return view;
        }

        public void RegisterDataSetObserver(DataSetObserver observer)
        {
            _observers.Add(observer);
        }

        public void UnregisterDataSetObserver(DataSetObserver observer)
        {
            _observers.Remove(observer);
        }

        public int Count
        {
            get { return _elements.Count; }
        }

        public bool HasStableIds
        {
            get { return true; }
        }

        public bool IsEmpty
        {
            get { return _elements.Count == 0; }
        }

        public int ViewTypeCount
        {
            get { return _viewTypes.GetViewTypeCount(); }
        }

        public View GetDropDownView(int position, View convertView, ViewGroup parent)
        {
            return GetView(position, convertView, parent);
        }

        public bool AreAllItemsEnabled()
        {
            return _elements.All(element => element.Enabled);
        }

        public bool IsEnabled(int position)
        {
            return _elements[position].Enabled;
        }
    }
}