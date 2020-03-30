using System.ComponentModel;
using Android.Graphics;
using Android.Views;
using Cognizant.Android.Effect;
using Cognizant.UI.Components.Effect;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(RoundCornersEffectDroid), "RoundCornersEffect")]

namespace Cognizant.Android.Effect
{
    public class RoundCornersEffectDroid : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Container != null)
            {
                PrepareContainer();
                SetCornerRadius();
            }
        }

        protected override void OnDetached()
        {
            if (Container != null)
            {
                Container.OutlineProvider = ViewOutlineProvider.Background;
            }
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == RoundCornersEffect.CornerRadiusProperty.PropertyName)
                SetCornerRadius();
        }

        private void PrepareContainer()
        {
            Container.ClipToOutline = true;
        }

        private void SetCornerRadius()
        {
            var cornerRadius = RoundCornersEffect.GetCornerRadius(Element) * GetDensity();
            Container.OutlineProvider = new RoundedOutlineProvider(cornerRadius);
        }

        private static float GetDensity() =>
            (float)DeviceDisplay.MainDisplayInfo.Density;

        private class RoundedOutlineProvider : ViewOutlineProvider
        {
            private readonly float _radius;

            public RoundedOutlineProvider(float radius)
            {
                _radius = radius;
            }

            public override void GetOutline(global::Android.Views.View view, Outline outline)
            {
                outline?.SetRoundRect(0, 0, view.Width, view.Height, _radius);
            }
        }
    }
}
