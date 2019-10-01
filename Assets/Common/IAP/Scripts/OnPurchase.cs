/*
 * author: Kirakosyan Nikita Andreevich
 * e-mail: noomank.games@gmail.com
 */
using UnityEngine;
using UnityEngine.Purchasing;

public class OnPurchase : MonoBehaviour
{
    private MyButton _myButton;

    private void Start()
    {
        _myButton = GetComponent<MyButton>();
        PurchaseManager.OnPurchaseNonConsumable += PurchaseManager_OnPurchaseNonConsumable;
    }

    private void PurchaseManager_OnPurchaseNonConsumable(PurchaseEventArgs args)
    {
        _myButton.EnableSetting();
        Debug.Log(PlayerPrefs.GetString("Ads"));
    }
}
