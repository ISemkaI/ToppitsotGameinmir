using System;
using System.Collections;
using UnityEngine;

public class EnemyShootingState : IState
{
    private readonly ICoroutineRunner _coroutineRunner;
    private readonly IShootable _shootable;
    private readonly IAnimatable _animatable;
    private readonly Transform _player;

    private Coroutine _shootingCoroutine;

    public EnemyShootingState(IShootable shootable, IAnimatable animatable, ICoroutineRunner coroutineRunner, Transform player)
    {
        _coroutineRunner = coroutineRunner;
        _shootable = shootable;
        _animatable = animatable;
        _player = player;

        _shootingCoroutine = null;
    }

    public void Enter()
    {
        _shootingCoroutine = _coroutineRunner.StartCoroutine(ShootingRoutine());
        _animatable.EnterShootingState();
    }

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
            _animatable.ShootAnimation();
            _shootable.Shoot(_player);
        }
    }

}