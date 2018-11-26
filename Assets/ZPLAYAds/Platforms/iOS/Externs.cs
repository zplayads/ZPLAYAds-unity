#if UNITY_IOS

using System;
using System.Runtime.InteropServices;

namespace ZPLAYAds.iOS
{
    class Externs
    {

        #region Common externs
        [DllImport("__Internal")]
        internal static extern IntPtr ZPLADRelease(IntPtr obj);
        #endregion

        #region Interstitial externs
        [DllImport("__Internal")]
        internal static extern IntPtr ZPLADCreateInterstitial(IntPtr interstitialClient, string adAppId, string adUnityId);

        [DllImport("__Internal")]
        internal static extern void ZPLADSetInterstitialAdCallbacks(
            IntPtr interstitial,
            InterstitialClient.ZPLADInterstitialDidReceivedAdCallback adReceivedCallback,
            InterstitialClient.ZPLADInterstitialDidFailToReceiveAdWithErrorCallback adFailedCallback,
            InterstitialClient.ZPLADInterstitialVideoDidStartPlayingCallback videoDidStartCallback,
            InterstitialClient.ZPLADInterstitialDidClickCallback didClickCallback,
            InterstitialClient.ZPLADInterstitialVideoDidCloseCallback videoDidCloseCallback,
            InterstitialClient.ZPLADInterstitialDidCompleteCallback didCompleteCallback
        );

        [DllImport("__Internal")]
        internal static extern void ZPLADRequestInterstitial(IntPtr interstitial);

        [DllImport("__Internal")]
        internal static extern bool ZPLADInterstitialReady(IntPtr interstitial);

        [DllImport("__Internal")]
        internal static extern void ZPLADShowInterstitial(IntPtr interstitial);

        [DllImport("__Internal")]
        internal static extern void ZPLADSetInterstitialAutoload(IntPtr interstitial, bool autoload);

        [DllImport("__Internal")]
        internal static extern void ZPLADSetInterstitialChannelId(IntPtr interstitial, string channelId);
        #endregion


        #region RewardVideo externs
        [DllImport("__Internal")]
        internal static extern IntPtr ZPLADCreateRewardVideo(IntPtr rewardVideoClient, string adAppId, string adUnityId);

        [DllImport("__Internal")]
        internal static extern void ZPLADSetRewardVideoAdCallbacks(
            IntPtr interstitial,
            RewardVideoClient.ZPLADRewardVideoDidReceivedAdCallback adReceivedCallback,
            RewardVideoClient.ZPLADRewardVideoDidFailToReceiveAdWithErrorCallback adFailedCallback,
            RewardVideoClient.ZPLADRewardVideoVideoDidStartPlayingCallback videoDidStartCallback,
            RewardVideoClient.ZPLADRewardVideoDidClickCallback didClickCallback,
            RewardVideoClient.ZPLADRewardVideoDidRewardCallback didRewardCallback,
            RewardVideoClient.ZPLADRewardVideoVideoDidCloseCallback videoDidCloseCallback,
            RewardVideoClient.ZPLADRewardVideoDidCompleteCallback didCompleteCallback
        );

        [DllImport("__Internal")]
        internal static extern void ZPLADRequestRewardVideo(IntPtr rewardVideo);

        [DllImport("__Internal")]
        internal static extern bool ZPLADRewardVideoReady(IntPtr rewardVideo);

        [DllImport("__Internal")]
        internal static extern void ZPLADShowRewardVideo(IntPtr rewardVideo);

        [DllImport("__Internal")]
        internal static extern void ZPLADSetRewardVideoAutoload(IntPtr rewardVideo, bool autoload);

        [DllImport("__Internal")]
        internal static extern void ZPLADSetRewardVideoChannelId(IntPtr rewardVideo, string channelId);
        #endregion
    }
}
#endif