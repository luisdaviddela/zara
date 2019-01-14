using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using FCEApp.Renderer;
using FCEApp.Droid.Renderer;
using Android.Content;
using Android.Graphics.Drawables;
using System.ComponentModel;
using Android.Util;

[assembly:ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace FCEApp.Droid.Renderer
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        public CustomDatePickerRenderer(Context context) : base(context)
        {
        }
        public async static void Init()
        {
            var temp = DateTime.Now;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var view = (CustomDatePicker)Element;
                if (view.IsCurvedCornersEnabled)
                {
                    // creating gradient drawable for the curved background  
                    var _gradientBackground = new GradientDrawable();
                    _gradientBackground.SetShape(ShapeType.Rectangle);
                    _gradientBackground.SetColor(view.BackgroundColor.ToAndroid());

                    // Thickness of the stroke line  
                    _gradientBackground.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());

                    // Radius for the curves  
                    _gradientBackground.SetCornerRadius(
                        DpToPixels(this.Context, Convert.ToSingle(view.CornerRadius)));

                    // set the background of the   
                    Control.SetBackground(_gradientBackground);
                }
                // Set padding for the internal text from border  
                Control.SetPadding(
                    (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingTop,
                    (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingBottom);
                if (view != null)
                {
                    SetIcon(view);
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var view = (CustomDatePicker)Element;
            if (e.PropertyName == CustomDatePicker.IconProperty.PropertyName)
                SetIcon(view);
        }
        private void SetIcon(CustomDatePicker view)
        {
            if (!string.IsNullOrEmpty(view.Icon))
            {
                try
                {
                    var context = Context;
                    var resId = context.Resources.GetIdentifier(System.IO.Path.GetFileNameWithoutExtension(view.Icon),
                        "drawable", context.PackageName);
                    if (resId != 0)
                    {
                        Control.SetCompoundDrawablesWithIntrinsicBounds(resId, 0, 0, 0);
                        Control.CompoundDrawablePadding = 15;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
            }
        }

        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}
