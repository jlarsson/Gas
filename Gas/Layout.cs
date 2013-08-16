using System;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using R = Android.Resource;

namespace Gas
{
    public class Style : IStyle
    {
        public static IStyle For<TLayout>(Action<View, TLayout> init) where TLayout : ViewGroup.LayoutParams
        {
            return new LambdaStyle<TLayout>(init);
        }

        public class WidthHeight
        {
            public int Width { get; set; }
            public int Height { get; set; }
        }

        public class FrameStyle : IStyle
        {
            public GravityFlags? Gravity { get; set; }

            public void Apply(View view, ViewGroup.LayoutParams layoutParams)
            {
                var lp = layoutParams as FrameLayout.LayoutParams;
                if (lp != null)
                {
                    if (Gravity.HasValue) lp.Gravity = Gravity.Value;
                }
            }
        }

        public class LinearStyle : IStyle
        {
            public GravityFlags? Gravity { get; set; }
            public float? Weight { get; set; }

            public void Apply(View view, ViewGroup.LayoutParams layoutParams)
            {
                var lp = layoutParams as LinearLayout.LayoutParams;
                if (lp != null)
                {
                    if (Gravity.HasValue) lp.Gravity = Gravity.Value;
                    if (Weight.HasValue) lp.Weight = Weight.Value;
                }
            }
        }

        public class MarginStyle : IStyle
        {
            public int? All { get; set; }
            public int? Bottom { get; set; }
            public int? Left { get; set; }
            public int? Right { get; set; }
            public int? Top { get; set; }

            public void Apply(View view, ViewGroup.LayoutParams layoutParams)
            {
                var lp = layoutParams as ViewGroup.MarginLayoutParams;
                if (lp != null)
                {
                    if (All.HasValue)
                    {
                        lp.BottomMargin = lp.LeftMargin = lp.RightMargin = lp.TopMargin = All.Value;
                    }
                    if (Bottom.HasValue) lp.BottomMargin = Bottom.Value;
                    if (Left.HasValue) lp.LeftMargin = Left.Value;
                    if (Right.HasValue) lp.RightMargin = Right.Value;
                    if (Top.HasValue) lp.TopMargin = Top.Value;
                }
            }
        }

        public class PaddingStyle : IStyle
        {
            public int? All { get; set; }
            public int? Bottom { get; set; }
            public int? Left { get; set; }
            public int? Right { get; set; }
            public int? Top { get; set; }

            public void Apply(View view, ViewGroup.LayoutParams layoutParams)
            {
                view.SetPadding(
                    Left.HasValue ? Left.Value : All.HasValue ? All.Value : view.PaddingLeft,
                    Top.HasValue ? Top.Value : All.HasValue ? All.Value : view.PaddingTop,
                    Right.HasValue ? Right.Value : All.HasValue ? All.Value : view.PaddingRight,
                    Bottom.HasValue ? Bottom.Value : All.HasValue ? All.Value : view.PaddingBottom
                    );
            }
        }

        public class RelativeStyle : IStyle
        {
            public int? AlignBaseline { get; set; }
            public int? AlignBottom { get; set; }
            public int? AlignLeft { get; set; }
            public int? AlignRight { get; set; }
            public int? AlignTop { get; set; }

            public bool? AlignParentTop { get; set; }
            public bool? AlignParentLeft { get; set; }
            public bool? AlignParentRight { get; set; }
            public bool? AlignParentBottom { get; set; }
            public bool? CenterHorizontal { get; set; }
            public bool? CenterInParent { get; set; }
            public bool? CenterVertical { get; set; }

            public int? ToLeftOf { get; set; }
            public int? ToRightOf { get; set; }
            public int? Above { get; set; }
            public int? Below { get; set; }

            private void TestAndAddRule(RelativeLayout.LayoutParams lp, int? anchor, LayoutRules layoutRule)
            {
                if (anchor.HasValue) lp.AddRule(layoutRule, anchor.Value);
            }

            private void TestAndAddRule(RelativeLayout.LayoutParams lp, bool? value, LayoutRules layoutRule)
            {
                if (value.HasValue && value.Value) lp.AddRule(layoutRule);
            }

            public void Apply(View view, ViewGroup.LayoutParams layoutParams)
            {
                var lp = layoutParams as RelativeLayout.LayoutParams;
                if (lp != null)
                {
                    TestAndAddRule(lp, AlignBaseline, LayoutRules.AlignBaseline);
                    TestAndAddRule(lp, AlignBottom, LayoutRules.AlignBottom);
                    TestAndAddRule(lp, AlignLeft, LayoutRules.AlignLeft);
                    TestAndAddRule(lp, AlignRight, LayoutRules.AlignRight);
                    TestAndAddRule(lp, AlignTop, LayoutRules.AlignTop);
                    TestAndAddRule(lp, AlignParentTop, LayoutRules.AlignParentTop);
                    TestAndAddRule(lp, AlignParentLeft, LayoutRules.AlignParentLeft);
                    TestAndAddRule(lp, AlignParentRight, LayoutRules.AlignParentRight);
                    TestAndAddRule(lp, AlignParentBottom, LayoutRules.AlignParentBottom);
                    TestAndAddRule(lp, CenterHorizontal, LayoutRules.CenterHorizontal);
                    TestAndAddRule(lp, CenterInParent, LayoutRules.CenterInParent);
                    TestAndAddRule(lp, CenterVertical, LayoutRules.CenterVertical);
                    TestAndAddRule(lp, ToLeftOf, LayoutRules.LeftOf);
                    TestAndAddRule(lp, ToRightOf, LayoutRules.RightOf);
                    TestAndAddRule(lp, Above, LayoutRules.Above);
                    TestAndAddRule(lp, Below, LayoutRules.Below);
                }
            }
        }

