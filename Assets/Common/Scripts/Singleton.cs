/*
 * author: Kirakosyan Nikita Andreevich
 * e-mail: noomank.games@gmail.com
 */
using UnityEngine;

//Дает доступ к единственному объекту на сцене
public class Singleton <T>: MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T instance
    {
        get
        {
            //Если объект не найден
            if(_instance == null)
            {
                //Попробовать найти его на сцене
                _instance = FindObjectOfType<T>();

                //Если объект не нашелся, то вывести ошибку
                if(_instance == null)
                {
                    Debug.LogError("Can't find " + typeof(T) + "!");
                }
            }

            return _instance;
        }
    }
}
