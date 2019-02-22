- [ZPLAYAds for Unity](#zplayads-for-unity)
  - [概述](#%E6%A6%82%E8%BF%B0)
  - [下载ZPLAYAds Unity插件](#%E4%B8%8B%E8%BD%BDzplayads-unity%E6%8F%92%E4%BB%B6)
  - [导入ZPLAYAds Unity插件](#%E5%AF%BC%E5%85%A5zplayads-unity%E6%8F%92%E4%BB%B6)
  - [集成ZPLAYAds](#%E9%9B%86%E6%88%90zplayads)
    - [部署iOS项目](#%E9%83%A8%E7%BD%B2ios%E9%A1%B9%E7%9B%AE)
    - [部署Android项目](#%E9%83%A8%E7%BD%B2android%E9%A1%B9%E7%9B%AE)
  - [选择广告形式](#%E9%80%89%E6%8B%A9%E5%B9%BF%E5%91%8A%E5%BD%A2%E5%BC%8F)
    - [Interstitial](#interstitial)
      - [初始化及请求插屏](#%E5%88%9D%E5%A7%8B%E5%8C%96%E5%8F%8A%E8%AF%B7%E6%B1%82%E6%8F%92%E5%B1%8F)
      - [请求Interstitial](#%E8%AF%B7%E6%B1%82interstitial)
      - [判断Interstitial是否准备好](#%E5%88%A4%E6%96%ADinterstitial%E6%98%AF%E5%90%A6%E5%87%86%E5%A4%87%E5%A5%BD)
      - [展示Interstitial](#%E5%B1%95%E7%A4%BAinterstitial)
    - [Rewarded Video](#rewarded-video)
      - [初始化及请求视频](#%E5%88%9D%E5%A7%8B%E5%8C%96%E5%8F%8A%E8%AF%B7%E6%B1%82%E8%A7%86%E9%A2%91)
      - [请求Rewarded Video](#%E8%AF%B7%E6%B1%82rewarded-video)
      - [判断Rewarded Video是否准备好](#%E5%88%A4%E6%96%ADrewarded-video%E6%98%AF%E5%90%A6%E5%87%86%E5%A4%87%E5%A5%BD)
      - [展示Rewarded Video](#%E5%B1%95%E7%A4%BArewarded-video)
  - [测试ID](#%E6%B5%8B%E8%AF%95id)

# ZPLAYAds for Unity

## 概述

1. 面向人群

本产品主要面向需要在Unity产品中接入ZPLAYAds SDK的开发人员。

2. 先决条件

- Unity 5.6 或更高版本


- 部署 iOS

   Xcode 7.0 或更高版本

   iOS 8.0 或更高版本

   [CocoaPods](https://guides.cocoapods.org/using/getting-started.html)

- 部署 Android

  Android API 14 或更高版本

3. [Demo 获取地址](https://github.com/zplayads/ZPLAYAds-unity/tree/master/Assets)   

## 下载ZPLAYAds Unity插件

ZPLAYAds Unity插件使Unity开发人员可以轻松地在Android和iOS应用上展示广告，无需编写Java或Objective-C代码，该插件提供了一个C#接口来请求广告。您可以下载[ZPLAYAds Unity插件包](source/ZPLAYAds.unitypackage)或在GitHub上查看相关代码，如[Android代码](source/android-library/app/src/main/java/com/zplay/adsunity)、[iOS代码](Assets/Plugins/iOS)或[全部源码](Assets/ZPLAYAds)


## 导入ZPLAYAds Unity插件

在Unity编辑器中打开您的项目，选择**Assets> Import Package> Custom Package**，找到您下载的ZPLAYAds.unitypackage文件。

![img](img/image-import-custom-package.png)

确保选中所有文件，然后单击**Import**.

![img](img/image-select-package.png)

## 集成ZPLAYAds

ZPLAYAds Unity插件与[Unity Play Services Resolver library](https://github.com/googlesamples/unity-jar-resolver)一起发布。这个Library适用于任何需要访问Android特定库(例如AARs)或iOS CocoaPods的Unity插件。它声明了Unity插件的依赖项，这些依赖项可被自动解析并复制到Unity项目中。

请按照下面列出的步骤操作以确保集成ZPLAYAds Unity插件。

### 部署iOS项目

将ZPLAYAds集成到Unity项目中无需其他步骤。

项目构建完成，打开**xcworkspace**工程即可看到完整的iOS项目。

**注意：使用CocoaPods识别iOS依赖项。CocoaPods作为后期构建过程步骤运行。**

### 部署Android项目

在Unity编辑器中，选择 **Assets> Play Services Resolver> Android Resolver>Force Resolve**。 Unity Play服务解析器库会将声明的依赖项复制到Unity应用程序的**Assets/Plugins/Android**目录中。

![img](img/image-play-services-resolver.png)

注意：ZPLAYAds Unity插件依赖项列在**Assets/ZPLAYAds/Editor/ZPLAYAdsDependencies.xml**中

## 选择广告形式

现在，您的Unity应用已经成功接入了ZPLAYAds SDK，接下来您可以选择您需要的广告形式，ZPLAYAd目前仅为Unity项目提供插屏、激励视频两种广告形式。

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

// 您可在此处看到所有的ZPLAYAds回调

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
## 测试ID

您在测试中可使用如下id进行测试，测试id不会产生收益，应用上线时请使用您申请的正式id。

| 操作系统      | 广告形式 | App_ID                               | Ad_Unit_id                           |
| ------- |  --------------- |------------------------------------ | ------------------------------------ |
| iOS     |激励视频| A650AB0D-7BFC-2A81-3066-D3170947C3DA | BAE5DAAC-04A2-2591-D5B0-38FA846E45E7 |
| iOS     |插屏| A650AB0D-7BFC-2A81-3066-D3170947C3DA | 0868EBC0-7768-40CA-4226-F9924221C8EB |
| Android |激励视频|  5C5419C7-A2DE-88BC-A311-C3E7A646F6AF | 3FBEFA05-3A8B-2122-24C7-A87D0BC9FEEC |
| Android |插屏|  5C5419C7-A2DE-88BC-A311-C3E7A646F6AF | 19393189-C4EB-3886-60B9-13B39407064E |
