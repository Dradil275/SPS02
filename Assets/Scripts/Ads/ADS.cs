using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADS : MonoBehaviour
{
    string bannerAdUnitId = "9971c382aa2bf12d"; // Retrieve the ID from your account

    // Start is called before the first frame update
    void Start()
    {
        MaxSdkCallbacks.OnSdkInitializedEvent += (MaxSdkBase.SdkConfiguration sdkConfiguration) =>
        {
            
            // AppLovin SDK is initialized, start loading ads
            // Banners are automatically sized to 320×50 on phones and 728×90 on tablets
            // You may call the utility method MaxSdkUtils.isTablet() to help with view sizing adjustments
          MaxSdk.CreateBanner(bannerAdUnitId, MaxSdkBase.BannerPosition.BottomLeft);

            // Set background or background color for banners to be fully functional
           
            MaxSdk.SetBannerBackgroundColor(bannerAdUnitId, Color.clear);
            MaxSdk.ShowBanner(bannerAdUnitId);
           

        };

        MaxSdk.SetSdkKey("EA5l_VJJr5FygR-WeE7HUkU1H_dO0ahgGhoWrTH8dzXRRc23f-wARAbJWQi2qBG3AQz-efSWg3BFTMXUw-pV5A");
        MaxSdk.SetUserId("USER_ID");
        MaxSdk.InitializeSdk();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
