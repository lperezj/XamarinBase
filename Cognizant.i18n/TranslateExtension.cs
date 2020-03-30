using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cognizant.i18n
{
    [ContentProperty("Value")]
    public class TranslateExtension : IMarkupExtension
    {
        private static readonly string ResourceFullName = $"{typeof(Common).FullName}";

        public string Value { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return Value is null ? null : Translate(Value);
        }

        public static string Translate(string requestedValue)
        {
            var resourceManager = new ResourceManager(ResourceFullName, typeof(TranslateExtension).GetTypeInfo().Assembly);
            var foundedValue = resourceManager.GetString(requestedValue, CultureInfo.CurrentCulture);
            return foundedValue ?? requestedValue;
        }
    }
}
