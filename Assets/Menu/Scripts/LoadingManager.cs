/*
 * author: Kirakosyan Nikita Andreevich
 * e-mail: noomank.games@gmail.com
 */
using UnityEngine;
using UnityEngine.UI;

//Загрузка уровня
public class LoadingManager : MonoBehaviour
{
    public GameObject loadingWindow;
    [SerializeField] private Slider _loadingSlider;

    public AsyncOperation async;

    private void Awake()
    {
        loadingWindow.SetActive(false);
        _loadingSlider.maxValue = 0.9f;
    }

    private void Update()
    {
        if (async != null)
        {
            _loadingSlider.value = async.progress;
        }
    }
}
