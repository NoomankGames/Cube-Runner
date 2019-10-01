/*
 * author: Kirakosyan Nikita Andreevich
 * e-mail: noomank.games@gmail.com
 */
using UnityEngine;

//Следование за целью
public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private Vector3 _distanceOffset;

    private void Start()
    {
        _distanceOffset = transform.position - _target.position;
    }

    private void LateUpdate()
    {
        transform.position = _distanceOffset + _target.position;
    }
}
