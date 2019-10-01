/*
 * author: Kirakosyan Nikita Andreevich
 * e-mail: noomank.games@gmail.com
 */
using UnityEngine;
using UnityEngine.UI;

public class Theme : MonoBehaviour
{
    [SerializeField] private Color _lightTheme = Color.white;
    [SerializeField] private Color _nightTheme = Color.black;

    [SerializeField] private Light _mainLight;
    private Image _thisImage;

    private void Start()
    {
        _thisImage = GetComponent<Image>();
    }

    private void LateUpdate()
    {
        if (PlayerPrefs.GetString("Theme") == "disabled")
        {
            if (_thisImage != null) _thisImage.color = _nightTheme;
            if (_mainLight != null) _mainLight.intensity = 0.5f;
            Camera.main.backgroundColor = _nightTheme;
        }
        else
        {
            if (_thisImage != null) _thisImage.color = _lightTheme;
            if (_mainLight != null) _mainLight.intensity = 1.0f;
            Camera.main.backgroundColor = _lightTheme;
        }
    }
}
