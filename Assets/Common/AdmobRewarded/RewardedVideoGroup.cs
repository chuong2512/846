﻿using UnityEngine;

public class RewardedVideoGroup : MonoBehaviour
{
    public GameObject buttonGroup;
    public GameObject textGroup;
    public TimerText timerText;

    private const string ACTION_NAME = "rewarded_video";

    private void Start()
    {
        if (timerText != null) timerText.onCountDownComplete += OnCountDownComplete;

        buttonGroup.SetActive(false);
    }
    
    private void IUpdate()
    {
        buttonGroup.SetActive(IsAvailableToShow());
    }

    public void OnClick()
    {
        AdmobController.instance.ShowRewardBasedVideo();
        Sound.instance.PlayButton();
    }

    private void ShowTimerText(int time)
    {
        if (textGroup != null)
        {
            textGroup.SetActive(true);
            timerText.SetTime(time);
            timerText.Run();
        }
    }

   

    private void OnCountDownComplete()
    {
        textGroup.SetActive(false);
        if (IsAdAvailable())
        {
            buttonGroup.SetActive(true);
        }
    }

    public bool IsAvailableToShow()
    {
        return IsActionAvailable() && IsAdAvailable();
    }

    private bool IsActionAvailable()
    {
        return CUtils.IsActionAvailable(ACTION_NAME, ConfigController.Config.rewardedVideoPeriod);
    }

    
    
    private bool IsAdAvailable()
    { return false;
    }

    private void OnDestroy()
    {
#if UNITY_ANDROID || UNITY_IOS
        if (AdmobController.instance.rewardBasedVideo != null)
        {
            AdmobController.instance.rewardBasedVideo.OnAdRewarded -= HandleRewardBasedVideoRewarded;
        }
#endif
    }

    private void OnApplicationPause(bool pause)
    {
        if (!pause)
        {
            if (textGroup != null && textGroup.activeSelf)
            {
                int remainTime = (int)(ConfigController.Config.rewardedVideoPeriod - CUtils.GetActionDeltaTime(ACTION_NAME));
                ShowTimerText(remainTime);
            }
        }
    }
}
