/*
 * author: Kirakosyan Nikita Andreevich
 * e-mail: noomank.games@gmail.com
 */
using UnityEngine;
using UnityEngine.EventSystems;

//Управление игроком
public class PlayerController : MonoBehaviour
{
    private EventSystem _eventSystem;

    [Header("Control")]
    [SerializeField] private Transform _cube;//Куб - игрок
    [SerializeField] private float _moveSpeed = 5.0f;//Скорость передвижения
    [SerializeField] private float _rollSpeed = 5.0f;//Скорость переворота
    [SerializeField] private float _maxXPosition = 1.0f;//Максимальная позиция по X
    [SerializeField] private float _minXPosition = -1.0f;//Минимальная позиция по X
    public static bool alive { get; private set; }

    private Vector3 _rollPosition;//Позиция на которую нужно перевернуться
    private bool _rolled = false;//Был переворот?

    [Header("Effects")]
    [SerializeField] private ParticleSystem _deathEffect;

    [Header("Audio")]
    [SerializeField] private AudioClip _rollSound;
    [SerializeField] private AudioClip _deathSound;
    private AudioSource _audioSource;

    [Header("Animations")]
    [SerializeField] private AnimationClip _rollToRightAnimation;//Анимация переворота направо
    [SerializeField] private AnimationClip _rollToLeftAnimation;//Анимация переворота налево
    private Animation _animation;

    private void Start()
    {
        _eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();

        alive = true;
        _audioSource = GetComponent<AudioSource>();
        _animation = GetComponent<Animation>();
    }

    private void Update()
    {
        //Если игра на паузе или игрок проиграл, то пропускать дальнейшие действия
        if (GameManager.GamePause == true || alive == false) return;

        transform.Translate(transform.forward * _moveSpeed * Time.deltaTime);

        //Если игрок не кликнул по элементу UI
        if (_eventSystem.IsPointerOverGameObject() == false)
        {
            if (Input.GetMouseButtonDown(0) && _animation.isPlaying == false)
            {
                if (Input.mousePosition.x >= Screen.width / 2 && _cube.position.x < _maxXPosition - 0.1f)
                {
                    Roll(_cube, _rollToRightAnimation, true);
                }
                else if (Input.mousePosition.x < Screen.width / 2 && _cube.position.x > _minXPosition + 0.1f)
                {
                    Roll(_cube, _rollToLeftAnimation, false);
                }
            }
        }

        if (_rolled == true)
        {
            Vector3 position = _cube.position;
            position = Vector3.MoveTowards(position, _rollPosition, _rollSpeed * Time.deltaTime);
            _cube.position = new Vector3(position.x, _cube.position.y, _cube.position.z);

            if (_cube.position == _rollPosition) _rolled = false;
        }
    }

    private void LateUpdate()
    {
        //Если игра на паузе или игрок проиграл, то пропускать дальнейшие действия
        if (GameManager.GamePause == true || alive == false) return;

        if (_cube.position.x >= _maxXPosition)
        {
            _cube.position = new Vector3(_maxXPosition, _cube.position.y, _cube.position.z);
            _rolled = false;
        }
        else if (_cube.position.x <= _minXPosition)
        {
            _cube.position = new Vector3(_minXPosition, _cube.position.y, _cube.position.z);
            _rolled = false;
        }
    }

    //Переворачивает объект
    private void Roll(Transform target, AnimationClip rollAnimation, bool rollToRight)
    {
        _rolled = true;

        _audioSource.clip = _rollSound;
        _audioSource.Play();
        _animation.clip = rollAnimation;
        _animation.Play();

        _rollPosition = new Vector3(target.position.x, target.position.y, target.position.z);

        if (rollToRight == true)
        {
            _rollPosition.x += 1;
        }
        else
        {
            _rollPosition.x -= 1;
        }
    }

    //Возвращает скорость передвижения
    public float GetMoveSpeed()
    {
        return _moveSpeed;
    }

    //Проиграть
    public void Defeat()
    {
        alive = false;

        _audioSource.clip = _deathSound;
        _audioSource.Play();
        _deathEffect.Play();

        Destroy(_cube.gameObject);
    }
}
