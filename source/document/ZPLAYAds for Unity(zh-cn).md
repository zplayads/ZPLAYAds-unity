* [ZPLAYAds for Unity](#zplayads-for-unity)
  * [概述](#概述)
  * [下载ZPLAYAds Unity插件](#下载zplayads-unity插件)
  * [导入ZPLAYAds Unity插件](#导入zplayads-unity插件)
  * [集成ZPLAYAds](#集成zplayads)
      * [部署iOS项目](#部署ios项目)
      * [部署Android项目](#部署android项目)
  * [选择广告形式](#选择广告形式)
      * [Interstitial](#interstitial)
        * [初始化及请求插屏](#初始化及请求插屏)
        * [请求Interstitial](#请求interstitial)
        * [判断Interstitial是否准备好](#判断interstitial是否准备好)
        * [展示Interstitial](#展示interstitial)
      * [Rewarded Video](#rewarded-video)
        * [初始化及请求视频](#初始化及请求视频)
        * [请求Rewarded Video](#请求rewarded-video)
        * [判断Rewarded Video是否准备好](#判断rewarded-video是否准备好)
        * [展示Rewarded Video](#展示rewarded-video)

# ZPLAYAds for Unity

## 概述

1.面向人群

本产品主要面向需要在 Unity 产品中接 ZPLAYAds SDK 的开发人员。

2.先决条件

- Unity 5.6 或更高版本


- 部署 iOS

   Xcode 7.0 或更高版本

   iOS 8.0 或更高版本

   [CocoaPods](https://guides.cocoapods.org/using/getting-started.html)

- 部署 Android

  Android API 14 或更高版本

3.[Demo 获取地址](../../Assets)   

## 下载ZPLAYAds Unity插件

ZPLAYAds Unity插件使Unity开发人员可以轻松地在 Android 和 iOS 应用上展示广告，无需编写 Java 或 Objective-C 代码。该插件提供了一个 C# 接口来请求广告。您可以[下载ZPLAYAds Unity插件包](https://github.com/zplayads/ZPLAYAds-unity/raw/master/source/ZPLAYAds.unitypackage)或在GitHub上查看代码。（[Android代码](source/android-library/app/src/main/java/com/zplay/adsunity)、[iOS代码](../../Assets/Plugins/iOS)、[查看源码](Assets/ZPLAYAds)）

## 导入ZPLAYAds Unity插件

在 Unity 编辑器中打开您的项目。选择 **Assets> Import Package> Custom Package**，找到您下载的 ZPLAYAds.unitypackage 文件。

![img](resources/image-import-custom-package.png)

确保选中所有文件，然后单击 **Import**.

![img](resources/image-select-package.png)

## 集成ZPLAYAds

ZPLAYAds Unity插件与[Unity Play Services Resolver library](https://github.com/googlesamples/unity-jar-resolver)一起发布。这个Library适用于任何需要访问Android特定库(例如AARs)或iOS CocoaPods的Unity插件。它声明了Unity插件的依赖项，这些依赖项可被自动解析并复制到Unity项目中。

请按照下面列出的步骤操作以确保集成ZPLAYAds Unity插件。

### 部署iOS项目

将ZPLAYAds集成到Unity项目中无需其他步骤。

构建完成，打开**xcworkspace**工程。

**注意：使用CocoaPods识别iOS依赖项。CocoaPods作为后期构建过程步骤运行。**

### 部署Android项目

在Unity编辑器中，选择 **Assets> Play Services Resolver> Android Resolver>Force Resolve**。 Unity Play 服务解析器库会将声明的依赖项复制到Unity应用程序的**Assets/Plugins/Android**目录中。

![img](./resources/image-play-services-resolver.png)

注意：ZPLAYAds Unity插件依赖项列在 **Assets/ZPLAYAds/Editor/ZPLAYAdsDependencies.xml**中

## 选择广告形式

现在，您的Unity应用已经成功接入了ZPLAYAds SDK，之后便可展示广告了。ZPLAYAds提供不同的广告形式，您可以选择最符合您用户体验要求的广告形式。

### Interstitial

#### 初始化及请求插屏

```C#
using ZPLAYAds.Api;
using ZPLAYAds.Common;
public class ZPLAYAdsDemoScript : MonoBehaviour
{
  #if UNITY_ANDROID
   const string ZPLAYADS_APP_ID = "YOUR_ZPLAYAds_APP_ID_ANDROID";
   const string ZPLAYADS_UNIT_ID_INTERSTITIAL = "YOUR_ZPLAYAds_UNIT_ID_INTERSTITIAL_ANDROID";
  #elif UNITY_IOS
   const string ZPLAYADS_APP_ID = "YOUR_ZPLAYAds_APP_ID_IOS";
   const string ZPLAYADS_UNIT_ID_INTERSTITIAL = "YOUR_ZPLAYAds_UNIT_ID_INTERSTITIAL_IOS";
  #else
   const string ZPLAYADS_APP_ID = "unexpected_platform";
   const string ZPLAYADS_UNIT_ID_INTERSTITIAL = "unexpected_platform";
  #endif

  InterstitialAd interstitial;

  void Start() 
  {
    interstitial = new InterstitialAd(ZPLAYADS_APP_ID, ZPLAYADS_UNIT_ID_INTERSTITIAL);
    interstitial.SetAutoloadNext(true);
    interstitial.OnAdLoaded += HandleInterstitialLoaded;
    interstitial.OnAdFailed += HandleInterstitialFailed;
    interstitial.OnAdStarted += HandleInterstitialStart;
    interstitial.OnAdVideoCompleted += HandleInterstitialVideoCompleted;
    interstitial.OnAdClicked += HandleInterstitialClicked;
    interstitial.OnAdCompleted += HandleInterstitialCompleted;
  }
  
  #region Interstitial callback handlers
  public void HandleInterstitialLoaded(object sender, EventArgs args)
  {
    print("===> HandleInterstitialLoaded event received");
  }
  public void HandleInterstitialFailed(object sender, AdFailedEventArgs args)
  {
    print("===> HandleInterstitialFailed event received with message: " + args.Message);
  }
  public void HandleInterstitialStart(object sender, EventArgs args)
  {
    print("===> HandleInterstitialStart event received.");
  }
  public void HandleInterstitialVideoCompleted(object sender, EventArgs args)
  {
    print("===> HandleInterstitialVideoCompleted event received.");
  }
  public void HandleInterstitialClicked(object sender, EventArgs args)
  {
    print("===> HandleInterstitialClicked event received.");
  }
  public void HandleInterstitialCompleted(object sender, EventArgs args)
  {
    print("===> HandleInterstitialClosed event received.");
  }
  #endregion
}
```

#### 请求Interstitial

如果打开自动请求 ```interstitial.SetAutoloadNext(true)``` 模式，首次请求后，SDK 会在展示完成后或广告请求失败后自动请求下一条广告

```C#
interstitial.LoadAd(ZPLAYADS_UNIT_ID_INTERSTITIAL);
```

#### 判断Interstitial是否准备好

```c#
interstitial.IsLoaded(ZPLAYADS_UNIT_ID_INTERSTITIAL)
```

#### 展示Interstitial

建议先调用 ```interstitial.IsLoaded(ZPLAYADS_UNIT_ID_INTERSTITIAL)``` 判断插屏是否准备好

```C#
if(interstitial.IsLoaded(ZPLAYADS_UNIT_ID_INTERSTITIAL))
{
  interstitial.Show(ZPLAYADS_UNIT_ID_INTERSTITIAL);
}
```

### Rewarded Video

#### 初始化及请求视频

```C#
using ZPLAYAds.Api;
using ZPLAYAds.Common;
public class ZPLAYAdsDemoScript : MonoBehaviour
{
  #if UNITY_ANDROID
   const string ZPLAYADS_APP_ID = "YOUR_ZPLAYAds_APP_ID_ANDROID";
   const string ZPLAYADS_UNIT_ID_REWARD_VIDEO = "YOUR_ZPLAYAds_UNIT_ID_REWARD_VIDEO_ANDROID";
  #elif UNITY_IOS
   const string ZPLAYADS_APP_ID = "YOUR_ZPLAYAds_APP_ID_IOS";
   const string ZPLAYADS_UNIT_ID_REWARD_VIDEO = "YOUR_ZPLAYAds_UNIT_ID_REWARD_VIDEO_IOS";
  #else
   const string ZPLAYADS_APP_ID = "unexpected_platform";
   const string ZPLAYADS_UNIT_ID_REWARD_VIDEO = "unexpected_platform";
  #endif

  RewardVideoAd rewardVideo;

  void Start() 
  {
    rewardVideo = new RewardVideoAd(ZPLAYADS_APP_ID, ZPLAYADS_UNIT_ID_REWARD_VIDEO);
    rewardVideo.SetAutoloadNext(true);
    rewardVideo.OnAdLoaded += HandleRewardVideoLoaded;
    rewardVideo.OnAdFailed += HandleRewardVideoFailed;
    rewardVideo.OnAdStarted += HandleRewardVideoStart;
    rewardVideo.OnAdVideoCompleted += HandleRewardVideoVideoCompleted;
    rewardVideo.OnAdClicked += HandleRewardVideoClicked;
    rewardVideo.OnAdRewarded += HandleRewardVideoRewarded;
    rewardVideo.OnAdCompleted += HandleRewardVideoCompleted;
  }

  #region RewardVideo callback handlers
  public void HandleRewardVideoLoaded(object sender, EventArgs args)
  {
      print("===> HandleRewardVideoLoaded event received");
  }
  public void HandleRewardVideoFailed(object sender, AdFailedEventArgs args)
  {
      print("===> HandleRewardVideoFailed event received with message: " + args.Message);
  }
  public void HandleRewardVideoStart(object sender, EventArgs args)
  {
      print("===> HandleRewardVideoStart event received.");
  }
  public void HandleRewardVideoVideoCompleted(object sender, EventArgs args)
  {
      print("===> HandleRewardVideoVideoCompleted event received.");
  }
  public void HandleRewardVideoClicked(object sender, EventArgs args)
  {
      print("===> HandleRewardVideoClicked event received.");
  }
  public void HandleRewardVideoRewarded(object sender, EventArgs args)
  {
      print("===> HandleRewardVideoRewarded event received.");
  }
  public void HandleRewardVideoCompleted(object sender, EventArgs args)
  {
      print("===> HandleRewardVideoCompleted event received.");
  }
  #endregion
}
```

#### 请求Rewarded Video
如果打开自动请求 ```rewardVideo.SetAutoloadNext(true)``` 模式，首次请求后，SDK会在展示完成后或广告请求失败后自动请求下一条广告

```C#
rewardVideo.LoadAd(ZPLAYADS_UNIT_ID_REWARD_VIDEO);
```

#### 判断Rewarded Video是否准备好

```c#
rewardVideo.IsLoaded(ZPLAYADS_UNIT_ID_REWARD_VIDEO)
```

#### 展示Rewarded Video

```c#
if(rewardVideo.IsLoaded(ZPLAYADS_UNIT_ID_REWARD_VIDEO))
{
  rewardVideo.Show(ZPLAYADS_UNIT_ID_REWARD_VIDEO);
} 
```
