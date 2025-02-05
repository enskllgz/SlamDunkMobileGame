using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
{
    [SerializeField] private string androidAdUnitId;
    [SerializeField] private string iosdAdUnitId;

    private string adunitId;

    private void Awake() 
    {
#if UNITY_IOS
//adUnitID = iosAdunitId;
#elif UNITY_ANDROÝD
adUnitID = androidAdunitId;
#endif
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }
    public void LoadBannerAd() 
    {

        BannerLoadOptions options = new BannerLoadOptions
        {
            loadCallback = BannerLoaded,
            errorCallback = BanenrLoadedError

        };

        Advertisement.Banner.Load(adunitId, options);
    }

    public void ShowBannerAd()
    {
        BannerOptions options = new BannerOptions
        {

            showCallback = BannerShown,
            clickCallback = BannerClicked,
            hideCallback = BannerHidden,

        };
        Advertisement.Banner.Show(adunitId, options);
    }

    public void HideBannerAd() 
    {
        Advertisement.Banner.Hide();
    }

    private void BannerHidden() {      }

    private void BannerClicked() {     }

    private void BannerShown()   {     }
     



    private void BanenrLoadedError(string message){}

    private void BannerLoaded()
    {
        Debug.Log("Banner Ad Loaded");
    }
}
