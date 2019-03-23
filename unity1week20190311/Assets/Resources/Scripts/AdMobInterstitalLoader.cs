using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobInterstitalLoader : MonoBehaviour
{
    public string unitId_android = "ca-app-pub-3940256099942544/1033173712";
    public string unitId_ios = "ca-app-pub-3940256099942544/4411468910";

    private InterstitialAd interstitial; 

    // Start is called before the first frame update
    void Start()
    {
        RequestInterstitial();
    }

    public void ShowInterstitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            Debug.Log("Interstitial is not ready yet");
        }
    }

    // Returns an ad request with custom ad targeting.
    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .AddTestDevice(AdRequest.TestDeviceSimulator)
            .AddTestDevice("0123456789ABCDEF0123456789ABCDEF")
            .AddKeyword("game")
            .SetGender(Gender.Male)
            .SetBirthday(new DateTime(1985, 1, 1))
            .TagForChildDirectedTreatment(false)
            .AddExtra("color_bg", "9B30FF")
            .Build();
    }

    private void RequestInterstitial()
    {
        // These ad units are configured to always serve test ads.
#if UNITY_EDITOR
        string adUnitId = "unused";
#elif UNITY_ANDROID
        string adUnitId = unitId_android;
#elif UNITY_IPHONE
        string adUnitId = unitId_ios;
#else
        string adUnitId = "unexpected_platform";
#endif

        // Clean up interstitial ad before creating a new one.
        if (interstitial != null)
        {
            interstitial.Destroy();
        }

        // Create an interstitial.
        interstitial = new InterstitialAd(adUnitId);

        // Register for ad events.
        interstitial.OnAdLoaded += HandleInterstitialLoaded;
        interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
        interstitial.OnAdOpening += HandleInterstitialOpened;
        interstitial.OnAdClosed += HandleInterstitialClosed;
        interstitial.OnAdLeavingApplication += HandleInterstitialLeftApplication;

        // Load an interstitial ad.
        interstitial.LoadAd(CreateAdRequest());
    }


    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        Debug.Log("HandleInterstitialLoaded event received");
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log(
            "HandleInterstitialFailedToLoad event received with message: " + args.Message);
    }

    public void HandleInterstitialOpened(object sender, EventArgs args)
    {
        Debug.Log("HandleInterstitialOpened event received");
    }

    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        Debug.Log("HandleInterstitialClosed event received");
    }

    public void HandleInterstitialLeftApplication(object sender, EventArgs args)
    {
        Debug.Log("HandleInterstitialLeftApplication event received");
    }

}
