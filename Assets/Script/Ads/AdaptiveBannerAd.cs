using UnityEngine;
using System;
using System.Collections;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System.Collections.Generic;

public class AdaptiveBannerAd : MonoBehaviour
{
    private BannerView _bannerView;
    public GameObject[] asd;
    // Use this for initialization
    void Start()
    {
        // Set your test devices.
        // https://developers.google.com/admob/unity/test-ads
        RequestConfiguration requestConfiguration = new RequestConfiguration
        {/*
            TestDeviceIds = new List<string>
            {
                AdRequest.TestDeviceSimulator,
                // Add your test device IDs (replace with your own device IDs).
                #if UNITY_IPHONE
                "96e23e80653bb28980d3f40beb58915c"
                #elif UNITY_ANDROID
                "75EF8D155528C04DACBBA6F36F433035"
                #endif
            }
            */
        };
        MobileAds.SetRequestConfiguration(requestConfiguration);

        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus status) =>
        {
            //asd[0].SetActive(true);
            RequestBanner();
        });
    }

    public void OnGUI()
    {
        GUI.skin.label.fontSize = 60;
       // Rect textOutputRect = new Rect( 0.15f * Screen.width,0.25f * Screen.height, 0.7f * Screen.width, 0.3f * Screen.height);
       // GUI.Label(textOutputRect, "Test");
    }

    private void RequestBanner()
    {
            // These ad units are configured to always serve test ads.
        #if UNITY_EDITOR
                string adUnitId = "unused";
        #elif UNITY_ANDROID
                    string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        #elif UNITY_IPHONE
                    string adUnitId = "ca-app-pub-3212738706492790/5381898163";
        #else
                    string adUnitId = "unexpected_platform";
        #endif

        // Clean up banner ad before creating a new one.
        if (_bannerView != null)
        {
            _bannerView.Destroy();
        }

        AdSize adaptiveSize =
                AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);

        _bannerView = new BannerView(adUnitId, adaptiveSize, AdPosition.Bottom);

        // Register for ad events.
        _bannerView.OnBannerAdLoaded += OnBannerAdLoaded;
        _bannerView.OnBannerAdLoadFailed += OnBannerAdLoadFailed;

        AdRequest adRequest = new AdRequest();

        // Load a banner ad.
        UnityMainThread.wkr.AddJob(() =>
        {
            //asd[1].SetActive(true);
            _bannerView.LoadAd(adRequest);
        });
        
    }

    #region Banner callback handlers

    private void OnBannerAdLoaded()
    {
        Debug.Log("Banner view loaded an ad with response : "
                 + _bannerView.GetResponseInfo());
        Debug.Log(string.Format("Ad Height: {0}, width: {1}",
                _bannerView.GetHeightInPixels(),
                _bannerView.GetWidthInPixels()));
    }

    private void OnBannerAdLoadFailed(LoadAdError error)
    {
        Debug.LogError("Banner view failed to load an ad with error : "
                + error);

        asd[2].SetActive(true);
    }

    #endregion
}