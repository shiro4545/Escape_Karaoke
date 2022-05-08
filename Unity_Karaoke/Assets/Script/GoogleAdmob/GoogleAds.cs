using System;
using UnityEngine;
using GoogleMobileAds.Api;

public class GoogleAds : MonoBehaviour
{

  // private BannerView bannerView;
  // private BannerView squareBannerView;
  // private RewardedAd rewardedAd;
  //
  // public GameObject Hint2_txt;
  // public GameObject Hint2_ads;
  //
  // public HintManager Hint;
  //
  // public void Start()
  // {
  //     // Initialize the Google Mobile Ads SDK.
  //     MobileAds.Initialize(initStatus => { });
  //
  //     //画面上バナー
  //     this.RequestHeaderBanner();
  //     //画面下バナー
  //     this.RequestFooterBanner();
  //     //リワード広告(動画)
  //     this.RequestReward();
  // }
  //
  // //**********************************
  // //**バナー広告(ヘッダー)
  // //**********************************
  //
  // //画面上のバナーの表示
  // private void RequestHeaderBanner()
  // {
  //     #if UNITY_ANDROID
  //         string adUnitId =  "ca-app-pub-7464443980940177/9127654597" ;
  //     #elif UNITY_IPHONE
  //         string adUnitId = "ca-app-pub-7464443980940177/9863804157" ;
  //         //テスト
  //         // string adUnitId = "ca-app-pub-3940256099942544/2934735716";
  //     #else
  //         string adUnitId = "unexpected_platform";
  //     #endif
  //
  //     //バナー位置
  //     // AdPosition position = AdPosition.Top ;
  //     // if(Screen.width>750)
  //     //   position = AdPosition.Top;
  //     //バナーサイズ
  //     AdSize adSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
  //     // AdSize adSize = new AdSize(320, 100);
  //     // AdSize adSize = AdSize.Banner;
  //     // Create a 320x50 banner at the top of the screen.
  //       this.bannerView = new BannerView(adUnitId, adSize, AdPosition.Top);
  //     // Create an empty ad request.
  //     AdRequest request = new AdRequest.Builder().Build();
  //     // Load the banner with the request.
  //     this.bannerView.LoadAd(request);
  // }
  //
  // //**********************************
  // //**バナー広告(フッター)
  // //**********************************
  //
  // //画面下のバナーの表示
  // private void RequestFooterBanner()
  // {
  //     #if UNITY_ANDROID
  //         string adUnitId = "ca-app-pub-7464443980940177/5152750567";
  //     #elif UNITY_IPHONE
  //         string adUnitId = "ca-app-pub-7464443980940177/2909730604";
  //         //テスト
  //         // string adUnitId = "ca-app-pub-3940256099942544/2934735716";
  //     #else
  //         string adUnitId = "unexpected_platform";
  //     #endif
  //
  //     //バナー位置
  //     //   AdPosition position = AdPosition.Bottom;
  //     // if(Screen.width>750)
  //     //   position = AdPosition.Bottom;
  //     //バナーサイズ
  //     AdSize adSize = AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
  //     // AdSize adSize = new AdSize(320, 100);
  //     // AdSize adSize = AdSize.Banner;
  //     // Create a 320x50 banner at the top of the screen.
  //       this.bannerView = new BannerView(adUnitId, adSize, AdPosition.Bottom );
  //     // Create an empty ad request.
  //     AdRequest request = new AdRequest.Builder().Build();
  //     // Load the banner with the request.
  //     this.bannerView.LoadAd(request);
  // }
  //
  // //**********************************
  // //**バナー広告(Menu画面内の長方形)
  // //**********************************
  // //Menu画面内のバナーの表示
  // public void RequestSquareBanner()
  // {
  //   #if UNITY_ANDROID
  //       string adUnitId = "ca-app-pub-7464443980940177/8417810790";
  //   #elif UNITY_IPHONE
  //       string adUnitId = "ca-app-pub-7464443980940177/3740199180";
  //       //テスト
  //       // string adUnitId = "ca-app-pub-3940256099942544/2934735716";
  //   #else
  //       string adUnitId = "unexpected_platform";
  //   #endif
  //
  //   // Create a banner at the top of the screen.
  //   // this.squareBannerView = new BannerView(adUnitId, AdSize.MediumRectangle, Screen.width/2,Screen.height/4);
  //   this.squareBannerView = new BannerView(adUnitId, AdSize.MediumRectangle, AdPosition.Center);
  //   // Create an empty ad request.
  //   AdRequest request = new AdRequest.Builder().Build();
  //   // Load the banner with the request.
  //   this.squareBannerView.LoadAd(request);
  // }
  //
  // //Menu画面内のバナーの非表示
  // public void unRequestSquareBanner()
  // {
  //   squareBannerView.Destroy();
  // }
  //
  // //**********************************
  // //**リワード広告
  // //**********************************
  //
  // //動画のロード
  // private void RequestReward()
  //   {
  //     string adUnitId = "";
  //     #if UNITY_ANDROID
  //       adUnitId = "ca-app-pub-7464443980940177/8868951529";  //本番
  //       // string adUnitId = "ca-app-pub-3940256099942544/5224354917";  //テスト
  //     #elif UNITY_IOS
  //       adUnitId = "ca-app-pub-7464443980940177/1373604886";  //本番
  //       // adUnitId = "ca-app-pub-3940256099942544/1712485313";  //テスト
  //     #endif
  //
  //     this.rewardedAd = new RewardedAd(adUnitId);
  //     //動画の視聴が完了したら「HandleUserEarnedReward」を呼ぶ
  //     this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
  //     // 広告が閉じたとき「HandleRewardedAdClosed」を呼ぶ
  //     this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
  //       AdRequest request = new AdRequest.Builder().Build();
  //     this.rewardedAd.LoadAd(request);
  //   }
  //
  // //動画の視聴開始
  // public void ShowReawrd()
  // {
  //     if (this.rewardedAd.IsLoaded())
  //     {
  //        this.rewardedAd.Show();
  //     }
  // }
  //
  // //動画視聴完了後の処理（途中で閉じられた場合は呼ばれない）
  // public void HandleUserEarnedReward(object sender, Reward args)
  // {
  //     Hint2_ads.SetActive(false);
  //     Hint2_txt.SetActive(true);
  //     SaveLoadSystem.Instance.gameData.hintArray[Hint.progress] = true;
  //     SaveLoadSystem.Instance.Save();
  //
  //   }
  //
  //  // 広告が閉じたときに呼び出されます
  //  public void HandleRewardedAdClosed(object sender, System.EventArgs args)
  //  {
  //     //リワード広告の再ロード
  //     this.RequestReward();
  //  }
}
