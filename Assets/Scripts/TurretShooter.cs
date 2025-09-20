using UnityEngine;

public class TurretShooter : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private float _spawnRate = 1.5f;
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
            SpawnBullet();
            timer = _spawnRate;
        }
    }

    private void SpawnBullet()
    {
        Instantiate(_bulletPrefab, _spawnPoint.position, _spawnPoint.rotation);
    }
}
