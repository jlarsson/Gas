using System;
using Android.Support.V4.View;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Gas;

namespace Gas
{
    public static class ViewExtensions
    {
        /*****************************************************************
         * Traversal
         ****************************************************************/
        public static View FindParentById(this View view, int id)
        {
            var p = view.Parent as View;
            while (p != null)
            {
                if (p.Id == id)
                {
                    return p;
                }
                p = p.Parent as View;
            }
            return null;
        }

        /*****************************************************************
         * General events
         ****************************************************************/
        public static TView OnKey<TView>(this TView view, Func<View, Keycode, KeyEvent, bool> onKey) where TView : View
        {
            view.SetOnKeyListener(new OnKeyListener {OnKey = onKey});
            return view;
        }

        public static TView OnKey<TView>(this TView view, Action<View, Keycode, KeyEvent> onKey) where TView : View
        {
            view.SetOnKeyListener(new OnKeyListener
                                      {
                                          OnKey = (v, c, e) =>
                                                      {
                                                          if (onKey != null)
                                                          {
                                                              onKey(v, c, e);
                                                              return true;
                                                          }
                                                          return false;
                                                      }
                                      });
            return view;
        }
        
        public static TView OnClick<TView>(this TView view, Action<View> onClick) where TView : View
        {
            view.SetOnClickListener(new OnClickListener { OnClick = onClick });
            return view;
        }
        public static TView OnLongClick<TView>(this TView view, Func<View, bool> onLongClick) where TView : View
        {
            view.SetOnLongClickListener(new OnLongClickListener { OnLongClick = onLongClick });
            return view;
        }
        public static TView OnLongClick<TView>(this TView view, Action<View> onLongClick) where TView : View
        {
            view.SetOnLongClickListener(new OnLongClickListener
                                            {
                                                OnLongClick = v =>
                                                                  {
                                                                      if (onLongClick != null)
                                                                      {
                                                                          onLongClick(v);
                                                                          return true;
                                                                      }
                                                                      return false;
                                                                  }
                                            });
            return view;
        }

        /*****************************************************************
         * AdapterView
         ****************************************************************/
        public static TView OnItemClick<TView>(this TView view, Action<int, View> onItemClick) where TView : AdapterView
        {
            view.OnItemClickListener = new OnItemClickListener((i,v,_) => onItemClick(i,v));
            return view;
        }
        public static TView OnLongItemClick<TView>(this TView view, Action<int, View> onItemLongClick) where TView : AdapterView
        {
            view.OnItemLongClickListener = new OnItemLongClickListener((i, v, _) => 
                                                                           {
                                                                               onItemLongClick(i, v);
                                                                               return true;
                                                                           });
            return view;
        }
        public static TView OnLongItemClick<TView>(this TView view, Func<int, View, bool> onItemLongClick) where TView : AdapterView
        {
            view.OnItemLongClickListener = new OnItemLongClickListener((i,v,_) => onItemLongClick(i,v));
            return view;
        }
        public static TView OnItemSelected<TView>(this TView view, Action<int, View> onItemSelected, Action onNothingSelected) where TView : AdapterView
        {
            view.OnItemSelectedListener = new OnItemSelectedListener((i,v,_) => onItemSelected(i,v), onNothingSelected);
            return view;
        }

        public static IElement SelectedElement<TView>(this TView view) where TView: AdapterView
        {
            var holder = view.SelectedItem as ListElementAdapter.ListElementHolder;
            return holder == null ? null : holder.Element;
        }

        /*****************************************************************
         * CompoundButton
         ****************************************************************/
        public static TView OnCheckedChange<TView>(this TView view, Action<CompoundButton, bool> @checked) where TView : CompoundButton
        {
            view.SetOnCheckedChangeListener(new OnCheckedChangeListenerForCompoundButton(@checked));
            return view;
        }

        /*****************************************************************
         * RadioGroup
         ****************************************************************/
        public static TView OnRadioCheckedChange<TView>(this TView view, Action<RadioGroup, int> @checked) where TView : RadioGroup
        {
            view.SetOnCheckedChangeListener(new OnCheckedChangeListenerForRadioGroup(@checked));
            return view;
        }

        /*****************************************************************
         * ViewPager
         ****************************************************************/
        public static TView OnPageChange<TView>(this TView view, Action<int> onPageSelected, Action<int, float, float> onPageScrolled = null, Action<int> onPageScrollStateChanged = null) where TView : ViewPager
        {
            view.SetOnPageChangeListener(new OnPageChangeListener
                                             {
                                                 OnPageSelected = onPageSelected,
                                                 OnPageScrolled = onPageScrolled,
                                                 OnPageScrollStateChanged = onPageScrollStateChanged
                                             });
            return view;
        }

        /*****************************************************************
         * WebView
         ****************************************************************/
        public static TView LoadMarkup<TView>(this TView view, string markup) where TView : WebView
        {
            view.LoadDataWithBaseURL(null,
                                        markup,
                                        "text/html",
                                        "utf-8",
                                        null);
            return view;
        }
    }
}