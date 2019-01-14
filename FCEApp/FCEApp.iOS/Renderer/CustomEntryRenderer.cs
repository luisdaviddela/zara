using CoreGraphics;
using FCEApp.iOS.Renderer;
using FCEApp.Renderer;
using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace FCEApp.iOS.Renderer
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var view = (CustomEntry)Element;
                Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));

                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
                Control.ReturnKeyType = UIReturnKeyType.Done;
                // Radius for the curves  
                Control.Layer.CornerRadius = Convert.ToSingle(view.CornerRadius);
                // Thickness of the Border Color  
                Control.Layer.BorderColor = view.BorderColor.ToCGColor();
                // Thickness of the Border Width  
                Control.Layer.BorderWidth = view.BorderWidth;
                Control.ClipsToBounds = true;
                if (view != null)
                {
                    SetIcon(view);

                }

            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var view = (CustomEntry)Element;
            //if (e.PropertyName == CustomEntry.IconRightProperty.PropertyName)
            //{
                SetIcon(view);
            //}
        }
        private void SetIcon(CustomEntry view)
        {
            if (!string.IsNullOrEmpty(view.IconLeft))
            {
                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.LeftViewRect(new CGRect(5, 5, 5, 5));
                Control.LeftView = new UIImageView(UIImage.FromBundle(view.IconLeft));
            }

            if (!string.IsNullOrEmpty(view.IconRight))
            {
                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.RightViewRect(new CGRect(5, 5, 5, 5));
                Control.RightView = new UIImageView(UIImage.FromBundle(view.IconRight));
            }

            if (string.IsNullOrEmpty(view.IconLeft) && string.IsNullOrEmpty(view.IconRight))
            {
                Control.LeftViewMode = UITextFieldViewMode.Never;
                Control.LeftView = null;
            }
        }
    }
}