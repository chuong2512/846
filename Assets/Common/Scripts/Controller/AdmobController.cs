using UnityEngine;
using System;

public class AdmobController : MonoBehaviour
{

    public static AdmobController instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        if (!CUtils.IsAdsRemoved())
        {
            //RequestBanner();
            RequestInterstitial();
        }

        InitRewardedVideo();
        RequestRewardBasedVideo();
    }

    private void InitRewardedVideo()
    {
        // Get singleton reward based video ad reference.
      
    }

    public void RequestBanner()
    {
       
    }

    public void RequestInterstitial()
    {
     
    }

    public void RequestRewardBasedVideo()
    {
    }


   

   
    public void ShowRewardBasedVideo()
    {
      
    }
}
