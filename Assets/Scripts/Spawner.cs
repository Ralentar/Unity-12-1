using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _repeatRate = 2;

    private const string PrefabName = "RedEnemy";

    private void Awake()
    {
        _enemy = Resources.Load<Enemy>(PrefabName);
        _spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
            _spawnPoints[i] = transform.GetChild(i);
    }

    private void Start()
    {
        float time = 0;
        InvokeRepeating(nameof(CreateEnemy), time, _repeatRate);
    }

    private void CreateEnemy()
    {
        int zero = 0;
        int index = Random.Range(zero, _spawnPoints.Length);
        Vector3 targetPosition = _spawnPoints[index].GetChild(zero).transform.position;

        Enemy enemy = Instantiate(_enemy, _spawnPoints[index].position, Quaternion.identity);
        enemy.Initialize(targetPosition);
    }
}