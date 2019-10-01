/*
 * author: Kirakosyan Nikita Andreevich
 * e-mail: noomank.games@gmail.com
 */
using UnityEngine;
using UnityEngine.UI;

//Управление процессом игры
public class GameManager : Singleton<GameManager>
{
    [Header("Objects on scene")]
    [SerializeField] private PlayerController _player;//Игрок на сцене
    [SerializeField] private GameObject _menu;//Меню на сцене
    [SerializeField] private GameObject _startWindow;//Стартовое окно на сцене
    [SerializeField] private GameObject _musicPoint;//Объект, содержащий музыку на сцене

    [Header("UI")]
    [SerializeField] private Text _distanceText;//Текст, отображающий пройденную дистанцию

    [Header("Game Settings")]
    [SerializeField] private float _timeAcceleration = 1.0f;//Ускорение времени
    [SerializeField] private float _maxTimeScale = 3.5f;//Максимальная скорость времени
    [HideInInspector] public float distance { get; private set; }//Пройденная дистанция от начала
    [HideInInspector] public float bestDistance { get; private set; }//Лучшая пройденная дистанция

    public static bool GamePause = true;//Пауза игры

    private void Start()
    {
        bestDistance = PlayerPrefs.GetFloat("Best Distance");
        _menu.SetActive(false);
        GamePause = true;
    }

    private void Update()
    {
        if (PlayerController.alive == false)
        {
            _menu.SetActive(true);
            _musicPoint.SetActive(false);

            if(distance > bestDistance)
            {
                bestDistance = distance;
                PlayerPrefs.SetFloat("Best Distance", bestDistance);
            }
        }

        //Если игра на паузе и меню отключено
        if (GamePause == true)
        {
            _distanceText.text = "Best: " + ((int)bestDistance).ToString() + "m";
            Time.timeScale = 0.0f;

            if (Input.GetMouseButton(0) && PlayerController.alive == true)
            {
                Time.timeScale = 1.0f;
                GamePause = false;
                _startWindow.SetActive(false);
            }
        }
    }

    private void LateUpdate()
    {
        if (PlayerController.alive == true && GamePause == false)
        {
            Time.timeScale += _timeAcceleration * Time.deltaTime;
            if (Time.timeScale > _maxTimeScale) Time.timeScale = _maxTimeScale;

            distance = Mathf.Abs(0.0f - _player.transform.position.z);
            _distanceText.text = ((int)distance).ToString() + "m";
        }
    }
}
