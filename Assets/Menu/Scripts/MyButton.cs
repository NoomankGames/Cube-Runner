/*
 * author: Kirakosyan Nikita Andreevich
 * e-mail: noomank.games@gmail.com
 */
using UnityEngine;
using UnityEngine.UI;

//Функционал самописной кнопки
public class MyButton : MonoBehaviour
{
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private Sprite _anotherSprite;

    [SerializeField] private string _settingsKeyName = "Audio";

    private Image _render;

    private void Start()
    {
        _render = GetComponent<Image>();
        _defaultSprite = _render.sprite;
    }

    private void LateUpdate()
    {
        if (PlayerPrefs.GetString(_settingsKeyName) == "disabled") _render.sprite = _anotherSprite;
        else _render.sprite = _defaultSprite;
    }

    //Изменяет спрайт кнопки
    public void Swap()
    {
        if (_render.sprite == _defaultSprite) _render.sprite = _anotherSprite;
        else _render.sprite = _defaultSprite;
    }

    //Изменяет настройку
    public void SwitchSetting()
    {
        if (PlayerPrefs.GetString(_settingsKeyName) == "disabled")
        {
            PlayerPrefs.SetString(_settingsKeyName, "enabled");
        }
        else
        {
            PlayerPrefs.SetString(_settingsKeyName, "disabled");
        }
    }

    public void EnableSetting()
    {
        PlayerPrefs.SetString(_settingsKeyName, "enabled");
    }

    public void DisableSetting()
    {
        PlayerPrefs.SetString(_settingsKeyName, "disabled");
    }
}
