using System;
using ZPLAYAds.Api;
namespace ZPLAYAds.Common
{
    public interface IRewardVideoClient
    {
        event EventHandler<EventArgs> OnAdLoaded;
        event EventHandler<AdFailedEventArgs> OnAdFailed;
        event EventHandler<EventArgs> OnAdStarted;
        event EventHandler<EventArgs> OnAdClicked;
        event EventHandler<EventArgs> OnAdRewarded;
        event EventHandler<EventArgs> OnAdVideoCompleted;
        event EventHandler<EventArgs> OnAdCompleted;

        void LoadAd(string adUnitId);

        bool IsLoaded(string adUnitId);

        void Show(string adUnitId);

        void SetAutoloadNext(bool autoload);

        void SetChannelId(string channelId);
    }
}