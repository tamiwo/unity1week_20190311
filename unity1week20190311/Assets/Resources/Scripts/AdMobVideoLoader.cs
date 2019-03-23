using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobVideoLoader : MonoBehaviour
{
    public string appId_android = "ca-app-pub-3940256099942544~3347511713";
    public string appId_ios = "ca-app-pub-3940256099942544~1458002511";
    public string unitId_android = "ca-app-pub-3940256099942544/5224354917";
    public string unitId_ios = "ca-app-pub-3940256099942544/1712485313";

    private RewardBasedVideoAd videoAd;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID
        string appId = appId_android;
#elif UNITY_IPHONE
        string appId = appId_ios;
#else
        string appId = "unexpected_platform";
#endif

        MobileAds.SetiOSAppPauseOnBackground(true);
        MobileAds.Initialize(appId);

        // Get singleton reward based video ad reference.
        videoAd = RewardBasedVideoAd.Instance;

        // RewardBasedVideoAd is a singleton, so handlers should only be registered once.
        videoAd.OnAdLoaded += HandleVideoAdLoaded;
        videoAd.OnAdFailedToLoad += HandleVideoAdFailedToLoad;
        videoAd.OnAdOpening += HandleVideoAdOpened;
        videoAd.OnAdStarted += HandleVideoAdStarted;
        videoAd.OnAdRewarded += HandleVideoAdRewarded;
        videoAd.OnAdClosed += HandleVideoAdClosed;
        videoAd.OnAdLeavingApplication += HandleVideoAdLeftApplication;

        RequestVideoAd();
    }

    // Returns an ad request with custom ad targeting.
    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder() //テスト用
            .AddTestDevice(AdRequest.TestDeviceSimulator)
            .AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
            .AddKeyword("game")
            .SetGender(Gender.Male)
            .SetBirthday(new DateTime(1985, 1, 1))
            .TagForChildDirectedTreatment(false)
            .AddExtra("color_bg", "9B30FF")
            .Build();
    }

    private void RequestVideoAd()
    {
#if UNITY_EDITOR
        string unitId = "unused";
#elif UNITY_ANDROID
        string unitId = unitId_android;
#elif UNITY_IPHONE
        string unitId = unitId_ios;
#else
        string unitId = "unexpected_platform";
#endif

        videoAd.LoadAd(CreateAdRequest(), unitId);
    }

    public void ShowVideoAd()
    {
        if (videoAd.IsLoaded())
        {
            videoAd.Show();
        }
        else
        {
            Debug.Log("Reward based video ad is not ready yet");
        }
    }

    public void HandleVideoAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("HandleVideoAdLoaded event received");
    }

    public void HandleVideoAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log(
            "HandleVideoAdFailedToLoad event received with message: " + args.Message);
    }

    public void HandleVideoAdOpened(object sender, EventArgs args)
    {
        Debug.Log("HandleVideoAdOpened event received");
    }

    public void HandleVideoAdStarted(object sender, EventArgs args)
    {
        Debug.Log("HandleVideoAdStarted event received");
    }

    public void HandleVideoAdClosed(object sender, EventArgs args)
    {
        Debug.Log("HandleVideoAdClosed event received");
    }

    public void HandleVideoAdRewarded(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        Debug.Log(
            "HandleVideoAdRewarded event received for " + amount.ToString() + " " + type);
    }

    public void HandleVideoAdLeftApplication(object sender, EventArgs args)
    {
        Debug.Log("HandleVideoAdLeftApplication event received");
    }

}
