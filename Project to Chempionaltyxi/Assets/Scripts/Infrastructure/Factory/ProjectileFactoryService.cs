using System;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactoryService : IFactoryProjectile
{
    public GameObject ProjectilePrefabGetter => ProjectilePrefab;

    protected readonly GameObject ProjectilePrefab;

    public ProjectileFactoryService(GameObject projectile)
    {
        ProjectilePrefab = projectile;
    }

    public GameObject Create(Vector3 position, Quaternion rotation, Transform parent = null) 
        => GameObject.Instantiate(ProjectilePrefab, position, rotation, parent) as GameObject;

    public GameObject CreateDirectional(Vector3 position, Quaternion rotation, Vector3 direction, Transform parent = null)
    {
        var bullet = GameObject.Instantiate(ProjectilePrefab, position, rotation, parent) as GameObject;
        bullet.GetComponent<IProjectile>().InitBullet(direction);
        
        return bullet;
    }
}

public class ProjectilePlayerFactoryService : ProjectileFactoryService, IFactoryPlayerProjectile
{
    public ProjectilePlayerFactoryService(GameObject projectile) : base(projectile)
    {

    }
}

public class ProjectileEnemyFactoryService : ProjectileFactoryService, IFactoryEnemyProjectile
{
    public ProjectileEnemyFactoryService(GameObject projectile) : base(projectile)
    {

    }
}