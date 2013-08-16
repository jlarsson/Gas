using System;
using System.Collections;
using System.Collections.Generic;
using Android.Graphics;
using Android.Text;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Java.Lang;
using R = Android.Resource;

namespace Gas
{
    public static class ElementExtensions
    {
        /*****************************************************************
         * Initialization
         ****************************************************************/

        public static IElement<TView> Init<TView>(this IElement<TView> element, Action<TView> init) where TView : View
        {
            element.EnsureInit(init);
            return element;
        }

        /*****************************************************************
         * Style, layout and apperance
         ****************************************************************/

        public static IElement<TView> Style<TView>(this IElement<TView> element, IStyle style) where TView : View
        {
            element.AddStyle(style);
            return element;
        }

        public static IElement<TView> Style<TView>(this IElement<TView> element, params IStyle[] styles)
            where TView : View
        {
            if (styles != null)
            {
                foreach (var style in styles)
                {
                    element.AddStyle(style);
                }
            }
            return element;
        }

        /*****************************************************************
         * General
         ****************************************************************/

        public static IElement<TView> Id<TView>(this IElement<TView> element, int id) where TView : View
        {
            return element.Init(v => v.Id = id);
        }

        public static IElement<TView> OnClick<TView>(this IElement<TView> element, Action<View> onClick)
            where TView : View
        {
            return element.Init(v => v.SetOnClickListener(new OnClickListener {OnClick = onClick}));
        }

        public static IElement<TView> OnLongClick<TView>(this IElement<TView> element, Func<View, bool> onLongClick)
            where TView : View
        {
            return element.Init(v => v.SetOnLongClickListener(new OnLongClickListener {OnLongClick = onLongClick}));
        }

        public static IElement<TView> OnLongClick<TView>(this IElement<TView> element, Action<View> onLongClick)
            where TView : View
        {
            return element.OnLongClick(v =>
                                           {
                                               if (onLongClick != null)
                                               {
                                                   onLongClick(v);
                                                   return true;
                                               }
                                               return false;
                                           });
        }

        public static IElement<TView> Visibility<TView>(this IElement<TView> element, ViewStates visibility)
            where TView : View
        {
            return element.Init(v => v.Visibility = visibility);
        }

        public static IElement<TView> OnCreateContextMenu<TView>(this IElement<TView> element,
                                                                 Action<IContextMenu, View, IContextMenuContextMenuInfo>
                                                                     onCreateContextMenu) where TView : View
        {
            return
                element.Init(
                    v =>
                    v.SetOnCreateContextMenuListener(new OnCreateContextMenuListener
                                                         {OnCreateContextMenu = onCreateContextMenu}));
        }

        /*****************************************************************
        * CompoundButton
        ****************************************************************/

        public static IElement<TView> OnCheckedChanged<TView>(this IElement<TView> element,
                                                              Action<CompoundButton, bool> onCheckedChange)
            where TView : CompoundButton
        {
            return element.Init(v => v.SetOnCheckedChangeListener(
                new OnCheckedChangeListenerForCompoundButton
                    {
                        OnCheckedChange = onCheckedChange
                    }));
        }

        /*****************************************************************
         * ImageView
         ****************************************************************/

        public static IElement<TView> ImageResource<TView>(this IElement<TView> element, int resid)
            where TView : ImageView
        {
            return element.Init(v => v.SetImageResource(resid));
        }

        /*****************************************************************
         * LinearLayout
         ****************************************************************/

        public static IElement<TView> Orientation<TView>(this IElement<TView> element, Orientation orientation)
            where TView : LinearLayout
        {
            return element.Init(v => v.Orientation = orientation);
        }

        public static IElement<TView> Horizontal<TView>(this IElement<TView> element) where TView : LinearLayout
        {
            return element.Init(v => v.Orientation = Android.Widget.Orientation.Horizontal);
        }

        public static IElement<TView> Vertical<TView>(this IElement<TView> element) where TView : LinearLayout
        {
            return element.Init(v => v.Orientation = Android.Widget.Orientation.Vertical);
        }

        /*****************************************************************
         * TextView
         ****************************************************************/

