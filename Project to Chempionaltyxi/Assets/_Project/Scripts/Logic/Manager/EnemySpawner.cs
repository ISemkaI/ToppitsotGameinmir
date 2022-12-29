using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _player;

    [Header("Настройка волн: ")]
    [SerializeField] private List<int> _wavesEnemiesCount;
    [SerializeField] private List<float> _wavesTime;
    [SerializeField] private List<Transform> _wavesEnemiesPoints;

    private readonly List<EnemyStateMachine> _enemies = new List<EnemyStateMachine>();

    private Coroutine _spawnerRoutine;

    void Start()
    {
        CreateEnemy();
        _spawnerRoutine = StartCoroutine(SpawnerRoutine());
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
        foreach(var spawnPoint in _wavesEnemiesPoints)
        {
            var enemy = Instantiate(_enemyPrefab,
                spawnPoint.position,
                Quaternion.identity);

            enemy.transform.Rotate(0, Random.Range(0, 360), 0);
            RealizeNewStateMachine(enemy);
        }


    }

    private void RealizeNewStateMachine(GameObject enemy)
    {
        var enemyStateMachine = new EnemyStateMachine(enemy.GetComponent<Healthable>(),
            enemy.GetComponent<IAnimatable>(), enemy.GetComponent<IShootable>(),
            this, enemy.transform, _player, enemy.GetComponent<PhysicsEventAdapter>(),
            enemy.GetComponent<NavMeshAgent>());

        _enemies.Add(enemyStateMachine);

        // Подписываемся на смерть врага
        //_enemy.EnemyDied = _playerCharacter.UpdateKillCount;
    }
}
