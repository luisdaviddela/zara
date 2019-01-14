using CoreGraphics;
using FCEApp.iOS.Renderer;
using FCEApp.Renderer;
using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly:ExportRenderer(typeof(CustomPicker),typeof(CustomPickerRenderer))]
namespace FCEApp.iOS.Renderer
{
    public class CustomPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var view = (CustomPicker)Element;
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
            var view = (CustomPicker)Element;
            if (e.PropertyName == CustomPicker.IconProperty.PropertyName)
            {
                SetIcon(view);
            }
        }
        private void SetIcon(CustomPicker view)
        {
            if (!string.IsNullOrEmpty(view.Icon))
            {

                //Control.LeftViewMode = UITextFieldViewMode.Always;
                //Control.LeftViewRect(new CGRect(5, 5, 5, 5));
                //Control.LeftView = new UIImageView(UIImage.FromBundle(view.Icon));
                Control.RightViewMode = UITextFieldViewMode.Always;
                Control.RightViewRect(new CGRect(5, 5, 5, 5));
                Control.RightView = new UIImageView(UIImage.FromBundle(view.Icon));
            }
            else
            {
                Control.LeftViewMode = UITextFieldViewMode.Never;
                Control.LeftView = null;
            }
        }
    }
}