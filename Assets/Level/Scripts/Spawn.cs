/*
 * author: Kirakosyan Nikita Andreevich
 * e-mail: noomank.games@gmail.com
 */
using UnityEngine;

//Спавн предметов
public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnObjects;//Объекты для спавна
    [SerializeField] private Material[] _materials;//Материалы для спавн объектов
    [SerializeField] private int _spawnAtTime = 10;//Кол-во заспавненных объектов за раз
    [SerializeField] private float _spawnOffset = 6.0f;//Дистанция между объектами
    [SerializeField] private float _delayToSpawn = 3.0f;//Промежуток времени, между которым происходит спавн
    private float _returnDelay;

    private Vector3 _lastSpawnPosition = new Vector3(0, 0.15f, 10.0f);

    private void Awake()
    {
        _returnDelay = _delayToSpawn;
        _delayToSpawn = 0.0f;
    }

    private void Update()
    {
        if (PlayerController.alive == false) Destroy(this);

        if (_delayToSpawn > 0) _delayToSpawn -= Time.deltaTime;
        else
        {
            SpawnRandomObject(_spawnObjects);
            _delayToSpawn = _returnDelay;
        }
    }

    //Заспавнить случайный объект из массива
    private void SpawnRandomObject(Transform[] objects)
    {
        for (int i = 0; i < _spawnAtTime; i++)
        {
            int index = Random.Range(0, objects.Length);
            int material = Random.Range(0, _materials.Length);
            int countAtTIme = Random.Range(1, 3);
            int xPosition = Random.Range(-1, 2);

            Vector3 spawnPosition;
            Transform spawnObject = Instantiate(objects[index]) as Transform;
            spawnObject.GetComponent<MeshRenderer>().material = _materials[material];

            if (spawnObject.localScale.y == 1) spawnPosition = new Vector3(xPosition, 0.15f, _lastSpawnPosition.z + _spawnOffset);
            else spawnPosition = new Vector3(xPosition, 0.65f, _lastSpawnPosition.z + 5.0f);
            spawnObject.position = spawnPosition;
            _lastSpawnPosition = spawnObject.position;

            if (countAtTIme > 1)
            {
                material = Random.Range(0, _materials.Length);
                spawnObject = Instantiate(objects[index]) as Transform;
                spawnObject.GetComponent<MeshRenderer>().material = _materials[material];

                if (spawnPosition.x > 0) spawnPosition = new Vector3(xPosition - 1.0f, spawnPosition.y, spawnPosition.z);
                else if (spawnPosition.x < 0) spawnPosition = new Vector3(xPosition + 1.0f, spawnPosition.y, spawnPosition.z);
                else spawnPosition = new Vector3(0.0f, spawnPosition.y, spawnPosition.z);
                spawnObject.position = spawnPosition;
                _lastSpawnPosition = spawnObject.position;
            }
        }
    }
}
