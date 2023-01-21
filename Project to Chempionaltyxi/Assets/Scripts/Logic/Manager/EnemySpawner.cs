using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour, ICoroutineRunner
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private SceneUI _playerCharacter;

    [Header("Главный менеджер игры")]
    [SerializeField] private GameManager _gameManager;

    [Header("Настройка волн: ")]
    [SerializeField] private List<Transform> _wavesEnemiesPoints;
    [SerializeField] private List<int> _wavesEnemiesCount;
    [SerializeField] private List<float> _wavesTime;

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
