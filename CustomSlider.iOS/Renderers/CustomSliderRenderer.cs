using System;
using System.ComponentModel;
using System.Linq;
using CoreGraphics;
using CustomSlider.iOS.Renderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomSlider.RatingSlider), typeof(CustomSliderRenderer))]
namespace CustomSlider.iOS.Renderers
{
    public class CustomSliderRenderer : ViewRenderer
    {
        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            OnTouchElement(touches, evt);
            base.TouchesBegan(touches, evt);
        }

        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            OnTouchElement(touches, evt);
            base.TouchesMoved(touches, evt);
        }

        void OnTouchElement(NSSet touches, UIEvent evt)
        {
            var slider = (Element as RatingSlider);
            var t = evt.AllTouches.Last() as UITouch;
            CGPoint location = t.LocationInView(this);

            int n = slider.Children.Count;
            double s = slider.ColumnSpacing;
            double w = (this.Bounds.Width - (s * (n - 1))) / n;

            double p = 0;
            double k = w;

            for (double i = 1, j = 0; i <= n; i++, j = j + s)
            {
                if ((location.X >= (p + j)) && (location.X <= (k + j)))
                {
                    slider.SetSelectedPosition((int)i);
                    break;


                }
                p = k;
                k = w * (i + 1);

            }
        }
    }

}
