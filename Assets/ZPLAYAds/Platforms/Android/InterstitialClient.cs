#if UNITY_ANDROID
using System;
using UnityEngine;

using ZPLAYAds.Api;
using ZPLAYAds.Common;
namespace ZPLAYAds.Android
{
    public class InterstitialClient : AndroidJavaProxy, IInterstitialClient
    {
        AndroidJavaObject androidInterstitial;
        public event EventHandler<EventArgs> OnAdLoaded = delegate { };
        public event EventHandler<AdFailedEventArgs> OnAdFailed = delegate { };
        public event EventHandler<EventArgs> OnAdStarted = delegate { };
        public event EventHandler<EventArgs> OnAdClicked = delegate { };
        public event EventHandler<EventArgs> OnAdVideoCompleted = delegate { };
        public event EventHandler<EventArgs> OnAdCompleted = delegate { };

        public InterstitialClient(string appId) : base(Utils.UnityInterstitialAdListenerClassName)
        {
            AndroidJavaClass playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
            AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            androidInterstitial = new AndroidJavaObject(Utils.InterstitialClassName, activity, appId, this);
        }

        #region InterstitialAdClient implementation

        public void LoadAd(string adUnitId)
        {
            androidInterstitial.Call("loadAd", adUnitId);
        }

        public bool IsLoaded(string adUnitId)
        {
            return androidInterstitial.Call<bool>("isLoaded", adUnitId);
        }

        public void Show(string adUnitId)
        {
            androidInterstitial.Call("show", adUnitId);
        }

        public void SetAutoloadNext(bool autoload)
        {
            androidInterstitial.Call("setAutoloadNext", autoload);
        }

        public void SetChannelId(string channelId)
        {
            androidInterstitial.Call("setChannelId", channelId);
        }
        #endregion

        #region Callback from UnityInterstitialAdListener
        void onAdLoaded()
        {
            if (OnAdLoaded != null)
            {
                OnAdLoaded(this, EventArgs.Empty);
            }
        }

        void onAdFailed(String errorReason)
        {
            if (OnAdFailed != null)
            {
                AdFailedEventArgs args = new AdFailedEventArgs()
                {
                    Message = errorReason
                };
                OnAdFailed(this, args);
            }
        }

        void onAdStarted()
        {
            if (OnAdStarted != null)
            {
                OnAdStarted(this, EventArgs.Empty);
            }
        }

        void onAdClicked()
        {
            if (OnAdClicked != null)
            {
                OnAdClicked(this, EventArgs.Empty);
            }
        }

        void onAdVideoCompleted()
        {
            if (OnAdVideoCompleted != null)
            {
                OnAdVideoCompleted(this, EventArgs.Empty);
            }
        }

        void onAdCompleted()
        {
            if (OnAdCompleted != null)
            {
                OnAdCompleted(this, EventArgs.Empty);
            }
        }
        #endregion
    }
}

#endif