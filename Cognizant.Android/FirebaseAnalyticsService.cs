using System.Collections.Generic;
using Android.OS;
using Cognizant.AppServices.Contracts;
using Firebase.Analytics;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(Cognizant.Android.FirebaseAnalyticsService))]
namespace Cognizant.Android
{
    public class FirebaseAnalyticsService : IFirebaseAnalytics
    {
        public void SendEvent(string eventId)
        {
            SendEvent(eventId, null);
        }

        public void SendEvent(string eventId, string paramName, string value)
        {
            SendEvent(eventId, new Dictionary<string, string>
            {
                {paramName, value}
            });
        }

        public void SendEvent(string eventId, IDictionary<string, string> parameters)
        {
            var fireBaseAnalytics = FirebaseAnalytics.GetInstance(CrossCurrentActivity.Current.AppContext);

            var eventToLog = eventId.Replace(' ', '_');

            if (parameters == null)
            {
                fireBaseAnalytics.LogEvent(eventToLog, null);
                return;
            }

            var bundle = new Bundle();
            foreach (var param in parameters)
            {
                bundle.PutString(param.Key, param.Value);
            }

            fireBaseAnalytics.LogEvent(eventToLog, bundle);
        }
    }
}
