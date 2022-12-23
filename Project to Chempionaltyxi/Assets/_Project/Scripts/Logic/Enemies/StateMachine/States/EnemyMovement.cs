using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementState : IState
{
    private readonly IStateSwitcher _stateSwitcher;
    private readonly Transform _enemy;
    private readonly Transform _player;
    private readonly NavMeshAgent _navMeshAgent;

    private readonly PhysicsEventAdapter _physicsEventAdapter;

    public EnemyMovementState(IStateSwitcher stateSwitcher, Transform enemy, Transform player, NavMeshAgent navMeshAgent, PhysicsEventAdapter physicsEventAdapter)
    {
        _stateSwitcher = stateSwitcher;

        _enemy = enemy;
        _player = player;
        _navMeshAgent = navMeshAgent;
        _physicsEventAdapter = physicsEventAdapter;
    }

    public void Enter()
    {
        // Указываем цель для движения врага
        _navMeshAgent.SetDestination(_player.position);

        // Подписываемся на событие остановки
        _physicsEventAdapter.TriggerEnterEvent.AddListener(OnTriggerStopEnter);
    }

    public void Exit()
    {
        // Отписываемся от события остановки
        _physicsEventAdapter.TriggerEnterEvent.AddListener(OnTriggerStopEnter);
    }

    // Слой триггера: TriggerEnemyStop
    // Слой врага: Enemy
    private void OnTriggerStopEnter()
    {
        _navMeshAgent.isStopped = true;
        FaceToPlayer();

        _stateSwitcher.SwitchState<EnemyMovementState>();
    }

    private void FaceToPlayer()
    {
        _enemy.LookAt(_player.position);
        _enemy.localEulerAngles = new Vector3(0f, _player.localEulerAngles.y, 0f);
    }

    /*    private void EnterShotingState()
        {
            // Разворачиваем врага к персонажу только по оси y (лицом).
            transform.LookAt(Player.position);
            transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);

        }

        IEnumerator ShootingRoutine()
        {
            while (true)
            {
                yield return null;
            }
        }*/


}
