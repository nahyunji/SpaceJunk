using GoogleMobileAds.Api;
using System;
using System.Collections;
using UnityEngine;

namespace Universe
{
    public class ADManager : SingletonConfigured<ADManager>
    {
        private string rewardAndroidID;
        private string rewardIOSID;

#if UNITY_ANDROID
        private const string rewardTestId;
        private string RewardId => rewardAndroidID;
#else
        private const string rewardTestId = "unused";
        private string RewardId = "unused";
#endif

        private RewardedAd _rewardedAd;

        public void LoadAd()
        {
            if (_rewardedAd != null)
            {
                DestroyAd();
            }
            var adRequest = new AdRequest();

            var id = ServerManager.Instance.IsADTest ? rewardTestId : rewardAndroidID;
#if UNITY_EDITOR
            id = rewardTestId;
#endif
            RewardedAd.Load(id, adRequest, (RewardedAd ad, LoadAdError error) =>
            {
                if (error != null)
                {
                    Log.PrintError("[ADManager]", $"LoadAd Error {error}", global::ELog.ADLog);
                    return;
                }
                if (ad == null)
                {
                    Log.PrintError("[ADManager]", $"LoadAd Error AD is null", global::ELog.ADLog);
                    return;
                }

                _rewardedAd = ad;
                RegisterEventHandlers(ad);
            });
        }

        private Action<bool> resultAct = null;

        public bool IsADNull()
        {
            if (_rewardedAd == null)
            {
                LoadAd();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ShowAd(Action<bool> resultAct)
        {
            this.resultAct = resultAct;
            if (_rewardedAd != null && _rewardedAd.CanShowAd())
            {
                _rewardedAd.Show((Reward reward) =>
                {
                });
            }
            else
            {
                LoadAd();
                resultAct?.Invoke(false);
                var popup = PopupManager.Open(Local.Utils.EPopup.Toast_Confirm);
                popup.GetComponent<Popup_ToastConfirm>().SetPopup(null, "{0}", (true, "AD_YET"));
            }
        }

        public void DestroyAd()
        {
            if (_rewardedAd != null)
            {
                _rewardedAd.Destroy();
                _rewardedAd = null;
            }
        }

        private void RegisterEventHandlers(RewardedAd ad)
        {
            //광고에서 수익이 발생한 것으로 추정될 때 발생합니다.
            ad.OnAdPaid += (AdValue adValue) =>
            {
                Log.Print("[ADManager]", $"OnAdPaid", global::ELog.ADLog);
                StartCoroutine(GetReward());
                MobileAds.RaiseAdEventsOnUnityMainThread = true;
            };
            //광고에 대한 노출이 기록될 때 발생합니다.
            ad.OnAdImpressionRecorded += () =>
            {
                Log.Print("[ADManager]", $"OnAdImpressionRecorded", global::ELog.ADLog);
            };
            //광고에 대한 클릭이 기록될 때 발생합니다.
            ad.OnAdClicked += () =>
            {
                Log.Print("[ADManager]", $"OnAdClicked", global::ELog.ADLog);
            };
            //광고가 전체 화면 콘텐츠를 열 때 발생합니다.
            ad.OnAdFullScreenContentOpened += () =>
            {
                Log.Print("[ADManager]", $"OnAdFullScreenContentOpened", global::ELog.ADLog);
            };
            //광고가 전체 화면 콘텐츠를 닫을 때 발생합니다.
            ad.OnAdFullScreenContentClosed += () =>
            {
                Log.Print("[ADManager]", $"OnAdFullScreenContentClosed", global::ELog.ADLog);
                LoadAd();

#if UNITY_EDITOR
                resultAct?.Invoke(true);
#endif
            };
            // 광고가 전체 화면 콘텐츠를 열지 못했을 때 발생합니다.
            ad.OnAdFullScreenContentFailed += (AdError error) =>
            {
                Log.PrintError("[ADManager]", $"OnAdFullScreenContentFailed {error}", global::ELog.ADLog);
            };
        }

        private IEnumerator GetReward()
        {
            yield return new WaitForSeconds(0.25f);
            resultAct?.Invoke(true);
        }
    }
}