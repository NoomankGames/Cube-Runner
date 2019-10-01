/*
 * author: Kirakosyan Nikita Andreevich
 * e-mail: noomank.games@gmail.com
 */
using UnityEngine;

//Управление платформой
public class PlatformController : MonoBehaviour
{
    public PlayerController player;
   
    private float _moveSpeed;

    private void Update()
    {
        _moveSpeed = player.GetMoveSpeed();
        transform.Translate(transform.forward * _moveSpeed * Time.deltaTime);
    }
}
