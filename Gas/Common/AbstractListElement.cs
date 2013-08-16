using Android.Content;
using Android.Views;

namespace Gas.Common
{
    public abstract class AbstractListElement : IListElement
    {
        protected AbstractListElement()
        {
            TypeTag = GetType().Name;
            IsReusable = true;
            Enabled = true;
        }

        public string TypeTag { get; set; }
        public bool IsReusable { get; set; }
        public bool Enabled { get; set; }

        public abstract View CreateView(Context context, ViewGroup parent);
        public abstract void UpdateView(View view);
    }
}