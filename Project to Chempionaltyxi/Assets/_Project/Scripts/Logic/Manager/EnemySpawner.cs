using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _playerTransform;

    [Header("Менеджеры игры")]
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameManagerUI _gameManagerUI;

    [Header("Настройка волн: ")]
    [SerializeField] private List<Transform> _wavesEnemiesPoints;
    [SerializeField] private List<int> _wavesEnemiesCount;
    [SerializeField] private List<float> _wavesTime;

    [Header("Разброс позиции спавна")]
    [SerializeField] private Vector2 _offsetBoundsX;
    [SerializeField] private Vector2 _offsetBoundsZ;

    private List<EnemyStateMachine> _enemyStateMachines;
    private Coroutine _spawnerRoutine;

    void Start()
    {
        _enemyStateMachines = new List<EnemyStateMachine>();
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
        for (int i = 0; i < _wavesTime.Count; i++)
        {
            CreateEnemyWave(i);

            yield return new WaitForSeconds(_wavesTime[i]);
        }

        _spawnerRoutine = null;
    }

    private void CreateEnemyWave(int waveIndex)
    {
        for (int i = 0; i < _wavesEnemiesPoints.Count; i++)
            for (int enemiesCount = 0; enemiesCount < _wavesEnemiesCount[waveIndex]; enemiesCount++) 
                CreateEnemy(_wavesEnemiesPoints[i].position);
    }

    private void CreateEnemy(Vector3 position)
    {
        // Разброс места спавна
        position.x += Random.Range(_offsetBoundsX.x, _offsetBoundsX.y);
        position.z += Random.Range(_offsetBoundsZ.x, _offsetBoundsZ.y);
        
        var enemy = Instantiate(_enemyPrefab, position, Quaternion.identity);
        enemy.transform.Rotate(0, Random.Range(0, 360), 0);

        var enemyStateMachine = new EnemyStateMachine(enemy.GetComponent<Healthable>(),
            enemy.GetComponent<IAnimatable>(), enemy.GetComponent<IShootable>(),
            this, enemy.transform, _playerTransform, enemy.GetComponent<PhysicsEventAdapter>(),
            enemy.GetComponent<NavMeshAgent>());
        
        SubscribeEnemyDeath(enemyStateMachine);
    }

    private void SubscribeEnemyDeath(EnemyStateMachine enemyStateMachine)
    {
        enemyStateMachine.EnemyDiedEvent += (_) => _gameManager.IncrementKills();
        enemyStateMachine.EnemyDiedEvent += DeleteFromEnemiesList;
        _enemyStateMachines.Add(enemyStateMachine);
    }

    private void DeleteFromEnemiesList(EnemyStateMachine enemyStateMachine) 
        => _enemyStateMachines.Remove(enemyStateMachine);
}
