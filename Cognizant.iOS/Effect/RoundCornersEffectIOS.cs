using System;
using System.ComponentModel;
using CoreAnimation;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Cognizant.UI.Components.Effect;
using Cognizant.iOS.Effect;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(RoundCornersEffectIOS), "RoundCornersEffect")]

namespace Cognizant.iOS.Effect
{
    public class RoundCornersEffectIOS : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                PrepareContainer();
                SetCornerRadius();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnDetached()
        {
            try
            {
                Container.Layer.CornerRadius = new nfloat(0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            if (args.PropertyName == RoundCornersEffect.CornerRadiusProperty.PropertyName)
                SetCornerRadius();
        }

        private void PrepareContainer()
        {
            if (this.Container is null)
            {
                return;
            }
            Container.ClipsToBounds = true;
            Container.Layer.AllowsEdgeAntialiasing = true;
            Container.Layer.EdgeAntialiasingMask = CAEdgeAntialiasingMask.All;
        }

        private void SetCornerRadius()
        {
            var cornerRadius = RoundCornersEffect.GetCornerRadius(Element);
            Container.Layer.CornerRadius = new nfloat(cornerRadius);
        }
    }
}
