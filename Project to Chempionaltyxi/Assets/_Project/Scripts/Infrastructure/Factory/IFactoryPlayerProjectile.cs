using UnityEngine;

public interface IFactoryProjectile : IFactoryService
{
    public GameObject ProjectilePrefabGetter { get; }
}

public interface IFactoryPlayerProjectile : IFactoryProjectile
{

}

public interface IFactoryEnemyProjectile : IFactoryProjectile
{

}
    
