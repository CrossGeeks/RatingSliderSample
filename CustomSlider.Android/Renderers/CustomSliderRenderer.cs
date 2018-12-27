using System;
using Android.Content;
using Android.Views;
using CustomSlider.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSlider.RatingSlider), typeof(CustomSliderRenderer))]
namespace CustomSlider.Droid.Renderers
{
    public class CustomSliderRenderer : ViewRenderer
    {
        public CustomSliderRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            var touchX = e.GetX();
            var touchY = e.GetY();

            var slider = (Element as RatingSlider);

            int n = slider.Children.Count;
            double s = slider.ColumnSpacing;
            double w = (this.Width - (s * (n - 1))) / n;

            System.Diagnostics.Debug.WriteLine($"{touchX}");

            double p = 0;
            double k = w;
            for (double i = 1, j = 0; i <= n; i++, j = j + s)
            {
                    if ((touchX >= (p + j)) && (touchX <= (k + j)))
                    {
                        slider.SetSelectedPosition((int)i);
                        System.Diagnostics.Debug.WriteLine($"{i}");
                        break;


                    }
                    p = k;
                    k = w * (i + 1);

            }


            return true;
        }

        public override bool OnInterceptTouchEvent(MotionEvent e)
        {

            return true;
        }
    }
}
