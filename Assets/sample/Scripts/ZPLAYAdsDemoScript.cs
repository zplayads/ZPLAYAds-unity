using System;
using UnityEngine;
using ZPLAYAds.Api;
using ZPLAYAds.Common;
using ZPLAYAds;
public class ZPLAYAdsDemoScript : MonoBehaviour
{
    RewardVideoAd rewardVideo;
    InterstitialAd interstitial;
    void Start()
    {
        AdOptions adOptions = new AdOptionsBuilder()
            .SetChannelId(GlobleSettings.GetChannelId)
            .SetAutoLoadNext(GlobleSettings.IsAutoload)
            .build();

        rewardVideo = new RewardVideoAd(GlobleSettings.GetAppID, GlobleSettings.GetRewardVideoUnitID, adOptions);
        rewardVideo.OnAdLoaded += HandleRewardVideoLoaded;
        rewardVideo.OnAdFailedToLoad += HandleRewardVideoFailedToLoad;
        rewardVideo.OnAdStarted += HandleRewardVideoStart;
        rewardVideo.OnAdClicked += HandleRewardVideoClicked;
        rewardVideo.OnAdRewarded += HandleRewardVideoRewarded;
        rewardVideo.OnAdClosed += HandleRewardVideoClosed;

        interstitial = new InterstitialAd(GlobleSettings.GetAppID, GlobleSettings.GetInterstitialUnitID, adOptions);
        interstitial.OnAdLoaded += HandleInterstitialLoaded;
        interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
        interstitial.OnAdStarted += HandleInterstitialStart;
        interstitial.OnAdClicked += HandleInterstitialClicked;
        interstitial.OnAdClosed += HandleInterstitialClosed;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnGUI()
    {
        GUI.skin.button.fontSize = (int)(0.034f * Screen.width);
        float buttonWidth = 0.35f * Screen.width;
        float buttonHeight = 0.15f * Screen.height;
        float columnOnePosition = 0.1f * Screen.width;
        float columnTwoPosition = 0.55f * Screen.width;

        Rect requestRewardRect = new Rect(columnOnePosition, 0.05f * Screen.height, buttonWidth, buttonHeight);
        if (GUI.Button(requestRewardRect, "Request\nRewardVideo"))
        {
            RequestRewarVideo(GlobleSettings.GetRewardVideoUnitID);
        }

        Rect showRewardRect = new Rect(columnTwoPosition, 0.05f * Screen.height, buttonWidth, buttonHeight);
        if (GUI.Button(showRewardRect, "Show\nRewarded Video"))
        {
            ShowRewarVideo(GlobleSettings.GetRewardVideoUnitID);
        }

        Rect requestInterstitialRect = new Rect(columnOnePosition, 0.25f * Screen.height, buttonWidth, buttonHeight);
        if (GUI.Button(requestInterstitialRect, "Request\nInterstitital"))
        {
            RequestInterstitital(GlobleSettings.GetInterstitialUnitID);
        }

        Rect showInterstitialRect = new Rect(columnTwoPosition, 0.25f * Screen.height, buttonWidth, buttonHeight);
        if (GUI.Button(showInterstitialRect, "Show\nInterstitital"))
        {
            ShowInterstitial(GlobleSettings.GetInterstitialUnitID);
        }
    }

    void RequestRewarVideo(string adUnitId)
    {
        rewardVideo.LoadAd(adUnitId);
    }

    void ShowRewarVideo(string adUnitId)
    {
        if (rewardVideo.IsReady(adUnitId))
        {
            rewardVideo.Show(adUnitId);
        }
        else
        {
            print("===> Reward video ad is not ready yet.");
        }
    }

    void RequestInterstitital(string adUnitId)
    {
        interstitial.LoadAd(adUnitId);
    }

    void ShowInterstitial(string adUnitId)
    {
        if (interstitial.IsReady(adUnitId))
        {
            interstitial.Show(adUnitId);
        }
        else
        {
            print("===> Reward video ad is not ready yet.");
        }
    }

    #region RewardVideo callback handlers

    public void HandleRewardVideoLoaded(object sender, EventArgs args)
    {
        print("===> HandleRewardVideoLoaded event received");
    }

    public void HandleRewardVideoFailedToLoad(object sender, AdFailedEventArgs args)
    {
        print("===> HandleRewardVideoFailedToLoad event received with message: " + args.Message);
    }

    public void HandleRewardVideoStart(object sender, EventArgs args)
    {
        print("===> HandleRewardVideoStart event received.");
    }

    public void HandleRewardVideoClicked(object sender, EventArgs args)
    {
        print("===> HandleRewardVideoClicked event received.");
    }


    public void HandleRewardVideoRewarded(object sender, EventArgs args)
    {
        print("===> HandleRewardVideoRewarded event received.");
    }


    public void HandleRewardVideoClosed(object sender, EventArgs args)
    {
        print("===> HandleRewardVideoClosed event received.");
    }

    #endregion


    #region Interstitial callback handlers

    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        print("===> HandleInterstitialLoaded event received");
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedEventArgs args)
    {
        print("===> HandleInterstitialFailedToLoad event received with message: " + args.Message);
    }

    public void HandleInterstitialStart(object sender, EventArgs args)
    {
        print("===> HandleInterstitialStart event received.");
    }

    public void HandleInterstitialClicked(object sender, EventArgs args)
    {
        print("===> HandleInterstitialClicked event received.");
    }


    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        print("===> HandleInterstitialClosed event received.");
    }

    #endregion
}