        public static IElement<TView> Gravity<TView>(this IElement<TView> element, GravityFlags gravity)
            where TView : TextView
        {
            return element.Init(v => v.Gravity = gravity);
        }

        public static IElement<TView> Email<TView>(this IElement<TView> element) where TView : EditText
        {
            return element.Init(v => v.InputType = InputTypes.ClassText | InputTypes.TextVariationEmailAddress);
        }

        public static IElement<TView> Password<TView>(this IElement<TView> element) where TView : EditText
        {
            return element.Init(v => v.InputType = InputTypes.ClassText | InputTypes.TextVariationPassword);
        }

        public static IElement<TView> SingleLine<TView>(this IElement<TView> element) where TView : EditText
        {
            return element.Init(v => v.SetSingleLine(true));
        }

        public static IElement<TView> MultiLine<TView>(this IElement<TView> element) where TView : TextView
        {
            return element.Init(tv => tv.SetSingleLine(false));
        }

        public static IElement<TView> InputType<TView>(this IElement<TView> element, InputTypes inputType)
            where TView : EditText
        {
            return element.Init(v => v.InputType = inputType);
        }

        public static IElement<TView> Lines<TView>(this IElement<TView> element, int n) where TView : TextView
        {
            return element.Init(v => v.SetLines(n));
        }

        public static IElement<TView> MinLines<TView>(this IElement<TView> element, int n) where TView : TextView
        {
            return element.Init(v => v.SetMinLines(n));
        }

        public static IElement<TView> MaxLines<TView>(this IElement<TView> element, int n) where TView : TextView
        {
            return element.Init(v => v.SetMaxLines(n));
        }

        public static IElement<TView> Text<TView>(this IElement<TView> element, string text) where TView : TextView
        {
            return element.Init(v => v.Text = text);
        }

        public static IElement<TView> Text<TView>(this IElement<TView> element, int resid) where TView : TextView
        {
            return element.Init(v => v.SetText(resid));
        }

        public static IElement<TView> Hint<TView>(this IElement<TView> element, string hint) where TView : TextView
        {
            return element.Init(v => v.Hint = hint);
        }

        public static IElement<TView> Hint<TView>(this IElement<TView> element, int resid) where TView : TextView
        {
            return element.Init(v => v.SetHint(resid));
        }

        public static IElement<TView> TextAppearanceLarge<TView>(this IElement<TView> element) where TView : TextView
        {
            return element.Init(v => v.SetTextAppearance(v.Context, R.Style.TextAppearanceLarge));
        }

        public static IElement<TView> TextAppearanceLargeInverse<TView>(this IElement<TView> element)
            where TView : TextView
        {
            return element.Init(v => v.SetTextAppearance(v.Context, R.Style.TextAppearanceLargeInverse));
        }

        public static IElement<TView> TextAppearanceMedium<TView>(this IElement<TView> element) where TView : TextView
        {
            return element.Init(v => v.SetTextAppearance(v.Context, R.Style.TextAppearanceMedium));
        }

        public static IElement<TView> TextAppearanceMediumInverse<TView>(this IElement<TView> element)
            where TView : TextView
        {
            return element.Init(v => v.SetTextAppearance(v.Context, R.Style.TextAppearanceMediumInverse));
        }

        public static IElement<TView> TextAppearanceSmall<TView>(this IElement<TView> element) where TView : TextView
        {
            return element.Init(v => v.SetTextAppearance(v.Context, R.Style.TextAppearanceSmall));
        }

        public static IElement<TView> TextAppearanceSmallInverse<TView>(this IElement<TView> element)
            where TView : TextView
        {
            return element.Init(v => v.SetTextAppearance(v.Context, R.Style.TextAppearanceSmallInverse));
        }

        public static IElement<TView> TextColor<TView>(this IElement<TView> element, Color color) where TView : TextView
        {
            return element.Init(v => v.SetTextColor(color));
        }

