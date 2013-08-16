using Android.Views;

namespace Gas
{
    public interface IListElement : IElement
    {
        string TypeTag { get; }
        bool IsReusable { get; }
        bool Enabled { get; }
        void UpdateView(View view);
    }
}