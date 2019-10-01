/*
 * author: Kirakosyan Nikita Andreevich
 * e-mail: noomank.games@gmail.com
 */
using UnityEngine;
public class SettingsManager : MonoBehaviour
{
    [SerializeField] private GameObject _musicPoint;

    [Header("Settings Keys")]
    [SerializeField] private string _musicKeyName = "Music";
    [SerializeField] private string _adsKeyName = "Ads";

    private void Start()
    {
        Application.targetFrameRate = 60;

        if (PlayerPrefs.GetString(_musicKeyName) == "disabled")
        {
            if(_musicPoint != null) _musicPoint.SetActive(false);
        }
        else
        {
            if (_musicPoint != null) _musicPoint.SetActive(true);
        }
    }

    public static bool GetKeyValue(string keyName)
    {
        bool value = false;

        if(PlayerPrefs.GetString(keyName) == "enabled")
        {
            value = true;
        }
        else
        {
            value = false;
        }

        return value;
    }
}
