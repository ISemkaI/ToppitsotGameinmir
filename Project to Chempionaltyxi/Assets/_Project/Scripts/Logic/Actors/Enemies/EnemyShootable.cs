using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootable : MonoBehaviour, IShootable
{
    [Header("Откуда идёт выстрел")]
    [SerializeField] private Transform _shootingPoint;
    
    [Header("Кулдаун стрельбы")]
    [SerializeField] private float _cooldown;

    public float Cooldown => _cooldown;

    private IFactoryEnemyProjectile _projectileFactory;

    private void Awake()
    {
        _projectileFactory = AllServices.Instance.GetService<IFactoryEnemyProjectile>();
    }

    public void Shoot(Transform target)
    {
        var projectile = _projectileFactory.Create(_shootingPoint.position);
        projectile.transform.LookAt(target);
    }
}

