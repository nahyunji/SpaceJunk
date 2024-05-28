using GoogleMobileAds.Api;
using Sirenix.OdinInspector;
using System;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Universe
{
    public class UnityADManager : SingletonConfigured<UnityADManager>, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
    {
        public string GAME_ID; //replace with your gameID from dashboard. note: will be different for each platform.

        public string RewardAndroid;
        public string InterstitialAndroid;

        private bool testMode = false;

        //utility wrappers for debuglog
        public delegate void DebugEvent(string msg);

        public static event DebugEvent OnDebugLog;

        private Action<bool> resultActReward;
        private Action resultActFront;
        private bool isReward = true;

        private void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
#if UNITY_EDITOR
            testMode = true;
#endif

            if (Advertisement.isSupported)
            {
                DebugLog(Application.platform + " supported by Advertisement");
            }
            Advertisement.Initialize(GAME_ID, testMode, this);
        }

        public void LoadRewardedAd()
        {
            Advertisement.Load(RewardAndroid, this);
        }

        public void ShowRewardedAd(Action<bool> aDResult)
        {
            isReward = true;
            resultActReward = aDResult;
            Advertisement.Show(RewardAndroid, this);
        }

        public void LoadNonRewardedAd()
        {
            Advertisement.Load(InterstitialAndroid, this);
        }

        public void ShowNonRewardedAd(Action aDResult)
        {
            isReward = false;
            resultActFront = aDResult;
            Advertisement.Show(InterstitialAndroid, this);
        }

        #region Interface Implementations

        public void OnInitializationComplete()
        {
            DebugLog("Init Success");
            LoadRewardedAd();
            LoadNonRewardedAd();
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            DebugLog($"Init Failed: [{error}]: {message}");
        }

        public void OnUnityAdsAdLoaded(string placementId)
        {
            DebugLog($"Load Success: {placementId}");
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            DebugLog($"Load Failed: [{error}:{placementId}] {message}");
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            DebugLog($"OnUnityAdsShowFailure: [{error}]: {message}");

            if (isReward)
            {
                var popup = PopupManager.Open(Local.Utils.EPopup.Toast_Confirm);
                popup.GetComponent<Popup_ToastConfirm>().SetPopup(null, "{0}", (true, "AD_YET"));
                resultActReward?.Invoke(false);
                LoadRewardedAd();
            }
            else
            {
                LoadNonRewardedAd();
                resultActFront.Invoke();
            }
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            DebugLog($"OnUnityAdsShowStart: {placementId}");
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            DebugLog($"OnUnityAdsShowClick: {placementId}");
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState state)
        {
            DebugLog($"OnUnityAdsShowComplete: [{state}]: {placementId}");

            if (isReward && state == UnityAdsShowCompletionState.COMPLETED)
            {
                resultActReward?.Invoke(true);
            }
            else if (isReward)
            {
                resultActReward?.Invoke(false);
            }

            if (isReward) LoadRewardedAd();
            else
            {
                LoadNonRewardedAd();
                resultActFront.Invoke();
            }
        }

        #endregion Interface Implementations

        public void OnGameIDFieldChanged(string newInput)
        {
            GAME_ID = newInput;
        }

        public void ToggleTestMode(bool isOn)
        {
            testMode = isOn;
        }

        //wrapper around debug.log to allow broadcasting log strings to the UI
        private void DebugLog(string msg)
        {
            OnDebugLog?.Invoke(msg);
            Debug.Log(msg);
        }
    }
}