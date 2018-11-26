using System;
using ZPLAYAds.Common;
namespace ZPLAYAds.Api
{
    public class InterstitialAd
    {
        private IInterstitialClient client;

        public InterstitialAd(string adAppId, string adUnitId)
        {
            client = ZPLAYAdsClientFactory.BuildInterstitialClient(adAppId, adUnitId);

            client.OnAdLoaded += (sender, args) =>
            {
                if (OnAdLoaded != null)
                {
                    OnAdLoaded(this, args);
                }
            };

            client.OnAdFailed += (sender, args) =>
            {
                if (OnAdFailed != null)
                {
                    OnAdFailed(this, args);
                }
            };

            client.OnAdStarted += (sender, args) =>
            {
                if (OnAdStarted != null)
                {
                    OnAdStarted(this, args);
                }
            };

            client.OnAdVideoCompleted += (sender, args) =>
            {
                if (OnAdVideoCompleted != null)
                {
                    OnAdVideoCompleted(this, args);
                }
            };

            client.OnAdClicked += (sender, args) =>
            {
                if (OnAdClicked != null)
                {
                    OnAdClicked(this, args);
                }
            };

            client.OnAdCompleted += (sender, args) =>
            {
                if (OnAdCompleted != null)
                {
                    OnAdCompleted(this, args);
                }
            };
        }

        // These are the ad callback events that can be hooked into.
        public event EventHandler<EventArgs> OnAdLoaded;
        public event EventHandler<AdFailedEventArgs> OnAdFailed;
        public event EventHandler<EventArgs> OnAdStarted;
        public event EventHandler<EventArgs> OnAdClicked;
        public event EventHandler<EventArgs> OnAdVideoCompleted;
        public event EventHandler<EventArgs> OnAdCompleted;

        // Loads a new reward video
        public void LoadAd(string adUnitId)
        {
            client.LoadAd(adUnitId);
        }

        // Determines whether the reward video has loaded
        public bool IsLoaded(string adUnitId)
        {
            return client.IsLoaded(adUnitId);
        }

        // Shows the reward video
        public void Show(string adUnitId)
        {
            client.Show(adUnitId);
        }

        // Sets whether load the next reward video automatically
        public void SetAutoloadNext(bool autoload)
        {
            client.SetAutoloadNext(autoload);
        }

        // Sets the channel id
        public void SetChannelId(string channelId)
        {
            client.SetChannelId(channelId);
        }
    }
}
