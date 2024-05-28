using GoogleMobileAds.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Universe
{
    public class AdmobMediationManager : MonoBehaviour
    {
        public void Start()
        {
            Debug.Log($"AdmobMediationManager Start");
            MobileAds.Initialize((initStatus) =>
           {
               Dictionary<string, AdapterStatus> map = initStatus.getAdapterStatusMap();
               foreach (KeyValuePair<string, AdapterStatus> keyValuePair in map)
               {
                   string className = keyValuePair.Key;
                   AdapterStatus status = keyValuePair.Value;
                   switch (status.InitializationState)
                   {
                       case AdapterState.NotReady:

                           MonoBehaviour.print("<color=#C64CB8>" + "Adapter: " + className + " not ready." + "</color>");
                           break;

                       case AdapterState.Ready:

                           MonoBehaviour.print("<color=#C64CB8>" + "Adapter: " + className + " is initialized." + "</color>");
                           break;
                   }
               }
               GetComponent<ADManager>().LoadAd();
               GetComponent<FrontADManager>().LoadAd();
           });
        }
    }
}