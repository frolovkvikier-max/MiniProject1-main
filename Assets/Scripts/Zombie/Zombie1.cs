using UnityEngine;

public class Zombie1 : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 0.2f;
    [SerializeField] private float _spawnRange = 15f;
    [SerializeField] private Zombie _zombiePrefab;

    [SerializeField] private Transform _carTransform;

    private float timer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = _spawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnZombie();
            timer = _spawnRate;
        }
    }

    private void SpawnZombie()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-9, 9), 0.09f, _carTransform.position.z + _spawnRange);
        Instantiate(_zombiePrefab, spawnPoint, Quaternion.identity);
    }
}
