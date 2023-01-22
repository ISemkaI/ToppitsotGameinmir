using UnityEngine;

public interface IFactoryProjectile : IFactoryService
{
    public GameObject ProjectilePrefabGetter { get; }

    public GameObject CreateDirectional(Vector3 position, Quaternion rotation, Vector3 direction, Transform parent = null);
}

public interface IFactoryPlayerProjectile : IFactoryProjectile
{

}

public interface IFactoryEnemyProjectile : IFactoryProjectile
{

}
    
