using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class AdController : MonoBehaviour
{
    public static AdController instance;
    public int adAmount = 1;

    private string store_id = "3336930";

    private string video_ad = "video";
    private string rewarded_video_ad = "rewardedVideo";

    private int deathCounter;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        Monetization.Initialize(store_id, false);
        deathCounter = 0;
    }
    
    public void ShowRewardedAd()
    {
        if (Monetization.IsReady(rewarded_video_ad))
        {
            ShowAdPlacementContent ad = null;
            ad = Monetization.GetPlacementContent(rewarded_video_ad) as ShowAdPlacementContent;

            if (ad != null)
            {
                ad.Show();
            }
        }
    }

    public void ShowNormalAd()
    {
        if (Player.died)
        {
            deathCounter++;
        }

        if (deathCounter == adAmount) 
        {
            if (Monetization.IsReady(video_ad))
            {
                ShowAdPlacementContent ad = null;
                ad = Monetization.GetPlacementContent(video_ad) as ShowAdPlacementContent;

                if (ad != null)
                {
                    ad.Show();
                }
            }

            deathCounter = 0;
        }
        
    }
}
