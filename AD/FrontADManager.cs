using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    public class FrontADManager : SingletonConfigured<FrontADManager>
    {
        private string InterstitialAndroidID;
#if UNITY_ANDROID
        private const string testID;
        private string InterstitialID => InterstitialAndroidID;
#else
        private const string rewardTestId = "unused";
        private string RewardId = "unused";
#endif
        private InterstitialAd _InterstitialAd;

        public void LoadAd()
        {
            var id = ServerManager.Instance.IsADTest ? testID : InterstitialAndroidID;
#if UNITY_EDITOR
            id = testID;
#endif
            if (_InterstitialAd != null)
            {
                DestroyAd();
            }
            AdRequest adRequest = new AdRequest();

            InterstitialAd.Load(id, adRequest, (InterstitialAd ad, LoadAdError error) =>
            {
                if (error != null)
                {
                    Log.PrintError("[FrontADManager]", $"LoadAd Error {error}", global::ELog.ADLog);
                    return;
                }
                if (ad == null)
                {
                    Log.PrintError("[FrontADManager]", $"LoadAd Error AD is null", global::ELog.ADLog);
                    return;
                }

                _InterstitialAd = ad;
                RegisterEventHandlers(ad);
            });
        }

        private Action resultAct = null;

        private void RegisterEventHandlers(InterstitialAd ad)
        {
            //광고에서 수익이 발생한 것으로 추정될 때 발생합니다.
            ad.OnAdPaid += (AdValue adValue) =>
            {
                Log.Print("[FrontADManager]", $"OnAdPaid", global::ELog.ADLog);
                //StartCoroutine(GetReward());
                MobileAds.RaiseAdEventsOnUnityMainThread = true;
            };
            //광고에 대한 노출이 기록될 때 발생합니다.
            ad.OnAdImpressionRecorded += () =>
            {
                Log.Print("[FrontADManager]", $"OnAdImpressionRecorded", global::ELog.ADLog);
            };
            //광고에 대한 클릭이 기록될 때 발생합니다.
            ad.OnAdClicked += () =>
            {
                Log.Print("[FrontADManager]", $"OnAdClicked", global::ELog.ADLog);
            };
            //광고가 전체 화면 콘텐츠를 열 때 발생합니다.
            ad.OnAdFullScreenContentOpened += () =>
            {
                Log.Print("[FrontADManager]", $"OnAdFullScreenContentOpened", global::ELog.ADLog);
            };
            //광고가 전체 화면 콘텐츠를 닫을 때 발생합니다.
            ad.OnAdFullScreenContentClosed += () =>
            {
                Log.Print("[FrontADManager]", $"OnAdFullScreenContentClosed", global::ELog.ADLog);
                LoadAd();
                resultAct?.Invoke();
            };
            // 광고가 전체 화면 콘텐츠를 열지 못했을 때 발생합니다.
            ad.OnAdFullScreenContentFailed += (AdError error) =>
            {
                Log.PrintError("[FrontADManager]", $"OnAdFullScreenContentFailed {error}", global::ELog.ADLog);
            };
        }

        public bool IsADNull()
        {
            if (_InterstitialAd == null)
            {
                LoadAd();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowAd(Action resultAct = null)
        {
            this.resultAct = resultAct;
            if (_InterstitialAd != null && _InterstitialAd.CanShowAd())
            {
                _InterstitialAd.Show();
            }
            else
            {
                LoadAd();
                resultAct?.Invoke();
            }
        }

        public void DestroyAd()
        {
            if (_InterstitialAd != null)
            {
                _InterstitialAd.Destroy();
                _InterstitialAd = null;
            }
        }
    }
}