        public static IElement<TView> OnTextChanged<TView>(this IElement<TView> element,
                                                           Action<TextChangedEventArgs> onTextChanged,
                                                           Action<ICharSequence, int, int, int> onBeforeTextChanged =
                                                               null,
                                                           Action<IEditable> onAfterTextChanged = null)
            where TView : TextView
        {
            return element.Init(v => v.AddTextChangedListener(new TextWatcher
                                                                  {
                                                                      BeforeTextChanged = onBeforeTextChanged,
                                                                      OnTextChanged = onTextChanged,
                                                                      AfterTextChanged = onAfterTextChanged
                                                                  }));
        }

        /*****************************************************************
         * WebView
         ****************************************************************/

        public static IElement<TView> Markup<TView>(this IElement<TView> element, string markup) where TView : WebView
        {
            return element.Init(v => v.LoadDataWithBaseURL(null,
                                                           markup,
                                                           "text/html",
                                                           "utf-8",
                                                           null));
        }

        /*****************************************************************
         * AdapterView
         ****************************************************************/

        public static IElement<TView> OnItemClick<TView>(this IElement<TView> element,
                                                         Action<int, View, IListElement> onItemClick)
            where TView : AdapterView
        {
            return element.Init(v => v.OnItemClickListener = new OnItemClickListener
                                                                 {
                                                                     OnItemClick = onItemClick,
                                                                 });
        }

        public static IElement<TView> OnLongItemClick<TView>(this IElement<TView> element,
                                                             Func<int, View, IListElement, bool> onItemLongClick)
            where TView : AdapterView
        {
            return
                element.Init(
                    v => v.OnItemLongClickListener = new OnItemLongClickListener {OnItemLongClick = onItemLongClick});
        }

        public static IElement<TView> OnLongItemClick<TView>(this IElement<TView> element,
                                                             Action<int, View, IListElement> onItemLongClick)
            where TView : AdapterView
        {
            return element.OnLongItemClick(onItemLongClick == null
                                               ? null
                                               : (Func<int, View, IListElement, bool>) ((p, v, e) =>
                                                                                            {
                                                                                                onItemLongClick(p, v,
                                                                                                                e);
                                                                                                return true;
                                                                                            }));
        }

        public static IElement<TView> OnItemSelected<TView>(this IElement<TView> element,
                                                            Action<int, View, IListElement> onItemSelected,
                                                            Action onNothingSelected = null) where TView : AdapterView
        {
            return element.Init(v => v.OnItemSelectedListener = new OnItemSelectedListener
                                                                    {
                                                                        OnItemSelected = onItemSelected,
                                                                        OnNothingSelected = onNothingSelected
                                                                    });
        }

        /*****************************************************************
         * ListView
         ****************************************************************/

        public static IElement<TView> Adapter<TView>(this IElement<TView> element, IListAdapter adapter)
            where TView : AbsListView
        {
            return element.Init(v => v.Adapter = adapter);
        }

        public static IElement<TView> Adapter<TView>(this IElement<TView> element, IEnumerable<IListElement> elements)
            where TView : AbsListView
        {
            return element.Adapter(new ListElementAdapter(elements));
        }

        public static IElement<TView> Adapter<TView>(this IElement<TView> element, params IListElement[] elements)
            where TView : AbsListView
        {
            return element.Adapter(new ListElementAdapter(elements));
        }

        public static IElement<TView> OnScroll<TView>(this IElement<TView> element,
                                                      Action<AbsListView, int, int, int> onScroll,
                                                      Action<AbsListView, ScrollState> onScrollStateChanged = null)
            where TView : AbsListView
        {
            return element.Init(v => v.SetOnScrollListener(new OnScrollListener
                                                               {
                                                                   OnScroll = onScroll,
                                                                   OnScrollStateChanged = onScrollStateChanged
                                                               }));
        }

        /*****************************************************************
         * Spinner
         ****************************************************************/

        public static IElement<TView> Adapter<TView>(this IElement<TView> element, IList values)
            where TView : AbsSpinner
        {
            return element.Init(v =>
                                    {
                                        var adapter = new ArrayAdapter(v.Context, R.Layout.SimpleSpinnerItem, values);
                                        adapter.SetDropDownViewResource(R.Layout.SimpleSpinnerDropDownItem);
                                        v.Adapter = adapter;
                                    });
        }
    }
}