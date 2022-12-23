using System;
using System.Collections;
using UnityEngine;

public class EnemyShootingState : IState
{
    private readonly IStateSwitcher _stateSwitcher;
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly IShootable _shootable;

    private readonly Transform _player;

    private Coroutine _shootingCoroutine;

    public EnemyShootingState(EnemyStateMachine enemyStateMachine, IShootable shootable, 
        ICoroutineRunner coroutineRunner, Transform player)
    {
        _stateSwitcher = enemyStateMachine;
        _coroutineRunner = coroutineRunner;
        _shootable = shootable;

        _player = player;

        _shootingCoroutine = null;
    }

    public void Enter() 
        => _shootingCoroutine = _coroutineRunner.StartCoroutine(ShootingRoutine());

    public void Exit()
    {
        if (_shootingCoroutine != null )
        {
            _coroutineRunner.StopCoroutine(_shootingCoroutine);
            _shootingCoroutine = null;
        }
    }

    // Каждые CoolDown секунд заставляем игрока стрелять
    private IEnumerator ShootingRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_shootable.Cooldown);
            _shootable.Shoot(_player);
        }
    }

}