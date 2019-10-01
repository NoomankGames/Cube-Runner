/*
 * author: Kirakosyan Nikita Andreevich
 * e-mail: noomank.games@gmail.com
 */
using UnityEngine;
using UnityEngine.Advertisements;

//Иницализация рекламы
public class InitializeAds : MonoBehaviour
{
    [Header("Ads Settings")]
    [SerializeField] private string _gameID = "3290769";
    [SerializeField] private bool testMode = true;
    public static bool adsShown { get; private set; }//Реклама была показана?
    public static float distanceToShowAds { get; private set; }//Дистанция для показа рекламы

    [Header("Ads Variations")]
    [SerializeField] private string _videoPlacementID = "video";
    [SerializeField] private string _rewardPlacementID = "rewardedVideo";

    private void Start()
    {
        adsShown = false;
        distanceToShowAds = 100.0f;

        if (SettingsManager.GetKeyValue("Ads") == true) Destroy(gameObject);
        Advertisement.Initialize(_gameID, testMode);
    }

    private void Update()
    {
        Advertisement.Load(_videoPlacementID);
        Advertisement.Load(_rewardPlacementID);

        //Если игрок проиграл и прошел фиксированное значение дистанции, то показать рекламу
        if (PlayerController.alive == false && GameManager.instance.distance >= distanceToShowAds)
        {
            //Если реклама не была показана
            if (adsShown == false)
            {
                OnUnityAdsReady(_videoPlacementID);
                adsShown = true;
            }
        }
    }

    //Вызывается, когда реклама готова
    public void OnUnityAdsReady(string placementId)
    {
        //Если реклама готова
        if (Advertisement.IsReady(placementId))
        {
            Advertisement.Show(placementId);
        }
    }

    //Вызывается, когда реклама закончилась
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        //Если результат = реклама закончилась
        if (showResult == ShowResult.Finished)
        {
            
        }
    }

    //Вызывается, если произошла ошибка в рекламе
    public void OnUnityAdsDidError(string message)
    {
       
    }

    //Вызывается, когда реклама началась
    public void OnUnityAdsDidStart(string placementId)
    {
        
    }
}
