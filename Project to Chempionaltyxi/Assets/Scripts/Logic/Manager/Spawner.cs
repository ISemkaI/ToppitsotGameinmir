using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ReactiveTarget _enemyPrefab;
    [SerializeField] private SceneUI _playerCharacter;

    [Header("Настройка волн: ")]
    [SerializeField] private List<int> _wavesEnemiesCount;
    [SerializeField] private List<float> _wavesTime;
    [SerializeField] private List<Transform> _wavesEnemiesPoints;

    private Coroutine _spawnerRoutine;
    private int _spawnerIndex;

    void Start()
    {
        CreateEnemy();
        _spawnerRoutine = StartCoroutine(SpawnerRoutine());
    }

    private void Update()
    {
    }

    public void StopSpawner()
    {
        if (_spawnerRoutine != null)
        {
            StopCoroutine(_spawnerRoutine);
            _spawnerRoutine = null;
        }    
    }

    IEnumerator SpawnerRoutine()
    {
        for (int i = 0; i < _wavesEnemiesCount.Count; i++)
        {
            for (int j = 0; j < _wavesEnemiesCount[i]; j++)
                CreateEnemy();

            yield return new WaitForSeconds(_wavesTime[i]);
        }

        _spawnerRoutine = null;
    }

    private void CreateEnemy()
    {
        Debug.Log(_spawnerIndex + " " +  _wavesEnemiesPoints.Count);

        int index = (_spawnerIndex++) % _wavesEnemiesPoints.Count;

        ReactiveTarget _enemy = Instantiate(_enemyPrefab,
            _wavesEnemiesPoints[index].position, 
            Quaternion.identity);

        _enemy.transform.Rotate(0, Random.Range(0, 360), 0);

        // Подписываемся на смерть врага
        _enemy.EnemyDied = _playerCharacter.UpdateKillCount;
    }
}