        public class RowStyle : IStyle
        {
            public int? Column { get; set; }
            public int? Span { get; set; }

            public void Apply(View view, ViewGroup.LayoutParams layoutParams)
            {
                var lp = layoutParams as TableRow.LayoutParams;
                if (lp != null)
                {
                    if (Column.HasValue) lp.Column = Column.Value;
                    if (Span.HasValue) lp.Span = Span.Value;
                }
            }
        }

        public class TextStyle : IStyle
        {
            public Color? Color { get; set; }
            public bool? Small { get; set; }
            public bool? Medium { get; set; }
            public bool? Large { get; set; }
            public bool? SmallInverse { get; set; }
            public bool? MediumInverse { get; set; }
            public bool? LargeInverse { get; set; }

            private bool Test(bool? b)
            {
                return b.HasValue && b.Value;
            }

            public void Apply(View view, ViewGroup.LayoutParams layoutParams)
            {
                var tv = view as TextView;
                if (tv != null)
                {
                    if (Test(Small)) tv.SetTextAppearance(tv.Context, R.Style.TextAppearanceSmall);
                    if (Test(Medium)) tv.SetTextAppearance(tv.Context, R.Style.TextAppearanceMedium);
                    if (Test(Large)) tv.SetTextAppearance(tv.Context, R.Style.TextAppearanceLarge);
                    if (Test(SmallInverse)) tv.SetTextAppearance(tv.Context, R.Style.TextAppearanceSmallInverse);
                    if (Test(MediumInverse)) tv.SetTextAppearance(tv.Context, R.Style.TextAppearanceMediumInverse);
                    if (Test(LargeInverse)) tv.SetTextAppearance(tv.Context, R.Style.TextAppearanceLargeInverse);
                    if (Color.HasValue) tv.SetTextColor(Color.Value);
                }
            }
        }

        public const int FillParent = ViewGroup.LayoutParams.FillParent;
        public const int MatchParent = ViewGroup.LayoutParams.MatchParent;
        public const int WrapContent = ViewGroup.LayoutParams.WrapContent;
        public static readonly WidthHeight FillFill = new WidthHeight {Width = FillParent, Height = FillParent};
        public static readonly WidthHeight FillWrap = new WidthHeight {Width = FillParent, Height = WrapContent};
        public static readonly WidthHeight WrapWrap = new WidthHeight {Width = WrapContent, Height = WrapContent};
        public static readonly WidthHeight WrapFill = new WidthHeight {Width = WrapContent, Height = FillParent};
        public static readonly WidthHeight MatchMatch = new WidthHeight {Width = MatchParent, Height = MatchParent};
        private FrameStyle _frame;
        private LinearStyle _linear;
        private MarginStyle _margin;
        private PaddingStyle _padding;
        private RelativeStyle _relative;
        private RowStyle _row;
        private TextStyle _text;

        public FrameStyle Frame
        {
            get { return (_frame ?? (_frame = new FrameStyle())); }
        }

        public LinearStyle Linear
        {
            get { return (_linear ?? (_linear = new LinearStyle())); }
        }

        public MarginStyle Margin
        {
            get { return (_margin ?? (_margin = new MarginStyle())); }
        }

        public PaddingStyle Padding
        {
            get { return (_padding ?? (_padding = new PaddingStyle())); }
        }

        public RelativeStyle Relative
        {
            get { return (_relative ?? (_relative = new RelativeStyle())); }
        }

        public RowStyle Row
        {
            get { return (_row ?? (_row = new RowStyle())); }
        }

        public TextStyle Text
        {
            get { return (_text ?? (_text = new TextStyle())); }
        }

        public int? Width { get; set; }
        public int? Height { get; set; }

        public int? MinWidth { get; set; }
        public int? MinHeight { get; set; }

        public void Apply(View view, ViewGroup.LayoutParams layoutParams)
        {
            if (Width.HasValue) layoutParams.Width = Width.Value;
            if (Height.HasValue) layoutParams.Height = Height.Value;
            if (MinHeight.HasValue) view.SetMinimumHeight(MinHeight.Value);
            if (MinWidth.HasValue) view.SetMinimumWidth(MinWidth.Value);

            if (_frame != null) _frame.Apply(view, layoutParams);
            if (_linear != null) _linear.Apply(view, layoutParams);
            if (_margin != null) _margin.Apply(view, layoutParams);
            if (_padding != null) _padding.Apply(view, layoutParams);
            if (_relative != null) _relative.Apply(view, layoutParams);
            if (_row != null) _row.Apply(view, layoutParams);
            if (_text != null) _text.Apply(view, layoutParams);
        }
    }

    public class LambdaStyle<T> : IStyle where T : ViewGroup.LayoutParams
    {
        private readonly Action<View, T> _init;

        public LambdaStyle(Action<View, T> init)
        {
            _init = init;
        }

        public void Apply(View view, ViewGroup.LayoutParams layoutParams)
        {
            var lp = layoutParams as T;
            if (lp != null)
            {
                _init(view, lp);
            }
        }
    }
}