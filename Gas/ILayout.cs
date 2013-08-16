using Android.Views;

namespace Gas
{
    public interface IStyle
    {
        void Apply(View view, ViewGroup.LayoutParams layoutParams);
    }
}