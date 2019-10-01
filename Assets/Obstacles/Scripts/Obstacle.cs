/*
 * author: Kirakosyan Nikita Andreevich
 * e-mail: noomank.games@gmail.com
 */
using UnityEngine;

//Скрипт препятствия
public class Obstacle : MonoBehaviour
{
    private void Update()
    {
        if(transform.position.z < Camera.main.transform.position.z - 2.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player Cube")
        {
            other.transform.parent.GetComponent<PlayerController>().Defeat();
            GetComponent<Collider>().enabled = false;
        }
    }
}
