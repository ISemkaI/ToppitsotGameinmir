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