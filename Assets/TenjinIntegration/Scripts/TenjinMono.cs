using System;
using UnityEngine;
#if UNITY_IOS
using UnityEngine.iOS;
#endif

namespace TenjinIntegration.Scripts
{
    public class TenjinMono : MonoBehaviour
    {
        [SerializeField] private string apiKey;
        private static BaseTenjin _instance;

        private void Awake()
        {
            if(_instance == null)
                DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            TenjinConnect();
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (!pauseStatus) TenjinConnect();
        }

        private void TenjinConnect()
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                Debug.LogError("Tenjin Api Key is null or empty");
                return;
            }
            _instance = Tenjin.getInstance(apiKey.Trim());
#if UNITY_IOS
            if (new Version(Device.systemVersion).CompareTo(new Version("14.0")) >= 0)
                // Tenjin wrapper for requestTrackingAuthorization
                _instance.RequestTrackingAuthorizationWithCompletionHandler(status =>
                {
                    Debug.Log("===> App Tracking Transparency Authorization Status: " + status);

                    // Sends install/open event to Tenjin
                    _instance.Connect();
                });
            else
                return;
            // Registers SKAdNetwork app for attribution
            _instance.RegisterAppForAdNetworkAttribution();
#endif
#if UNITY_ANDROID
            //Keep if game is uploaded to google play store
            _instance.SetAppStoreType(AppStoreType.googleplay);
#endif 
            //Until you set a privacy policy use OptOut then switch to prompt to store the user request for OptIn
            _instance.OptOut();
            // Sends install/open event to Tenjin
            _instance.Connect();
        }

        public static void SendTenjinEvent(string eventName, string eventValue = "")
        {
            if (_instance == null)
            {
                Debug.LogError("Tenjin Instance is null");
                return;
            }
            _instance.SendEvent(eventName, eventValue);
        }
    }
}