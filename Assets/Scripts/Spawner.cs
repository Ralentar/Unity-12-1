using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const string PrefabName = "RedEnemy";

    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _waitTime = 2;
    [SerializeField] private float _offsetPosition = 10;

    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_waitTime);
        StartCoroutine(CreateEnemy());
    }

    private IEnumerator CreateEnemy()
    {
        int zero = 0;
        bool isWork = true;

        while (isWork)
        {
            int index = Random.Range(zero, _spawnPoints.Length);

            Vector3 spawnPosition = _spawnPoints[index].transform.position;

            Enemy enemy = Instantiate(_enemy, spawnPosition, Quaternion.identity);
            enemy.SetDirection(CreateDirection(spawnPosition));

            yield return _wait;
        }
    }

    private Vector3 CreateDirection(Vector3 spawnPosition)
    {
        Vector3 offset = new Vector3(Random.Range(-_offsetPosition, _offsetPosition),
                                     Random.Range(-_offsetPosition, _offsetPosition),
                                     Random.Range(-_offsetPosition, _offsetPosition));

        return (offset - spawnPosition).normalized;
    }

#if UNITY_EDITOR
    [ContextMenu("Refresh SpawnPoints Array")]
    private void RefreshSpawnPoints()
    {
        _enemy = Resources.Load<Enemy>(PrefabName);

        _spawnPoints = new Transform[transform.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
            _spawnPoints[i] = transform.GetChild(i);
    }
#endif
}