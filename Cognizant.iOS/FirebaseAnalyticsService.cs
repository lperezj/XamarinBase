using System.Collections.Generic;
using Cognizant.AppServices.Contracts;
using Firebase.Analytics;
using Foundation;
using Xamarin.Forms;

[assembly: Dependency(typeof(Core.iOS.FirebaseAnalyticsService))]
namespace Core.iOS
{
    public class FirebaseAnalyticsService : IFirebaseAnalytics
    {
        public void SendEvent(string eventId)
        {
            SendEvent(eventId, (IDictionary<string, string>)null);
        }

        public void SendEvent(string eventId, string paramName, string value)
        {
            SendEvent(eventId, new Dictionary<string, string>
            {
                { paramName, value }
            });
        }

        public void SendEvent(string eventId, IDictionary<string, string> parameters)
        {
            var eventToLog = eventId.Replace(' ', '_');
            if (parameters == null)
            {
                Analytics.LogEvent(eventToLog, (Dictionary<object, object>)null);
                return;
            }

            var keys = new List<NSString>();
            var values = new List<NSString>();
            foreach (var item in parameters)
            {
                keys.Add(new NSString(item.Key));
                values.Add(new NSString(item.Value));
            }

            var parametersDictionary =
                NSDictionary<NSString, NSObject>.FromObjectsAndKeys(values.ToArray(), keys.ToArray(), keys.Count);
            Analytics.LogEvent(eventToLog, parametersDictionary);
        }
    }
}
